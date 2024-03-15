using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Xml.Schema;

namespace Jastech.Battery.Structure.VisionTool
{
    public class AlgorithmTool
    {

        TestClass testInspParam = new TestClass();


        #region 2024.03.11 구조 변경 중
        // 아마 고정
        public const double CalibrationX = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double CalibrationY = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double pixelLength1mm = 1.0 / CalibrationX;

        // 아마 Teaching, Model
        public int CoatingMinimumLength = 10;
        public int CoatingAreaMaximumCount = 5;
        public sbyte ContrastOffsetBrighter = 20;
        public sbyte ContrastOffsetDarker = -20;
        public byte CoatingExistanceThreshold = 179;
        public byte CoatingExistanceCriteria = 70;
        public byte CoatingEdgeConstrastThreshold = 39; // Para.CoatEdgeLv[m_ModuleNo];
        public byte BackGroundGrayLevelCriteria = 100;

        public double CoatingAreaInflationScale = 40.0;       // NonCoating 영역 탐색 시 CoatingArea 확장에 사용됨
        public double NonCoatingMinimumWidthScale = 15.0;       // NonCoating 영역 탐색 시 최소 너비 계산에 사용됨
        public double NonCoatingMaximumWidthScale = 20.0;       // NonCoating 영역 탐색 시 최대 너비 계산에 사용됨

        public int WidthSamplingScale = 300;
        public int HeightSamplingScale = 200;
        #endregion

        public void Inspect()
        {
        }

        public void FindCoatingArea()
        {

        }

        public void SetParam()
        {

        }


        public Rectangle GetInspectionArea(int maxLaneCount)
        {
            Rectangle rect = new Rectangle();

            int x1 = 0;
            int y1 = 0;

            int x2 = 0;
            int y2 = 0;


            return rect;
        }

        public void GetWorkBuffer(Rectangle rect, int ratioX, int ratioY)
        {
            if (ShapeHelper.CheckValidRectangle(rect, 16 * 1024, 1024))
                return;
        }

        public void CoatingArea_Line()
        {
            int workRatioX = 2;
            int workRatioY = 6;
        }

        public void CoatingArea_LineBlack(SurfaceParam param)
        {
            int threshold = 128 - param.LineParam.LineLevel;

            int workRatioX = 3;
            int workRatioY = 10;

            int tapePosY1 = 0;
            int tapePosY2 = param.ImageHeight;
        }

        //////////////////////////////////
        ///
        public bool CheckCoatingLength(DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null || imageData.Length == 0 || distanceResult.IsValidScanWidth() == false)
                return false;

            int coatingWidth = distanceResult.ScanEndX - distanceResult.ScanStartX;
            int samplingWidth = Math.Max(1, coatingWidth / WidthSamplingScale);
            int samplingAreaCount = coatingWidth / samplingWidth;
             
            for (int y = 0, length = 0; y < imageHeight; y++)
            {
                int coatingAreaCount = 0;
                for (int x = distanceResult.ScanStartX; x < distanceResult.ScanEndX; x += samplingWidth)
                {
                    if (imageData[y * imageWidth + x] < CoatingExistanceThreshold)
                        coatingAreaCount++;
                }

                double coveringPercentage = (double)samplingAreaCount / (double)coatingAreaCount * 100;
                if (coveringPercentage < CoatingExistanceCriteria)
                    length = 0;
                else
                    length++;

                if (length >= pixelLength1mm * CoatingMinimumLength)
                    return true;
            }

            return false;
        }

        public bool FindVerticalCoatingAreaEdges(ref DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null || imageData.Length == 0)
                return false;

