using Jastech.Battery.Structure.Data;
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

namespace Jastech.Battery.Structure.VisionTool
{
    public class AlgorithmTool
    {
        TestClass testClass = new TestClass();

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
            int Pix2mm = (int)(2.0 / 0.0423); //(int)(2.0 / m_CalibX);
            int CornerMargin = (int)(nonCoatingParam.CornerMargin / 0.0423);  //(int)(Para.CornerMargin / m_CalibY);

            double RefMin = nonCoatingParam.MinWidth; // Para.NonCoatMinW;
            double RefMax = nonCoatingParam.MaxWidth; // Para.NonCoatMaxW;

            DistanceParam distanceParam = new DistanceParam();

            bResult = true;
            for (int iCopper = 0; iCopper < distanceParam.CopperNum/*m_CopperNum*/; iCopper++)
            {
                x1 = (int)(m_pCopperInfo[iCopper].CopperStX / 0.0423/*m_CalibX*/);
                x2 = (int)(m_pCopperInfo[iCopper].CopperEndX / 0.0423/*m_CalibX*/);
                CopperW = x2 - x1;

                if (CopperW < 5)
                    continue;

                //===== 소형3동에서만 사용함 (Rewinder Slitter)
                m_NonCoatW = CopperW * 0.0423; // m_CalibX;

                cx = (x1 + x2) / 2;

                x1 -= Pix2mm;
                x2 += Pix2mm;
                if (x1 < 0)
                    x1 = 0;
                if (x2 >= width/*m_ImgW*/)
                    x2 = width; // m_ImgW - 1;

                for (int iVert = 0; iVert < m_VertCoatNum; iVert++)
                {
                    y1 = m_VertCoatArea[iVert].Top;
                    y2 = m_VertCoatArea[iVert].Bottom;

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

                        CopperW = (pos_r - pos_l) * 0.0423; // m_CalibX;

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

                        if (NgLineCount >= Para.NonCoatWidCount)
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

        public bool CheckNonCoating(Bitmap bmp, DistanceResult distanceResult)
        {
            byte[] imageData = ImageHelper.GetByteArrayFromBitmap(bmp);

            int width = bmp.Width;
            int height = bmp.Height;

            bool bResult = true;
            int x1 = distanceResult.FoilStartX; // m_FoilSt;
            int x2 = distanceResult.FoilEndX; // m_FoilEnd;

            int y1 = 0;
            int y2 = bmp.Height; // m_ImgH;

            int TotalCnt = 0;
            int BlackCnt = 0;
            int Ratio = 0;

            int CoatingCnt = 0;
            int Thresh = 179; // Para.NonCoatingLv;

            int xStep = (x2 - x1) / 500;
            int Pix10mm = (int)(10.0 / 0.0423/*m_CalibY*/);
            if (xStep < 1)
                xStep = 1;

            bResult = true;
            for (int j = y1; j < y2; j++)
            {
                TotalCnt = 0;
                BlackCnt = 0;
                for (int i = x1; i < x2; i += xStep)
                {
                    TotalCnt++;
                    if (imageData[j * width + i]/*m_pImgBuff[j * m_ImgW + i]*/ < Thresh)
                        BlackCnt++;
                }

                Ratio = BlackCnt * 100 / TotalCnt;
                if (Ratio >= 51 /*Para.NonCoatingRatio*/)
                {
                    CoatingCnt++;
                }
                else
                {
                    CoatingCnt = 0;
                }

                if (CoatingCnt >= Pix10mm)
                {
                    bResult = false;
                    break;
                }
            }
            return bResult;
        }

        public void SetBuffer(byte[] pBuff, int BuffW, int BuffH)
        {
            if (BuffW < 1 || BuffH < 1 || pBuff == null)
                return;

            //==================================================== 이미지 복사하기
            if (testClass.m_pImgBuff == null)
            {
                testClass.m_pImgBuff = new byte[BuffW * BuffH];
                testClass.m_pW = new double[BuffW];
                testClass.m_pTmpW1 = new double[BuffW];
                testClass.m_pTmpW2 = new double[BuffW];
                testClass.m_pDiffW = new double[BuffW];
                testClass.m_pProfileW = new double[BuffW];

                testClass.m_pH = new double[BuffH];
                testClass.m_pTmpH1 = new double[BuffH];
                testClass.m_pTmpH2 = new double[BuffH];
                testClass.m_pDiffH = new double[BuffH];
                testClass.m_pProfileH = new double[BuffH];
            }
            else
            {
                if (BuffW != testClass.m_ImgW || BuffH != testClass.m_ImgH)
                {
                    Array.Resize(ref testClass.m_pImgBuff, BuffW * BuffH);
                    Array.Resize(ref testClass.m_pW, BuffW);
                    Array.Resize(ref testClass.m_pTmpW1, BuffW);
                    Array.Resize(ref testClass.m_pTmpW2, BuffW);
                    Array.Resize(ref testClass.m_pDiffW, BuffW);
                    Array.Resize(ref testClass.m_pProfileW, BuffW);

                    Array.Resize(ref testClass.m_pH, BuffH);
                    Array.Resize(ref testClass.m_pTmpH1, BuffH);
                    Array.Resize(ref testClass.m_pTmpH2, BuffH);
                    Array.Resize(ref testClass.m_pDiffH, BuffH);
                    Array.Resize(ref testClass.m_pProfileH, BuffH);
                }
            }

            testClass.m_ImgW = BuffW;
            testClass.m_ImgH = BuffH;
            Buffer.BlockCopy(pBuff, 0, testClass.m_pImgBuff, 0, BuffW * BuffH);
        }

        public DistanceResult FindFoilEnd(Bitmap bmp, int scanMarginX1 = 200, int scanMarginX2 = 200/*byte[] imageData, int imageWidth, int imageHeight, int scanMarginX1, int scanMarginX2*/)
        {
            Stopwatch sw = Stopwatch.StartNew();
            byte[] imageData = ImageHelper.GetByteArrayFromBitmap(bmp);

            Console.WriteLine("Conv bitmap to byte array : " + sw.ElapsedMilliseconds);
            sw.Restart();
            /////////////////////////////////////////////////////////////////////////////

            DistanceResult distanceResult = new DistanceResult();

            int width = bmp.Width;
            int height = bmp.Height;

            //bool IsWhiteBackGround = false;
            int i = 0, j = 0;

            int Sum = 0, Cnt = 0, Avg = 0;
            int FoilSt = -1, FoilEnd = -1;

            int x1 = scanMarginX1; //Config.ScanMarginX1;
            int x2 = width - scanMarginX2; //m_ImgW - Config.ScanMarginX2;

            int Pix1mm = (int)(1.0 / 0.0423); //(int)(1.0 / m_CalibX);

            int FoilLv = 20; //Para.FoilLv[m_ModuleNo];

            int CompStep = 2; // Config.EdgeCompSizeWid;
            int jStep = height / 200; // m_ImgH / 200;

            int FindCount = 0;
            bool bFind = false;

            //======================================================== Roller Start
            FoilSt = -1;
            i = x1;
            Sum = 0;
            Cnt = 0;
            for (j = 0; j < height; /*m_ImgH;*/ j += jStep)
            {
                Sum += imageData[j * width + i]; //m_pImgBuff[j * m_ImgW + i];
                Cnt++;
            }
            if (Cnt < 1)
                Cnt = 1;

            Avg = Sum / Cnt;

            if (Avg <= 100)
            {   // Black Back Ground
                FoilLv = Avg + 20; // Para.FoilLv[m_ModuleNo];
                distanceResult.IsWhiteBackGround = false;
            }
            else
            {             // White Back Ground
                FoilLv = Avg - 20; // Para.FoilLv[m_ModuleNo];
                distanceResult.IsWhiteBackGround = true;
            }

            //====== 얻은값을 저장해 놓는다.
            //Config.bWhiteBackGround = IsWhiteBackGround;

            bFind = false;
            for (i = x1; i < x2; i++)
            {
                Sum = 0;
                Cnt = 0;
                for (j = 0; j < height; /*m_ImgH;*/ j += jStep)
                {
                    Sum += imageData[j * width + i]; //m_pImgBuff[j * m_ImgW + i];
                    Cnt++;
                }
                if (Cnt < 1)
                    Cnt = 1;

                Avg = Sum / Cnt;

                if (distanceResult.IsWhiteBackGround == true)
                { //===== White Back Ground
                    if (Avg <= FoilLv)
                    {
                        if (FindCount == 0)
                            FoilSt = i;

                        FindCount++;
                        if (FindCount >= Pix1mm)
                        {
                            bFind = true;
                            break;
                        }
                    }
                    else
                    {
                        FindCount = 0;
                    }
                }
                else
                {  //========================== Black Back Ground (Default)
                    if (Avg >= FoilLv)
                    {
                        if (FindCount == 0)
                            FoilSt = i;

                        FindCount++;
                        if (FindCount >= Pix1mm)
                        {
                            bFind = true;
                            break;
                        }
                    }
                    else
                    {
                        FindCount = 0;
                    }
                }
            }


            if (bFind == false)
            {
                FoilSt = x1;
            }

            //========================================================== Roller End
            i = x2;
            Sum = 0;
            Cnt = 0;
            for (j = 0; j < height;  /*m_ImgH;*/ j += jStep)
            {
                Sum += imageData[j * width + i];//m_pImgBuff[j * m_ImgW + i];
                Cnt++;
            }
            if (Cnt < 1) Cnt = 1;
            Avg = Sum / Cnt;

            if (Avg <= 100)
            {   // Black Back Ground
                FoilLv = Avg + 20; // Para.FoilLv[m_ModuleNo];
                distanceResult.IsWhiteBackGround = false;
            }
            else
            {             // White Back Ground
                FoilLv = Avg - 20; // Para.FoilLv[m_ModuleNo];
                distanceResult.IsWhiteBackGround = true;
            }

            FoilEnd = -1;
            bFind = false;
            FindCount = 0;
            for (i = x2; i > x1; i--)
            {
                Sum = 0;
                Cnt = 0;
                for (j = 0; j < height; /*m_ImgH;*/ j += jStep)
                {
                    Sum += imageData[j + width + i]; // m_pImgBuff[j * m_ImgW + i];
                    Cnt++;
                }

                if (Cnt < 1)
                    Cnt = 1;
                Avg = Sum / Cnt;

                if (distanceResult.IsWhiteBackGround == true)
                {
                    if (Avg <= FoilLv)
                    {
                        if (FindCount == 0)
                            FoilEnd = i;

                        FindCount++;
                        if (FindCount >= Pix1mm)
                        {
                            bFind = true;
                            break;
                        }
                    }
                    else
                    {
                        FindCount = 0;
                    }
                }
                else
                {
                    if (Avg >= FoilLv)
                    {
                        if (FindCount == 0)
                            FoilEnd = i;

                        FindCount++;
                        if (FindCount >= Pix1mm)
                        {
                            bFind = true;
                            break;
                        }
                    }
                    else
                    {
                        FindCount = 0;
                    }
                }

            }
            if (bFind == false)
            {
                FoilEnd = x2;
            }

            if (FoilSt >= 0)
                //m_FoilSt = FoilSt;
                distanceResult.FoilStartX = FoilSt;
            else
                //m_FoilSt = x1;
                distanceResult.FoilStartX = x1;

            if (FoilEnd >= 0)
                //m_FoilEnd = FoilEnd;
                distanceResult.FoilEndX = FoilEnd;
            else
                //m_FoilEnd = x2;
                distanceResult.FoilEndX = x2;

            /*
            m_Draw.DrawLine(x1, 0, x1, m_ImgH, Color.Yellow, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            m_Draw.DrawLine(x2, 0, x2, m_ImgH, Color.Yellow, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);


            x1 = (int)(m_FoilSt - 10 / Config.Zoom[m_ModuleNo]);
            x2 = (int)(m_FoilEnd + 10 / Config.Zoom[m_ModuleNo]);
            y1 = 1 * m_ImgH / 3;
            y2 = 2 * m_ImgH / 3;
            m_Draw.DrawLine(x1, y1, x1, y2, Color.Aqua, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            m_Draw.DrawLine(x2, y1, x2, y2, Color.Aqua, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            */

            return distanceResult; // Define.RESULT_OK;
        }

        public DistanceResult FindFoilEnd_WithTeachingArea(Bitmap bmp, int scanMarginX1 = 200, int scanMarginX2 = 200)
        {
            DistanceResult distanceResult = new DistanceResult();

            int FoilSt = -1, FoilEnd = -1;
            int y1 = 0, y2 = 0, x1 = 0, x2 = 0;

            int EdgeLv = 39; //Para.CoatEdgeLv[m_ModuleNo];
            int CoatLv = 99; // Para.CoatLv[m_ModuleNo];

            int CompSize = 2; // Config.EdgeCompSizeWid;

            //===== 검사 한계선 측정
            x1 = scanMarginX1; // Config.ScanMarginX1;
            x2 = bmp.Width - scanMarginX2; // m_ImgW - Config.ScanMarginX2;

            //m_Draw.DrawLine(x1, 0, x1, m_ImgH, Color.Yellow, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            //m_Draw.DrawLine(x2, 0, x2, m_ImgH, Color.Yellow, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);

            FoilSt = x1;
            FoilEnd = x2;

            y1 = 1 * bmp.Height/*m_ImgH*/ / 3;
            y2 = 2 * bmp.Height/*m_ImgH*/ / 3;

            if (FoilSt > 0)
            {
                //m_Draw.DrawLine(FoilSt, y1, FoilSt, y2, Color.Aqua, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            }

            if (FoilEnd > 0)
            {
                //m_Draw.DrawLine(FoilEnd, y1, FoilEnd, y2, Color.Aqua, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            }


            if (FoilSt < 0 || FoilEnd < 0)
            {
                //return Define.RESULT_IMAGE_PROCESS_FAIL;
                return distanceResult = null;
            }

            distanceResult.FoilStartX = FoilSt; //m_FoilSt = FoilSt;
            distanceResult.FoilEndX = FoilEnd; //m_FoilEnd = FoilEnd;


            //return Define.RESULT_OK;
            return distanceResult;
        }

        public int FindCoatingArea_Vertical(Bitmap bmp, DistanceResult distanceResult, int verticalCoatingMaxCount = 5, double zoom = 0.08825)
        {
            //int verticalCoatingMaxCount = AppsConfig.Instance().VERTICAL_COATING_MAX_COUNT;
            //double zoom = AppsConfig.Instance().VERTICAL_COATING_MAX_COUNT;

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

            int CopperLv = 99; // Para.CoatLv[m_ModuleNo];
            int CompSize = 3; // Config.EdgeCompSizeLen;
            int EdgeLv = 39; // Para.CoatEdgeLv[m_ModuleNo];

            int Pix5mm = (int)(5.0 / 0.0423/*m_CalibY*/);

            int foilStartX = distanceResult.FoilStartX; // m_FoilSt;
            int foilEndX = distanceResult.FoilEndX; // m_FoilEnd;
            int y1 = 0;
            int imageHeight = bmp.Height; // m_ImgH;

            int width = bmp.Width;

            int xStep = (foilEndX - foilStartX) / 300;   // 시간단축 위해서 300 Point만 계산함.
            if (xStep < 1) xStep = 1;

            if (foilStartX < 0 || foilStartX > width/*m_ImgW*/ || foilEndX < 0 || foilEndX > width/*m_ImgW*/)
                return 29;// Define.RESULT_IMAGE_PROCESS_FAIL;

            Array.Clear(testClass.m_pH, 0, testClass.m_ImgH);

            //======================================================= 수직방향 프로파일 얻기
            for (int j = 0; j < testClass.m_ImgH; j++)
            {
                sum = 0;
                count = 0;
                for (int i = foilStartX; i < foilEndX; i += xStep)
                {
                    sum += testClass.m_pImgBuff[j * testClass.m_ImgW + i];
                    count++;
                }
                if (count < 1) count = 1;
                testClass.m_pH[j] = sum / count;
            }

            //======================================================= 프로파일에서 최소값, 최대값을 찾는다.
            maxLevel = 0.0;
            minLevel = 255;
            for (int j = 0; j < testClass.m_ImgH; j++)
            {
                if (testClass.m_pH[j] <= 0)
                    continue;

                if (j < 5 || j > testClass.m_ImgH - 5)   // 위,아래 마진을 두고 계산한다.
                    continue;

                if (testClass.m_pH[j] < minLevel) minLevel = testClass.m_pH[j];
                if (testClass.m_pH[j] > maxLevel) maxLevel = testClass.m_pH[j];
            }

            diffLevel = (int)(maxLevel - minLevel);

            if (diffLevel < EdgeLv)
            {         
                // 밝기의 변화가 생기는 엣지를 못 찾았을 경우
                testClass.m_VertCoatNum = 1;
                testClass.m_VertCoatArea[0].X = foilStartX;
                testClass.m_VertCoatArea[0].Y = 0;
                testClass.m_VertCoatArea[0].Width = foilEndX - foilStartX;
                testClass.m_VertCoatArea[0].Height = testClass.m_ImgH;
                testClass.m_MaxVertCoatArea = testClass.m_VertCoatArea[0];
            }
            else
            {
                //====================================================== 엣지 부분이 발견이 됐다면 코팅 부분을 찾음
                threshold = (int)(minLevel + maxLevel) / 2;

                start = -1;
                end = -1;
                coatingCount = 0;
                for (int j = 0; j < testClass.m_ImgH; j++)
                {
                    if (start < 0 && testClass.m_pH[j] <= threshold)
                        start = j;   // 코팅 시작 부분 찾기
                    if (start < 0)
                        continue;

                    if (end < 0 && testClass.m_pH[j] > threshold)
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
                        testClass.m_VertCoatArea[coatingCount].X = foilStartX;
                        testClass.m_VertCoatArea[coatingCount].Width = foilEndX - foilStartX;
                        testClass.m_VertCoatArea[coatingCount].Y = start;
                        testClass.m_VertCoatArea[coatingCount].Height = end - start;
                        coatingCount++;
                    }

                    start = -1;
                    end = -1;
                }

                if (start >= 0 && end < 0)
                {
                    end = testClass.m_ImgH;

                    if (coatingCount < verticalCoatingMaxCount)
                    {
                        testClass.m_VertCoatArea[coatingCount].X = foilStartX;
                        testClass.m_VertCoatArea[coatingCount].Width = foilEndX - foilStartX;
                        testClass.m_VertCoatArea[coatingCount].Y = start;
                        testClass.m_VertCoatArea[coatingCount].Height = end - start;
                        coatingCount++;
                    }
                }

                testClass.m_VertCoatNum = coatingCount;
            }

            //===== 예외 처리
            if (testClass.m_VertCoatNum < 1 || testClass.m_VertCoatNum >= verticalCoatingMaxCount)
            {
                return 33; // Define.RESULT_ETC;
            }

            //==================================== 찾아낸 영역 중 가장 큰 영역을 얻는다.
            unitMaxHeight = 0;
            for (int iCoat = 0; iCoat < testClass.m_VertCoatNum; iCoat++)
            {
                unitHeight = testClass.m_VertCoatArea[iCoat].Height;
                if (unitHeight > unitMaxHeight)
                {
                    unitMaxHeight = unitHeight;
                    testClass.m_MaxVertCoatArea = testClass.m_VertCoatArea[iCoat];
                }
            }

            foilStartX = testClass.m_MaxVertCoatArea.X - (int)(30 / zoom/*Config.Zoom[m_ModuleNo]*/);
            foilEndX = testClass.m_MaxVertCoatArea.X;
            y1 = testClass.m_MaxVertCoatArea.Y;
            imageHeight = testClass.m_MaxVertCoatArea.Y + testClass.m_MaxVertCoatArea.Height;

            //m_Draw.DrawLine(foilStartX, y1, foilEndX, y1, Color.Red, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);
            //m_Draw.DrawLine(foilStartX, imageHeight, foilEndX, imageHeight, Color.Red, 3, System.Drawing.Drawing2D.DashStyle.Solid, false);

            //=================================== 파우치인지.. 패턴타입인지 파악한다 (PLC로부터 어떤 정보도 받지 못했을 경우에만 실행됨)
            DistanceParam distanceParam = new DistanceParam();
            
            if (distanceParam.ModelType == ModelType.None/*Global.ModelType == 0*/)
            {
                if (distanceParam.FrameCountTotal < distanceParam.FRAME_COUNT_TOTAL /*m_FrameCountTotal < 30*/)
                {
                    int DiffT = testClass.m_MaxVertCoatArea.Y;
                    int DiffB = testClass.m_ImgH - testClass.m_MaxVertCoatArea.Bottom;

                    if (DiffT < 10 && DiffB < 10)
                    {
                        // Pouch타입이다.
                        distanceParam.FrameCountPouch++; // m_FrameCountPouch++;

                        if (distanceParam.FrameCountPouch >= distanceParam.FRAME_COUNT_POUCH/*m_FrameCountPouch >= 5*/)
                        {
                            //Global.ModelType = Define.MODEL_POUCH;
                            distanceParam.ModelType = ModelType.Pouch;
                        }
                    }
                    else
                    {
                        //m_FrameCountPouch = 0;
                        distanceParam.FrameCountPouch = 0;
                    }

                    //m_FrameCountTotal++;
                    distanceParam.FrameCountTotal++;
                }
                else
                {
                    // 30Frame이 지나는 동안 Pouch로 판정할 만한 근거가 없으면 Pattern모델로 인식한다.
                    //Global.ModelType = Define.MODEL_PATTERN;
                    distanceParam.ModelType = ModelType.Pattern;
                }
            }
            else if (distanceParam.ModelType == ModelType.Pouch/*Global.ModelType == Define.MODEL_POUCH*/)
            {
                if (AppsConfig.Instance().ProgramType)
                //===== 파우치일 경우에는 Y방향으로 영역이 여러개 나올수가 없음 (중간에 테이핑 영역을 불량으로 찾기 위해서 필요함, 슬리터에서만 필요함)
                if (Config.VisionType == Define.VISION_SLITTER)
                {
                    foilStartX = testClass.m_VertCoatArea[0].Left;
                    foilEndX = testClass.m_VertCoatArea[0].Right;
                    y1 = testClass.m_VertCoatArea[0].Top;
                    imageHeight = testClass.m_VertCoatArea[testClass.m_VertCoatNum - 1].Bottom;

                    //===== 완전한 코팅 상태일 경우에는 전체 영역임 (테이핑 영역이 이미지의 맨위, 맨 아래에 있는 경우 검사 영역에서 빠지는 걸 막기 위해서)
                    if (m_CoatingCount > 0)
                    {
                        y1 = 0;
                        imageHeight = testClass.m_ImgH;
                    }

                    testClass.m_VertCoatArea[0].Y = y1;
                    testClass.m_VertCoatArea[0].Height = imageHeight - y1;
                    testClass.m_VertCoatNum = 1;
                }
            }

            return 0; // Define.RESULT_OK;

            return result;
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
