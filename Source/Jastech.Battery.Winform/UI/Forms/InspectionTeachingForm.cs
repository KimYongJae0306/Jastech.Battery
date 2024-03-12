using Emgu.CV;
using Emgu.CV.CvEnum;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Battery.Structure.VisionTool;
using Jastech.Battery.Winform.Settings;
using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Device.Plcs;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

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

            AppsInspModel model = ModelManager.Instance().CurrentModel as AppsInspModel;
            SliceInspResult sliceInspResult = new SliceInspResult();
            AlgorithmTool algorithmTool = new AlgorithmTool();

            _imageWidth = _orgBmp.Width;
            _imageHeight = _orgBmp.Height;

            _grayImage?.Dispose();
            _imageData?.Initialize();
            _grayImage = ImageHelper.ConvertToGrayscale(_orgBmp);  // 2024.03.12 임시 변환 추가, 2064*1000 기준 100ms 정도 소요
            _imageData = ImageHelper.GetByteArrayFromBitmap(_grayImage);

            if (model == null)
                model = new AppsInspModel();
            model.DistanceParam.LeftScanMargin = 350;    // 시퀀스 검증용 임시 하드코딩, 티칭 완성 후 제거
            model.DistanceParam.RightScanMargin = 210;    // 시퀀스 검증용 임시 하드코딩, 티칭 완성 후 제거

            DistanceResult distanceResult = new DistanceResult
            {
                FoilStartX = model.DistanceParam.LeftScanMargin,
                FoilEndX = _imageWidth - model.DistanceParam.RightScanMargin,
                FoilStartY = model.DistanceParam.TopScanMargin,
                FoilEndY = _imageHeight - model.DistanceParam.BottomScanMargin,
            };
            sliceInspResult.DistanceResult = distanceResult;

            // teaching 영역 사용 시 별도 계산 하지 않음
            if (AppsConfig.Instance().UseTeachingArea == false)
                sliceInspResult.foilFound = algorithmTool.FindVerticalFoilEdge(ref distanceResult, _imageData, _imageWidth, _imageHeight);

            if (AppsConfig.Instance().UseTeachingArea == false && sliceInspResult.foilFound == false)
                return;     // Define.RESULT_NO_FOIL

            sliceInspResult.IsCoating = algorithmTool.CheckFoilExistance(distanceResult, _imageData, _imageWidth, _imageHeight);

            if (sliceInspResult.IsCoating == false)
                return;     // Define.RESULT_NON_COAT_ONE_SIDE

            //algorithmTool.FindCoatingArea_Vertical();

            
            //if(model.ModelType == Structure.Parameters.ModelType.None) // PLC로부터 받아온 정보가 없거나 그냥 모델이 설정이 안되어 있으면, 모델을 식별한다
            //    algorithmTool. IdentifyModelType(ref foilStartY, ref foilEndX, ref y1, ref imageHeight);
        }
    }

    public enum DisplayType
    {
        Distance,
        Coating,
        NonCoating,
    }
}
