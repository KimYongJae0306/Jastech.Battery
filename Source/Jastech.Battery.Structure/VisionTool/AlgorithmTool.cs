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
using Emgu.CV.BgSegm;
using System.Data;

namespace Jastech.Battery.Structure.VisionTool
{
    public class AlgorithmTool
    {
        #region 2024.03.11 구조 변경 중
        // 상수 어디에 넣을지
        public const double CalibrationX = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double CalibrationY = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double pixelLength1mm = 1.0 / CalibrationX;
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

        public double GetHorizontalMeanSampledLevel(DistanceParam distanceParam,  ImageBuffer image, int rowStartIndex, int horizontalOffset)
        {
            byte[] imageData = image.ImageData;
            int imageWidth = image.Width;
            int imageHeight = image.Height;

            int heightSamplingScale = distanceParam.HeightSamplingScale;

            int sum = 0;
            for (int rowIndex = rowStartIndex; rowIndex < imageHeight; rowIndex+= heightSamplingScale)
            {
                var currentRow = rowIndex * imageWidth;
                sum += imageData[currentRow + horizontalOffset];
            }

            int samplingCount = imageHeight / heightSamplingScale;
            return sum / Math.Max(1, samplingCount);
        }

        private double GetVerticalMeanSampledLevel(DistanceParam distanceParam, ImageBuffer image, int columnStartIndex, int verticalOffset)
        {
            byte[] imageData = image.ImageData;
            int imageWidth = image.Width;
            int imageHeight = image.Height;

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

        public DistanceInspResult ExecuteDistanceInspection(ImageBuffer imageBuffer, DistanceParam parameters, Rectangle searchROI)
        {
            if (imageBuffer == null || imageBuffer.ImageData.Length == 0)
                return null;

            // 수직방향 샘플링 결과를 저장한다.
            var verticalSamplingResult = new List<byte>();
            for (int y = searchROI.Top; y < searchROI.Bottom; y++)
                verticalSamplingResult.Add((byte)GetVerticalMeanSampledLevel(parameters, imageBuffer, searchROI.Top, y));

            // 수직방향 순간 변화량 계산, 피크 추출
            var verticalLevelDifferences = MathHelper.GetDerivedArray(verticalSamplingResult.ToArray(), 2).ToList();
            var verticalPeaks = FindPeakPairs(verticalLevelDifferences, parameters.ROIThreshold, pixelLength1mm * parameters.CoatingMinimumLength, searchROI.Height);

            // 영역 저장
            var searchAreas = new List<Rectangle>();
            if (verticalPeaks.Count == 0)
                searchAreas.Add(searchROI);
            else
            {
                foreach ((int startY, int endY) in verticalPeaks)
                {
                    var searchArea = new Rectangle
                    {
                        X = searchROI.Left,
                        Y = searchROI.Top + startY,
                        Width = searchROI.Width,
                        Height = endY - startY,
                    };
                    searchAreas.Add(searchArea);
                }

                // 구분된 영역에 대해 NG 처리를 하기 위해 검사 영역을 제외한 영역을 탐색
                var additionalAreas = new List<Rectangle>();
                Rectangle previousArea = new Rectangle(searchROI.Left, searchROI.Top, searchROI.Width, 0);
                Rectangle currentArea;
                for (int index = 0; index <= searchAreas.Count; index++)
                {
                    if (index != searchAreas.Count)
                        currentArea = searchAreas[index];
                    else
                        currentArea = new Rectangle(searchROI.Left, searchROI.Bottom, searchROI.Width, 0);

                    var additionalArea = new Rectangle(currentArea.Left, previousArea.Bottom, currentArea.Width, currentArea.Top - previousArea.Bottom);
                    previousArea = currentArea;

                    additionalAreas.Add(additionalArea);
                }
                searchAreas.AddRange(additionalAreas.Where(rect => rect.Height > 1));
            }

            List<Rectangle> coatingAreas = new List<Rectangle>();
            List<Rectangle> nonCoatingAreas = new List<Rectangle>();
            List<byte> horizontalSamplingResult = new List<byte>();
            List<byte> horizontalLevelDifferences = new List<byte>();
            foreach (Rectangle searchArea in searchAreas)
            {
                // 수평방향 샘플링 결과를 저장한다.
                horizontalSamplingResult = new List<byte>();
                for (int x = searchArea.Left; x < searchArea.Right; x++)
                    horizontalSamplingResult.Add((byte)GetHorizontalMeanSampledLevel(parameters, imageBuffer, searchArea.Left, x));

                // 그래프 출력을 위해 미분 데이터를 별도로 저장한다.     // TODO : 다중 영역에 대해서 List로 관리
                horizontalLevelDifferences = MathHelper.GetDerivedArray(horizontalSamplingResult.ToArray(), 1).ToList();

                // 미분 데이터에서 피크 쌍을 추출하여 CoatingArea를 저장한다.
                var coatingPeaks = FindPeakPairs(horizontalLevelDifferences, parameters.CoatingThreshold, pixelLength1mm * parameters.CoatingMinimumWidth, pixelLength1mm * parameters.CoatingMaximumWidth);
                foreach ((int startX, int endX) in coatingPeaks)
                {
                    var coatingArea = new Rectangle
                    {
                        X = searchArea.Left + startX,
                        Y = searchArea.Top,
                        Width = endX - startX,
                        Height = searchArea.Height
                    };
                    coatingAreas.Add(coatingArea);
                }

                // 미분 데이터에서 피크 쌍을 추출하여 NonCoatingArea를 저장한다.
                var nonCoatingPeaks = FindPeakPairs(horizontalLevelDifferences, parameters.NonCoatingThreshold, pixelLength1mm * parameters.NonCoatingMinimumWidth, pixelLength1mm * parameters.NonCoatingMaximumWidth);
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

            // TODO Lane 나누기


            return new DistanceInspResult
            {
                CoatingAreas = coatingAreas,
                NonCoatingAreas = nonCoatingAreas,
                VerticalDifferentials = verticalLevelDifferences,
                VerticalSamplingResults = verticalSamplingResult,
                HorizontalDifferentials = horizontalLevelDifferences,
                HorizontalSamplingResults = horizontalSamplingResult,
            };
        }

        public List<(int startPos, int endPos)> FindPeakPairs(List<byte> levelDifferences, int levelThreshold, double minimumSize, double maximumSize)
        {
            var positionIndices = new List<(int, int)>();

            if (levelDifferences.Count == 0)
                return positionIndices;

            // 최대 피크의 절반 지점에서 최대 50개 만큼 샘플링한다.
            //var halfOfMaxDifference = Math.Max(levelThreshold, levelDifferences.Max(value => (double)value) / 2);

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
                        positionIndices.Add((mostIntensePeaks[startPos].position, mostIntensePeaks[endPos].position));

                        for (int skipIndex = startPos; skipIndex < endPos; skipIndex++)
                            usedIndices.Add(skipIndex);    // 쌍을 이룬 피크 및 사이에 포함된 피크는 이후 탐색에서 제외한다
                        break;
                    }
                }
            }

