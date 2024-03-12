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
        public const int MAX_COPPER_NUM = 10;

        // 확인 필요
        double zoom = 0.08825; //Config.Zoom[m_ModuleNo]

        // 아마 Teaching, Model
        public int foilExistanceCriteria = 70;
        public int foilExistanceThreshold = 179;
        public int contrastOffsetBrighter = 20;
        public int contrastOffsetDarker = -20;
        public int brightBackGroundGrayLevelCriteria = 100;
        public int widthDenominator = 300;
        public int heightDenominator = 200;

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

        public bool CheckFoilExistance(DistanceResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null)
                return false;
            else if (distanceResult.FoilStartX < distanceResult.FoilEndX && distanceResult.FoilStartX > 0 && distanceResult.FoilEndX > 0)
                return false;

            int foilWidth = distanceResult.FoilEndX - distanceResult.FoilStartX;
            int horizontalSpacing = Math.Max(1, foilWidth / widthDenominator);
            int slicedAreaCount = foilWidth / horizontalSpacing;

            for (int y = 0, length = 0; y < imageHeight; y++)
            {
                int coveredAreaCount = 0;
                for (int x = distanceResult.FoilStartX; x < distanceResult.FoilEndX; x += horizontalSpacing)
                {
                    if (imageData[y * imageWidth + x] < foilExistanceThreshold)
                        coveredAreaCount++;
                }

                double coveringPercentage = slicedAreaCount / coveredAreaCount * 100;
                if (coveringPercentage < foilExistanceCriteria)
                    length = 0;
                else if (++length >= pixelLength1mm * 10)
                    return true;
            }

            return false;
        }

        public bool FindVerticalFoilEdge(ref DistanceResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            int verticalSpacing = imageHeight / heightDenominator;

            int foilStartReferenceGrayLevel = (int)GetMeanGrayLevel(imageData, imageWidth, imageHeight, verticalSpacing, distanceResult.FoilStartX);
            int foilEndReferenceGrayLevel = (int)GetMeanGrayLevel(imageData, imageWidth, imageHeight, verticalSpacing, distanceResult.FoilEndX);

            int foilStartLocation = FindContinuousContrastLocation(distanceResult, foilStartReferenceGrayLevel, imageData, imageWidth, imageHeight, true);
            int foilEndLocation = FindContinuousContrastLocation(distanceResult, foilEndReferenceGrayLevel, imageData, imageWidth, imageHeight, false);

            distanceResult.FoilStartX = foilStartLocation > 0 ? foilStartLocation : distanceResult.FoilStartX;
            distanceResult.FoilEndX = foilStartLocation > 0 ? foilEndLocation : distanceResult.FoilEndX;

            bool isValidArea = distanceResult.FoilStartX < distanceResult.FoilEndX && distanceResult.FoilStartX > 0 && distanceResult.FoilEndX > 0;
            return isValidArea;
        }

        private int FindContinuousContrastLocation(DistanceResult distanceResult, int referenceGrayLevel, byte[] imageData, int imageWidth, int imageHeight, bool searchForward)
        {
            // Pixel이 연속된 지점 찾기
            int verticalSpacing = imageHeight / heightDenominator;
            bool isBackGroundWhite = referenceGrayLevel >= brightBackGroundGrayLevelCriteria;
            var range = searchForward ?
                Enumerable.Range(distanceResult.FoilStartX, distanceResult.FoilEndX - distanceResult.FoilStartX) :
                Enumerable.Range(distanceResult.FoilStartX, distanceResult.FoilEndX - distanceResult.FoilStartX).Reverse();

            int pixelStreak = 0, continousLocation = 0;
            foreach (int x in range)
            {
                int meanGrayLevel = (int)GetMeanGrayLevel(imageData, imageWidth, imageHeight, verticalSpacing, x);
                bool hasContrast =
                    (isBackGroundWhite && meanGrayLevel <= referenceGrayLevel + contrastOffsetDarker) ||
                    (!isBackGroundWhite && meanGrayLevel >= referenceGrayLevel + contrastOffsetBrighter);

                if (hasContrast)
                {
                    if (pixelStreak++ == 0)
                        continousLocation = x;
                    else if (pixelStreak >= pixelLength1mm)
                        return continousLocation;
                }
                else
                    pixelStreak = 0;
            }

            return -1;
        }

        private double GetMeanGrayLevel(byte[] image, int width, int height, int verticalSpacing, int horizontalOffset)
        {
            int sum, row;
            for (sum = 0, row = 0; row < height / verticalSpacing; row++)
                sum += image[row * width + horizontalOffset];
            return sum / Math.Max(1, row);
        }

        public int FindCoatingArea_Vertical(Bitmap bmp, DistanceResult distanceResult, int verticalCoatingMaxCount = 5)
        {
            int result = 0;

            int sum = 0;
            int count = 0;

            int start = -1;
            int end = -1;

            int unitHeight = 0;
            int unitMaxHeight = 0;

            double maxLevel = 0, minLevel = 0;
            int diffLevel = 0;
            int threshold = 0;

            int coatingCount = 0;
            int EdgeLv = 39; // Para.CoatEdgeLv[m_ModuleNo];

            int foilStartX = distanceResult.FoilStartX; // m_FoilSt;
            int foilEndX = distanceResult.FoilEndX; // m_FoilEnd;
            int y1 = 0;

            int imageWidth = bmp.Width;
            int imageHeight = bmp.Height; // m_ImgH;

            int foilWidth = foilEndX - foilStartX;
            int horizontalSpacing = Math.Max(1, foilWidth / widthDenominator);

            if (foilStartX < 0 || foilStartX > imageWidth/*m_ImgW*/ || foilEndX < 0 || foilEndX > imageWidth/*m_ImgW*/)
                return 29;// Define.RESULT_IMAGE_PROCESS_FAIL;

            Array.Clear(testInspParam.m_pH, 0, testInspParam.m_ImgH);

            //======================================================= 수직방향 프로파일 얻기
            for (int j = 0; j < testInspParam.m_ImgH; j++)
            {
                sum = 0;
                count = 0;
                for (int i = foilStartX; i < foilEndX; i += horizontalSpacing)
                {
                    sum += testInspParam.m_pImgBuff[j * testInspParam.m_ImgW + i];
                    count++;
                }
                if (count < 1) count = 1;
                testInspParam.m_pH[j] = sum / count;
            }

            //======================================================= 프로파일에서 최소값, 최대값을 찾는다.
            maxLevel = 0.0;
            minLevel = 255;
            for (int j = 0; j < testInspParam.m_ImgH; j++)
            {
                if (testInspParam.m_pH[j] <= 0)
                    continue;

                if (j < 5 || j > testInspParam.m_ImgH - 5)   // 위,아래 마진을 두고 계산한다.
                    continue;

                if (testInspParam.m_pH[j] < minLevel) minLevel = testInspParam.m_pH[j];
                if (testInspParam.m_pH[j] > maxLevel) maxLevel = testInspParam.m_pH[j];
            }

            diffLevel = (int)(maxLevel - minLevel);

            if (diffLevel < EdgeLv)
            {
                // 밝기의 변화가 생기는 엣지를 못 찾았을 경우
                testInspParam.coatingRowCount = 1;
                testInspParam.verticalCoatArea[0].X = foilStartX;
                testInspParam.verticalCoatArea[0].Y = 0;
                testInspParam.verticalCoatArea[0].Width = foilEndX - foilStartX;
                testInspParam.verticalCoatArea[0].Height = testInspParam.m_ImgH;
                testInspParam.m_MaxVertCoatArea = testInspParam.verticalCoatArea[0];
            }
            else
            {
                //====================================================== 엣지 부분이 발견이 됐다면 코팅 부분을 찾음
                threshold = (int)(minLevel + maxLevel) / 2;

                start = -1;
                end = -1;
                coatingCount = 0;
                for (int j = 0; j < testInspParam.m_ImgH; j++)
                {
                    if (start < 0 && testInspParam.m_pH[j] <= threshold)
                        start = j;   // 코팅 시작 부분 찾기
                    if (start < 0)
                        continue;

                    if (end < 0 && testInspParam.m_pH[j] > threshold)
                        end = j;
                    if (end < 0)
                        continue;

                    //----- 찾아낸 코팅 길이가 100픽셀이 안되면 패스..
                    if (start >= 0 && end >= 0)
                    {
                        int CoatLen = end - start;
                        if (CoatLen < 100)
                        {
                            start = -1;
                            end = -1;
                            continue;
                        }
                    }

                    if (coatingCount < verticalCoatingMaxCount)
                    {
                        testInspParam.verticalCoatArea[coatingCount].X = foilStartX;
                        testInspParam.verticalCoatArea[coatingCount].Width = foilEndX - foilStartX;
                        testInspParam.verticalCoatArea[coatingCount].Y = start;
                        testInspParam.verticalCoatArea[coatingCount].Height = end - start;
                        coatingCount++;
                    }

                    start = -1;
                    end = -1;
                }

                if (start >= 0 && end < 0)
                {
                    end = testInspParam.m_ImgH;

                    if (coatingCount < verticalCoatingMaxCount)
                    {
                        testInspParam.verticalCoatArea[coatingCount].X = foilStartX;
                        testInspParam.verticalCoatArea[coatingCount].Width = foilEndX - foilStartX;
                        testInspParam.verticalCoatArea[coatingCount].Y = start;
                        testInspParam.verticalCoatArea[coatingCount].Height = end - start;
                        coatingCount++;
                    }
                }

                testInspParam.coatingRowCount = coatingCount;
            }

            //===== 예외 처리
            if (testInspParam.coatingRowCount < 1 || testInspParam.coatingRowCount >= verticalCoatingMaxCount)
            {
                return 33; // Define.RESULT_ETC;
            }

            //==================================== 찾아낸 영역 중 가장 큰 영역을 얻는다.
            unitMaxHeight = 0;
            for (int iCoat = 0; iCoat < testInspParam.coatingRowCount; iCoat++)
            {
                unitHeight = testInspParam.verticalCoatArea[iCoat].Height;
                if (unitHeight > unitMaxHeight)
                {
                    unitMaxHeight = unitHeight;
                    testInspParam.m_MaxVertCoatArea = testInspParam.verticalCoatArea[iCoat];
                }
            }

            foilStartX = testInspParam.m_MaxVertCoatArea.X - (int)(30 / zoom);
            foilEndX = testInspParam.m_MaxVertCoatArea.X;
            y1 = testInspParam.m_MaxVertCoatArea.Y;
            imageHeight = testInspParam.m_MaxVertCoatArea.Y + testInspParam.m_MaxVertCoatArea.Height;

            return 0; // Define.RESULT_OK;

            return result;
        }

        public void IdentifyModelType(int imageWidth,  int imageHeight, DistanceResult distanceResult)
        {
            //=================================== 파우치인지.. 패턴타입인지 파악한다 (PLC로부터 어떤 정보도 받지 못했을 경우에만 실행됨)
            //DistanceParam distanceParam = new DistanceParam();

            //if (distanceParam.ModelType == ModelType.None/*Global.ModelType == 0*/)
            //{
            //    if (distanceParam.FrameCountTotal < distanceParam.FRAME_COUNT_TOTAL /*m_FrameCountTotal < 30*/)
            //    {
            //        int DiffT = testInspParam.m_MaxVertCoatArea.Y;
            //        int DiffB = testInspParam.m_ImgH - testInspParam.m_MaxVertCoatArea.Bottom;

            //        if (DiffT < 10 && DiffB < 10)
            //        {
            //            // Pouch타입이다.
            //            distanceParam.FrameCountPouch++; // m_FrameCountPouch++;

            //            if (distanceParam.FrameCountPouch >= distanceParam.FRAME_COUNT_POUCH/*m_FrameCountPouch >= 5*/)
            //            {
            //                //Global.ModelType = Define.MODEL_POUCH;
            //                distanceParam.ModelType = ModelType.Pouch;
            //            }
            //        }
            //        else
            //        {
            //            //m_FrameCountPouch = 0;
            //            distanceParam.FrameCountPouch = 0;
            //        }

            //        //m_FrameCountTotal++;
            //        distanceParam.FrameCountTotal++;
            //    }
            //    else
            //    {
            //        // 30Frame이 지나는 동안 Pouch로 판정할 만한 근거가 없으면 Pattern모델로 인식한다.
            //        //Global.ModelType = Define.MODEL_PATTERN;
            //        distanceParam.ModelType = ModelType.Pattern;
            //    }
            //}
            //else if (distanceParam.ModelType == ModelType.Pouch/*Global.ModelType == Define.MODEL_POUCH*/)
            //{
            //    //if (AppsConfig.Instance().ProcessType) 종속성 때문에 상호참조 안됨. /*if (Config.VisionType == Define.VISION_SLITTER)*/
            //    //===== 파우치일 경우에는 Y방향으로 영역이 여러개 나올수가 없음 (중간에 테이핑 영역을 불량으로 찾기 위해서 필요함, 슬리터에서만 필요함)
            //    {
            //        foilStartX = testInspParam.verticalCoatArea[0].Left;
            //        foilEndX = testInspParam.verticalCoatArea[0].Right;
            //        y1 = testInspParam.verticalCoatArea[0].Top;
            //        imageHeight = testInspParam.verticalCoatArea[testInspParam.coatingRowCount - 1].Bottom;

            //        //===== 완전한 코팅 상태일 경우에는 전체 영역임 (테이핑 영역이 이미지의 맨위, 맨 아래에 있는 경우 검사 영역에서 빠지는 걸 막기 위해서)
            //        if (testInspParam.coatingRowCount/*m_CoatingCount*/ > 0)
            //        {
            //            y1 = 0;
            //            imageHeight = testInspParam.m_ImgH;
            //        }

            //        testInspParam.verticalCoatArea[0].Y = y1;
            //        testInspParam.verticalCoatArea[0].Height = imageHeight - y1;
            //        testInspParam.coatingRowCount = 1;
            //    }
            //}
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
