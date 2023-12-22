using Emgu.CV;
using Emgu.CV.CvEnum;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform;
using Jastech.Battery.Winform.Core;
using Jastech.Framework.Config;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Device.LAFCtrl;
using Jastech.Framework.Device.Motions;
using Jastech.Framework.Imaging;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Forms;
using Jastech.Framework.Winform.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static Jastech.Framework.Device.Motions.AxisMovingParam;

namespace Jastech.Battery.Winform.Forms
{
    public partial class OpticTeachingForm : Form
    {
        #region 필드
        private Color _selectedColor = new Color();

        private Color _nonSelectedColor = new Color();

        private Direction _direction = Direction.CW;

        public double _prevAnalogGain { get; set; } = 0;

        public double _prevDigitalGain { get; set; } = 0;
        #endregion

        #region 속성

        public AxisName AxisNameZ { get; set; } = AxisName.Z0;

        public InspModelService InspModelService { get; set; } = null;

        private DrawBoxControl DrawBoxControl { get; set; } = null;

        private DataGraphControl DataGraphControl { get; set; } = null;

        public AxisHandler AxisHandler { get; set; } = null;

        public LineCamera LineCamera { get; set; } = null;

        private Axis SelectedAxis { get; set; } = null;
        #endregion

        #region 이벤트
        //public MotionPopupDelegate OpenMotionPopupEventHandler;

        //public MotionPopupDelegate CloseMotionPopupEventHandler;
        #endregion

        #region 델리게이트
        private delegate void UpdateUIDelegate();

        //public delegate void MotionPopupDelegate(UnitName unitName);
        #endregion

        #region 생성자
        public OpticTeachingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void OpticTeachingForm_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();
            InitializeData();

            lblCamInfo.Text = $"CAM : {LineCamera.Camera.Name}";

            //SelectedAxis = AxisHandler.GetAxis(AxisName.X);

            StatusTimer.Start();
        }

