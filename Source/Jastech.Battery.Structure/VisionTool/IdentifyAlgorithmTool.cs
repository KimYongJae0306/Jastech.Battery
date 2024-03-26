using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.VisionTool
{
    public class IdentifyAlgorithmTool
    {
        public double pixelResolution_mm = 1.0 / 0.0423;

        #region 메소드
        public bool FindSearchAreas(DistanceInspResult distanceResult, ImageBuffer imageBuffer, DistanceParam parameters)
        {
            if (imageBuffer == null || imageBuffer.ImageData == null)
                return false;
            if (distanceResult == null || parameters == null)
                return false;

            var Roi = parameters._Roi;

            // 수직방향 샘플링 결과를 저장한다.
            var verticalSamplingResult = new List<byte>();
            for (int y = Roi.Top; y < Roi.Bottom; y++)
                verticalSamplingResult.Add((byte)GetVerticalMeanSampledLevel(parameters, imageBuffer, Roi.Left, y));

            // 수직방향 순간 변화량 계산, 피크 추출
            var verticalLevelDifferences = MathHelper.GetDerivedArray(verticalSamplingResult.ToArray(), 2).ToList();

            // 수직방향 시작과 끝은 반드시 경계선이 된다.
            verticalLevelDifferences[0] = byte.MaxValue;
            verticalLevelDifferences[verticalLevelDifferences.Count - 1] = byte.MaxValue;

            // 피크 쌍 추출
            double minimumSearchAreaHeight = pixelResolution_mm * parameters.CoatingMinimumLength;
            double maximumSearchAreaHeight = Roi.Height;
            var verticalPeaks = MakePeakPairs(verticalLevelDifferences, parameters.ROIThreshold, minimumSearchAreaHeight, maximumSearchAreaHeight);

            // 영역 저장
            var searchAreas = new List<Rectangle>();
            AddRegionsFromPeakPairs(searchAreas, verticalPeaks, Roi, false);

            distanceResult.VerticalSamplingResults = verticalSamplingResult;
            distanceResult.VerticalDifferentials = verticalLevelDifferences;
            distanceResult.SearchAreas = searchAreas;

            return true;
        }

        public bool FindInspectionAreas(DistanceInspResult distanceResult, ImageBuffer imageBuffer, DistanceParam parameters)
        {
            if (imageBuffer == null || imageBuffer.ImageData.Length == 0)
                return false;
            if (distanceResult == null || distanceResult.SearchAreas.Count == 0 || parameters == null)
                return false;

            var coatingAreas = new List<Rectangle>();
            var nonCoatingAreas = new List<Rectangle>();
            var horizontalSamplingResult = new List<byte>();
            var horizontalLevelDifferences = new List<byte>();

            foreach (Rectangle searchArea in distanceResult.SearchAreas)
            {
                // 수평방향 샘플링 결과를 저장한다.
                horizontalSamplingResult = new List<byte>();
                for (int x = searchArea.Left; x < searchArea.Right; x++)
                    horizontalSamplingResult.Add((byte)GetHorizontalMeanSampledLevel(parameters, imageBuffer, searchArea.Top, searchArea.Bottom, x));

                // 그래프 출력을 위해 미분 데이터를 별도로 저장한다.     // TODO : 다중 영역에 대해서 List로 관리
                horizontalLevelDifferences = MathHelper.GetDerivedArray(horizontalSamplingResult.ToArray(), 1).ToList();

                // *Slitting일 경우 좌, 우측 전극이 잘려나갔을 때 그 지점을 막아준다.
                if (parameters.LeftElectrodeSlitted)
                    horizontalLevelDifferences[0] = byte.MaxValue;
                if (parameters.RightElectrodeSlitted)
                    horizontalLevelDifferences[horizontalLevelDifferences.Count - 1] = byte.MaxValue;

                // 미분 데이터에서 피크 쌍을 추출하여 CoatingArea를 저장한다.
                double minimumCoatingAreaWidth = pixelResolution_mm * parameters.CoatingMinimumWidth;
                double maximumCoatingAreaWidth = pixelResolution_mm * parameters.CoatingMaximumWidth;
                var coatingPeaks = MakePeakPairs(horizontalLevelDifferences, parameters.CoatingThreshold, minimumCoatingAreaWidth, maximumCoatingAreaWidth);
                AddRegionsFromPeakPairs(coatingAreas, coatingPeaks, searchArea, true);

                // 미분 데이터에서 피크 쌍을 추출하여 NonCoatingArea를 저장한다.
                double minimumNonCoatingAreaWidth = pixelResolution_mm * parameters.NonCoatingMinimumWidth;
                double maximumNonCoatingAreaWidth = pixelResolution_mm * parameters.NonCoatingMaximumWidth;
                var nonCoatingPeaks = MakePeakPairs(horizontalLevelDifferences, parameters.NonCoatingThreshold, minimumNonCoatingAreaWidth, maximumNonCoatingAreaWidth);
                AddRegionsFromPeakPairs(nonCoatingAreas, nonCoatingPeaks, searchArea, true);
            }

            distanceResult.CoatingAreas = coatingAreas;
            distanceResult.NonCoatingAreas = nonCoatingAreas;
            distanceResult.HorizontalSamplingResults = horizontalSamplingResult;
            distanceResult.HorizontalDifferentials = horizontalLevelDifferences;

            return true;
        }

        public bool SeparateRegionsByLane(DistanceInspResult distanceResult, DistanceParam parameters)
        {
            if (distanceResult == null || parameters == null)
                return false;

            int laneCount = parameters.LaneCount;
            if (laneCount < 1)
            {
                Debug.WriteLine("LaneCount is under 1");
                return false;
            }
            else if (distanceResult.CoatingAreas.Count != laneCount || distanceResult.CoatingAreas.Count == 0)
            {
                Debug.WriteLine("Coating Areas not matched with LaneCount");
                return false;
            }
            List<Rectangle> separatedAreas = new List<Rectangle>();
            for (int index = 0; index < distanceResult.NonCoatingAreas.Count; index++)
            {
                if (index == 0 || index == distanceResult.NonCoatingAreas.Count - 1)
                    separatedAreas.Add(distanceResult.NonCoatingAreas[index]);
                else
                {
                    Rectangle leftArea = new Rectangle
                    {
                        X = distanceResult.NonCoatingAreas[index].X,
                        Y = distanceResult.NonCoatingAreas[index].Y,
                        Width = distanceResult.NonCoatingAreas[index].Width / 2,
                        Height = distanceResult.NonCoatingAreas[index].Height,
                    };
                    Rectangle rightArea = new Rectangle
                    {
                        X = distanceResult.NonCoatingAreas[index].X + (distanceResult.NonCoatingAreas[index].Width / 2),
                        Y = distanceResult.NonCoatingAreas[index].Y,
                        Width = distanceResult.NonCoatingAreas[index].Width / 2,
                        Height = distanceResult.NonCoatingAreas[index].Height,
                    };
                    separatedAreas.Add(leftArea);
                    separatedAreas.Add(rightArea);
                }
            }

            distanceResult.NonCoatingAreas = separatedAreas;
            return true;
        }

        public bool CaluateAveragesAreas(DistanceInspResult distanceResult)
        {
            if (distanceResult == null)
                return false;


            return true;
        }

        private double GetHorizontalMeanSampledLevel(DistanceParam distanceParam, ImageBuffer image, int rowStartIndex, int rowEndIndex, int horizontalOffset)
        {
            byte[] imageData = image.ImageData;
            int imageWidth = image.ImageWidth;
            int imageHeight = rowEndIndex - rowStartIndex;

            int heightSamplingScale = distanceParam.HeightSamplingScale;

            int sum = 0;
            for (int rowIndex = rowStartIndex; rowIndex < rowStartIndex + imageHeight; rowIndex += heightSamplingScale)
            {
                var currentRow = rowIndex * imageWidth;
                sum += imageData[currentRow + horizontalOffset];
            }

            int samplingCount = (int)Math.Ceiling((double)imageHeight / heightSamplingScale);
            return sum / Math.Max(1, samplingCount);
        }

        private double GetVerticalMeanSampledLevel(DistanceParam distanceParam, ImageBuffer image, int columnStartIndex, int verticalOffset)
        {
            byte[] imageData = image.ImageData;
            int imageWidth = image.ImageWidth;
            int imageHeight = image.ImageHeight;

            int widthSamplingScale = distanceParam.WidthSamplingScale;

            int sum = 0;
            for (int columnIndex = columnStartIndex; columnIndex < imageWidth; columnIndex += widthSamplingScale)
            {
                var currentRow = verticalOffset * imageWidth;
                sum += imageData[currentRow + columnIndex];
            }

            int samplingCount = imageWidth / widthSamplingScale;
            return sum / Math.Max(1, samplingCount);
        }

        private List<(int startPos, int endPos)> MakePeakPairs(List<byte> levelDifferences, int levelThreshold, double minimumSize, double maximumSize)
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

        private void AddRegionsFromPeakPairs(List<Rectangle> areaCollection, List<(int startPos, int endPos)> peakPairs, Rectangle searchArea, bool isHorizontal)
        {
            if (isHorizontal)
            {
                foreach ((int startX, int endX) in peakPairs)
                {
                    var newArea = new Rectangle
                    {
                        X = searchArea.Left + startX,
                        Y = searchArea.Top,
                        Width = endX - startX,
                        Height = searchArea.Height
                    };
                    areaCollection.Add(newArea);
                }
            }
            else
            {
                foreach ((int startY, int endY) in peakPairs)
                {
                    var newArea = new Rectangle
                    {
                        X = searchArea.Left,
                        Y = searchArea.Top + startY,
                        Width = searchArea.Width,
                        Height = endY - startY,
                    };
                    areaCollection.Add(newArea);
                }
            }
        }
        #endregion
    }
}
