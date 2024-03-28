using Emgu.CV;
using Emgu.CV.Dnn;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Battery.Structure.VisionTool;
using Jastech.Battery.Winform.Settings;
using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Config;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class InspectionTeachingForm : Form
    {
        #region 필드
        private Color _selectedColor;

        private Color _nonSelectedColor;

        private Bitmap _orgBmp = null;

        private Bitmap _grayImage = null;

        private Bitmap _resultImage = null;
        #endregion

        #region 속성
        public UnitName UnitName { get; set; } = UnitName.Upper;

        public InspModelService InspModelService { get; set; } = null;

        private Mat OrgMat { get; set; } = null;

        public InspDirection InspDirection { get; set; }

        private DrawBoxControl DrawBoxControl { get; set; } = null;

        private PixelValueGraphControl PixelValueGraphControl { get; set; } = null;

        private ImageViewerControl ImageViewerControl { get; set; } = null;

        private DisplayType _displayType { get; set; } = DisplayType.Distance;

        private GraphResultType _graphResultType { get; set; } = GraphResultType.VerticalSampling;

        public LineCamera LineCamera { get; set; }

        private DistanceControl DistanceControl { get; set; } = null;

        private SurfaceControl SurfaceControl { get; set; } = null;

        private FindAreaResult LastDistanceResult { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public InspectionTeachingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void InspectionTeachingForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            AddControl();

            TeachingData.Instance().UpdateTeachingData();

            SelectPage(DisplayType.Distance);
            UpdateGraph(_graphResultType);
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            if (LineCamera == null)
                lblDirection.Text = $"CAM : ";
            else
                lblDirection.Text = $"CAM : {LineCamera.Camera.Name}";
        }

        private void AddControl()
        {
            //DrawBoxControl = new DrawBoxControl();
            //DrawBoxControl.Dock = DockStyle.Fill;
            //DrawBoxControl.ViewColor = Color.Black;
            //DrawBoxControl.DisplayMode = DisplayMode.Panning;
            //DrawBoxControl.UseGrayLevel = true;
            //pnlDisplay.Controls.Add(DrawBoxControl);

            PixelValueGraphControl = new PixelValueGraphControl();
            PixelValueGraphControl.DataPen = new Pen(Color.DodgerBlue);
            PixelValueGraphControl.Dock = DockStyle.Fill;
            pnlGraph.Controls.Add(PixelValueGraphControl);

            ImageViewerControl = new ImageViewerControl();
            ImageViewerControl.Dock = DockStyle.Fill;
            pnlDisplay.Controls.Add(ImageViewerControl);

            DistanceControl = new DistanceControl();
            DistanceControl.Dock = DockStyle.Fill;
            pnlTeach.Controls.Add(DistanceControl);

            SurfaceControl = new SurfaceControl();
            SurfaceControl.Dock = DockStyle.Fill;
            pnlTeach.Controls.Add(SurfaceControl);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OrgMat?.Dispose();
            OrgMat = null;

            ParamTrackingLogger.ClearChangedLog();
            this.Close();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.ReadOnlyChecked = true;
            dlg.Filter = "BMP Files (*.bmp)|*.bmp; | "
                + "JPG Files (*.jpg, *.jpeg)|*.jpg; *.jpeg; |"
                + "모든 파일(*.*) | *.*;";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadImage(dlg.FileNames);
                _orgBmp = new Bitmap(dlg.FileName, useIcm: false);
            }
        }

        private void LoadImage(string[] imageFilePathes)
        {
            List<ImageInfo> imageInfoList = new List<ImageInfo>();

            foreach (string imagePath in imageFilePathes)
            {
                ImageInfo imageInfo = new ImageInfo();

                imageInfo.OriginBitmap = new Bitmap(imagePath);
                imageInfo.ImagePath = imagePath;
                imageInfo.ImageName = Path.GetFileNameWithoutExtension(imagePath);

                imageInfoList.Add(imageInfo);
            }

            ImageViewerControl.SetImageInfo(imageInfoList);
        }

        private void InspectionTeachingForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadImage(files);
        }

        private void InspectionTeachingForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void btnDistance_Click(object sender, EventArgs e)
        {
            SelectPage(DisplayType.Distance);
        }

        private void btnSurface_Click(object sender, EventArgs e)
        {
            SelectPage(DisplayType.Surface);
        }

        private void SelectPage(DisplayType displayType)
        {
            if (ModelManager.Instance().CurrentModel == null || UnitName.ToString() == "")
                return;

            ClearSelectedButton();
            SetTeachingControl(displayType);
        }

        private void ClearSelectedButton()
        {
            pnlTeach.Controls.Clear();

            foreach (Control control in tlpTeachingItems.Controls)
            {
                if (control is Button)
                    control.BackColor = _nonSelectedColor;
            }
        }

        private void SetTeachingControl(DisplayType displayType)
        {
            var currentUnit = TeachingData.Instance().GetUnit(UnitName.ToString());
            _displayType = displayType;

            switch (displayType)
            {
                case DisplayType.Distance:
                    btnDistance.BackColor = _selectedColor;
                    DistanceControl.SetParam(currentUnit.DistanceParam);
                    pnlTeach.Controls.Add(DistanceControl);
                    break;

                case DisplayType.Surface:
                    btnSurface.BackColor = _selectedColor;
                    pnlTeach.Controls.Add(SurfaceControl);
                    break;

                default:
                    break;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_orgBmp == null)
                return;

            Stopwatch stopwatch = Stopwatch.StartNew();
            WriteTactTime(stopwatch, "=================================Test Start=================================");

            var unit = TeachingData.Instance().GetUnit(UnitName.ToString());
            FindAreaParam distanceParam = unit?.DistanceParam;

            if (unit == null)
            {
                MessageBox.Show("CurrentModel이 Null 입니다.");
                return;
            }
            if (distanceParam == null)
            {
                MessageBox.Show("DistanceParam이 Null 입니다.");
                return;
            }

            SliceInspResult sliceInspResult = new SliceInspResult();
            var camera = LineCamera.Camera;
			double resolution_mm = (camera.PixelResolution_um / camera.LensScale) / 1000;

            FindAreaAlgorithmTool findAreaAlgorithmTool = new FindAreaAlgorithmTool();
            findAreaAlgorithmTool.pixelResolution_mm = resolution_mm;

            WriteTactTime(stopwatch, "Before converting image");
            _grayImage = ImageHelper.ConvertRGB24ToGrayscale(_orgBmp);  // 2024.03.12 임시 변환 추가, 2064*1000 기준 100ms 정도 소요
            WriteTactTime(stopwatch, "After converting image to grayscale");
            ImageBuffer imageBuffer = new ImageBuffer();
            imageBuffer.ImageData = ImageHelper.GetByteArrayFromBitmap(_grayImage);
            imageBuffer.Index = 999999;
            imageBuffer.ImageWidth = _orgBmp.Width;
            imageBuffer.ImageHeight = _orgBmp.Height;
            WriteTactTime(stopwatch, "After converting image to byte array");

            WriteTactTime(stopwatch, "Initializing finished");

            FindAreaResult distanceInspResult = new FindAreaResult();
            distanceParam._Roi = new Rectangle  //2024.03.26 + 안쓸 것 같음, 삭제 대기
            {
                X = distanceParam.ROIMarginLeft,
                Y = distanceParam.ROIMarginTop,
                Width = imageBuffer.ImageWidth - distanceParam.ROIMarginRight,
                Height = imageBuffer.ImageHeight - distanceParam.ROIMarginBottom,
            };
            findAreaAlgorithmTool.FindSearchAreas(distanceInspResult, imageBuffer, distanceParam);
            findAreaAlgorithmTool.FindInspectionAreas(distanceInspResult, imageBuffer, distanceParam);
            sliceInspResult.DistanceResult = distanceInspResult;

            WriteTactTime(stopwatch, "DistanceInspecitonFinished");

            // 추가 검증용 코드
            LastDistanceResult = distanceInspResult;
            DistanceControl.dgvReviewOnlyTest1.DataSource = LastDistanceResult.CoatingInfoList;
            DistanceControl.dgvReviewOnlyTest2.DataSource = LastDistanceResult.NonCoatingInfoList;
            UpdateGraph(_graphResultType);
            ShowTestResults(distanceInspResult);

            //WriteTactTime(stopwatch, "=============================Start Surface Test=============================");
            //SurfaceParam surfaceParam = unit?.SurfaceParam;
            //SurfaceInspResult surfaceInspResult = new SurfaceInspResult();
            //
            //SurfaceAlgorithmTool surfaceAlgorithmTool = new SurfaceAlgorithmTool();
            //surfaceAlgorithmTool.PixelResolution_mm = resolution_mm;
            //
            //var coatingInfoList = distanceInspResult.CoatingInfoList;
            //
            //surfaceParam.LineParam.EnableCheckLine = true;
            //surfaceAlgorithmTool.CheckCoatingArea_Line(imageBuffer, coatingInfoList, surfaceParam, surfaceInspResult, true);
            //
            //sliceInspResult.SurfaceInspResult = surfaceInspResult;

            WriteTactTime(stopwatch, "=================================Test Finished==============================");

            WriteTactTime(stopwatch, "=============================Start Surface Test=============================");
            SurfaceParam surfaceParam = unit?.SurfaceParam;
            SurfaceInspResult surfaceInspResult = new SurfaceInspResult();

            SurfaceAlgorithmTool surfaceAlgorithmTool = new SurfaceAlgorithmTool();
            surfaceAlgorithmTool.PixelResolution_mm = resolution_mm;

            var coatingInfoList = distanceInspResult.CoatingInfoList;

            imageBuffer.InitializeSmallBuffer(smallRatioX: 5, smallRatioY: 5);
            surfaceParam.LineParam.EnableCheckLine = true;
            surfaceAlgorithmTool.CheckCoatingArea_Line(imageBuffer, coatingInfoList, surfaceParam, surfaceInspResult, false);

            sliceInspResult.SurfaceInspResult = surfaceInspResult;
        }

        private void ShowTestResults(FindAreaResult distanceResult)
        {
            if (_orgBmp == null)
                return;

            int imageWidth = _orgBmp.Width;
            int penSize = (int)(Math.Sqrt(imageWidth) / Math.Log10(imageWidth));
            Font textFont = new Font(Font.FontFamily, (float)Math.Sqrt(imageWidth) / 1.5f, FontStyle.Bold);
            Pen coatingWidthPen = new Pen(Color.LawnGreen, penSize)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor
            };
            Pen nonCoatingWidthPen = new Pen(Color.Crimson, penSize)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor
            };
            Pen coatingROIpen = new Pen(Color.Yellow, penSize) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            Pen nonCoatingROIpen = new Pen(Color.DarkGreen, penSize) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

            using (Bitmap convertedBitmap = ImageHelper.ConvertGrayscaleToRGB24(_orgBmp))
            {
                using (Graphics g = Graphics.FromImage(convertedBitmap))
                {
                    foreach (SurfaceInfo nonCoatingInfo in distanceResult.NonCoatingInfoList)
                    {
                        Rectangle nonCoatingArea = nonCoatingInfo.Area;
                        var laneString = $"Lane{nonCoatingInfo.Lane}";
                        var stringSize = g.MeasureString(laneString, textFont);
                        g.DrawLine(nonCoatingWidthPen, nonCoatingArea.Left, nonCoatingArea.Top + nonCoatingArea.Height / 2, nonCoatingArea.Right, nonCoatingArea.Top + nonCoatingArea.Height / 2);
                        g.DrawRectangle(nonCoatingROIpen, nonCoatingArea.Left, nonCoatingArea.Top, nonCoatingArea.Width, nonCoatingArea.Height);
                        g.DrawString(laneString, textFont, Brushes.Black, new PointF(nonCoatingArea.X + ((nonCoatingArea.Width-stringSize.Width) / 2), nonCoatingArea.Height / 3));
                    }

                    foreach (SurfaceInfo coatingInfo in distanceResult.CoatingInfoList)
                    {
                        Rectangle coatingArea = coatingInfo.Area;
                        var laneString = $"Lane{coatingInfo.Lane}";
                        var stringSize = g.MeasureString(laneString, textFont);
                        g.DrawLine(coatingWidthPen, coatingArea.Left, coatingArea.Top + coatingArea.Height / 2, coatingArea.Right, coatingArea.Top + coatingArea.Height / 2);
                        g.DrawRectangle(coatingROIpen, coatingArea.Left, coatingArea.Top, coatingArea.Width, coatingArea.Height);
                        g.DrawString(laneString, textFont, Brushes.Black, new PointF(coatingArea.X + ((coatingArea.Width-stringSize.Width) / 2), coatingArea.Height / 4));
                    }

                    g.Save();
                }
                ImageViewerControl.SetInternalImage(convertedBitmap);
            }
        }

        private long WriteTactTime(Stopwatch stopwatch, string message)     // 2024.03.13 테스트 후 참조 모두 제거할 것
        {
            stopwatch.Stop();
            long elapsedTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Start();
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}, Elapsed : {elapsedTime}ms");
            return elapsedTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppsInspModel model = ModelManager.Instance().CurrentModel as AppsInspModel;

            if (model == null)
                return;

            MessageYesNoForm yesNoForm = new MessageYesNoForm();
            yesNoForm.Message = "Teaching data will change.\nDo you agree?";

            if (yesNoForm.ShowDialog() == DialogResult.Yes)
            {
                SaveModelData(model);

                MessageConfirmForm confirmForm = new MessageConfirmForm();
                confirmForm.Message = "Save Model Completed.";
                confirmForm.ShowDialog();

                if (ParamTrackingLogger.IsEmpty == false)
                {
                    ParamTrackingLogger.AddLog($"{_displayType} Teaching Saved.");
                    ParamTrackingLogger.WriteLogToFile();
                }
            }

            Logger.Write(LogType.GUI, "Clicked InpectionTeachingForm Save Button");
        }

        private void SaveModelData(AppsInspModel model)
        {
            model.SetUnitList(TeachingData.Instance().UnitList);

            string fileName = Path.Combine(ConfigSet.Instance().Path.Model, model.Name, InspModel.FileName);
            InspModelService?.Save(fileName, model);
        }

        private void btnShowVerticalSamplingResult_Click(object sender, EventArgs e)
        {
            UpdateGraph(GraphResultType.VerticalSampling);
        }

        private void btnShowVerticalDifferentials_Click(object sender, EventArgs e)
        {
            UpdateGraph(GraphResultType.VerticalDifferentials);
        }

        private void btnShowHorizontalSamplingResult_Click(object sender, EventArgs e)
        {
            UpdateGraph(GraphResultType.HorizontalSampling);
        }

        private void btnShowHorizontalDifferentials_Click(object sender, EventArgs e)
        {
            UpdateGraph(GraphResultType.HorizontalDifferentials);
        }

        private void UpdateGraph(GraphResultType resultType)
        {
            pnlVerticalSampleResult.BorderStyle = BorderStyle.None;
            pnlVerticalDifferentials.BorderStyle = BorderStyle.None;
            pnlHorizontalSampleResult.BorderStyle = BorderStyle.None;
            pnlHorizontalDifferentials.BorderStyle = BorderStyle.None;

            lblSelectVerticalSampling.BackColor = _nonSelectedColor;
            lblSelectVerticalDifferentials.BackColor = _nonSelectedColor;
            lblSelectHorizontalSampling.BackColor = _nonSelectedColor;
            lblSelectHorizontalDifferentials.BackColor = _nonSelectedColor;

            _graphResultType = resultType;
            byte[] datas = null;
            switch (_graphResultType)
            {
                case GraphResultType.VerticalSampling:
                    lblSelectVerticalSampling.BackColor = Color.DodgerBlue;
                    pnlVerticalSampleResult.BorderStyle = BorderStyle.FixedSingle;
                    datas = LastDistanceResult?.VerticalSamplingResults?.ToArray();
                    break;
                case GraphResultType.VerticalDifferentials:
                    lblSelectVerticalDifferentials.BackColor = Color.DodgerBlue;
                    pnlVerticalDifferentials.BorderStyle = BorderStyle.FixedSingle;
                    datas = LastDistanceResult?.VerticalDifferentials?.ToArray();
                    break;
                case GraphResultType.HorizontalSampling:
                    lblSelectHorizontalSampling.BackColor = Color.DodgerBlue;
                    pnlHorizontalSampleResult.BorderStyle = BorderStyle.FixedSingle;
                    datas = LastDistanceResult?.HorizontalSamplingResults?.ToArray();
                    break;
                case GraphResultType.HorizontalDifferentials:
                    lblSelectHorizontalDifferentials.BackColor = Color.DodgerBlue;
                    pnlHorizontalDifferentials.BorderStyle = BorderStyle.FixedSingle;
                    datas = LastDistanceResult?.HorizontalDifferentials?.ToArray();
                    break;
            }

            if (datas != null)
                PixelValueGraphControl.SetData(datas);
        }
        #endregion
        private void btnHorizontalSampleResults_MouseEnter(object sender, EventArgs e)
        {
            if (lblSelectHorizontalSampling.BackColor != Color.DodgerBlue)
                lblSelectHorizontalSampling.BackColor = _selectedColor;
        }

        private void btnHorizontalSampleResults_MouseLeave(object sender, EventArgs e)
        {
            if (lblSelectHorizontalSampling.BackColor != Color.DodgerBlue)
                lblSelectHorizontalSampling.BackColor = _nonSelectedColor;
        }

        private void btnVerticalSampleResults_MouseEnter(object sender, EventArgs e)
        {
            if (lblSelectVerticalSampling.BackColor != Color.DodgerBlue)
                lblSelectVerticalSampling.BackColor = _selectedColor;
        }

        private void btnVerticalSampleResults_MouseLeave(object sender, EventArgs e)
        {
            if (lblSelectVerticalSampling.BackColor != Color.DodgerBlue)
                lblSelectVerticalSampling.BackColor = _nonSelectedColor;
        }

        private void btnVerticalDifferentials_MouseEnter(object sender, EventArgs e)
        {
            if (lblSelectVerticalDifferentials.BackColor != Color.DodgerBlue)
                lblSelectVerticalDifferentials.BackColor = _selectedColor;
        }

        private void btnVerticalDifferentials_MouseLeave(object sender, EventArgs e)
        {
            if (lblSelectVerticalDifferentials.BackColor != Color.DodgerBlue)
                lblSelectVerticalDifferentials.BackColor = _nonSelectedColor;
        }

        private void btnHorizontalDifferentials_MouseEnter(object sender, EventArgs e)
        {
            if (lblSelectHorizontalDifferentials.BackColor != Color.DodgerBlue)
                lblSelectHorizontalDifferentials.BackColor = _selectedColor;
        }

        private void btnHorizontalDifferentials_MouseLeave(object sender, EventArgs e)
        {
            if (lblSelectHorizontalDifferentials.BackColor != Color.DodgerBlue)
                lblSelectHorizontalDifferentials.BackColor = _nonSelectedColor;
        }
    }

    public enum DisplayType
    {
        Distance,
        Surface,
    }

    public enum GraphResultType
    {
        VerticalSampling,
        VerticalDifferentials,
        HorizontalSampling,
        HorizontalDifferentials,
    }
}
