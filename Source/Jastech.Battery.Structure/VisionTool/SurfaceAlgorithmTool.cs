using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Xml.Schema;
using Emgu.CV.BgSegm;
using System.Reflection;
using System.Data;
using Emgu.CV.Cuda;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Security.Principal;

namespace Jastech.Battery.Structure.VisionTool
{
    public partial class SurfaceAlgorithmTool
    {
        #region 2024.03.11 구조 변경 중
        // 상수 어디에 넣을지
        public const double CalibrationX = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double CalibrationY = 0.0423; // CIS 사용 시 X,Y Scale 확인할 것
        public const double pixelLength1mm = 1.0 / CalibrationX;
        public const double PixelLength5mm = 5.0 / CalibrationX;
        public const double PixelLength40mm = 40.0 / CalibrationX;
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

        private void CheckCoatingArea_Line(ImageBuffer imageBuffer, List<SurfaceInfo> coatingInfoList, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult, bool isTapeInsp)
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

            foreach (SurfaceInfo coatingInfo in coatingInfoList)
            {
                var inspArea = TempAlgorithmTool.GetValidRectangle(coatingInfo.Area, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < pix40mm && inspArea.Height < pix5mm)
                    continue;

                imageBuffer.WorkBuffer.SetWorkBuffer(imageBuffer.ImageData, imageBuffer.ImageWidth, inspArea, workRatioX, workRatioY);

                byte[] workBuff = imageBuffer.WorkBuffer.GetWorkBuffer();
                if (workBuff == null)
                    continue;

                int averageLevel = TempAlgorithmTool.GetAverageLevel(workBuff, imageBuffer.WorkBuffer.BuffWidth, imageBuffer.WorkBuffer.BuffHeight);

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

                var blobList = BlobContour(workBuff, imageBuffer.WorkBuffer.BuffWidth, imageBuffer.WorkBuffer.BuffHeight, workArea, threshold, 255);

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

        private void CheckCoatingArea_LineBlack(ImageBuffer imageBuffer, FindAreaResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
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

            foreach (SurfaceInfo coatingInfo in distanceInspResult.CoatingInfoList)
            {
                var inspArea = TempAlgorithmTool.GetValidRectangle(coatingInfo.Area, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
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

                var blobList = BlobContour(diffBuff, buffWidth, buffHeight, workArea, threshold, 255);

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

        private void CheckCoatingArea_Edge(ImageBuffer imageBuffer, FindAreaResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            int pixRefernceHeight = (int)((surfaceParam.LineParam.LineSizeY + 1.0) / CalibrationY);

            Rectangle findArea = new Rectangle();

            foreach (SurfaceInfo conatingInfo in distanceInspResult.CoatingInfoList)
            {
                var inspArea = TempAlgorithmTool.GetValidRectangle(conatingInfo.Area, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < PixelLength40mm && inspArea.Height < PixelLength5mm)
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

                    inspArea = TempAlgorithmTool.GetValidRectangle(inspArea, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
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

                        var blobList = BlobContour(imageBuffer.ImageData, imageBuffer.ImageWidth, imageBuffer.ImageHeight, edgeRect, threshold, 255);

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

                    var blobList = BlobContour(imageBuffer.ImageData, imageBuffer.ImageWidth, imageBuffer.ImageHeight, inspArea, threshold, 255);
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

        private void CheckCoatingArea(ImageBuffer imageBuffer, FindAreaResult distanceInspResult, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            Rectangle originArea = new Rectangle();

            double defectMinSize = 10.0;

            double defectMinSizeWhite = 0.0;
            double defectMinSizeDent = 0.0;
            double defectMinSizeCrater = 0.0;

            int smallRatioX = 0;
            int smallRatioY = 0;

            int pix5mm = (int)PixelLength5mm / smallRatioX;
            int pix40mm = (int)PixelLength40mm / smallRatioX;

            //if (surfaceParam.PinHoleParam.EnablePinHole)
            //    defectMinSizeWhite = surfaceParam.PinHoleParam.PinHoleSize;

            //if (surfaceParam.NonCoatingDentParam.EnableDent)
            //    defectMinSizeDent = surfaceParam.NonCoatingDentParam.DentSize;

            if (surfaceParam.CraterParam.EnableCrater)
            {
                if (surfaceParam.CraterParam.CraterLargeSize > 0 && surfaceParam.CraterParam.CraterLargeSize < defectMinSizeDent)
                    defectMinSizeCrater = surfaceParam.CraterParam.CraterLargeSize;

                if (surfaceParam.CraterParam.CraterSmallSize > 0 && surfaceParam.CraterParam.CraterSmallSize < defectMinSizeDent)
                    defectMinSizeCrater = surfaceParam.CraterParam.CraterSmallSize;
            }

            foreach (SurfaceInfo coatingInfo in distanceInspResult.CoatingInfoList)
            {
                var inspArea = TempAlgorithmTool.GetValidRectangle(coatingInfo.Area, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
                if (inspArea.Width < 2 && inspArea.Height < 2)
                    continue;

                byte[] smallBuff = MakeBinary(imageBuffer, surfaceParam, inspArea, surfaceInspResult);

                int averageLevel = TempAlgorithmTool.GetAverageLevel(smallBuff, imageBuffer.SmallBuffer.BufferWidth, inspArea);
                surfaceInspResult.CoatingAverageLevel.Add(averageLevel);

                var smallBuffer = imageBuffer.SmallBuffer;
                int coatingLinePosY = GetDoubleCoatingLine(imageBuffer, smallBuffer.OriginBuffer, smallBuffer.BufferWidth, smallBuffer.BufferHeight, inspArea, smallRatioX);

                surfaceInspResult.DoubleCoatingPosY.Add(coatingLinePosY);

                var smallArea = TempAlgorithmTool.GetValidRectangle(inspArea, smallBuffer.BufferWidth, smallBuffer.BufferHeight);
                if (smallArea.Width < PixelLength40mm && smallArea.Height < PixelLength5mm)
                    continue;

                CheckCorner(imageBuffer, surfaceParam, smallArea, smallRatioX, out bool isTopCorner, out bool isBottomCorner);

                // 두 번해
                GetPinHole(smallBuffer, smallArea, smallRatioX, smallRatioY, surfaceParam, ref surfaceInspResult);


                defectMinSize = defectMinSizeWhite;

                BlobContour(smallBuffer.BwBuffer, smallBuffer.BufferWidth, smallBuffer.BufferHeight, smallArea, 50, 251);
            }
        }

        private void GetPinHole(SmallBuffer smallBuffer, Rectangle smallArea, int smallRatioX, int smallRatioY, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            double pinHoleSize = 100000.0;
            if (surfaceParam.PinHoleParam.EnablePinHole)
                pinHoleSize = surfaceParam.PinHoleParam.PinHoleSize;

            var blobList = BlobContour(smallBuffer.BwBuffer, smallBuffer.BufferWidth, smallBuffer.BufferHeight, smallArea, 250, 251);
            foreach (var item in blobList)
            {
                int blobLeft = item.Left * smallRatioX;
                int blobRight = item.Right * smallRatioX;
                int blobTop = item.Top * smallRatioY;
                int blobBottom = item.Bottom * smallRatioY;

                double findWidth = blobRight - blobLeft;
                double findHeight = blobBottom - blobTop;

                int distanceTop = blobTop - smallArea.Top;
                int distanceBottom = smallArea.Bottom - blobBottom;

                SizeF defectSize = new SizeF();
                defectSize.Width = (float)((findWidth + 1) * CalibrationX);
                defectSize.Height = (float)((distanceBottom + 1) * CalibrationY);

                DefectInfo defectInfo = new DefectInfo();
                defectInfo.DefectType = DefectDefine.DefectTypes.Pinhole;
                defectInfo.Size = new SizeF((float)pinHoleSize, (float)pinHoleSize);
                surfaceInspResult.DefectList.Add(defectInfo);
            }
        }

        private void GetDent(SmallBuffer smallBuffer, Rectangle smallArea, int smallRatioX, int smallRatioY, SurfaceParam surfaceParam, ref SurfaceInspResult surfaceInspResult)
        {
            double dentSize = 100000.0;
            if (surfaceParam.NonCoatingDentParam.EnableDent)
                dentSize = surfaceParam.NonCoatingDentParam.DentSize;

            var blobList = BlobContour(smallBuffer.BwBuffer, smallBuffer.BufferWidth, smallBuffer.BufferHeight, smallArea, 50, 250);
            foreach (var item in blobList)
            {
                int blobLeft = item.Left * smallRatioX;
                int blobRight = item.Right * smallRatioX;
                int blobTop = item.Top * smallRatioY;
                int blobBottom = item.Bottom * smallRatioY;

                double findWidth = blobRight - blobLeft;
                double findHeight = blobBottom - blobTop;

                int distanceTop = blobTop - smallArea.Top;
                int distanceBottom = smallArea.Bottom - blobBottom;

                SizeF defectSize = new SizeF();
                defectSize.Width = (float)((findWidth + 1) * CalibrationX);
                defectSize.Height = (float)((distanceBottom + 1) * CalibrationY);

                DefectInfo defectInfo = new DefectInfo();
                defectInfo.DefectType = DefectDefine.DefectTypes.Pinhole;
                defectInfo.Size = new SizeF((float)dentSize, (float)dentSize);
                surfaceInspResult.DefectList.Add(defectInfo);
            }
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
            byte[] smallBuff_Bw = new byte[smallBuffWidth * smallBuffHeight];

            for (int w = smallArea.Left; w < smallArea.Right; w++)
            {
                List<int> verticalDatas = new List<int>();

                for (int h = smallArea.Top; h < smallArea.Bottom; h += 10)
                {
                    bool checkConnectionTape = CheckConnectionTape(surfaceInspResult, h);
                    if (checkConnectionTape)
                        continue;

                    verticalDatas.Add(imageBuffer.ImageData[h * imageWidth + w]);
                }

                int average = 0;

                if (verticalDatas.Count > 0)
                    average = (int)verticalDatas.Average();

                projectionWidth[w] = (byte)average;

                if (average < 10)
                    magnifyFactor[w] = 10.0;
                else
                    magnifyFactor[w] = (double)(targetValue) / (double)(average);

                if (magnifyFactor[w] < 1.0)
                    magnifyFactor[w] = 1.0;
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

                        //smallBuff[h * smallBuffWidth + w] = (byte)originValue;
                        //stretchSmallBuff[h * smallBuffWidth + w] = (byte)stretchValue;
                        imageBuffer.SmallBuffer.OriginBuffer[h * smallBuffWidth + w] = (byte)originValue;
                        imageBuffer.SmallBuffer.StretchBuffer[h * smallBuffWidth + w] = (byte)stretchValue;

                        if (magnifiedValue < 0)
                            magnifiedValue = 0;

                        if (magnifiedValue > 255)
                            magnifiedValue = 255;

                        //magnifiedSmallBuff[h * smallBuffWidth + w] = (byte)magnifiedValue;
                        imageBuffer.SmallBuffer.MagnifiedBuffer[h * smallBuffWidth + w] = (byte)fillValue;

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

                        //smallBuff_Bw[h * smallBuffWidth + w] = (byte)fillValue;
                        imageBuffer.SmallBuffer.BwBuffer[h * smallBuffWidth + w] = (byte)fillValue;
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
                            int diffX = endX - startX;

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

        private List<BlobContourResult> BlobContour(byte[] buffer, int bufferWidth, int bufferHeight, Rectangle inputRect, int lowThreshold, int highThreshold)
        {
            if (TempAlgorithmTool.CheckValidRectangle(inputRect, bufferWidth, bufferHeight) == false)
                return null;

            //int x = inputRect.Left;
            //int width = inputRect.Width;
            //int height = inputRect.Height;

            List<BlobContourResult> resultList = new List<BlobContourResult>();

            byte[] tempBuff = new byte[inputRect.Width * inputRect.Height];

            for (int h = 0; h < inputRect.Height; h++)
            {
                int y = inputRect.Top + h;
                Array.Copy(buffer, y * bufferWidth + inputRect.Left, tempBuff, h * inputRect.Width, inputRect.Width);
            }

            int fillValue = 0;

            if (lowThreshold >= 50)
                fillValue = 0;
            else
                fillValue = 255;

            TempAlgorithmTool.FillBound(tempBuff, inputRect.Width, inputRect.Height, fillValue);

            List<Point> pointList = TempAlgorithmTool.GetPointListBetweenThresholdRange(buffer, inputRect.Width, inputRect.Height, new Point(0, 0), lowThreshold, highThreshold);

            foreach (var point in pointList)
            {
                if (point.X == -1 && point.Y == -1)
                    break;

                Rectangle foundrect = TempAlgorithmTool.DetectEdge(buffer, inputRect.Width, inputRect.Height, point, lowThreshold, highThreshold);     // point 이새끼가 m_pContourPosX, m_pContourPosY, m_ContourCount 이거임

                if (foundrect.Left == 0 || foundrect.Top == 0 || foundrect.Right == 0 || foundrect.Bottom == 0)
                    break;

                if (foundrect.Left == -1 || foundrect.Top == -1 || foundrect.Right == -1 || foundrect.Bottom == -1)
                {
                    buffer[point.Y * inputRect.Width + point.X] = (byte)fillValue;
                    continue;
                }

                TempAlgorithmTool.FillValueWithCount(buffer, foundrect, fillValue, lowThreshold, highThreshold, out int fillCount);

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

        private int GetDoubleCoatingLine(ImageBuffer imageBuffer, byte[] buffer, int buffWidth, int buffHeight, Rectangle rectangle, int smallRatio)
        {
            Array.Clear(imageBuffer.HorizontalData, 0, imageBuffer.ImageHeight);

            int findPos = -1;

            for (int h = rectangle.Top; h < rectangle.Bottom; h++)
            {
                int sum = 0;
                int count = 0;

                for (int w = rectangle.Left; w < rectangle.Right; w += 10)
                {
                    sum += buffer[h * buffWidth + w];
                    count++;
                }

                int average = sum / count;
                imageBuffer.HorizontalData[h] = average;
            }

            Array.Copy(imageBuffer.HorizontalData, imageBuffer.AverageHorizontalData, buffHeight);

            imageBuffer.AverageHorizontalData = TempAlgorithmTool.GetSmooth1D(imageBuffer.AverageHorizontalData, buffHeight, 0, buffHeight, 100);

            for (int h = rectangle.Top; h < rectangle.Bottom; h++)
                imageBuffer.DifferentialHorizontalData[h] = imageBuffer.HorizontalData[h] - imageBuffer.AverageHorizontalData[h];

            int threshold = 0; /*Para.DoubleCoatingLv;*/

            int start = -1;
            int end = -1;

            for (int h = rectangle.Top; h < rectangle.Bottom; h++)
            {
                if (start < 0 && imageBuffer.DifferentialHorizontalData[h] <= -threshold)
                    start = h;

                if (start < 0)
                    continue;

                if (end < 0 && imageBuffer.DifferentialHorizontalData[h] > -threshold)
                    end = h;

                if (end < 0)
                    continue;

                int x1 = (rectangle.Left + 100) * smallRatio;
                int x2 = (rectangle.Right - 100) * smallRatio;
                int y1 = smallRatio * (start + end) / 2;
                int y2 = y1;

                findPos = y1;
            }
            
            return findPos;
        }

        private void CheckCorner(ImageBuffer imageBuffer, SurfaceParam surfaceParam, Rectangle inputRect, int smallRatio, out bool isTopCorner, out bool isBottomCorner)
        {
            isTopCorner = false;
            isBottomCorner = false;

            int x1 = 0;
            int y1 = 0;

            int x2 = 0;
            int y2 = 0;

            int clearMarginX = 0;
            int clearMarginY = 0;

            int pixelCornerX = (int)(surfaceParam.CornerMargin / CalibrationX);
            int pixelCornerY = (int)(surfaceParam.CornerMargin / CalibrationY);

            int marginX1 = 0;
            int marginX2 = 0;
            int marginY1 = 0;
            int marginY2 = 0;

            int clearX1 = 0;
            int clearX2 = 0;
            int clearY1 = 0;
            int clearY2 = 0;

            foreach (CornerType cornerType in Enum.GetValues(typeof(CornerType)))
            {
                switch (cornerType)
                {
                    case CornerType.LeftTop:
                        x1 = inputRect.Left;
                        y1 = inputRect.Top;

                        clearMarginX = (pixelCornerX - marginX1) / smallRatio;
                        clearMarginY = (pixelCornerX - marginY1) / smallRatio;

                        clearX1 = 0;
                        clearX2 = clearMarginX;
                        clearY1 = 0;
                        clearY2 = clearMarginY;
                        break;

                    case CornerType.RightTop:
                        x1 = inputRect.Right - pixelCornerX;
                        y1 = inputRect.Top;

                        clearMarginX = (pixelCornerX - marginX2) / smallRatio;
                        clearMarginY = (pixelCornerY - marginY1) / smallRatio;

                        clearX1 = imageBuffer.SmallBuffer.BufferWidth - clearMarginX;
                        clearX2 = imageBuffer.SmallBuffer.BufferWidth;
                        clearY1 = 0;
                        clearY2 = clearMarginY;
                        break;

                    case CornerType.LeftBottom:
                        x1 = inputRect.Left;
                        y1 = inputRect.Bottom - pixelCornerY;

                        clearMarginX = (pixelCornerX - marginX1) / smallRatio;
                        clearMarginY = (pixelCornerY - marginY2) / smallRatio;

                        clearX1 = 0;
                        clearX2 = clearMarginX;
                        clearY1 = imageBuffer.SmallBuffer.BufferHeight - clearMarginY;
                        clearY2 = imageBuffer.SmallBuffer.BufferHeight;
                        break;

                    case CornerType.RightBottom:
                        x1 = inputRect.Right - pixelCornerX;
                        y1 = inputRect.Bottom - pixelCornerY;

                        clearMarginX = (pixelCornerX - marginX2) / smallRatio;
                        clearMarginY = (pixelCornerY - marginY2) / smallRatio;

                        clearX1 = imageBuffer.SmallBuffer.BufferWidth - clearMarginX;
                        clearX2 = imageBuffer.SmallBuffer.BufferWidth;
                        clearY1 = imageBuffer.SmallBuffer.BufferHeight - clearMarginY;
                        clearY2 = imageBuffer.SmallBuffer.BufferHeight;
                        break;

                    default:
                        break;
                }

                x2 = x1 + pixelCornerX;
                y2 = y1 + pixelCornerY;

                if (x1 < 0 || y1 < 0 || x2 > imageBuffer.ImageWidth || y2 > imageBuffer.ImageHeight)
                    continue;

                Rectangle cornerRect = new Rectangle();
                cornerRect.X = x1;
                cornerRect.Y = y1;
                cornerRect.Width = x2 - x1;
                cornerRect.Height = y2 - y1;

                bool isCorner = IsCorner(imageBuffer, cornerRect, cornerType, surfaceParam.CoatingEdgeLevel);
                if (isCorner == false)
                    continue;

                if (clearX1 < 0)
                    clearX1 = 0;

                if (clearX2 > imageBuffer.SmallBuffer.BufferWidth)
                    clearX2 = imageBuffer.SmallBuffer.BufferWidth;

                if (clearY1 < 0)
                    clearY1 = 0;

                if (clearY2 > imageBuffer.SmallBuffer.BufferHeight)
                    clearY2 = imageBuffer.SmallBuffer.BufferHeight;

                imageBuffer.SmallBuffer.BwBuffer = TempAlgorithmTool.FillValue(imageBuffer.SmallBuffer.BwBuffer, imageBuffer.SmallBuffer.BufferWidth, cornerRect, 0);

                if (cornerType == CornerType.LeftTop || cornerType == CornerType.RightTop)
                    isTopCorner = true;
                else if (cornerType == CornerType.LeftBottom || cornerType == CornerType.RightBottom)
                    isBottomCorner = true;
            }
        }

        private bool IsCorner(ImageBuffer imageBuffer, Rectangle inputRect, CornerType cornerType, int edgeLevel)
        {
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();

            int inspSizeX = inputRect.Width / 10;
            if (inspSizeX < 10)
                inspSizeX = 10;

            int inspSizeY = inputRect.Height / 10;
            if (inspSizeY < 10)
                inspSizeY = 10;

            switch (cornerType)
            {
                case CornerType.LeftTop:
                    rect1.X = inputRect.X;
                    rect1.Y = inputRect.Y;

                    rect2.X = rect2.Right - inspSizeX;
                    rect2.Y = rect2.Bottom - inspSizeY;
                    break;

                case CornerType.RightTop:
                    rect1.X = inputRect.Right - inspSizeX;
                    rect1.Y = inputRect.Y;

                    rect2.X = inputRect.X;
                    rect2.Y = inputRect.Bottom - inspSizeY;
                    break;

                case CornerType.LeftBottom:
                    rect1.X = inputRect.X;
                    rect1.Y = inputRect.Bottom - inspSizeY;

                    rect2.X = inputRect.Right - inspSizeX;
                    rect2.Y = inputRect.Top;
                    break;

                case CornerType.RightBottom:
                    rect1.X = inputRect.X;
                    rect1.Y = inputRect.Y;

                    rect2.X = inputRect.Right - inspSizeX;
                    rect2.Y = inputRect.Bottom - inspSizeY;
                    break;

                default:
                    break;
            }

            rect1.Width = inspSizeX;
            rect1.Height = inspSizeY;

            rect2.Width = inspSizeX;
            rect2.Height = inspSizeY;

            rect1 = TempAlgorithmTool.GetValidRectangle(rect1, imageBuffer.ImageWidth, imageBuffer.ImageHeight);
            rect2 = TempAlgorithmTool.GetValidRectangle(rect2, imageBuffer.ImageWidth, imageBuffer.ImageHeight);

            List<Rectangle> rectList = new List<Rectangle>();
            rectList.Add(rect1);
            rectList.Add(rect2);

            List<int> averageList = new List<int>();
            foreach (Rectangle rect in rectList)
            {
                int average = TempAlgorithmTool.GetAverageLevel(imageBuffer.ImageData, imageBuffer.ImageWidth, rect);
                averageList.Add(average);
            }

            int diffLevel = averageList.Max() - averageList.Min();

            if (diffLevel >= edgeLevel)
                return true;

            return false;
        }
    }

    public partial class SurfaceAlgorithmTool
    {
    }

    public enum CornerType
    {
        LeftTop,
        RightTop,
        LeftBottom,
        RightBottom,
    }
}
