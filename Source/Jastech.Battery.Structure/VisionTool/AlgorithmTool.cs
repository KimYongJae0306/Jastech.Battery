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

        // 확인 필요
        double zoom = 0.08825; //Config.Zoom[m_ModuleNo]

        // 아마 Teaching, Model
        public int CoatingMinimumLength = 10;
        public int CoatingAreaMaximumCount = 5;
        public sbyte ContrastOffsetBrighter = 20;
        public sbyte ContrastOffsetDarker = -20;
        public byte CoatingExistanceThreshold = 179;
        public byte CoatingExistanceCriteria = 70;
        public byte CoatingEdgeConstrastCriteria = 39; // Para.CoatEdgeLv[m_ModuleNo];                EdgeThreashold TeachingParameter로 따로 빼기
        public byte BackGroundGrayLevelCriteria = 100;


        public int WidthSamplingScale = 300;
        public int HeightSamplingScale = 200;

        List<CopperInfo> CopperInfos = new List<CopperInfo>();      //이거 지워야할수도 있음
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

        public void CoatingArea_LineBlack(CoatingParam param)
        {
            int threshold = 128 - param.LineParam.LineLevel;

            int workRatioX = 3;
            int workRatioY = 10;

            int tapePosY1 = 0;
            int tapePosY2 = param.ImageHeight;
        }

        //////////////////////////////////

        public void Check()
        {
        }

        public void CheckNonCoatingWidth(Bitmap bmp)
        {
            NonCoatingParam nonCoatingParam = new NonCoatingParam();

            if (nonCoatingParam.CheckNonCoatingWidth == false) //if (Para.bCheckNonCoatW == false)
                return;

            byte[] imageData = ImageHelper.GetByteArrayFromBitmap(bmp);
            int width = bmp.Width;
            int height = bmp.Height;

            bool bResult = true;
            double CopperW = 0;
            int x1 = 0, x2 = 0, cx = 0;
            int y1 = 0, y2 = 0, cy = 0;
            int val = 0, max_val = 0, max_pos = 0;
            int pos_l = 0, pos_r = 0;

            int NgLineCount = 0;

            Rectangle DefectArea = new Rectangle();

            int CompSize = 2; // Config.EdgeCompSizeWid;
            int Pix2mm = (int)(2.0 / CalibrationX); //(int)(2.0 / m_CalibX);
            int CornerMargin = (int)(testInspParam.CornerMargin / CalibrationX);  //(int)(Para.CornerMargin / m_CalibY);

            double RefMin = nonCoatingParam.MinWidth; // Para.NonCoatMinW;
            double RefMax = nonCoatingParam.MaxWidth; // Para.NonCoatMaxW;

            DistanceParam distanceParam = new DistanceParam();

            bResult = true;
            for (int iCopper = 0; iCopper < distanceParam.CopperNum; iCopper++)
            {
                x1 = (int)(CopperInfos[iCopper].CopperStX / CalibrationX);
                x2 = (int)(CopperInfos[iCopper].CopperEndX / CalibrationX);
                CopperW = x2 - x1;

                if (CopperW < 5)
                    continue;

                ////===== 소형3동에서만 사용함 (Rewinder Slitter)
                //double nonCoatWidth = CopperW * CalibrationX;

                cx = (x1 + x2) / 2;

                x1 -= Pix2mm;
                x2 += Pix2mm;
                if (x1 < 0)
                    x1 = 0;
                if (x2 >= width/*m_ImgW*/)
                    x2 = width; // m_ImgW - 1;

                for (int coatingRow = 0; coatingRow < testInspParam.coatingRowCount /*m_VertCoatNum*/; coatingRow++/*iVert++*/)
                {
                    y1 = testInspParam.verticalCoatArea[coatingRow].Top;
                    y2 = testInspParam.verticalCoatArea[coatingRow].Bottom;

                    //==== 시작부분이 맨 위쪽이 아닐경우.
                    int tmp_diff = y1 - 0;
                    if (tmp_diff > 1)
                    {
                        y1 += CornerMargin;

                        if (y1 >= height/*m_ImgH*/)
                            y1 = height - 1; // m_ImgH - 1;
                    }

                    //===== 끝 부분이 맨 아래쪽이 아닐경우 코너 마진 제외함.
                    tmp_diff = height - y2;// m_ImgH - y2;
                    if (tmp_diff > 1)
                    {
                        y2 -= CornerMargin;

                        if (y2 < 0)
                            y2 = 0;
                    }

                    cy = (y1 + y2) / 2;

                    //m_Draw.DrawCross(cx, cy, 10, Color.Red, false);

                    for (int j = y1; j < y2; j += 5)
                    {
                        //===== 왼쪽
                        max_val = 0;
                        max_pos = 0;
                        for (int i = cx - CompSize; i > x1 + CompSize; i--)
                        {
                            //val = m_pImgBuff[j * m_ImgW + i + CompSize] - m_pImgBuff[j * m_ImgW + i - CompSize];
                            val = imageData[j * width + i + CompSize] - imageData[j * width + i - CompSize];
                            if (val > max_val)
                            {
                                max_val = val;
                                max_pos = i;
                            }
                        }

                        pos_l = max_pos;
                        //m_Draw.DrawLine(pos_l, j, pos_l, j + 5, Color.Red, 1, System.Drawing.Drawing2D.DashStyle.Solid, false);

                        //===== 오른쪽
                        max_val = 0;
                        max_pos = 0;
                        for (int i = cx + CompSize; i < x2 - CompSize; i++)
                        {
                            //val = m_pImgBuff[j * m_ImgW + i - CompSize] - m_pImgBuff[j * m_ImgW + i + CompSize];
                            val = imageData[j * width + i - CompSize] - imageData[j * width + i + CompSize];
                            if (val > max_val)
                            {
                                max_val = val;
                                max_pos = i;
                            }
                        }

                        pos_r = max_pos;
                        //m_Draw.DrawLine(pos_r, j, pos_r, j + 5, Color.Red, 1, System.Drawing.Drawing2D.DashStyle.Solid, false);

                        CopperW = (pos_r - pos_l) * CalibrationX; // m_CalibX;

                        DefectArea.X = x1;
                        DefectArea.Width = x2 - x1;
                        DefectArea.Y = j;
                        DefectArea.Height = 5;

                        if (RefMin > 0.0 && RefMax > 0.0)
                        {
                            if (CopperW < RefMin || CopperW > RefMax)
                            {
                                NgLineCount++;
                            }
                            else
                            {
                                NgLineCount = 0;
                            }
                        }
                        else if (RefMin > 0.0)
                        {
                            if (CopperW < RefMin)
                            {
                                NgLineCount++;
                            }
                            else
                            {
                                NgLineCount = 0;
                            }
                        }
                        else if (RefMax > 0.0)
                        {
                            if (CopperW > RefMax)
                            {
                                NgLineCount++;
                            }
                            else
                            {
                                NgLineCount = 0;
                            }
                        }

                        if (NgLineCount >= nonCoatingParam.WidthCount/*Para.NonCoatWidCount*/)
                        {
                            bResult = false;
                            //SaveErrInfo(Define.RESULT_CHIPPING, CopperW, 1, 1, DefectArea);
                            SaverErrorInfo();
                        }

                        if (bResult == false)
                        {
                            //m_Draw.DrawRect(DefectArea, Color.Red, 2, System.Drawing.Drawing2D.DashStyle.Solid, false);
                            break;
                        }

                    }

                    if (bResult == false)
                        break;
                }
            }
        }

        public void GetSharpness()
        {

        }

        public void SetCycleTime()
        {

        }

        public void SetBuffer(byte[] pBuff, int BuffW, int BuffH)
        {
            if (BuffW < 1 || BuffH < 1 || pBuff == null)
                return;

            //==================================================== 이미지 복사하기
            if (testInspParam.m_pImgBuff == null)
            {
                testInspParam.m_pImgBuff = new byte[BuffW * BuffH];
                testInspParam.m_pW = new double[BuffW];
                testInspParam.m_pTmpW1 = new double[BuffW];
                testInspParam.m_pTmpW2 = new double[BuffW];
                testInspParam.m_pDiffW = new double[BuffW];
                testInspParam.m_pProfileW = new double[BuffW];

                testInspParam.m_pH = new double[BuffH];
                testInspParam.m_pTmpH1 = new double[BuffH];
                testInspParam.m_pTmpH2 = new double[BuffH];
                testInspParam.m_pDiffH = new double[BuffH];
                testInspParam.m_pProfileH = new double[BuffH];
            }
            else
            {
                if (BuffW != testInspParam.m_ImgW || BuffH != testInspParam.m_ImgH)
                {
                    Array.Resize(ref testInspParam.m_pImgBuff, BuffW * BuffH);
                    Array.Resize(ref testInspParam.m_pW, BuffW);
                    Array.Resize(ref testInspParam.m_pTmpW1, BuffW);
                    Array.Resize(ref testInspParam.m_pTmpW2, BuffW);
                    Array.Resize(ref testInspParam.m_pDiffW, BuffW);
                    Array.Resize(ref testInspParam.m_pProfileW, BuffW);

                    Array.Resize(ref testInspParam.m_pH, BuffH);
                    Array.Resize(ref testInspParam.m_pTmpH1, BuffH);
                    Array.Resize(ref testInspParam.m_pTmpH2, BuffH);
                    Array.Resize(ref testInspParam.m_pDiffH, BuffH);
                    Array.Resize(ref testInspParam.m_pProfileH, BuffH);
                }
            }

            testInspParam.m_ImgW = BuffW;
            testInspParam.m_ImgH = BuffH;
            Buffer.BlockCopy(pBuff, 0, testInspParam.m_pImgBuff, 0, BuffW * BuffH);
        }

        public bool CheckCoatingWidth(DistanceResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null || distanceResult.IsValidScanWidth == false)
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

        public bool FindVerticalCoatingAreaEdges(ref DistanceResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null)
                return false;

            byte startReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, distanceResult.ScanStartX);
            byte endReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, distanceResult.ScanEndX);

            int coatingStartLocation = FindContinuousContrastLocation(distanceResult, startReferenceGrayLevel, imageData, imageWidth, imageHeight, pixelLength1mm, true);
            int coatingEndLocation = FindContinuousContrastLocation(distanceResult, endReferenceGrayLevel, imageData, imageWidth, imageHeight, pixelLength1mm, false);

            distanceResult.ScanStartX = coatingStartLocation > 0 ? coatingStartLocation : distanceResult.ScanStartX;
            distanceResult.ScanEndX = coatingStartLocation > 0 ? coatingEndLocation : distanceResult.ScanEndX;

            return distanceResult.IsValidScanWidth;
        }

        private int FindContinuousContrastLocation(DistanceResult distanceResult, byte referenceGrayLevel, byte[] imageData, int imageWidth, int imageHeight, double searchLength, bool searchForward)
        {
            bool isBackGroundWhite = referenceGrayLevel >= BackGroundGrayLevelCriteria;
            var searchRange = searchForward ?
                Enumerable.Range(distanceResult.ScanStartX, distanceResult.ScanEndX - distanceResult.ScanStartX) :
                Enumerable.Range(distanceResult.ScanStartX, distanceResult.ScanEndX - distanceResult.ScanStartX).Reverse();

            // Pixel이 연속된 지점 찾기
            int pixelStreak = 0, continousLocation = 0;
            foreach (int x in searchRange)
            {
                byte meanGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, x);
                bool hasContrast =
                    (isBackGroundWhite && meanGrayLevel <= referenceGrayLevel + ContrastOffsetDarker) ||
                    (!isBackGroundWhite && meanGrayLevel >= referenceGrayLevel + ContrastOffsetBrighter);

                if (hasContrast)        // 기준레벨값과 비교하여 대비가 있으면, 연속된 픽셀 개수 증가
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

        public double GetMeanSampledLevel(byte[] image, int width, int height, int horizontalOffset)
        {
            int sum = 0;
            int samplingCount = height / HeightSamplingScale;

            for (int row = 0; row < samplingCount; row++)
                sum += image[(row * HeightSamplingScale * width) + horizontalOffset];

            return sum / Math.Max(1, samplingCount);
        }

        private double GetMeanSampledLevel(byte[] image, int width, int verticalOffset)
        {
            int sum = 0;
            int samplingCount = width / WidthSamplingScale;

            for (int col = 0; col < samplingCount; col++)
                sum += image[(verticalOffset * width) + (col * WidthSamplingScale)];

            return sum / Math.Max(1, samplingCount);
        }

        public bool FindCoatingAreas(ref DistanceResult distanceResult, AppsInspModel model, byte[] imageData, int imageWidth, int imageHeight, int minimumFoilLength)
        {
            if (distanceResult == null)
                return false;

            int scanStartX = distanceResult.ScanStartX;
            int scanEndX = distanceResult.ScanEndX;
            int scanStartY = distanceResult.ScanStartY;
            int scanEndY = distanceResult.ScanEndY;
            int scanWidth = scanEndX - scanStartX;
            int scanHeight = scanEndY - scanStartY;

            if (distanceResult.IsValidScanWidth == false || scanWidth > imageWidth ||
                distanceResult.IsValidScanHeight == false || scanHeight > imageHeight)
                return false;   // Define.RESULT_IMAGE_PROCESS_FAIL;

            // 수직 샘플링
            List<byte> verticalSamplingResults = new List<byte>();
            for (int y = scanStartY; y < scanEndY; y++)
                verticalSamplingResults.Add((byte)GetMeanSampledLevel(imageData, imageWidth, y));
            distanceResult.VerticalSamplingResults = verticalSamplingResults;

            byte foilEdgeConstrast = (byte)(verticalSamplingResults.Max() - verticalSamplingResults.Min());
            bool isSlittingPouchCell = model.ProcessType == ProcessType.Slitting && model.ModelType == ModelType.Pouch;

            // Edge 대비가 기준치 이하 일때, 혹은 Slitting공정 Pouch 모델일 때 Foil 영역은 하나로 검사
            if (foilEdgeConstrast < CoatingEdgeConstrastCriteria || isSlittingPouchCell)
                distanceResult.CoatingAreas.Add(new Rectangle(scanStartX, scanStartY, scanWidth, scanHeight));
            // 여러 Foil 영역이 존재할 것으로 판단하고 영역 탐색
            else
            {
                byte foilThreshold = (byte)((verticalSamplingResults.Max() + verticalSamplingResults.Min()) / 2);
                bool foundTop = false, foundBottom = false;
                int top = 0, bottom = 0;

                for (int index = 0; index < verticalSamplingResults.Count; index++)
                {
                    bool isFoilArea = verticalSamplingResults[index] > foilThreshold;

                    if (foundTop && foundBottom)
                    {
                        int foilLength = bottom - top;
                        if (foilLength >= pixelLength1mm * minimumFoilLength && isFoilArea == false)    // 크기를 만족하고 영역이 끝나는 지점에서 영역 분할
                        {
                            distanceResult.CoatingAreas.Add(new Rectangle(scanStartX, top, scanWidth, bottom - top));
                            foundTop = foundBottom = false;
                        }
                    }

                    if (foundTop == false && isFoilArea == false)
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

                if (foundTop == true && foundBottom == false)    // 탐색 종료 시점에서 마지막 영역 처리
                    distanceResult.CoatingAreas.Add(new Rectangle(scanStartX, top, scanWidth, scanHeight - top));
            }

            // Foil 영역이 없거나 너무 많으면 실패 처리
            if (distanceResult.CoatingAreas.Count == 0 || distanceResult.CoatingAreas.Count >= CoatingAreaMaximumCount)
                return false; // Define.RESULT_ETC;

            // 제일 큰 영역은 처리 속도를 위해 별도 저장
            distanceResult.LargestCoatingArea = distanceResult.CoatingAreas.Aggregate((maxRect, nextRect) => (maxRect.Width * maxRect.Height >= nextRect.Width * nextRect.Height) ? maxRect : nextRect);

            return ShapeHelper.CheckValidRectangle(distanceResult.LargestCoatingArea, distanceResult.LargestCoatingArea.Width, distanceResult.LargestCoatingArea.Height);
        }

        public int GetCoatingLevel()
        {
            return 0;
        }

        public void GetCopperArea()
        {

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