            // 스캔 시작, 끝 지점의 기준 레벨값을 얻는다.
            byte startReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, 0, distanceResult.ScanStartX);
            byte endReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, 0, distanceResult.ScanEndX);

            // 기준 레벨값과 다른 값이 연속적으로 나타나는 지점을 찾는다.
            int coatingStartLocation = FindContinuousContrastLocation(distanceResult, startReferenceGrayLevel, imageData, imageWidth, imageHeight, pixelLength1mm, true);
            int coatingEndLocation = FindContinuousContrastLocation(distanceResult, endReferenceGrayLevel, imageData, imageWidth, imageHeight, pixelLength1mm, false);

            distanceResult.ScanStartX = coatingStartLocation > 0 ? coatingStartLocation : distanceResult.ScanStartX;
            distanceResult.ScanEndX = coatingStartLocation > 0 ? coatingEndLocation : distanceResult.ScanEndX;

            return distanceResult.IsValidScanWidth();
        }

        private int FindContinuousContrastLocation(DistanceInspResult distanceResult, byte referenceGrayLevel, byte[] imageData, int imageWidth, int imageHeight, double searchLength, bool searchForward)
        {
            bool isBackGroundWhite = referenceGrayLevel >= BackGroundGrayLevelCriteria;
            var searchRange = searchForward ?
                Enumerable.Range(distanceResult.ScanStartX, distanceResult.ScanEndX - distanceResult.ScanStartX) :
                Enumerable.Range(distanceResult.ScanStartX, distanceResult.ScanEndX - distanceResult.ScanStartX).Reverse();

            // Pixel이 연속된 지점 찾기
            int pixelStreak = 0, continousLocation = 0;
            foreach (int x in searchRange)
            {
                byte meanGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, 0, x);
                bool hasContrast =
                    (isBackGroundWhite && meanGrayLevel <= referenceGrayLevel + ContrastOffsetDarker) ||
                    (!isBackGroundWhite && meanGrayLevel >= referenceGrayLevel + ContrastOffsetBrighter);

                if (hasContrast)        // 기준레벨값과 비교하여 대비가 있으면, 연속된 픽셀 개수를 증가시킨다.
                {
                    if (pixelStreak == 0)
                        continousLocation = x;

                    pixelStreak++;
                    if (pixelStreak >= searchLength)
                        return continousLocation;
                }
                else
                    pixelStreak = 0;
            }

            return -1;
        }

        public double GetMeanSampledLevel(byte[] imageData, int imageWidth, int imageHeight, int rowStartIndex, int horizontalOffset)
        {
            int sum = 0;
            int samplingCount = imageHeight / HeightSamplingScale;

            for (int row = rowStartIndex / HeightSamplingScale; row < samplingCount; row++)
                sum += imageData[(row * HeightSamplingScale * imageWidth) + horizontalOffset];

            return sum / Math.Max(1, samplingCount);
        }

        private double GetMeanSampledLevel(byte[] imageData, int imageWidth, int columnStartIndex, int verticalOffset)
        {
            int sum = 0;
            int samplingCount = imageWidth / WidthSamplingScale;

            for (int column = columnStartIndex / WidthSamplingScale; column < samplingCount; column++)
                sum += imageData[(verticalOffset * imageWidth) + (column * WidthSamplingScale)];

            return sum / Math.Max(1, samplingCount);
        }

        public bool FindCoatingAreas(ref DistanceInspResult distanceResult, AppsInspModel model, byte[] imageData, int imageWidth, int imageHeight, int minimumFoilLength)
        {
            if (distanceResult == null || imageData.Length == 0)
                return false;

            int scanStartX = distanceResult.ScanStartX;
            int scanEndX = distanceResult.ScanEndX;
            int scanStartY = distanceResult.ScanStartY;
            int scanEndY = distanceResult.ScanEndY;
            int scanWidth = scanEndX - scanStartX;
            int scanHeight = scanEndY - scanStartY;

            if (distanceResult.IsValidScanWidth() == false || scanWidth > imageWidth ||
                distanceResult.IsValidScanHeight() == false || scanHeight > imageHeight)
                return false;

            // 수직 방향 샘플링을 수행하고 결과에 저장한다.
            var verticalSamplingResults = distanceResult.VerticalSamplingResults;
            verticalSamplingResults.Clear();
            for (int y = scanStartY; y < scanEndY; y++)
                verticalSamplingResults.Add((byte)GetMeanSampledLevel(imageData, imageWidth, 0, y));

            byte foilEdgeConstrast = (byte)(verticalSamplingResults.Max() - verticalSamplingResults.Min());
            bool isSlittingPouchCell = model.ProcessType == ProcessType.Slitting && model.ModelType == ModelType.Pouch;

            var coatingAreas = distanceResult.CoatingAreas;
            coatingAreas.Clear();
            // Edge 대비가 기준치 이하 일때, 혹은 Slitting공정 Pouch 모델일 때 Foil 영역은 하나이다. 
            if (foilEdgeConstrast < CoatingEdgeConstrastThreshold || isSlittingPouchCell)
                coatingAreas.Add(new Rectangle(scanStartX, scanStartY, scanWidth, scanHeight));
            // 여러 코팅 영역이 존재할 것으로 판단하고 영역 탐색을 시작한다.
            else
            {
                byte foilThreshold = (byte)((verticalSamplingResults.Max() + verticalSamplingResults.Min()) / 2);
                bool foundTop = false, foundBottom = false;
                int top = -1, bottom = -1;

                for (int index = 0; index < verticalSamplingResults.Count; index++)
                {
                    bool isFoilArea = verticalSamplingResults[index] > foilThreshold;

                    if (foundTop && foundBottom)
                    {
                        bool isSufficientLength = bottom - top >= pixelLength1mm * minimumFoilLength;
                        bool isBorder = isFoilArea == false || index + 1 == verticalSamplingResults.Count;
                        // 크기를 만족하면서 영역이 끝나는 지점에서 영역을 분할한다
                        if (isSufficientLength && isBorder)
                        {
                            coatingAreas.Add(new Rectangle(scanStartX, top, scanWidth, bottom - top));
                            foundTop = foundBottom = false;
                        }
                    }

                    if (top == -1 || isFoilArea == false)
                    {
                        top = scanStartY + index;
                        foundTop = true;
                    }

                    if (foundTop == true && isFoilArea == true)
                    {
                        bottom = scanStartY + index;
                        foundBottom = true;
                    }
                }
            }

            // Foil 영역이 없거나 너무 많으면 실패 처리한다.
            if (coatingAreas.Count == 0 || coatingAreas.Count >= CoatingAreaMaximumCount)
                return false; // Define.RESULT_ETC;

            // 제일 큰 영역은 이후 처리 속도를 위해 미리 저장한다.
            distanceResult.UpdateLargestCoatingArea();

            return ShapeHelper.CheckValidRectangle(distanceResult.LargestCoatingArea, distanceResult.LargestCoatingArea.Width, distanceResult.LargestCoatingArea.Height);
        }

        public void FindInsulatorAreas(ref DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            // 절연필름 사용하는 공정 확인하여 내용 추가할 것
        }

        public bool FindNonCoatingAreas(ref DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null || imageData.Length == 0)
                return false;

            var nonCoatingAreas = distanceResult.NonCoatingAreas;
            nonCoatingAreas.Clear();

            foreach(Rectangle coatingArea in distanceResult.CoatingAreas)
            {
                Rectangle searchArea = new Rectangle(coatingArea.Location, coatingArea.Size);
                searchArea.Inflate((int)(pixelLength1mm * CoatingAreaInflationScale), 0);
                searchArea = ShapeHelper.GetValidRectangle(searchArea, imageWidth, imageHeight);

                // 수평방향 샘플링 결과를 저장한다.
                var horizontalSamplingResult = distanceResult.HorizontalSamplingResults;
                horizontalSamplingResult.Clear();
                for (int x = searchArea.Left; x < searchArea.Right; x++)
                    horizontalSamplingResult.Add((byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, searchArea.Top, x));

                // 그래프 출력을 위해 미분 데이터를 별도로 저장한다.
                var levelDifferences = distanceResult.HorizontalDifferentials;
                levelDifferences.Clear();
                levelDifferences.AddRange(MathHelper.GetDerivedArray(horizontalSamplingResult.ToArray(), 1));

                // 미분 데이터에서 피크 쌍을 추출한다.
                var nonCoatingPeaks = FindPeakPairs(levelDifferences, pixelLength1mm * NonCoatingMinimumWidthScale, pixelLength1mm * NonCoatingMaximumWidthScale);
                if (nonCoatingPeaks.Count == 0)
                    return false;

                // 피크 쌍으로 ROI를 생성하여 추가한다.
                foreach ((int startX, int endX) in nonCoatingPeaks)
                {
                    var nonCoatingArea = new Rectangle
                    {
                        X = searchArea.Left + startX,
                        Y = searchArea.Top,
                        Width = endX - startX,
                        Height = searchArea.Height
                    };
                    nonCoatingAreas.Add(nonCoatingArea);
                }
            }

            if (false)  // 만약 코팅면 사이 빈 공간을 활용할거라면               bool useBlankArea
            {
                if (nonCoatingAreas.Count != 0 && distanceResult.CoatingAreas.Count >= 2)
                {
                    var additionalNonCoatingAreas = new List<Rectangle>();
                    int startX = nonCoatingAreas.Min(rect => rect.Left);
                    int endX = nonCoatingAreas.Max(rect => rect.Right);

                    for (int previousIndex = 0, nextIndex = 1; nextIndex < distanceResult.CoatingAreas.Count; nextIndex++)
                    {
                        var previousRectangle = distanceResult.CoatingAreas[previousIndex];
                        var nextRectangle = distanceResult.CoatingAreas[nextIndex];

                        var blankArea = new Rectangle(startX, previousRectangle.Bottom, endX - startX, nextRectangle.Top - previousRectangle.Bottom);
                        additionalNonCoatingAreas.Add(blankArea);
                    }
                    nonCoatingAreas.AddRange(additionalNonCoatingAreas);
                }
            }

            return true;
        }

        public List<(int startPos, int endPos)> FindPeakPairs(List<byte> levelDifferences, double minimumWidth, double maximumWidth)
        {
            var positionIndices = new List<(int, int)>();

            if (levelDifferences.Count == 0)
                return positionIndices;

            // 최대 피크의 절반 지점에서 최대 50개 만큼 샘플링한다.
            var halfOfMaxDifference = levelDifferences.Max(value => (double)value) / 2;

            var mostIntensePeaks = levelDifferences
                .Select((value, position) => new { value, position })
                .Where(peak => peak.value > halfOfMaxDifference)
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
                    int width = mostIntensePeaks[endPos].position - mostIntensePeaks[startPos].position;

                    // 피크 쌍이 너비 조건을 충족하면 start, end 위치를 추가한다
                    if (width >= minimumWidth && width <= maximumWidth)
                    {
                        positionIndices.Add((mostIntensePeaks[startPos].position, mostIntensePeaks[endPos].position));

                        for (int skipIndex = startPos; skipIndex < endPos; skipIndex++)
                            usedIndices.Add(skipIndex);    // 쌍을 이룬 피크 및 사이에 포함된 피크는 이후 탐색에서 제외한다
                        break;
                    }
                }
            }

            return positionIndices;
        }

        public void GetCoatingArea()
        {

        }

        public void GetCoatingArea_WidthoutNonCoat()
        {

        }

        public void SaverErrorInfo()
        {

        }

        public void GetLaneNumber()
        {

        }
    }
}
