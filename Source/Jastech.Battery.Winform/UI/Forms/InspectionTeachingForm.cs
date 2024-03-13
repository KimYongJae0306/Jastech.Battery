using Emgu.CV;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Battery.Structure.VisionTool;
using Jastech.Battery.Winform.Settings;
using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private byte[] _imageData = null;

        private int _imageWidth = 0;

        private int _imageHeight = 0;
        #endregion

        #region 속성
        public UnitName UnitName { get; set; } = UnitName.Upper;

        public InspModelService InspModelService { get; set; } = null;

        private Mat OrgMat { get; set; } = null;

        //public InspDirection InspDirection { get; set; }

        private DrawBoxControl DrawBoxControl { get; set; } = null;

        private PixelValueGraphControl PixelValueGraphControl { get; set; } = null;

        private ImageViewerControl ImageViewerControl { get; set; } = null;

        private DisplayType _displayType { get; set; } = DisplayType.Distance;

        public LineCamera LineCamera { get; set; }

        private DistanceControl DistanceControl { get; set; } = null;

        private CoatingControl CoatingControl { get; set; } = null;

        private NonCoatingControl NonCoatingControl { get; set; } = null;
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

            SelectPage(DisplayType.Distance);
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(26, 26, 26);

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
            PixelValueGraphControl.Dock = DockStyle.Fill;
            pnlGraph.Controls.Add(PixelValueGraphControl);

            ImageViewerControl = new ImageViewerControl();
            ImageViewerControl.Dock = DockStyle.Fill;
            pnlDisplay.Controls.Add(ImageViewerControl);

            DistanceControl = new DistanceControl();
            DistanceControl.Dock = DockStyle.Fill;
            pnlTeach.Controls.Add(DistanceControl);

            CoatingControl = new CoatingControl();
            CoatingControl.Dock = DockStyle.Fill;
            pnlTeach.Controls.Add(CoatingControl);

            NonCoatingControl = new NonCoatingControl();
            NonCoatingControl.Dock = DockStyle.Fill;
            pnlTeach.Controls.Add(NonCoatingControl);
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
                //OrgMat?.Dispose();
                //OrgMat = null;

                //OrgMat = new Mat(dlg.FileName, ImreadModes.Grayscale);

                //if (OrgMat != null)
                //{
                //    var bmp = OrgMat.ToBitmap();
                //    DrawBoxControl.SetImage(bmp);
                //    DrawBoxControl.FitZoom();
                //}
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

        private void btnCoating_Click(object sender, EventArgs e)
        {
            SelectPage(DisplayType.Coating);
        }

        private void btnNonCoating_Click(object sender, EventArgs e)
        {
            SelectPage(DisplayType.NonCoating);
        }

        private void SelectPage(DisplayType displayType)
        {
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
            _displayType = displayType;

            switch (displayType)
            {
                case DisplayType.Distance:
                    btnDistance.BackColor = _selectedColor;
                    pnlTeach.Controls.Add(DistanceControl);
                    break;

                case DisplayType.Coating:
                    btnCoating.BackColor = _selectedColor;
                    pnlTeach.Controls.Add(CoatingControl);
                    break;

                case DisplayType.NonCoating:
                    btnNonCoating.BackColor = _selectedColor;
                    pnlTeach.Controls.Add(NonCoatingControl);
                    break;

                default:
                    break;
            }
        }
        #endregion

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_orgBmp == null)
                return;

            Stopwatch stopwatch = Stopwatch.StartNew();
            WriteTactTime(stopwatch, "=================================Test Start=================================");

            AppsInspModel model = ModelManager.Instance().CurrentModel as AppsInspModel;
            SliceInspResult sliceInspResult = new SliceInspResult();
            AlgorithmTool algorithmTool = new AlgorithmTool();

            _imageWidth = _orgBmp.Width;
            _imageHeight = _orgBmp.Height;

            _grayImage?.Dispose();
            _imageData?.Initialize();

            WriteTactTime(stopwatch, "Before converting image");
            _grayImage = ImageHelper.ConvertRGB24ToGrayscale(_orgBmp);  // 2024.03.12 임시 변환 추가, 2064*1000 기준 100ms 정도 소요
            WriteTactTime(stopwatch, "After converting image to grayscale");
            _imageData = ImageHelper.GetByteArrayFromBitmap(_grayImage);
            WriteTactTime(stopwatch, "After converting image to byte array");

            if (model == null)
                model = new AppsInspModel();
            model.DistanceParam.LeftScanMargin = 350;    // 시퀀스 검증용 임시 하드코딩, 티칭 완성 후 제거
            model.DistanceParam.RightScanMargin = 210;    // 시퀀스 검증용 임시 하드코딩, 티칭 완성 후 제거

            DistanceResult distanceResult = new DistanceResult
            {
                ScanStartX = model.DistanceParam.LeftScanMargin,
                ScanEndX = _imageWidth - model.DistanceParam.RightScanMargin,
                ScanStartY = model.DistanceParam.TopScanMargin,
                ScanEndY = _imageHeight - model.DistanceParam.BottomScanMargin,
            };
            sliceInspResult.DistanceResult = distanceResult;

            WriteTactTime(stopwatch, "Initializing finished");

            // teaching 영역 사용 시 별도 계산 하지 않음
            if (AppsConfig.Instance().UseTeachingArea == false)
                sliceInspResult.CoatingVerticalEdgesExist = algorithmTool.FindVerticalCoatingAreaEdges(ref distanceResult, _imageData, _imageWidth, _imageHeight);

            if (AppsConfig.Instance().UseTeachingArea == false && sliceInspResult.CoatingVerticalEdgesExist == false)
                return;     // Define.RESULT_NO_FOIL

            WriteTactTime(stopwatch, "Coating vertical edges were found");

            sliceInspResult.CoatingWidthSufficient = algorithmTool.CheckCoatingWidth(distanceResult, _imageData, _imageWidth, _imageHeight);

            if (sliceInspResult.CoatingWidthSufficient == false)
                return;     // Define.RESULT_NON_COAT_ONE_SIDE

            WriteTactTime(stopwatch, "Coating width checked");

            sliceInspResult.CoatingROIFound = algorithmTool.FindCoatingAreas(ref distanceResult, model, _imageData, _imageWidth, _imageHeight, model.DistanceParam.MinimumFoilLength);

            if (sliceInspResult.CoatingROIFound == false)
                return;     // Define.RESULT_NON_COAT_ONE_SIDE

            WriteTactTime(stopwatch, "Coating Areas were found");
            #region 추가 검증용 코드
            List<byte> horizontalSamplingResults = new List<byte>();
            for (int x = 0; x < _imageWidth; x++)
                horizontalSamplingResults.Add((byte)algorithmTool.GetMeanSampledLevel(_imageData, _imageWidth, _imageHeight, x));
            PixelValueGraphControl.SetData(horizontalSamplingResults.ToArray());

            SaveTestResults(distanceResult);
            #endregion
            WriteTactTime(stopwatch, "=================================Test Finished==============================");
        }

        private void SaveTestResults(DistanceResult distanceResult)
        {
            if (_orgBmp == null)
                return;

            Pen foilEdgeXPen = new Pen(Color.Red, 5);
            Pen foilEdgeYPen = new Pen(Color.Indigo, 5);
            Pen foilWidthPen = new Pen(Color.LawnGreen, 7)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
                EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor
            };
            Pen foilROIPen = new Pen(Color.Yellow, 3)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            using (Bitmap cloneBitmap = ImageHelper.ConvertGrayscaleToRGB24((Bitmap)_orgBmp.Clone()))
            {
                using (Graphics g = Graphics.FromImage(cloneBitmap))
                {
                    g.DrawLine(foilEdgeXPen, distanceResult.ScanStartX, 0, distanceResult.ScanStartX, _imageHeight);
                    g.DrawLine(foilEdgeXPen, distanceResult.ScanEndX, 0, distanceResult.ScanEndX, _imageHeight);
                    g.DrawLine(foilEdgeYPen, 0, distanceResult.ScanStartY, _imageWidth, distanceResult.ScanStartY);
                    g.DrawLine(foilEdgeYPen, 0, distanceResult.ScanEndY, _imageWidth, distanceResult.ScanEndY);

                    g.DrawLine(foilWidthPen, distanceResult.ScanStartX, _imageHeight / 2, distanceResult.ScanEndX, _imageHeight / 2);
                    g.DrawRectangle(foilROIPen, distanceResult.LargestCoatingArea);

                    g.Save();
                }
                cloneBitmap.Save(@"D:\FoilTestResult.bmp");
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
    }

    public enum DisplayType
    {
        Distance,
        Coating,
        NonCoating,
    }
}
