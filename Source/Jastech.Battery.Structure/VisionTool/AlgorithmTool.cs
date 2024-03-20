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
using System.Reflection;
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

        public double GetHorizontalMeanSampledLevel(DistanceParam distanceParam, ImageBuffer image, int rowStartIndex, int horizontalOffset)
        {
            byte[] imageData = image.ImageData;
            int imageWidth = image.Width;
            int imageHeight = image.Height;

            int heightSamplingScale = distanceParam.HeightSamplingScale;

            int sum = 0;
            for (int rowIndex = rowStartIndex; rowIndex < imageHeight; rowIndex += heightSamplingScale)
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

        private void CheckCoatingArea_Line(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, byte[] imageData, int imageWidth, int imageHeight, ref SurfaceInspResult surfaceInspResult, bool isTapeInsp)
        {
            if (surfaceParam.LineParam.EnableCheckLine == false)
                return;

            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int workRatioX = 2;
            int workRatioY = 6;

            int buffWidth = 0;
            int buffHeight = 0;

            double referenceSizeX = 0.0;
            double referenceSizeY = 0.0;

            Rectangle workArea = new Rectangle();
            Rectangle findArea = new Rectangle();
            Rectangle drawArea = new Rectangle();

            double findWidth = 0.0;
            double findHeight = 0.0;

            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                if (area.Width < pix40mm && area.Height < pix5mm)
                    continue;

                byte[] workBuff = GetWorkBuffer(area, workRatioX, workRatioY, imageData, imageWidth, imageHeight, out buffWidth, out buffHeight);
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

                surfaceInspResult.CoatingAverageLevel.Add(averageLevel);

                int threshold = 0;

                workArea.X = 0;
                workArea.Width = buffWidth;
                workArea.Y = 0;
                workArea.Height = buffHeight;

                if (isTapeInsp == true)
                {
                    if (surfaceParam.TapeParam.EnableConnectionTape)
                    {
                        threshold = averageLevel + surfaceParam.TapeParam.ConnectionTapeLevel;
                        referenceSizeX = area.Width / 2 * CalibrationX;
                        referenceSizeY = 1.0;
                    }
                }
                else
                {
                    threshold = averageLevel + surfaceParam.LineParam.LineLevel;
                    referenceSizeX = surfaceParam.LineParam.LineSizeX;
                    referenceSizeY = surfaceParam.LineParam.LineSizeY;
                }

                var blobList = BlobContour(workBuff, workArea, threshold, 255);

                foreach (var item in blobList)
                {
                    int blobLeft = area.Left + item.Left * workRatioX;
                    int blobRight = area.Left + item.Right * workRatioX;
                    int blobTop = area.Top + item.Top * workRatioY;
                    int blobBottom = area.Bottom + item.Bottom * workRatioY;

                    findArea.X = blobLeft;
                    findArea.Y = blobTop;
                    findArea.Width = blobRight - blobLeft;
                    findArea.Height = blobBottom - blobTop;

                    findWidth = (findArea.Width + 1) * CalibrationX;
                    findHeight = (findArea.Height + 1) * CalibrationY;

                    if (findWidth < referenceSizeX || findHeight < referenceSizeY)
                        continue;

                    bool samePos = CheckAlreadySaved();
                    if (samePos == true)
                        continue;

                    drawArea = findArea;
                    drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);

                    if (isTapeInsp == true)
                    {
                        surfaceInspResult.IsConnectionTape = true;
                        surfaceInspResult.ConnectionTapeArea = drawArea;
                    }
                    else
                    {
                        surfaceInspResult.IsConnectionTape = false;
                        surfaceInspResult.ConnectionTapeArea = new Rectangle();
                    }
                }
            }
        }

        private void CheckCoatingArea_LineBlack(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, byte[] imageData, int imageWidth, int imageHeight, ref SurfaceInspResult surfaceInspResult)
        {
            if (surfaceParam.LineBlackParam.EnableCheckLine == false)
                return;

            int buffWidth = 0;
            int buffHeight = 0;

            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int workRatioX = 3;
            int workRatioY = 10;

            Rectangle workArea = new Rectangle();
            Rectangle findArea = new Rectangle();
            Rectangle drawArea = new Rectangle();

            int threshold = 128 - surfaceParam.LineBlackParam.LineLevel;

            double findWidth = 0.0;
            double findHeight = 0.0;

            int tapePosY1 = 0;
            int tapePosY2 = imageHeight;

            if (surfaceInspResult.IsConnectionTape == true)
            {
                tapePosY1 = surfaceInspResult.ConnectionTapeArea.Top * workRatioY;
                tapePosY2 = surfaceInspResult.ConnectionTapeArea.Bottom * workRatioY;
            }

            int averageSize = (int)(10 / CalibrationX);

            int samplingStep = averageSize / 5;

            if (samplingStep < 1)
                samplingStep = 1;

            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                if (area.Width < pix40mm && area.Height < pix5mm)
                    continue;

                byte[] workBuff = GetWorkBuffer(area, workRatioX, workRatioY, imageData, imageWidth, imageHeight, out buffWidth, out buffHeight);
                if (workBuff == null)
                    continue;

                Parallel.For(0, buffHeight, h =>
                {
                    for (int w = 0; w < buffWidth; w++)
                    {
                        int tempSum = 0;
                        int tempCount = 0;

                        for (int y = h - averageSize; y < h + averageSize; y += samplingStep)
                        {
                            if (y < 0 || y >= buffHeight)
                                continue;

                            if (y < tapePosY1 || y >= tapePosY2)
                                continue;

                            for (int x = w - averageSize; x < w + averageSize; x += samplingStep)
                            {
                                if (x < 0 || x > buffWidth)
                                    continue;

                                // TODO : asfas
                                if (workBuff[y * buffWidth + x] > 0 /* noncoatinglevel */)
                                    continue;

                                tempSum += workBuff[y * buffWidth + x];
                                tempCount++;
                            }
                        }

                        if (tempCount < 1)
                            tempCount = 1;

                        byte[] workBuffAverage = new byte[buffWidth * buffHeight];
                        workBuffAverage[h * buffWidth + w] = (byte)(tempSum / tempCount);

                        int diffValue = 128 + workBuff[h * buffWidth + w] - workBuffAverage[h * buffWidth + w];

                        if (diffValue < 0)
                            diffValue = 0;
                        if (diffValue > 255)
                            diffValue = 255;

                        workBuff[h * buffWidth + w] = (byte)diffValue;
                    }
                });

                workArea.X = 0;
                workArea.Width = buffWidth;
                workArea.Y = 0;
                workArea.Height = buffHeight;

                var blobList = BlobContour(workBuff, workArea, threshold, 255);

                foreach (var item in blobList)
                {
                    int blobLeft = area.Left + item.Left * workRatioX;
                    int blobRight = area.Left + item.Right * workRatioX;
                    int blobTop = area.Top + item.Top * workRatioY;
                    int blobBottom = area.Bottom + item.Bottom * workRatioY;

                    findArea.X = blobLeft;
                    findArea.Y = blobTop;
                    findArea.Width = blobRight - blobLeft;
                    findArea.Height = blobBottom - blobTop;

                    findWidth = (findArea.Width + 1) * CalibrationX;
                    findHeight = (findArea.Height + 1) * CalibrationY;

                    if (findWidth < surfaceParam.LineParam.LineSizeY)
                        continue;

                    bool samePos = CheckAlreadySaved();
                    if (samePos == true)
                        continue;

                    drawArea = findArea;
                    drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                }
            }
        }

        private void CheckCoatingArea_Edge(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, byte[] imageData, int imageWidth, int imageHeight, ref SurfaceInspResult surfaceInspResult)
        {
            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int pixRefernceHeight = (int)((surfaceParam.LineParam.LineSizeY + 1.0) / CalibrationY);

            Rectangle findArea = new Rectangle();
            Rectangle drawArea = new Rectangle();

            double findWidth = 0.0;
            double findHeight = 0.0;

            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                if (area.Width < pix40mm && area.Height < pix5mm)
                    continue;

                int threshold = 0;

                int left = 0;
                int right = 0;
                int pinholeLeft = 0;
                int pinholeRight = 0;

                for (int direction = 0; direction < 2; direction++)
                {
                    if (direction == 0)
                    {
                        if (area.Left < 2)
                            continue;

                        left = area.Left - surfaceParam.PinHoleParam.MarginOut;
                        right = area.Left + surfaceParam.PinHoleParam.MarginIn;

                        if (left < 0)
                            left = 0;

                        if (right > imageWidth)
                            right = imageWidth;

                        pinholeLeft = area.Left;
                        pinholeRight = right;
                    }
                    else
                    {
                        if (area.Right > imageWidth - 3)
                            continue;

                        left = area.Right - surfaceParam.PinHoleParam.MarginIn;
                        right = area.Right + surfaceParam.PinHoleParam.MarginOut;

                        if (left < 0)
                            left = 0;

                        if (right > imageWidth)
                            right = imageWidth;

                        pinholeLeft = left;
                        pinholeRight = area.Right;
                    }

                    area.X = left;
                    area.Width = right - left;

                    area = ShapeHelper.GetValidRectangle(area, imageWidth, imageHeight);
                }

                if (surfaceParam.LineParam.EnableCheckLine)
                {
                    threshold = (int)(surfaceInspResult.CoatingAverageLevel.Average()) + surfaceParam.LineParam.LineEdgeLevel;

                    int divideCount = area.Height / pixRefernceHeight;

                    for (int divideIndex = 0; divideIndex < divideCount; divideIndex++)
                    {
                        Rectangle edgeRect = new Rectangle();

                        edgeRect.X = area.X;
                        edgeRect.Width = area.Width;
                        edgeRect.Y = divideIndex * pixRefernceHeight;
                        edgeRect.Height = pixRefernceHeight;

                        if (edgeRect.Bottom > area.Bottom)
                            edgeRect.Height = area.Bottom - edgeRect.Y;

                        var blobList = BlobContour(imageData, edgeRect, threshold, 255);

                        foreach (var item in blobList)
                        {
                            int blobLeft = item.Left;
                            int blobRight = item.Right;
                            int blobTop = item.Top;
                            int blobBottom = item.Bottom;

                            findArea.X = blobLeft;
                            findArea.Width = blobRight - blobLeft;
                            findArea.Y = blobTop;
                            findArea.Height = blobBottom - blobTop;

                            int diffLeft = blobLeft - edgeRect.Left;
                            int diffRight = edgeRect.Right - blobRight;

                            findWidth = (findArea.Width + 1) * CalibrationX;
                            findHeight = (findArea.Height + 1) * CalibrationY;

                            if (findHeight > surfaceParam.LineParam.LineSizeY)
                            {
                                drawArea = findArea;
                                drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                                break;
                            }
                        }
                    }
                }

                if (surfaceParam.PinHoleParam.EnablePinHole)
                {
                    area.X = pinholeLeft;
                    area.Width = pinholeRight - pinholeLeft;
                    threshold = (int)(surfaceInspResult.CoatingAverageLevel.Average()) + surfaceParam.PinHoleEdgeParam.PinHoleLevel;

                    var blobList = BlobContour(imageData, area, threshold, 255);
                    foreach (var item in blobList)
                    {
                        int blobLeft = item.Left;
                        int blobRight = item.Right;
                        int blobTop = item.Top;
                        int blobBottom = item.Bottom;

                        findArea.X = blobLeft;
                        findArea.Width = blobRight - blobLeft;
                        findArea.Y = blobTop;
                        findArea.Height = blobBottom - blobTop;

                        findWidth = (findArea.Width + 1) * CalibrationX;
                        findHeight = (findArea.Height + 1) * CalibrationY;

                        var pinholeSize = surfaceParam.PinHoleEdgeParam.PinHoleSize;
                        if (findWidth >= pinholeSize && findHeight >= pinholeSize)
                        {
                            drawArea = findArea;
                            drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                            break;
                        }
                    }

                }
            }
        }

        private void CheckCoatingArea(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, byte[] imageData, int imageWidth, int imageHeight, ref SurfaceInspResult surfaceInspResult)
        {
            Rectangle originArea = new Rectangle();

            double defectMinSize = 10.0;

            double defectMinSizeWhite = 0.0;
            double defectMinSizeDent = 0.0;
            double defectMinSizeCrater = 0.0;

            if (surfaceParam.PinHoleParam.EnablePinHole)
                defectMinSizeWhite = surfaceParam.PinHoleParam.PinHoleSize;

            if (surfaceParam.NonCoatingDentParam.EnableDent)
                defectMinSizeDent = surfaceParam.NonCoatingDentParam.DentSize;

            if (surfaceParam.CraterParam.EnableCrater)
            {
                if (surfaceParam.CraterParam.CraterLargeSize > 0 && surfaceParam.CraterParam.CraterLargeSize < defectMinSizeDent)
                    defectMinSizeCrater = surfaceParam.CraterParam.CraterLargeSize;

                if (surfaceParam.CraterParam.CraterSmallSize > 0 && surfaceParam.CraterParam.CraterSmallSize < defectMinSizeDent)
                    defectMinSizeCrater = surfaceParam.CraterParam.CraterSmallSize;
            }

            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                if (area.Width < 2 && area.Height < 2)
                    continue;

                //MakeBinary(0, area, surfaceInspResult.IsConnectionTape);
            }
        }

        private void MakeBinary(int inputIndex, Rectangle inputRect, byte[] imageData, int imageWidth, int imageHeight, SurfaceInspResult surfaceInspResult)
        {
            int averageSize = (int)(10 / CalibrationX);
            int scanSampling = averageSize / 5;
            if (scanSampling < 1)
                scanSampling = 1;

            int targetValue = 128; // Config.ImageProcTargetValue;

            for (int x = inputRect.Left; x < inputRect.Right; x++)
            {
                int sum = 0;
                int count = 0;

                for (int y = inputRect.Top; y < inputRect.Bottom; y+= 10)
                {
                    bool checkConnectionTape = CheckConnectionTape(surfaceInspResult, y);
                    if (checkConnectionTape)
                        continue;

                    sum += imageData[y * imageWidth + x];
                    count++;
                }


            }
        }

        private bool CheckConnectionTape(SurfaceInspResult surfaceInspResult, int height)
        {
            if (surfaceInspResult.IsConnectionTape)
            {
                if (height < surfaceInspResult.ConnectionTapeArea.Top || height > surfaceInspResult.ConnectionTapeArea.Bottom)
                    return true;
            }

            return false;
        }

        private void CheckNonCoating(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            foreach (var inspArea in distanceInspResult.CoatingAreas)
            {
                //var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                //if (area.Width < pix40mm && area.Height < pix5mm)
                //    continue;

                //byte[] workBuff = GetWorkBuffer(area, workRatioX, workRatioY, imageData, imageWidth, imageHeight, out buffWidth, out buffHeight);
                //if (workBuff == null)
                //    continue;
            }
        }

        private void CheckCoating(DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            // Input Insp Area
            foreach (var inspArea in distanceInspResult.NonCoatingAreas)
            {
                //var area = ShapeHelper.GetValidRectangle(inspArea, imageWidth, imageHeight);
                //if (area.Width < pix40mm && area.Height < pix5mm)
                //    continue;

                //byte[] workBuff = GetWorkBuffer(area, workRatioX, workRatioY, imageData, imageWidth, imageHeight, out buffWidth, out buffHeight);
                //if (workBuff == null)
                //    continue;
            }

            // Blob

            // Coordinate -> Rect

            // Add Rect at SurfaceInspResult.Rectagle
        }

        private void DrawRectangle(Rectangle inputRectangle)
        {

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

        private List<BlobContourResult> BlobContour(byte[] imageData, /*int width, int height,*/ Rectangle inputRect, int lowThreshold, int highThreshold)
        {
            int width = inputRect.Width;
            int height = inputRect.Height;

            if (ShapeHelper.CheckValidRectangle(inputRect, width, height) == false)
                return null;

            List<BlobContourResult> resultList = new List<BlobContourResult>();

            int x = inputRect.Left;
            int y = 0;

            byte[] tempBuff = new byte[width * height];

            for (int h = 0; h < height; h++)
            {
                y = inputRect.Top + h;
                Array.Copy(imageData, y * width + x, tempBuff, h * width, width);
            }

            int fillValue = 0;

            if (lowThreshold >= 50)
                fillValue = 0;
            else
                fillValue = 255;

            ShapeHelper.FillBound(tempBuff, width, height, fillValue);

            List<Point> pointList = ShapeHelper.GetPointListBetweenThresholdRange(imageData, width, height, new Point(0, 0), lowThreshold, highThreshold);

            foreach (var point in pointList)
            {
                if (point.X == -1 && point.Y == -1)
                    break;

                Rectangle foundrect = ShapeHelper.DetectEdge(imageData, width, height, point, lowThreshold, highThreshold);     // point 이새끼가 m_pContourPosX, m_pContourPosY, m_ContourCount 이거임

                if (foundrect.Left == 0 || foundrect.Top == 0 || foundrect.Right == 0 || foundrect.Bottom == 0)
                    break;

                if (foundrect.Left == -1 || foundrect.Top == -1 || foundrect.Right == -1 || foundrect.Bottom == -1)
                {
                    imageData[point.Y * width + point.X] = (byte)fillValue;
                    continue;
                }

                ShapeHelper.FillValueWithCount(imageData, foundrect, fillValue, lowThreshold, highThreshold, out int fillCount);

                BlobContourResult blobContourResult = new BlobContourResult();

                blobContourResult.Left = inputRect.X + foundrect.Left;
                blobContourResult.Top = inputRect.Y + foundrect.Top;
                blobContourResult.Right = inputRect.X + foundrect.Right;
                blobContourResult.Bottom = inputRect.Y + foundrect.Bottom;
                blobContourResult.PixelCount = fillCount;
                blobContourResult.ContourPointList.Add(new Point(inputRect.X + point.X, inputRect.Y + point.Y));

                resultList.Add(blobContourResult);
            }

            return resultList;
        }

        private bool CheckAlreadySaved()
        {
            return false;
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
