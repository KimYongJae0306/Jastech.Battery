using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Battery.Structure.Data;
using Jastech.Framework.Winform.Helper;
using System.Drawing.Drawing2D;
using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Winform.Controls;
using static Jastech.Battery.Structure.Data.DefectDefine;      //테스트 후 삭제
using System.IO;
using System.Threading;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using Emgu.CV;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace ESI.UI.Pages
{
    public partial class MainPage : UserControl
    {
        #region 필드
        public Dictionary<DefectTypes, int> _defectCounts;
        #endregion

        #region 속성
        private CompactDefectMapControl DefectMapControl { get; set; } = null;

        private DefectInfoContainerControl DefectInfoContainerControl { get; set; } = null;

        private GLDrawBoxControl UpperDrawBoxControl { get; set; } = null;

        private GLDrawBoxControl LowerDrawBoxControl { get; set; } = null;

        private DoubleBufferedPanel dpnlDataArea { get; set; } = null;

        private DataGraphControl SideMismatchGraphControl { get; set; } = null;

        private DataGraphControl CenterMismatchGraphControl { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        #endregion

        private void MainPage_Load(object sender, EventArgs e)
        {
            InitializeDrawBoxControls();
            InitializeChartControl();
            InitializeMiscellaneousControls();
            InitializeDefectSummry();
            AddControls();

            ClearDatas();
        }

        private void AddControls()
        {
            pnlDefectMap.Controls.Add(DefectMapControl);
            pnlUpperImage.Controls.Add(UpperDrawBoxControl);
            pnlLowerImage.Controls.Add(LowerDrawBoxControl);
            pnlDefectInfoArea.Controls.Add(DefectInfoContainerControl);
            pnlMismatchChart1.Controls.Add(SideMismatchGraphControl);
            pnlMismatchChart2.Controls.Add(CenterMismatchGraphControl);
        }

        private void InitializeMiscellaneousControls()
        {
            DefectMapControl = new CompactDefectMapControl { Dock = DockStyle.Fill };
            dpnlDataArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };
            DefectInfoContainerControl = new DefectInfoContainerControl
            {
                Dock = DockStyle.Fill,
                IsVertical = true
            };
            DefectMapControl.SelectedDefectChanged += DefectInfoContainerControl.SelectedControlIndexChanged;
            DefectInfoContainerControl.SelectedDefectChanged += DefectMapControl.ChangeSelectedDefect;
        }

        private void InitializeDrawBoxControls()
        {
            UpperDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            LowerDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            UpperDrawBoxControl.DisableFunctionButtons();
            LowerDrawBoxControl.DisableFunctionButtons();
        }

        private void InitializeDefectSummry()
        {
            var padding = 10;
            _defectCounts = new Dictionary<DefectTypes, int>();
            foreach (DefectTypes defectType in Enum.GetValues(typeof(DefectTypes)))
                _defectCounts.Add(defectType, 0);  
            using (var g = pnlSummary.CreateGraphics())
            {
                lblDefectSummaryPinhole.Width = (int)Math.Ceiling(g.MeasureString(lblDefectSummaryPinhole.Text, Font).Width) + padding;
                lblDefectSummaryDent.Width = (int)Math.Ceiling(g.MeasureString(lblDefectSummaryDent.Text, Font).Width) + padding;
                lblDefectSummaryCrater.Width = (int)Math.Ceiling(g.MeasureString(lblDefectSummaryCrater.Text, Font).Width) + padding;
                lblDefectSummaryIsland.Width = (int)Math.Ceiling(g.MeasureString(lblDefectSummaryIsland.Text, Font).Width) + padding;
                lblDefectSummaryDrag.Width = (int)Math.Ceiling(g.MeasureString(lblDefectSummaryDrag.Text, Font).Width) + padding;
            }
            lblDefectSummaryPinholeEllipse.ForeColor = Colors[DefectTypes.Pinhole];
            lblDefectSummaryDentEllipse.ForeColor = Colors[DefectTypes.Dent];
            lblDefectSummaryCraterEllipse.ForeColor = Colors[DefectTypes.Crater];
            lblDefectSummaryIslandEllipse.ForeColor = Colors[DefectTypes.Island];
            lblDefectSummaryDragEllipse.ForeColor = Colors[DefectTypes.Drag];
        }

        private void InitializeChartControl()
        {
            SideMismatchGraphControl = new DataGraphControl { Dock = DockStyle.Fill };
            CenterMismatchGraphControl = new DataGraphControl { Dock = DockStyle.Fill };

            SideMismatchGraphControl.Initialize();
            SideMismatchGraphControl.SetCaption(captionAxisX: "m", captionAxisY: "mm");
            SideMismatchGraphControl.AddLegend("Left_Upper", 0, Color.LightSalmon);
            SideMismatchGraphControl.AddLegend("Right_Upper", 1, Color.LimeGreen);
            SideMismatchGraphControl.AddLegend("Left_Lower", 2, Color.LightCoral);
            SideMismatchGraphControl.AddLegend("Right_Lower", 3, Color.LightSeaGreen);

            CenterMismatchGraphControl.Initialize();
            CenterMismatchGraphControl.SetCaption(captionAxisX: "m", captionAxisY: "mm");
            CenterMismatchGraphControl.AddLegend("Missmatch_Upper", 0, Color.LightSalmon);
            CenterMismatchGraphControl.AddLegend("Missmatch_Lower", 1, Color.DodgerBlue);
        }

        private void ClearDatas()
        {
            DefectMapControl.Clear();
            DefectInfoContainerControl.Clear();
            SideMismatchGraphControl.Clear();
            CenterMismatchGraphControl.Clear();
            for (int index = 0; index < _defectCounts.Count; index++)
                _defectCounts[(DefectTypes)index] = 0;
        }

        private void Test_Click(object sender, EventArgs e)
        {
            bool isMultipleImages = false;

            string imgPath = string.Empty;
            Random rand = new Random();

            Bitmap testUpperBitmap = null;
            Bitmap testLowerBitmap = null;

            List<Bitmap> testUpperBitmaps = new List<Bitmap>();
            List<Bitmap> testLowerBitmaps = new List<Bitmap>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ReadOnlyChecked = true;
            ofd.Filter = "BMP Files (*.bmp)|*.bmp; | "
                + "JPG Files (*.jpg, *.jpeg)|*.jpg; *.jpeg; |"
                + "모든 파일(*.*) | *.*;";
            ofd.ShowDialog();
            if(ofd.FileNames.Length > 1)
            {
                isMultipleImages = true;
                foreach (var name in ofd.FileNames)
                {
                    imgPath = name;
                    testUpperBitmaps.Add(new Bitmap(name));
                    testLowerBitmaps.Add(new Bitmap(name));
                }
            }
            else
            {
                if (ofd.FileName == "")
                    return;

                imgPath = ofd.FileName;
                testUpperBitmap = new Bitmap(imgPath);
                testLowerBitmap = new Bitmap(imgPath);
            }


            ClearDatas();

            Task.Run(async () =>
            {
                try
                {
                    for (int yValue = 0; yValue < DefectMapControl.MaximumMeter * 50000; yValue += 50000)
                    {
                        if (rand.Next(20) == 0)
                        {
                            List<DefectInfo> defectInfos = new List<DefectInfo>();
                            int loop = rand.Next(1, 5);
                            while (loop-- > 0)
                            {
                                var testInfo = new DefectInfo
                                {
                                    InspectionTime = DateTime.Now,
                                    Judgement = (DefectJudge)Enum.GetValues(typeof(DefectJudge)).GetValue(rand.Next(1, 4)),
                                    DefectLevel = rand.Next(1, 6),
                                    DefectType = (DefectTypes)rand.Next(1, 6),
                                    CameraName = rand.Next(2) == 0 ? "Upper" : "Lower",
                                    Lane = 1
                                };
                                testInfo.Index = testInfo.GetHashCode();

                                testInfo.SetFeatureDataType(FeatureTypes.X, typeof(float));
                                testInfo.SetFeatureDataType(FeatureTypes.Y, typeof(float));
                                testInfo.SetFeatureDataType(FeatureTypes.Width, typeof(float));
                                testInfo.SetFeatureDataType(FeatureTypes.Height, typeof(float));
                                testInfo.SetFeatureDataType(FeatureTypes.LocalImagePath, typeof(string));

                                testInfo.SetFeatureValue(FeatureTypes.X, rand.Next(16384));            // TODO: maximage width 받을 것
                                testInfo.SetFeatureValue(FeatureTypes.Y, yValue);
                                testInfo.SetFeatureValue(FeatureTypes.Width, 7f + rand.Next(0, 10) / 10f);
                                testInfo.SetFeatureValue(FeatureTypes.Height, 3f + rand.Next(70, 150) / 10f);

                                if (File.Exists(@"Y:\TestImg.bmp"))
                                    testInfo.SetFeatureValue(FeatureTypes.LocalImagePath, @"Y:\TestImg.bmp");
                                else
                                    testInfo.SetFeatureValue(FeatureTypes.LocalImagePath, imgPath);

                                _defectCounts[testInfo.DefectType]++;

                                defectInfos.Add(testInfo);
                                //_dfsQueue.Enqueue(testInfo);
                            }

                            BeginInvoke(new Action(() =>
                            {
                                DefectInfoContainerControl.AddDefectInfo(defectInfos);
                                DefectMapControl.AddCoordinate(defectInfos);

                                lblDefectSummaryPinholeValue.Text = $"{_defectCounts[DefectTypes.Pinhole]}ea";
                                lblDefectSummaryDentValue.Text = $"{_defectCounts[DefectTypes.Dent]}ea";
                                lblDefectSummaryCraterValue.Text = $"{_defectCounts[DefectTypes.Crater]}ea";
                                lblDefectSummaryIslandValue.Text = $"{_defectCounts[DefectTypes.Island]}ea";
                                lblDefectSummaryDragValue.Text = $"{_defectCounts[DefectTypes.Drag]}ea";
                            }));

                            UpperDrawBoxControl.SetOverlay(new List<OverlayGraphic> { new OverlayGraphic(new Point(30, 30), new Point(200, 200)) });
                            LowerDrawBoxControl.SetOverlay(new List<OverlayGraphic> { new OverlayGraphic(new Point(30, 30), new Point(200, 200)) });
                        }

                        float testLeftUpperMismatch = (rand.Next(1700, 1800) / 100f);
                        float testRightUpperMismatch = (rand.Next(1200, 1300) / 100f);
                        float testLeftLowerMismatch = (rand.Next(1800, 1950) / 100f);
                        float testRightLowerMismatch = (rand.Next(1111, 1222) / 100f);
                        float testUpperMismatch = Math.Abs(testLeftUpperMismatch - testRightUpperMismatch);
                        float testLowerMismatch = Math.Abs(testLeftLowerMismatch - testRightLowerMismatch);

                        float testCenterLowerMismatch = (rand.Next(1900, 2150) / 100f);
                        float testCenterUpperMismatch = (rand.Next(2300, 2550) / 100f);

                        SideMismatchGraphControl.AddData(0, testLeftUpperMismatch);
                        SideMismatchGraphControl.AddData(1, testRightUpperMismatch);
                        SideMismatchGraphControl.AddData(2, testLeftLowerMismatch);
                        SideMismatchGraphControl.AddData(3, testRightLowerMismatch, true);
                        
                        CenterMismatchGraphControl.AddData(0, testUpperMismatch);
                        CenterMismatchGraphControl.AddData(1, testLowerMismatch, true);

                        DefectMapControl.MaximumY = yValue + 50000;

                        if (isMultipleImages)
                        {
                            UpperDrawBoxControl.SetImage(testUpperBitmaps[(yValue / 50000) % testUpperBitmaps.Count], false);
                            LowerDrawBoxControl.SetImage(testLowerBitmaps[(yValue / 50000) % testLowerBitmaps.Count], false);
                        }
                        else
                        {
                            UpperDrawBoxControl.SetImage(testUpperBitmap, false);
                            LowerDrawBoxControl.SetImage(testLowerBitmap, false);
                        }
                        UpperDrawBoxControl.FitZoom();
                        LowerDrawBoxControl.FitZoom();

                        await Task.Delay(50);
                    }
                }
                catch (Exception ex)
                {

                }
            });
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            UpperDrawBoxControl.Width = pnlUpperImage.Width / 2;
            LowerDrawBoxControl.Width = pnlLowerImage.Width / 2;
            DefectInfoContainerControl.Size = dpnlDataArea.Size;
            Invalidate(true);
        }
    }
}