            return positionIndices;
        }

        public byte GetOptimalNonCoatingThreshold(List<byte> derivedDifferences)
        {
            if (derivedDifferences.Count < 2)
                return 0;

            int peakSamplingCount = Math.Max(2, derivedDifferences.Count / 20);
            var topPeakSamples = derivedDifferences
                .OrderByDescending(x => x)
                .Take(peakSamplingCount);

            var samplingAverage = topPeakSamples.Average(value => (double)value);
            var threshold = (byte)topPeakSamples.Where(value => value > samplingAverage).Average(value => (double)value);
            return threshold;
        }

        public void CheckCoatingArea_Line(DistanceInspResult distanceInspResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            int ratioX = 2;
            int ratioY = 6;

            int buffWidth = 0;
            int buffHeight = 0;

            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                SurfaceInspResult surfaceInspResult = new SurfaceInspResult();

                var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);

                byte[] workBuff = GetWorkBuffer(inspArea, ratioX, ratioY, imageData, imageWidth, imageHeight, out buffWidth, out buffHeight);
                if (workBuff == null)
                    continue;

                int stepX = buffWidth / 100;
                int stepY = buffHeight / 100;

                if (stepX < 1)
                    stepX = 1;

                if (stepY < 1)
                    stepY = 1;

                int sum = 0;
                int count = 0;

                for (int h = 0; h < buffHeight; h++)
                {
                    for (int w = 0; w < buffWidth; w++)
                    {
                        sum += workBuff[h * imageWidth + w];
                        count++;
                    }
                }

                if (count < 1)
                    count = 1;

                int averageLevel = sum / count;

                surfaceInspResult.CoatingAverageLevel = averageLevel;
            }
        }

        private byte[] GetWorkBuffer(Rectangle inputRect, int ratioX, int ratioY, byte[] imageData, int imageWidth, int imageHeight, out int buffWidth, out int buffHeight)
        {
            buffWidth = inputRect.Width / ratioX;
            buffHeight = inputRect.Height / ratioY;

            if (ShapeHelper.CheckValidRectangle(inputRect, imageWidth, imageHeight))
                return null;

            if (buffWidth < 1 || buffHeight < 1)
                return null;

            byte[] outputBuff = new byte[buffWidth * buffHeight];

            int x = 0;
            int y = 0;

            for (int h = 0; h < buffHeight; h++)
            {
                y = inputRect.Top + h * ratioY;

                for (int w = 0; w < buffWidth; w++)
                {
                    x = inputRect.Left + w * ratioX;

                    outputBuff[h * buffWidth + w] = imageData[y * imageWidth + x];
                }
            }

            return outputBuff;
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
