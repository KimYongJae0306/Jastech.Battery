﻿using Emgu.CV;
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

        public LineCamera LineCamera { get; set; }

        private DistanceControl DistanceControl { get; set; } = null;

        private SurfaceControl SurfaceControl { get; set; } = null;

        private DistanceInspResult LastDistanceResult { get; set; } = null;
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
        #endregion

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (_orgBmp == null)
                return;

            Stopwatch stopwatch = Stopwatch.StartNew();
            WriteTactTime(stopwatch, "=================================Test Start=================================");

            var unit = TeachingData.Instance().GetUnit(UnitName.ToString());
            DistanceParam distanceParam = unit?.DistanceParam;

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
            AlgorithmTool algorithmTool = new AlgorithmTool();

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

            DistanceInspResult distanceInspResult = new DistanceInspResult();
            distanceParam._Roi = new Rectangle
            {
                X = distanceParam.ROIMarginLeft,
                Y = distanceParam.ROIMarginLeft,
                Width = imageBuffer.ImageWidth - distanceParam.ROIMarginRight,
                Height = imageBuffer.ImageHeight - distanceParam.ROIMarginBottom,
            };
            algorithmTool.FindSearchAreas(distanceInspResult, imageBuffer, distanceParam);
            algorithmTool.FindInspectionAreas(distanceInspResult, imageBuffer, distanceParam);
            algorithmTool.SeparateRegionsByLane(distanceInspResult, distanceParam);
            sliceInspResult.DistanceResult = distanceInspResult;

            WriteTactTime(stopwatch, "DistanceInspecitonFinished");

            // 추가 검증용 코드
            LastDistanceResult = distanceInspResult;
            ShowTestResults(distanceInspResult);

            WriteTactTime(stopwatch, "=================================Test Finished==============================");
        }

        private void ShowTestResults(DistanceInspResult distanceResult)
        {
            if (_orgBmp == null)
                return;

            int imageWidth = _orgBmp.Width;
            int penSize = (int)(Math.Sqrt(imageWidth) / Math.Log10(imageWidth));
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
            Pen coatingROIpen = new Pen(Color.Yellow, penSize) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            Pen nonCoatingROIpen = new Pen(Color.DarkGreen, penSize) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            Bitmap convertedBitmap = ImageHelper.ConvertGrayscaleToRGB24(_orgBmp);
            {
                using (Graphics g = Graphics.FromImage(convertedBitmap))
                {
                    foreach (Rectangle nonCoatingArea in distanceResult.NonCoatingAreas)
                    {
                        g.DrawLine(nonCoatingWidthPen, nonCoatingArea.Left, nonCoatingArea.Top + nonCoatingArea.Height / 2, nonCoatingArea.Right, nonCoatingArea.Top + nonCoatingArea.Height / 2);
                        g.DrawRectangle(nonCoatingROIpen, nonCoatingArea.Left, nonCoatingArea.Top, nonCoatingArea.Width, nonCoatingArea.Height);
                    }

                    foreach (Rectangle coatingArea in distanceResult.CoatingAreas)
                    {
                        g.DrawLine(coatingWidthPen, coatingArea.Left, coatingArea.Top + coatingArea.Height / 2, coatingArea.Right, coatingArea.Top + coatingArea.Height / 2);
                        g.DrawRectangle(coatingROIpen, coatingArea.Left, coatingArea.Top, coatingArea.Width, coatingArea.Height);
                    }

                    g.Save();
                }
                ImageViewerControl.SetInternalImage((Bitmap)convertedBitmap);

                //var tempDiag = new Form { Size = new Size(500, 500), StartPosition = FormStartPosition.CenterParent };
                //tempDiag.Controls.Add(new PictureBox { Image = cloneBitmap, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom });
                //tempDiag.ShowDialog();
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

        private void testVerticalSamplingResult_Click(object sender, EventArgs e)
        {
            if (LastDistanceResult != null)
                PixelValueGraphControl.SetData(LastDistanceResult?.VerticalSamplingResults.ToArray());
        }

        private void testHorizontalSamplingResult_Click(object sender, EventArgs e)
        {
            if (LastDistanceResult != null)
                PixelValueGraphControl.SetData(LastDistanceResult?.HorizontalSamplingResults.ToArray());
        }

        private void testVerticalDerivedResult_Click(object sender, EventArgs e)
        {
            if (LastDistanceResult != null)
                PixelValueGraphControl.SetData(LastDistanceResult?.VerticalDifferentials.ToArray());
        }

        private void testHorizontalDerivedResult_Click(object sender, EventArgs e)
        {
            if (LastDistanceResult != null)
                PixelValueGraphControl.SetData(LastDistanceResult?.HorizontalDifferentials.ToArray());
        }
    }

    public enum DisplayType
    {
        Distance,
        Surface,
    }
}
