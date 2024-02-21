using Emgu.CV;
using Emgu.CV.CvEnum;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class InspectionTeachingForm : Form
    {
        #region 필드
        private Color _selectedColor;

        private Color _nonSelectedColor;

        private Mat _orgMat { get; set; } = null;
        #endregion

        #region 속성

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
            _orgMat?.Dispose();
            _orgMat = null;

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
                //_orgMat?.Dispose();
                //OrgMat = null;

                //OrgMat = new Mat(dlg.FileName, ImreadModes.Grayscale);

                //if (OrgMat != null)
                //{
                //    var bmp = OrgMat.ToBitmap();
                //    DrawBoxControl.SetImage(bmp);
                //    DrawBoxControl.FitZoom();
                //}
                LoadImage(dlg.FileNames);
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
    }

    public enum DisplayType
    {
        Distance,
        Coating,
        NonCoating,
    }
}
