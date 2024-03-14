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

        // 확인 필요
        double zoom = 0.08825; //Config.Zoom[m_ModuleNo]

        // 아마 Teaching, Model
        public int CoatingMinimumLength = 10;
        public int CoatingAreaMaximumCount = 5;
        public sbyte ContrastOffsetBrighter = 20;
        public sbyte ContrastOffsetDarker = -20;
        public byte CoatingExistanceThreshold = 179;
        public byte CoatingExistanceCriteria = 70;
        public byte CoatingEdgeConstrastThreshold = 39; // Para.CoatEdgeLv[m_ModuleNo];
        public byte BackGroundGrayLevelCriteria = 100;

        public double CoatingAreaInflationScale = 5.0;       // NonCoating 영역 탐색 시 CoatingArea 확장에 사용됨

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

        public void CoatingArea_LineBlack(SurfaceParam param)
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

        public void CheckNonCoatingWidth(Bitmap bmp , DistanceInspResult distanceResult)
        {
            SurfaceParam SurfaceParam = new SurfaceParam();

            if (SurfaceParam.CheckNonCoatingWidth == false) //if (Para.bCheckNonCoatW == false)
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

            double RefMin = SurfaceParam.MinWidth; // Para.NonCoatMinW;
            double RefMax = SurfaceParam.MaxWidth; // Para.NonCoatMaxW;

            DistanceParam distanceParam = new DistanceParam();

            bResult = true;
            for (int iCopper = 0; iCopper < distanceResult.NonCoatingAreas.Count; iCopper++)
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
                if (x2 >= width/*imageWidth*/)
                    x2 = width; // imageWidth - 1;

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
                            //val = imageData[j * imageWidth + i + CompSize] - imageData[j * imageWidth + i - CompSize];
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
                            //val = imageData[j * imageWidth + i - CompSize] - imageData[j * imageWidth + i + CompSize];
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

                        if (NgLineCount >= SurfaceParam.WidthCount/*Para.NonCoatWidCount*/)
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

        public bool CheckCoatingWidth(DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            if (distanceResult == null || distanceResult.IsValidScanWidth() == false)
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
            if (distanceResult == null)
                return false;

            byte startReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, distanceResult.ScanStartX);
            byte endReferenceGrayLevel = (byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, distanceResult.ScanEndX);

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

        public bool FindCoatingAreas(ref DistanceInspResult distanceResult, AppsInspModel model, byte[] imageData, int imageWidth, int imageHeight, int minimumFoilLength)
        {
            if (distanceResult == null)
                return false;

            int scanStartX = distanceResult.ScanStartX;
            int scanEndX = distanceResult.ScanEndX;
            int scanStartY = distanceResult.ScanStartY;
            int scanEndY = distanceResult.ScanEndY;
            int scanWidth = scanEndX - scanStartX;
            int scanHeight = scanEndY - scanStartY;

            if (distanceResult.IsValidScanWidth() == false || scanWidth > imageWidth ||
                distanceResult.IsValidScanHeight() == false || scanHeight > imageHeight)
                return false;   // Define.RESULT_IMAGE_PROCESS_FAIL;

            // 수직 샘플링
            var verticalSamplingResults = distanceResult.VerticalSamplingResults;
            verticalSamplingResults.Clear();
            for (int y = scanStartY; y < scanEndY; y++)
                verticalSamplingResults.Add((byte)GetMeanSampledLevel(imageData, imageWidth, y));

            byte foilEdgeConstrast = (byte)(verticalSamplingResults.Max() - verticalSamplingResults.Min());
            bool isSlittingPouchCell = model.ProcessType == ProcessType.Slitting && model.ModelType == ModelType.Pouch;

            var coatingAreas = distanceResult.CoatingAreas;
            coatingAreas.Clear();
            // Edge 대비가 기준치 이하 일때, 혹은 Slitting공정 Pouch 모델일 때 Foil 영역은 하나로 검사
            if (foilEdgeConstrast < CoatingEdgeConstrastThreshold || isSlittingPouchCell)
                coatingAreas.Add(new Rectangle(scanStartX, scanStartY, scanWidth, scanHeight));
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
                            coatingAreas.Add(new Rectangle(scanStartX, top, scanWidth, bottom - top));
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
                    coatingAreas.Add(new Rectangle(scanStartX, top, scanWidth, scanHeight - top));
            }

            // Foil 영역이 없거나 너무 많으면 실패 처리
            if (coatingAreas.Count == 0 || coatingAreas.Count >= CoatingAreaMaximumCount)
                return false; // Define.RESULT_ETC;

            // 제일 큰 영역은 처리 속도를 위해 별도 저장
            distanceResult.UpdateLargestCoatingArea();

            return ShapeHelper.CheckValidRectangle(distanceResult.LargestCoatingArea, distanceResult.LargestCoatingArea.Width, distanceResult.LargestCoatingArea.Height);
        }

        public void FindInsulatorAreas(ref DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {

        }

        public void FindNonCoatingAreas(ref DistanceInspResult distanceResult, byte[] imageData, int imageWidth, int imageHeight)
        {
            Rectangle searchArea = new Rectangle(distanceResult.LargestCoatingArea.Location, distanceResult.LargestCoatingArea.Size);
            searchArea.Inflate((int)(pixelLength1mm * CoatingAreaInflationScale), 0);

            searchArea = ShapeHelper.GetValidRectangle(searchArea, imageWidth, imageHeight);

            // 수평 샘플링 결과 저장
            var horizontalSamplingResult = distanceResult.HorizontalSamplingResults;
            horizontalSamplingResult.Clear();
            for (int x = searchArea.Left; x < searchArea.Right; x++)
                horizontalSamplingResult.Add((byte)GetMeanSampledLevel(imageData, imageWidth, imageHeight, x));

            // 엣지 식별을 위한 샘플링 미분결과 저장
            var derivedSamplingResult = distanceResult.DerivedHorizontalSamplingResults;
            derivedSamplingResult.Clear();
            derivedSamplingResult.AddRange(MathHelper.GetDerivedArray(horizontalSamplingResult.ToArray(), 1));

            var nonCoatingPeaks = FindPeakPairs(derivedSamplingResult, pixelLength1mm * 10, pixelLength1mm * 20);
            foreach(var peakPair in nonCoatingPeaks)
            {
                var nonCoatingArea = new Rectangle
                {
                    X = searchArea.Left + peakPair.startIndex,
                    Y = searchArea.Top,
                    Width = peakPair.endIndex - peakPair.startIndex,
                    Height = searchArea.Height
                };
                distanceResult.NonCoatingAreas.Add(nonCoatingArea);
            }
            return;

            //미코팅 레벨값을 자동으로 찾음2 
            //int coatingAreaGrayLeveltest = GetOptimalNonCoatingThreshold(derivedSamplingResult);

            int x1 = 0, x2 = 0, areaCenter = 0, cy = 0;
            int St = -1, End = -1;
            double PeakMinLv = 0, PeakMaxLv = 0;
            int PeakMinPos = 0, PeakMaxPos = 0;

            bool bCloseEnd = false;
            areaCenter = searchArea.X + searchArea.Width / 2;
            //===== 미코팅 레벨값을 자동으로 찾음
            //if ((Para.bAutoCoatLv == true))
            //{
            //var arrHorizontalSampleResult = horizontalSamplingResult.Select(value => (double)value).ToArray();
            //var arrDerivedSampleResult = MathHelper.GetDerivedArray(arrHorizontalSampleResult.Select(value => (sbyte)value).ToArray(), 1, 3).Select(value => (double)value).ToArray();
            //int coatingAreaGrayLevel = GetCoatingLv(arrHorizontalSampleResult, arrDerivedSampleResult, 0, arrDerivedSampleResult.Length);
            //}

            //int CopperLv = Para.CoatLv[m_ModuleNo];
            //m_CopperLv = CopperLv;

            ////===== 1차 스캔을 하여 설정값보다 좁은 미코팅 영역이 나오면 먼저 처리한다. (단 포일 끝단과 멀리 떨어져 있을 경우에만)
            //St = -1; End = -1;

            //double dDiffW = 0.0;

            //double CopperMinW = Para.CopperMinW;
            //double dDist1 = 0.0;    // 포일 시작 부분과의 거리
            //double dDist2 = 0.0;    // 포일 끝 부분과의 거리
            //for (int x = searchArea.Left + 1; x < searchArea.Right; x++)
            //{
            //    if (St < 0 && horizontalSamplingResult[x] >= CopperLv)
            //        St = x;
            //    if (St < 0)
            //        continue;

            //    if (End < 0 && horizontalSamplingResult[x] < CopperLv)
            //        End = x;
            //    if (End < 0)
            //        continue;

            //    dDiffW = (End - St) * m_CalibX;

            //    dDist1 = (St - m_FoilSt) * m_CalibX;
            //    dDist2 = (m_FoilEnd - End) * m_CalibX;
            //    bCloseEnd = false;
            //    if (dDist1 < 2.0 || dDist2 < 2.0)
            //        bCloseEnd = true;

            //    if (bCloseEnd == false && dDiffW < CopperMinW)
            //    {   // 포일 끝단에 가까이 붙어있는 경우는 제외함. 
            //        for (int ii = St; ii < End; ii++)
            //        {
            //            horizontalSamplingResult[ii] = CopperLv - CoatingEdgeConstrastThreshold;
            //            if (horizontalSamplingResult[ii] < 0.0)
            //                horizontalSamplingResult[ii] = 0.0;
            //        }
            //    }
            //    St = -1; End = -1;
            //}

            ////===== 좁은 폭은 삭제한 horizontalSamplingResult[] 데이터를 가지고 m_pDiffW[] 를 채운다.
            //for (int x = searchArea.Left; x < searchArea.Right; x++)
            //{
            //    m_pDiffW[x] = horizontalSamplingResult[x] - horizontalSamplingResult[x];
            //}

            ////===== 전처리된 그래프를 가지고 다시 미코팅 구간을 찾음 (임시 Info에 넣는다)
            //int TmpCopperNum = 0;
            //St = -1; End = -1;
            //int CopperNum = 0;
            //for (int x = searchArea.Left + 1; x < searchArea.Right; x++)
            //{
            //    if (St < 0 && horizontalSamplingResult[x] >= CopperLv) St = x;
            //    if (St < 0) continue;

            //    if (End < 0 && horizontalSamplingResult[x] < CopperLv) End = x;
            //    if (End < 0) continue;

            //    dDiffW = (End - St) * m_CalibX;

            //    dDist1 = (St - m_FoilSt) * m_CalibX;
            //    dDist2 = (m_FoilEnd - End) * m_CalibX;
            //    bCloseEnd = false;
            //    if (dDist1 < 2.0 || dDist2 < 2.0)
            //        bCloseEnd = true;

            //    if (bCloseEnd == false && dDiffW < CopperMinW)
            //    {
            //        St = -1; End = -1;
            //        continue;
            //    }

            //    areaCenter = (St + End) / 2;

            //    if (CopperNum < Define.MAX_COPPER_NUM)
            //    {
            //        m_CopperSt[CopperNum] = St;
            //        m_CopperCx[CopperNum] = areaCenter;
            //        m_CopperEnd[CopperNum] = End;

            //        m_CopperStLv[CopperNum] = horizontalSamplingResult[St];
            //        m_CopperEndLv[CopperNum] = horizontalSamplingResult[End];

            //        CopperNum++;
            //    }

            //    cy = searchArea.Y + searchArea.Height / 2;
            //    m_Draw.DrawCross(areaCenter, cy, 5, Color.Red, false);
            //    St = -1; End = -1;
            //}

            ////===== 미코팅 구간을 찾았는데, 오른쪽 포일 끝단과 너무 멀리 떨어져 있으면 가상의 미코팅 구간을 만들어 준다 (미코팅이 한쪽만 있는 제품임)
            //if (CopperNum >= 1 && CopperNum < Define.MAX_COPPER_NUM)
            //{
            //    //===== 앞쪽 체크
            //    double Dist = m_CopperSt[0] - m_FoilSt;
            //    Dist *= m_CalibX;
            //    if (Dist > 10)
            //    {
            //        for (int icopper = CopperNum; icopper > 0; icopper--)
            //        {
            //            m_CopperSt[icopper] = m_CopperSt[icopper - 1];
            //            m_CopperCx[icopper] = m_CopperCx[icopper - 1];
            //            m_CopperEnd[icopper] = m_CopperEnd[icopper - 1];
            //            m_CopperStLv[icopper] = m_CopperStLv[icopper - 1];
            //            m_CopperEndLv[icopper] = m_CopperEndLv[icopper - 1];
            //        }

            //        m_CopperSt[0] = m_FoilSt;
            //        m_CopperCx[0] = m_FoilSt;
            //        m_CopperEnd[0] = m_FoilSt;
            //        m_CopperStLv[0] = horizontalSamplingResult[m_FoilSt];
            //        m_CopperEndLv[0] = horizontalSamplingResult[m_FoilSt];
            //        CopperNum++;
            //    }

            //    //===== 끝쪽을 미코팅으로 막기
            //    Dist = m_FoilEnd - m_CopperEnd[CopperNum - 1];
            //    Dist *= m_CalibX;
            //    if (Dist > 10)
            //    {
            //        m_CopperSt[CopperNum] = m_FoilEnd;
            //        m_CopperCx[CopperNum] = m_FoilEnd;
            //        m_CopperEnd[CopperNum] = m_FoilEnd;
            //        m_CopperStLv[CopperNum] = horizontalSamplingResult[m_FoilEnd];
            //        m_CopperEndLv[CopperNum] = horizontalSamplingResult[m_FoilEnd];
            //        CopperNum++;
            //    }
            //}

            //if (CopperNum < 1)
            //{
            //    m_CopperNum = CopperNum;
            //    return;
            //}

            ////================================================================= 미코팅 영역의 시작 끝 지점 찾음
            //TmpCopperNum = CopperNum;
            //CopperNum = 0;
            //for (int icnt = 0; icnt < TmpCopperNum; icnt++)
            //{
            //    dDiffW = m_CopperEnd[icnt] - m_CopperSt[icnt];
            //    if (dDiffW < 2)
            //    {  // 미코팅 구간의 폭이 2픽셀 이하라는 건 가상으로 만들어준 구간임.. 따라서 자세히 검사할 필요 없음
            //        CopperInfos[CopperNum].CopperStX = m_CopperSt[icnt];
            //        CopperInfos[CopperNum].CopperEndX = m_CopperEnd[icnt];

            //        CopperInfos[CopperNum].CopperStLv = m_CopperStLv[icnt];
            //        CopperInfos[CopperNum].CopperEndLv = m_CopperEndLv[icnt];
            //        CopperNum++;
            //        continue;
            //    }

            //    areaCenter = m_CopperCx[icnt];
            //    x1 = areaCenter - (int)dDiffW;          // 검사구간은 보다 더 크게 설정한다.
            //    x2 = areaCenter + (int)dDiffW;
            //    if (x1 < 0) x1 = 0;
            //    if (x2 >= imageWidth) x2 = imageWidth - 1;

            //    //================================= 왼쪽으로 스캔하면서 가장 밝기차이가 큰 부분을 찾는다.
            //    PeakMaxLv = 0;
            //    PeakMaxPos = 0;
            //    St = -1; End = -1;
            //    for (int x = areaCenter; x > x1; x--)
            //    {
            //        if (m_pDiffW[x] >= CoatingEdgeConstrastThreshold && m_pDiffW[x + 1] < CoatingEdgeConstrastThreshold) St = x;
            //        if (St < 0) continue;

            //        if (m_pDiffW[x] > PeakMaxLv)
            //        {
            //            PeakMaxLv = m_pDiffW[x];
            //            PeakMaxPos = x;
            //        }

            //        if (m_pDiffW[x] < CoatingEdgeConstrastThreshold && m_pDiffW[x + 1] >= CoatingEdgeConstrastThreshold)
            //            End = x;

            //        if (End < 0)
            //            continue;

            //        St = -1; End = -1;
            //        PeakMaxLv = 0;
            //    }
            //    //================================= 오른쪽으로 스캔
            //    PeakMinLv = 0;
            //    St = -1; End = -1;
            //    for (int x = areaCenter; x < x2; x++)
            //    {
            //        if (m_pDiffW[x] <= -CoatingEdgeConstrastThreshold && m_pDiffW[x - 1] > -CoatingEdgeConstrastThreshold) St = x;
            //        if (St < 0) continue;

            //        if (m_pDiffW[x] < PeakMinLv)
            //        {
            //            PeakMinLv = m_pDiffW[x];
            //            PeakMinPos = x;
            //        }

            //        if (m_pDiffW[x] > -CoatingEdgeConstrastThreshold && m_pDiffW[x - 1] <= -CoatingEdgeConstrastThreshold) End = x;
            //        if (End < 0) continue;

            //        St = -1; End = -1;
            //        PeakMinLv = 0;
            //    }

            //    //=========== 원하는 Edge Lv이 없으면 그냥 저장하지 않고 통과함..
            //    if (PeakMaxPos < 1 || PeakMinPos < 1)
            //    {
            //        continue;
            //    }

            //    CopperInfos[CopperNum].CopperStX = PeakMaxPos;
            //    CopperInfos[CopperNum].CopperEndX = PeakMinPos;

            //    CopperInfos[CopperNum].CopperStLv = PeakMaxLv;
            //    CopperInfos[CopperNum].CopperEndLv = PeakMinLv;

            //    CopperInfos[CopperNum].LocationEncoder = Config.EncCnt[m_ModuleNo] * m_CalibY;  // mm단위 
            //    CopperInfos[CopperNum].LocationRewinder = Config.LinePos[m_ModuleNo] * 1000;    // mm단위 
            //    CopperNum++;
            //}

            ////===== 최종 갯수를 저장함
            //m_CopperNum = CopperNum;

            ////==================================================
            //for (int iCopper = 0; iCopper < CopperNum; iCopper++)
            //{
            //    CopperInfos[iCopper].CopperStX *= m_CalibX;
            //    CopperInfos[iCopper].CopperEndX *= m_CalibX;
            //}
        }

        public int GetCoatingLv(double[] pW, double[] pDiffW, int StPos, int EndPos)
        {
            int CoatCnt = 0;

            int Thresh = 0;
            int EdgeLv = CoatingEdgeConstrastThreshold;

            int Pix5mm = (int)(pixelLength1mm * 5);
            int x1 = 0, x2 = 0;

            int St1 = -1;    // Coat Start검사용
            int End1 = -1;

            int St2 = -1;    // 코팅 End 검사용
            int End2 = -1;

            int CoatSt = -1;
            int CoatEnd = -1;

            double MaxLv = 0;

            CoatCnt = 0;
            for (int index = StPos; index < EndPos; index++)
            {

                if (CoatSt < 0)
                {
                    if (St1 < 0 && pDiffW[index] < -EdgeLv)
                        St1 = index;

                    if (St1 >= 0 && End1 < 0 && pDiffW[index] >= -EdgeLv)
                        End1 = index;


                    if (St1 >= 0 && End1 >= 0)
                    {
                        CoatSt = (St1 + End1) / 2;
                        St1 = -1;
                        End1 = -1;
                    }
                }

                if (CoatCnt >= 1 && CoatSt < 0)   // 코팅영역을 한번이라도 찾았을 경우에는, 두번째 부터는 Coating Start위치값을 고려한다.
                    continue;

                if (CoatEnd < 0)
                {
                    if (St2 < 0 && pDiffW[index] >= EdgeLv)
                        St2 = index;

                    if (St2 >= 0 && End2 < 0 && pDiffW[index] < EdgeLv)
                        End2 = index;

                    if (St2 >= 0 && End2 >= 0)
                    {
                        CoatEnd = (St2 + End2) / 2;
                        St2 = -1;
                        End2 = -1;
                    }
                }
                if (CoatEnd < 0)
                    continue;

                if (CoatCnt == 0 && CoatSt < 0)
                {
                    CoatSt = StPos;
                }

                x1 = CoatSt + Pix5mm;
                x2 = CoatEnd - Pix5mm;
                for (int ii = x1; ii < x2 - Pix5mm; ii += Pix5mm)
                {
                    double sum = 0;
                    int cnt = 0;
                    for (int tmp = ii; tmp < ii + Pix5mm; tmp++)
                    {
                        sum += pW[tmp];
                        cnt++;
                    }
                    if (cnt < 1)
                        continue;
                    double avg = sum / (double)cnt;

                    if (avg > MaxLv)
                        MaxLv = avg;
                }

                CoatSt = -1;
                CoatEnd = -1;
                CoatCnt++;
            }

            //==== 시작점은 찾고 끝점은 못 찾았을 경우 끝점 처리함.
            if (CoatSt >= 0 && CoatEnd < 0)
            {
                CoatEnd = EndPos;

                x1 = CoatSt + Pix5mm;
                x2 = CoatEnd - Pix5mm;

                for (int ii = x1; ii < x2 - Pix5mm; ii += Pix5mm)
                {
                    double sum = 0;
                    int cnt = 0;
                    for (int tmp = ii; tmp < ii + Pix5mm; tmp++)
                    {
                        sum += pW[tmp];
                        cnt++;
                    }
                    if (cnt < 1)
                        continue;
                    double avg = sum / (double)cnt;

                    if (avg > MaxLv)
                        MaxLv = avg;
                }

                //for (int ii = x1; ii < x2; ii++) {
                //    if (pW[ii] > MaxLv)
                //        MaxLv = pW[ii];
                //}
            }

            Thresh = (int)MaxLv;

            return Thresh;
        }

        public List<(int startIndex, int endIndex)> FindPeakPairs(List<byte> intensifyDifferences, double minimumWidth, double maximumWidth)
        {
            var positionIndices = new List<(int, int)>();

            if (intensifyDifferences.Count == 0)
                return positionIndices;

            int peakSamplingCount = Math.Max(2, intensifyDifferences.Count / 50);
            var topPeakSamples = intensifyDifferences
                .Select((value, index) => new { index, value })
                .OrderByDescending(x => x.value)
                .Take(peakSamplingCount);

            var samplingAverage = topPeakSamples.Average(peak => (double)peak.value);
            var mostIntensePeaks = topPeakSamples.Where(peak => peak.value > samplingAverage).OrderBy(peak => peak.index).ToArray();

            var matchedPeaks = new List<int>();
            for (int index = 0; index < mostIntensePeaks.Length; index++)
            {
                if (matchedPeaks.Contains(index))
                    continue;

                for (int subIndex = index + 1; subIndex < mostIntensePeaks.Length; subIndex++)
                {
                    int width = mostIntensePeaks[subIndex].index - mostIntensePeaks[index].index;
                    if (width >= minimumWidth && width <= maximumWidth)
                    {
                        // 피크 start, end 등록, 중복 방지 처리
                        positionIndices.Add((mostIntensePeaks[index].index, mostIntensePeaks[subIndex].index));
                        for (int skipIndex = index; skipIndex < subIndex; skipIndex++)
                            matchedPeaks.Add(skipIndex);

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
