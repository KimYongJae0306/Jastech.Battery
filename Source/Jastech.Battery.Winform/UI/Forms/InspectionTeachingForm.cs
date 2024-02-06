using Emgu.CV;
using Emgu.CV.CvEnum;
using Jastech.Battery.Structure.Data;
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
using static System.Net.WebRequestMethods;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class InspectionTeachingForm : Form
    {
        
        private Mat OrgMat { get; set; } = null;

        public InspDirection InspDirection { get; set; }

        private DrawBoxControl DrawBoxControl { get; set; } = null;

        private PixelValueGraphControl PixelValueGraphControl { get; set; } = null;

        private ImageViewerControl ImageViewerControl { get; set; } = null;

        public InspectionTeachingForm()
        {
            InitializeComponent();
        }

        private void InspectionTeachingForm_Load(object sender, EventArgs e)
        {
            //TeachingData.Instance().
            AddControl();
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
    }
}
