using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Jastech.Battery.Structure.VisionTool
{
    public class FindAreaAlgorithmTool
    {
        public double pixelResolution_mm = 1;

        #region 메소드
        public bool FindSearchAreas(FindAreaResult distanceResult, ImageBuffer imageBuffer, FindAreaParam parameters)
        {
            if (imageBuffer == null || imageBuffer.ImageData == null)
                return false;
            if (distanceResult == null || parameters == null)
                return false;

            var Roi = parameters._Roi;

            // 수직방향 샘플링 결과를 저장한다.
            var verticalSamplingResult = new List<byte>();
            for (int y = Roi.Top; y < Roi.Bottom; y++)
                verticalSamplingResult.Add((byte)TempAlgorithmTool.GetMeanSampledLevel(parameters, imageBuffer, Roi.Left, y));

            // 수직방향 순간 변화량 계산, 피크 추출
            var verticalLevelDifferences = MathHelper.GetDerivedArray(verticalSamplingResult.ToArray(), 2).ToList();

            // 수직방향 시작과 끝은 반드시 경계선이 된다.
            verticalLevelDifferences[0] = byte.MaxValue;
            verticalLevelDifferences[verticalLevelDifferences.Count - 1] = byte.MaxValue;

            // 피크 쌍 추출
            double minimumSearchAreaHeight = pixelResolution_mm * parameters.CoatingLengthMin;
            double maximumSearchAreaHeight = Roi.Height;
            var verticalPeaks = MakePeakPairs(verticalLevelDifferences, parameters.ROIThreshold, minimumSearchAreaHeight, maximumSearchAreaHeight);

            // 영역 저장
            var searchAreas = new List<Rectangle>();
            foreach ((int startY, int endY) in verticalPeaks)
            {
                var newArea = new Rectangle
                {
                    X = Roi.Left,
                    Y = Roi.Top + startY,
                    Width = Roi.Width,
                    Height = endY - startY,
                };
                searchAreas.Add(newArea);
            }

            distanceResult.VerticalSamplingResults = verticalSamplingResult;
            distanceResult.VerticalDifferentials = verticalLevelDifferences;
            distanceResult.SearchAreas = searchAreas;

            return true;
        }

        public bool FindInspectionAreas(FindAreaResult distanceResult, ImageBuffer imageBuffer, FindAreaParam parameters)
        {
            if (imageBuffer == null || imageBuffer.ImageData.Length == 0)
                return false;
            if (distanceResult == null || distanceResult.SearchAreas.Count == 0 || parameters == null)
                return false;

            var coatingInfoList = new List<SurfaceInfo>();
            var nonCoatingInfoList = new List<SurfaceInfo>();
            var horizontalSamplingResult = new List<byte>();
            var horizontalLevelDifferences = new List<byte>();

            foreach (Rectangle searchArea in distanceResult.SearchAreas)
            {
                // 수평방향 샘플링 결과를 저장한다.
                horizontalSamplingResult = new List<byte>();
                for (int x = searchArea.Left; x < searchArea.Right; x++)
                    horizontalSamplingResult.Add((byte)TempAlgorithmTool.GetMeanSampledLevel(parameters, imageBuffer, searchArea.Top, searchArea.Bottom, x));

                // 그래프 출력을 위해 미분 데이터를 별도로 저장한다.     // TODO : 다중 영역에 대해서 List로 관리
                horizontalLevelDifferences = MathHelper.GetDerivedArray(horizontalSamplingResult.ToArray(), 1).ToList();

                // *Slitting일 경우 좌, 우측 전극이 잘려나갔을 때 그 지점을 막아준다. 2024.03.26+ 안쓸 것 같음, 삭제 대기
                if (parameters.LeftElectrodeSlitted)
                    horizontalLevelDifferences[0] = byte.MaxValue;
                if (parameters.RightElectrodeSlitted)
                    horizontalLevelDifferences[horizontalLevelDifferences.Count - 1] = byte.MaxValue;

                // 미분 데이터에서 피크 쌍을 추출하여 CoatingArea를 저장한다.
                double coatingAreaWidthMin = pixelResolution_mm * parameters.CoatingWidthMin;
                double coatingAreaWidthMax = pixelResolution_mm * parameters.CoatingWidthMax;
                var coatingPeakPairs = MakePeakPairs(horizontalLevelDifferences, parameters.CoatingThreshold, coatingAreaWidthMin, coatingAreaWidthMax);
                coatingInfoList.AddRange(MakeSurfaceInfoList("Coating", parameters.LaneCount, coatingPeakPairs, searchArea));

                // 미분 데이터에서 피크 쌍을 추출하여 NonCoatingArea를 저장한다.
                double nonCoatingAreaWidthMin = pixelResolution_mm * parameters.NonCoatingWidthMin;
                double nonCoatingAreaWidthMax = pixelResolution_mm * parameters.NonCoatingWidthMax;
                var nonCoatingPeakPairs = MakePeakPairs(horizontalLevelDifferences, parameters.NonCoatingThreshold, nonCoatingAreaWidthMin, nonCoatingAreaWidthMax);
                nonCoatingInfoList.AddRange(MakeSurfaceInfoList("NonCoating", parameters.LaneCount, nonCoatingPeakPairs, searchArea));
            }

            distanceResult.CoatingInfoList = coatingInfoList;
            distanceResult.NonCoatingInfoList = nonCoatingInfoList;
            distanceResult.HorizontalSamplingResults = horizontalSamplingResult;
            distanceResult.HorizontalDifferentials = horizontalLevelDifferences;

            return true;
        }

        private List<(int, int)> MakePeakPairs(List<byte> levelDifferences, int levelThreshold, double minimumSize, double maximumSize)
        {
            var positionIndices = new List<(int, int)>();

            if (levelDifferences.Count == 0)
                return positionIndices;

            // 기준 레벨값 이상의 피크들을 샘플링한다.
            var mostIntensePeaks = levelDifferences
                .Select((value, position) => new { value, position })
                .Where(peak => peak.value > levelThreshold)
                .OrderBy(peak => peak.position)
                .ThenByDescending(peak => peak.value)
                .ToArray();

            var usedIndices = new List<int>();
            for (int startPos = 0; startPos < mostIntensePeaks.Length; startPos++)
            {
                // 이미 사용된 위치는 건너뛴다.
                if (usedIndices.Contains(startPos))
                    continue;

                for (int endPos = startPos + 1; endPos < mostIntensePeaks.Length; endPos++)
                {
                    int size = mostIntensePeaks[endPos].position - mostIntensePeaks[startPos].position;

                    // 피크 쌍이 너비 조건을 충족하면 start, end 위치를 추가한다
                    if (size >= minimumSize && size <= maximumSize)
                    {
                        positionIndices.Add((mostIntensePeaks[startPos].position + 1, mostIntensePeaks[endPos].position));

                        for (int skipIndex = startPos; skipIndex < endPos; skipIndex++)
                            usedIndices.Add(skipIndex);    // 쌍을 이룬 피크 및 사이에 포함된 피크는 이후 탐색에서 제외한다
                        break;
                    }
                }
            }

            return positionIndices;
        }

        private List<SurfaceInfo> MakeSurfaceInfoList(string type, int laneCount, List<(int, int)> peakPairs, Rectangle searchArea)
        {
            List<SurfaceInfo> surfaceInfoList = new List<SurfaceInfo>();

            double laneDivider = (double)searchArea.Width / laneCount;
            for (int index = 0; index < peakPairs.Count; index++)
            {
                (int startX, int endX) = peakPairs[index];

                if (type != "NonCoating" || index == 0 || index == peakPairs.Count - 1)
                {
                    SurfaceInfo surfaceInfo = new SurfaceInfo();
                    surfaceInfo.Type = type;
                    surfaceInfo.Area = new Rectangle
                    {
                        X = searchArea.Left + startX,
                        Y = searchArea.Top,
                        Width = endX - startX,
                        Height = searchArea.Height
                    };
                    surfaceInfo.Lane = Math.Max(1, (int)Math.Ceiling(surfaceInfo.Area.X / laneDivider));
                    surfaceInfoList.Add(surfaceInfo);
                }
                else
                {
                    int halfWidth = (endX - startX) / 2;

                    SurfaceInfo leftSurfaceInfo = new SurfaceInfo();
                    leftSurfaceInfo.Type = type;
                    leftSurfaceInfo.Area = new Rectangle
                    {
                        X = searchArea.Left + startX,
                        Y = searchArea.Top,
                        Width = halfWidth,
                        Height = searchArea.Height
                    };
                    leftSurfaceInfo.Lane = Math.Max(1, (int)Math.Ceiling(leftSurfaceInfo.Area.X / laneDivider));
                    surfaceInfoList.Add(leftSurfaceInfo);

                    SurfaceInfo rightSurfaceInfo = new SurfaceInfo();
                    rightSurfaceInfo.Type = type;
                    rightSurfaceInfo.Area = new Rectangle
                    {
                        X = searchArea.Left + startX + halfWidth,
                        Y = searchArea.Top,
                        Width = halfWidth,
                        Height = searchArea.Height
                    };
                    rightSurfaceInfo.Lane = leftSurfaceInfo.Lane + 1;
                    surfaceInfoList.Add(rightSurfaceInfo);
                }
            }

            return surfaceInfoList;
        }

        private List<SurfaceInfo> MakeSurfaceInfoFromAreas(List<Rectangle> areas, string type, int imageWidth, int laneCount)
        {
            List<SurfaceInfo> surfaceInfoList = new List<SurfaceInfo>();

            foreach(Rectangle area in areas)
            {
            }
            return surfaceInfoList;
        }
        #endregion
    }
}
