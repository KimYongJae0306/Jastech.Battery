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
            int imageWidth = image.ImageWidth;
            int imageHeight = image.ImageHeight;

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

        private void CheckCoatingArea_Line(ImageBuffer imageBuffer, DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult, bool isTapeInsp)
        {
            if (surfaceParam.LineParam.EnableCheckLine == false)
                return;

            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int workRatioX = surfaceParam.LineParam.WorkRatioX;
            int workRatioY = surfaceParam.LineParam.WorkRatioY;

            int buffWidth = 0;
            int buffHeight = 0;

            double referenceSizeX = 0.0;
            double referenceSizeY = 0.0;

            Rectangle workArea = new Rectangle();
            Rectangle findArea = new Rectangle();

            foreach (var coatingArea in distanceInspResult.CoatingAreas)
            {
                var inspArea = ShapeHelper.GetValidRectangle(coatingArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < pix40mm && inspArea.Height < pix5mm)
                    continue;

                imageBuffer.WorkBuffer.SetWorkBuffer(imageBuffer.ImageData, imageBuffer.ImageWidth, inspArea, workRatioX, workRatioY);

                byte[] workBuff = imageBuffer.WorkBuffer.GetWorkBuffer();
                if (workBuff == null)
                    continue;
                
                int stepX = imageBuffer.WorkBuffer.BuffWidth / 100;
                int stepY = imageBuffer.WorkBuffer.BuffHeight / 100;

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
                        sum += workBuff[h * imageBuffer.WorkBuffer.BuffWidth + w];
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
                        referenceSizeX = inspArea.Width / 2 * CalibrationX;
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
                    int blobLeft = inspArea.Left + item.Left * workRatioX;
                    int blobRight = inspArea.Left + item.Right * workRatioX;
                    int blobTop = inspArea.Top + item.Top * workRatioY;
                    int blobBottom = inspArea.Bottom + item.Bottom * workRatioY;

                    findArea.X = blobLeft;
                    findArea.Y = blobTop;
                    findArea.Width = blobRight - blobLeft;
                    findArea.Height = blobBottom - blobTop;

                    double findWidth = (findArea.Width + 1) * CalibrationX;
                    double findHeight = (findArea.Height + 1) * CalibrationY;

                    if (findWidth < referenceSizeX || findHeight < referenceSizeY)
                        continue;

                    bool samePos = CheckAlreadySaved();
                    if (samePos == true)
                        continue;

                    Rectangle drawArea = new Rectangle();
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

        private void CheckCoatingArea_LineBlack(ImageBuffer imageBuffer, DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            if (surfaceParam.LineBlackParam.EnableCheckLine == false)
                return;

            int buffWidth = imageBuffer.WorkBuffer.BuffWidth;
            int buffHeight = imageBuffer.WorkBuffer.BuffHeight;

            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int workRatioX = 3;
            int workRatioY = 10;

            Rectangle workArea = new Rectangle();
            Rectangle findArea = new Rectangle();

            int threshold = 128 - surfaceParam.LineBlackParam.LineLevel;

            int tapePosY1 = 0;
            int tapePosY2 = imageBuffer.ImageHeight;

            if (surfaceInspResult.IsConnectionTape == true)
            {
                tapePosY1 = surfaceInspResult.ConnectionTapeArea.Top * workRatioY;
                tapePosY2 = surfaceInspResult.ConnectionTapeArea.Bottom * workRatioY;
            }

            int averageSize = (int)(10 / CalibrationX);

            int samplingStep = averageSize / 5;

            if (samplingStep < 1)
                samplingStep = 1;

            foreach (var coatingArea in distanceInspResult.CoatingAreas)
            {
                var inspArea = ShapeHelper.GetValidRectangle(coatingArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < pix40mm && inspArea.Height < pix5mm)
                    continue;

                imageBuffer.WorkBuffer.SetWorkBuffer(imageBuffer.ImageData, imageBuffer.ImageWidth, inspArea, workRatioX, workRatioY);

                byte[] workBuff = imageBuffer.WorkBuffer.GetWorkBuffer();
                if (workBuff == null)
                    continue;

                byte[] diffBuff = new byte[workBuff.Length];

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

                        byte[] workBuffAverage = new byte[workBuff.Length];
                        workBuffAverage[h * buffWidth + w] = (byte)(tempSum / tempCount);

                        int diffValue = 128 + workBuff[h * buffWidth + w] - workBuffAverage[h * buffWidth + w];

                        if (diffValue < 0)
                            diffValue = 0;
                        if (diffValue > 255)
                            diffValue = 255;

                        diffBuff[h * buffWidth + w] = (byte)diffValue;
                    }
                });

                workArea.X = 0;
                workArea.Width = buffWidth;
                workArea.Y = 0;
                workArea.Height = buffHeight;

                var blobList = BlobContour(diffBuff, workArea, threshold, 255);

                foreach (var item in blobList)
                {
                    int blobLeft = inspArea.Left + item.Left * workRatioX;
                    int blobRight = inspArea.Left + item.Right * workRatioX;
                    int blobTop = inspArea.Top + item.Top * workRatioY;
                    int blobBottom = inspArea.Bottom + item.Bottom * workRatioY;

                    findArea.X = blobLeft;
                    findArea.Y = blobTop;
                    findArea.Width = blobRight - blobLeft;
                    findArea.Height = blobBottom - blobTop;

                    double findWidth = (findArea.Width + 1) * CalibrationX;
                    double findHeight = (findArea.Height + 1) * CalibrationY;

                    if (findWidth < surfaceParam.LineParam.LineSizeY)
                        continue;

                    bool samePos = CheckAlreadySaved();
                    if (samePos == true)
                        continue;

                    Rectangle drawArea = new Rectangle();
                    drawArea = findArea;
                    drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                }
            }
        }

        private void CheckCoatingArea_Edge(ImageBuffer imageBuffer, DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            int pix5mm = (int)(5.0 / CalibrationX);
            int pix40mm = (int)(40.0 / CalibrationX);

            int pixRefernceHeight = (int)((surfaceParam.LineParam.LineSizeY + 1.0) / CalibrationY);

            Rectangle findArea = new Rectangle();

            foreach (var conatingArea in distanceInspResult.CoatingAreas)
            {
                var inspArea = ShapeHelper.GetValidRectangle(conatingArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < pix40mm && inspArea.Height < pix5mm)
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
                        if (inspArea.Left < 2)
                            continue;

                        left = inspArea.Left - surfaceParam.PinHoleParam.MarginOut;
                        right = inspArea.Left + surfaceParam.PinHoleParam.MarginIn;

                        if (left < 0)
                            left = 0;

                        if (right > imageBuffer.ImageWidth)
                            right = imageBuffer.ImageWidth;

                        pinholeLeft = inspArea.Left;
                        pinholeRight = right;
                    }
                    else
                    {
                        if (inspArea.Right > imageBuffer.ImageWidth - 3)
                            continue;

                        left = inspArea.Right - surfaceParam.PinHoleParam.MarginIn;
                        right = inspArea.Right + surfaceParam.PinHoleParam.MarginOut;

                        if (left < 0)
                            left = 0;

                        if (right > imageBuffer.ImageWidth)
                            right = imageBuffer.ImageWidth;

                        pinholeLeft = left;
                        pinholeRight = inspArea.Right;
                    }

                    inspArea.X = left;
                    inspArea.Width = right - left;

                    inspArea = ShapeHelper.GetValidRectangle(inspArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                }

                if (surfaceParam.LineParam.EnableCheckLine)
                {
                    threshold = (int)(surfaceInspResult.CoatingAverageLevel.Average()) + surfaceParam.LineParam.LineEdgeLevel;

                    int divideCount = inspArea.Height / pixRefernceHeight;

                    for (int divideIndex = 0; divideIndex < divideCount; divideIndex++)
                    {
                        Rectangle edgeRect = new Rectangle();

                        edgeRect.X = inspArea.X;
                        edgeRect.Width = inspArea.Width;
                        edgeRect.Y = divideIndex * pixRefernceHeight;
                        edgeRect.Height = pixRefernceHeight;

                        if (edgeRect.Bottom > inspArea.Bottom)
                            edgeRect.Height = inspArea.Bottom - edgeRect.Y;

                        var blobList = BlobContour(imageBuffer.ImageData, edgeRect, threshold, 255);

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

                            double findWidth = (findArea.Width + 1) * CalibrationX;
                            double findHeight = (findArea.Height + 1) * CalibrationY;

                            if (findHeight > surfaceParam.LineParam.LineSizeY)
                            {
                                Rectangle drawArea = new Rectangle();
                                drawArea = findArea;
                                drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                                break;
                            }
                        }
                    }
                }

                if (surfaceParam.PinHoleParam.EnablePinHole)
                {
                    inspArea.X = pinholeLeft;
                    inspArea.Width = pinholeRight - pinholeLeft;
                    threshold = (int)(surfaceInspResult.CoatingAverageLevel.Average()) + surfaceParam.PinHoleEdgeParam.PinHoleLevel;

                    var blobList = BlobContour(imageBuffer.ImageData, inspArea, threshold, 255);
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

                        double findWidth = (findArea.Width + 1) * CalibrationX;
                        double findHeight = (findArea.Height + 1) * CalibrationY;

                        var pinholeSize = surfaceParam.PinHoleEdgeParam.PinHoleSize;
                        if (findWidth >= pinholeSize && findHeight >= pinholeSize)
                        {
                            Rectangle drawArea = new Rectangle();
                            drawArea = findArea;
                            drawArea.Inflate(20 /* / zoom */, 20 /* / zoom */);
                            break;
                        }
                    }
                }
            }
        }

        private void CheckCoatingArea(ImageBuffer imageBuffer, DistanceInspResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
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

            foreach (var coatingArea in distanceInspResult.CoatingAreas)
            {
                var inspArea = ShapeHelper.GetValidRectangle(coatingArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < 2 && inspArea.Height < 2)
                    continue;

                byte[] smallBuff = MakeBinary(imageBuffer, surfaceParam, inspArea, surfaceInspResult);

                Rectangle smallArea = inspArea;
                surfaceInspResult.CoatingAverageLevel.Add(GetCoatingAverageLevel(smallBuff/*, width*/, smallArea));
            }
        }

        private int GetCoatingAverageLevel(byte[] smallBuffer, Rectangle smallArea)
        {
            int samplingX = smallArea.Width / 100;
            int samplingY = smallArea.Height / 100;

            if (samplingX < 1)
                samplingX = 1;

            if (samplingY < 1)
                samplingY = 1;

            int sum = 0;
            int count = 0;

            for (int h = smallArea.Top; h < smallArea.Bottom; h++)
            {
                for (int w = smallArea.Left; w < smallArea.Right; w++)
                {
                    sum += smallBuffer[h * 0 + w];
                    count++;
                }
            }

            if (count < 1)
                count = 1;

            return sum / count;
        }

        private byte[] MakeBinary(ImageBuffer imageBuffer, SurfaceParam surfaceParam, Rectangle smallArea, SurfaceInspResult surfaceInspResult)
        {
            int averageSize = (int)(10 / CalibrationX);
            int scanSampling = averageSize / 5;
            if (scanSampling < 1)
                scanSampling = 1;

            int smallRatioX = 1;
            int smallRatioY = 1;

            int imageWidth = imageBuffer.ImageWidth;
            int imageHeight = imageBuffer.ImageHeight;

            int targetValue = 128; // Config.ImageProcTargetValue;
            byte[] projectionWidth = new byte[imageWidth];
            double[] magnifyFactor = new double[imageWidth];

            int smallBuffWidth = (int)((double)imageWidth / (double)smallRatioX);
            int smallBuffHeight = (int)((double)imageHeight / (double)smallRatioX);
            byte[] smallBuff = new byte[smallBuffWidth * smallBuffHeight];
            byte[] stretchSmallBuff = new byte[smallBuffWidth * smallBuffHeight];
            byte[] magnifiedSmallBuff = new byte[smallBuffWidth * smallBuffHeight];
            byte[] smallBuff_Bw = new byte[smallBuffWidth * smallBuffHeight];

            for (int x = smallArea.Left; x < smallArea.Right; x++)
            {
                int sum = 0;
                int count = 0;

                for (int y = smallArea.Top; y < smallArea.Bottom; y += 10)
                {
                    bool checkConnectionTape = CheckConnectionTape(surfaceInspResult, y);
                    if (checkConnectionTape)
                        continue;

                    sum += imageBuffer.ImageData[y * imageWidth + x];
                    count++;
                }

                if (count < 1)
                    count = 1;

                int average = sum / count;
                projectionWidth[x] = (byte)average;

                if (average < 10)
                    magnifyFactor[x] = 10.0;
                else
                    magnifyFactor[x] = (double)(targetValue) / (double)(average);

                if (magnifyFactor[x] < 1.0)
                    magnifyFactor[x] = 1.0;
            }

            smallArea.X = smallArea.X / smallRatioX;
            smallArea.Y = smallArea.Y / smallRatioY;
            smallArea.Width = smallArea.Width / smallRatioX;
            smallArea.Height = smallArea.Width / smallRatioY;

            int defectWhiteLevel = 255;
            if (surfaceParam.PinHoleParam.EnablePinHole && surfaceParam.PinHoleParam.PinHoleLevel < defectWhiteLevel)
                defectWhiteLevel = surfaceParam.PinHoleParam.PinHoleLevel;

            int defectDentLevel = 255;
            if (surfaceParam.DentParam.EnableDent && surfaceParam.DentParam.DentLevel < defectDentLevel)
                defectDentLevel = surfaceParam.DentParam.DentLevel;

            int defectCraterLevel = 255;
            if (surfaceParam.CraterParam.EnableCrater && surfaceParam.CraterParam.CraterLevel < defectCraterLevel)
                defectCraterLevel = surfaceParam.CraterParam.CraterLevel;

            if (true /* Congfig.bUseParallel == true*/)
            {
                Parallel.For(smallArea.Top, smallArea.Bottom, h =>
                {
                    for (int w = smallArea.Left; w < smallArea.Right; w++)
                    {
                        int x = w * smallRatioX;
                        int y = h * smallRatioY;

                        int originValue = 0;
                        int diffValue = 0;
                        int stretchValue = 0;
                        int magnifiedValue = 0;
                        byte fillValue = 0;

                        originValue = imageBuffer.ImageData[y * imageWidth + x];
                        diffValue = originValue - projectionWidth[x];
                        stretchValue = targetValue + diffValue;
                        magnifiedValue = targetValue + (int)(diffValue * magnifyFactor[x]);

                        if (stretchValue < 0)
                            stretchValue = 0;

                        if (stretchValue > 255)
                            stretchValue = 255;

                        smallBuff[h * smallBuffWidth + w] = (byte)originValue;
                        stretchSmallBuff[h * smallBuffWidth + w] = (byte)stretchValue;

                        if (magnifiedValue < 0)
                            magnifiedValue = 0;

                        if (magnifiedValue > 255)
                            magnifiedValue = 255;

                        magnifiedSmallBuff[h * smallBuffWidth + w] = (byte)magnifiedValue;

                        int thresholdWhite = targetValue + defectWhiteLevel;
                        int thresholdDent = targetValue + defectDentLevel;
                        int thresholdCrater = targetValue + defectCraterLevel;

                        if (stretchValue >= thresholdWhite)
                            fillValue = 255; /* Define.MARK_WHITE;*/
                        else if (magnifiedValue >= thresholdDent)
                            fillValue = 150; /* Define.MARK_DENT;*/
                        else if (magnifiedValue <= thresholdCrater)
                            fillValue = 0; /* Define.MARK_CRATER;*/
                        else
                            continue;

                        smallBuff_Bw[h * smallBuffWidth + w] = (byte)fillValue;
                    }
                });
            }
            else
            {
                for (int h = smallArea.Top; h < smallArea.Bottom; h++)
                {
                    for (int w = smallArea.Left; w < smallArea.Right; w++)
                    {
                        int x = w * smallRatioX;
                        int y = h * smallRatioY;
                    }
                }
            }

            smallBuff_Bw = ReduceDentNoise(smallArea, smallBuff_Bw, smallBuffWidth);
            return smallBuff;
        }

        private byte[] ReduceDentNoise(Rectangle smallArea, byte[] smallBuff_Bw, int smallBuffWidth)
        {
            int diffX = 0;

            for (int h = smallArea.Top; h < smallArea.Bottom; h++)
            {
                int startX = -1;
                int endX = -1;

                for (int w = smallArea.Left; w < smallArea.Right; w++)
                {
                    if (smallBuff_Bw[h * smallBuffWidth + w] >= 0)
                    {
                        if (startX < 0)
                            startX = w;
                    }
                    else
                    {
                        if (startX >= smallArea.Left && endX < 0)
                        {
                            endX = w;
                            diffX = endX - startX;

                            if (diffX <= 1)
                            {
                                for (int horizontal = startX; horizontal < endX; horizontal++)
                                    smallBuff_Bw[h * smallBuffWidth + w] = 0;
                            }
                        }

                        startX = -1;
                        endX = -1;
                    }
                }
            }

            return smallBuff_Bw;
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

        //private byte[] GetWorkBuffer(ImageBuffer imageBuffer, Rectangle inputRect, int workRatioX, int workRatioY)
        //{
        //    if (ShapeHelper.CheckValidRectangle(inputRect, imageBuffer.ImageWidth, imageBuffer.ImageHeight))
        //        return null;

        //    int buffWidth = inputRect.Width / workRatioX;
        //    int buffHeight = inputRect.Height / workRatioY;

        //    if (buffWidth < 1 || buffHeight < 1)
        //        return null;

        //    imageBuffer.InitializeWorkBuffer();

        //    byte[] outputBuff = new byte[buffWidth * buffHeight];

        //    int x = 0;
        //    int y = 0;

        //    for (int h = 0; h < buffHeight; h++)
        //    {
        //        y = inputRect.Top + h * workRatioY;

        //        for (int w = 0; w < buffWidth; w++)
        //        {
        //            x = inputRect.Left + w * workRatioX;

        //            outputBuff[h * buffWidth + w] = imageData[y * imageWidth + x];
        //        }
        //    }

        //    return outputBuff;
        //}

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