        private void OpticTeachingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParamTrackingLogger.ClearChangedLog();
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);
        }

        private void AddControl()
        {
            DrawBoxControl = new DrawBoxControl();
            DrawBoxControl.Dock = DockStyle.Fill;
            pnlDrawBox.Controls.Add(DrawBoxControl);

            DataGraphControl = new DataGraphControl();
            DataGraphControl.Dock = DockStyle.Fill;
            pnlHistogram.Controls.Add(DataGraphControl);
        }

        private void InitializeData()
        {
        }

        public void UpdateUI()
        {
            if (this.InvokeRequired)
            {
                UpdateUIDelegate callback = UpdateUI;
                BeginInvoke(callback);
                return;
            }

            //UpdateMotionStatus();
        }

        private void UpdateCurrentdata()
        {
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

                if (ParamTrackingLogger.IsEmpty == false)
                {
                    ParamTrackingLogger.AddLog("Optic Teaching Parameter saved.");
                    ParamTrackingLogger.WriteLogToFile();
                }

                MessageConfirmForm confirmForm = new MessageConfirmForm();
                confirmForm.Message = "Save Model Completed.";
                confirmForm.ShowDialog();
            }
        }

        private void SaveModelData(AppsInspModel model)
        {
            UpdateCurrentdata();

            string fileName = System.IO.Path.Combine(ConfigSet.Instance().Path.Model, model.Name, InspModel.FileName);
            InspModelService?.Save(fileName, model);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMotionPopup_Click(object sender, EventArgs e)
        {
        }

        private void LiveDisplay(string cameraName, Mat image)
        {
            if (image == null)
                return;

            var camera = LineCamera.Camera;

            if(camera is ICameraTDIavailable tdiCamera)
            {
                if (tdiCamera.TDIOperationMode == TDIOperationMode.Area)
                {
                    int tdiStage = tdiCamera.TDIStages;
                    tdiStage = 256;
                    // Orginal Data를 Transpose해 Queue에 쌓아 Crop 시 Width, Height가 반대임
                    Mat cropImage = MatHelper.CropRoi(image, new Rectangle(0, 0, tdiStage, camera.ImageWidth));
           
                    Bitmap bmp = cropImage.ToBitmap();
                    DrawBoxControl.SetImage(bmp);

                    cropImage.Dispose();
                }
                else
                {
                    DrawBoxControl.SetImage(image.ToBitmap());
                }
            }
            image.Dispose();
        }

        private void btnGrabStart_Click(object sender, EventArgs e)
        {
            StartGrab(false);
        }

        private void StartGrab(bool isRepeat)
        {
            StopGrab();

            //if (isRepeat)
            //{
            //    AppsInspModel inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;
            //    double length = Convert.ToDouble(lblScanXLength.Text);

            //    LineCamera.ClearTabScanBuffer();
            //    // Motion 이동 추가
            //    LineCamera.StartGrab((float)length);
            //}
            //else
            //{
            //    LineCamera.StartGrabContinous();
            //}
        }

        private void btnGrabStop_Click(object sender, EventArgs e)
        {
            LineCamera.IsLive = false;
            StopGrab();
        }

        float[] OrgHistData;
        byte[] OrgCompressedData;
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ReadOnlyChecked = true;
            dlg.Filter = "BMP Files (*.bmp)|*.bmp; | "
                + "JPG Files (*.jpg, *.jpeg)|*.jpg; *.jpeg; |"
                + "모든 파일(*.*) | *.*;";
            dlg.ShowDialog();

            if (dlg.FileName != "")
            {
                string extension = Path.GetExtension(dlg.FileName);
                Mat image = null;

                if (extension == ".bmp")
                {
                    image = new Mat(dlg.FileName, ImreadModes.Grayscale);
                }
                else if (extension == ".jpg" || extension == ".jpeg")
                {
                    if (GetHalfFilePath(dlg.FileName, out string leftFilePath, out string rightFilePath))
                    {
                        Mat leftMatImage = new Mat(leftFilePath, ImreadModes.Grayscale);
                        Mat rightMatImage = new Mat(rightFilePath, ImreadModes.Grayscale);

                        Size mergeSize = new Size(leftMatImage.Width + rightMatImage.Width, leftMatImage.Height);
                        image = new Mat(mergeSize, DepthType.Cv8U, 1);
                        CvInvoke.HConcat(leftMatImage, rightMatImage, image);

                        leftMatImage.Dispose();
                        rightMatImage.Dispose();
                    }
                    else
                    {
                        MessageConfirmForm form = new MessageConfirmForm();
                        form.Message = "The file name format is incorrect.";
                        form.ShowDialog();
                        return;
                    }
                }

                if (image == null)
                    return;

                DrawBoxControl.SetImage(image.ToBitmap());

                CalculateHistogram(image);
                CalculateCompressedImageData(image);
            }
        }

        private bool GetHalfFilePath(string fileName, out string leftFilePath, out string rightFilePath)
        {
            leftFilePath = "";
            rightFilePath = "";

            string dir = Path.GetDirectoryName(fileName);
            string name = Path.GetFileName(fileName);

            if (name.Contains("Left"))
            {
                string rightName = name.Replace("Left", "Right");
                leftFilePath = fileName;
                rightFilePath = Path.Combine(dir, rightName);
            }
            else if (name.Contains("Right"))
            {
                rightFilePath = fileName;
                string leftName = name.Replace("Right", "Left");
                leftFilePath = Path.Combine(dir, leftName);
            }

            if (leftFilePath != "" && rightFilePath != "")
            {
                bool isLeftExist = File.Exists(leftFilePath);
                bool isRightExist = File.Exists(rightFilePath);

                if (isLeftExist && isRightExist)
                    return true;
            }

            return false;
        }

        private void DataViewOptions_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            string name = radio.Name;

            if (rdoGraphArrowTypeView.Checked)
            {
                DataGraphControl.SetPenColor(Color.Blue);
                DrawBoxControl.Refresh();
            }
            else if (rdoGraphHistTypeView.Checked)
            {
                DataGraphControl.SetCaption("GrayLevel", "Count");
                DataGraphControl.SetPenColor(Color.Yellow);
                DataGraphControl.SetData(OrgHistData);
            }
            else if (rdoGraphCompressedTypeView.Checked)
            {
                if (OrgCompressedData == null)
                    return;

                float[] compressedData = OrgCompressedData.Select(value => Convert.ToSingle(value)).ToArray();
                DataGraphControl.SetPenColor(Color.IndianRed);
                DataGraphControl.SetCaption("Pixel", "Deviation");
                DataGraphControl.SetData(compressedData);
            }
            else if (rdoGraphDerivedTypeView.Checked)
            {
                if (OrgCompressedData == null)
                    return;

                float[] derived2ndData = MathHelper.GetDerivedArray(OrgCompressedData, 2).Select(value => Convert.ToSingle(value)).ToArray();
                DataGraphControl.SetPenColor(Color.OrangeRed);
                DataGraphControl.SetCaption("Pixel", "Deviation");
                DataGraphControl.SetData(derived2ndData);
            }
            else if (rdoGraphMoveAvgTypeView.Checked)
            {
                if (OrgCompressedData == null)
                    return;

                float[] derived2ndData = MathHelper.GetDerivedArray(OrgCompressedData, 2).Select(value => Convert.ToSingle(value)).ToArray();
                float[] movingAverage = MathHelper.GetMovingAverage(derived2ndData, 2);
                DataGraphControl.SetPenColor(Color.SaddleBrown);
                DataGraphControl.SetCaption("Pixel", "Deviation");
                DataGraphControl.SetData(movingAverage);
            }
        }

        private void CalculateHistogram(Mat image)
        {
            OrgHistData = MatHelper.GetHistogram(image, null);
        }

        private void CalculateCompressedImageData(Mat image)
        {
            Mat avgResult = new Mat();
            CvInvoke.Reduce(image, avgResult, ReduceDimension.SingleRow, ReduceType.ReduceAvg, image.Depth);
            CvInvoke.Normalize(avgResult, avgResult, 0, 255, NormType.MinMax, image.Depth);
            OrgCompressedData = new byte[avgResult.Width * avgResult.Height];
            Marshal.Copy(avgResult.DataPointer, OrgCompressedData, 0, OrgCompressedData.Length);
        }

        private void StopGrab()
        {
            //LineCamera.StopGrab();
        }

        private void OpticTeachingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopGrab();

            DrawBoxControl.DisposeImage();
            StatusTimer.Stop();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        public delegate void UpdateGrabButtonDele(bool isEnable);
        private void UpdateGrabButton(bool isEnable)
        {
            if(this.InvokeRequired)
            {
                UpdateGrabButtonDele callback = UpdateGrabButton;
                BeginInvoke(callback, isEnable);
                return;
            }

            btnGrabStart.Enabled = isEnable;
            btnGrabStop.Enabled = isEnable;
        }
        #endregion

        private void trkDataXMin_Scroll(object sender, EventArgs e)
        {
        }

        private void trkDataXMax_Scroll(object sender, EventArgs e)
        {

        }

        private void trkDataYMin_Scroll(object sender, EventArgs e)
        {

        }

        private void trkDataYMax_Scroll(object sender, EventArgs e)
        {

        }
    }
}
