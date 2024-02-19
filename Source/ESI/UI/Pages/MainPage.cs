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

namespace ESI.UI.Pages
{
    public partial class MainPage : UserControl
    {
        #region 필드
        private CompactDefectMapControl _defectMapControl = null;   // TODO : Control은 Property로

        private DefectInfoContainerControl _defectInfoContainerControl = null;

        private GLDrawBoxControl _upperDrawBoxControl = null;

        private GLDrawBoxControl _lowerDrawBoxControl = null;

        private DoubleBufferedPanel _pnlDataArea = null;

        private DataGraphControl _missmatchDataGraphControl1 = null;

        private DataGraphControl _missmatchDataGraphControl2 = null;

        private Queue<DefectInfo> _dfsQueue = new Queue<DefectInfo>();

        private Task _defectHandlingTask = null;      // TODO : UI 클래스말고 외부로 빼야함

        public CancellationTokenSource _cancellationDefectHandling = null;

        public Dictionary<DefectTypes, int> _defectCounts;
        #endregion

        #region 속성
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
            InitializeTasks();
        }

        private void AddControls()
        {
            pnlDefectMap.Controls.Add(_defectMapControl);
            pnlUpperImage.Controls.Add(_upperDrawBoxControl);
            pnlLowerImage.Controls.Add(_lowerDrawBoxControl);
            pnlDefectInfoArea.Controls.Add(_defectInfoContainerControl);
            pnlMismatchChart1.Controls.Add(_missmatchDataGraphControl1);
            pnlMismatchChart2.Controls.Add(_missmatchDataGraphControl2);
        }

        private void InitializeMiscellaneousControls()
        {
            _defectMapControl = new CompactDefectMapControl { Dock = DockStyle.Fill };
            _pnlDataArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };
            _defectInfoContainerControl = new DefectInfoContainerControl
            {
                Dock = DockStyle.Fill,
                IsVertical = true
            };
            _defectMapControl.SelectedDefectChanged += _defectInfoContainerControl.SelectedControlIndexChanged;
        }

        private void InitializeDrawBoxControls()
        {
            _upperDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            _lowerDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            _upperDrawBoxControl.DisableFunctionButtons();
            _lowerDrawBoxControl.DisableFunctionButtons();
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
            _missmatchDataGraphControl1 = new DataGraphControl { Dock = DockStyle.Fill };
            _missmatchDataGraphControl2 = new DataGraphControl { Dock = DockStyle.Fill };

            _missmatchDataGraphControl1.Initialize();
            _missmatchDataGraphControl1.SetCaption(captionAxisX: "m", captionAxisY: "mm");
            _missmatchDataGraphControl1.AddLegend("Left_Upper", 0, Color.LightSalmon);
            _missmatchDataGraphControl1.AddLegend("Right_Upper", 1, Color.LimeGreen);
            _missmatchDataGraphControl1.AddLegend("Left_Lower", 2, Color.LightCoral);
            _missmatchDataGraphControl1.AddLegend("Right_Lower", 3, Color.LightSeaGreen);

            _missmatchDataGraphControl2.Initialize();
            _missmatchDataGraphControl2.SetCaption(captionAxisX: "m", captionAxisY: "mm");
            _missmatchDataGraphControl2.AddLegend("Center_Upper", 0, Color.LightSalmon);
            _missmatchDataGraphControl2.AddLegend("Center_Lower", 1, Color.DodgerBlue);
            _missmatchDataGraphControl2.AddLegend("Center_Missmatch", 2, Color.FloralWhite);
        }

        private void ClearDatas()
        {
            _defectMapControl.Clear();
            _defectInfoContainerControl.Clear();
            _missmatchDataGraphControl1.Clear();
            _missmatchDataGraphControl2.Clear();
            for (int index = 0; index < _defectCounts.Count; index++)
                _defectCounts[(DefectTypes)index] = 0;
        }

        private void InitializeTasks()
        {
            _cancellationDefectHandling = new CancellationTokenSource();
            _defectHandlingTask = new Task(new Action(async () =>
            {
                var checkQueueDelegate = new Action(CheckQueue);
                while(_cancellationDefectHandling.IsCancellationRequested == false)
                {
                    BeginInvoke(checkQueueDelegate);
                    await Task.Delay(40);
                }
            }), _cancellationDefectHandling.Token, TaskCreationOptions.LongRunning);

            _defectHandlingTask.Start();
        }

        private void CheckQueue()
        {
            while (_dfsQueue.Count > 0)
            {
                var defectInfo = _dfsQueue.Dequeue();

                _defectInfoContainerControl.AddDefectInfo(defectInfo);
                _defectMapControl.AddCoordinate(defectInfo);
                _defectCounts[defectInfo.DefectType]++;

                lblDefectSummaryPinholeValue.Text = $"{_defectCounts[DefectTypes.Pinhole]}ea";
                lblDefectSummaryDentValue.Text = $"{_defectCounts[DefectTypes.Dent]}ea";
                lblDefectSummaryCraterValue.Text = $"{_defectCounts[DefectTypes.Crater]}ea";
                lblDefectSummaryIslandValue.Text = $"{_defectCounts[DefectTypes.Island]}ea";
                lblDefectSummaryDragValue.Text = $"{_defectCounts[DefectTypes.Drag]}ea";

                if (defectInfo.CameraName == "Upper")
                {
                    btnUpperJudgement.Text = defectInfo.Judgement;
                    btnUpperJudgement.BackColor = defectInfo.Judgement == "NG" ? Color.Red : Color.LimeGreen;
                }
                else
                {
                    btnLowerJudgement.Text = defectInfo.Judgement;
                    btnLowerJudgement.BackColor = defectInfo.Judgement == "NG" ? Color.Red : Color.LimeGreen;
                }
                Thread.Sleep(50);
            }
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
                    //_upperDrawBoxControl.EnableBrush = false;  //일반 DrawBox일 때
                    //_lowerDrawBoxControl.EnableBrush = false;
                    for (int yValue = 0; yValue <= _defectMapControl.maximumMeter * 50000; yValue += 50000)
                    {
                        Stopwatch stopwatch = Stopwatch.StartNew();

                        if (rand.Next(20) == 0)
                        {
                            var testInfo = new DefectInfo
                            {
                                Index = yValue/50000,
                                InspectionTime = DateTime.Now,
                                Judgement = "NG",
                                DefectLevel = rand.Next(1, 6),
                                DefectType = (DefectTypes)rand.Next(1, 6),
                                CameraName = rand.Next(2) == 0 ? "Upper" : "Lower",
                                Lane = 1
                            };

                            testInfo.SetFeatureDataType(FeatureTypes.X, typeof(float));
                            testInfo.SetFeatureDataType(FeatureTypes.Y, typeof(float));
                            testInfo.SetFeatureDataType(FeatureTypes.Width, typeof(float));
                            testInfo.SetFeatureDataType(FeatureTypes.Height, typeof(float));
                            testInfo.SetFeatureDataType(FeatureTypes.LocalImagePath, typeof(string));

                            testInfo.SetFeatureValue(FeatureTypes.X, rand.Next(16383));            // TODO: maximage width 받을 것
                            testInfo.SetFeatureValue(FeatureTypes.Y, yValue);
                            testInfo.SetFeatureValue(FeatureTypes.Width, 7f + rand.Next(0, 10) / 10f);
                            testInfo.SetFeatureValue(FeatureTypes.Height, 3f + rand.Next(70, 150) / 10f);

                            if (File.Exists(@"Y:\TestImg.bmp"))
                                testInfo.SetFeatureValue(FeatureTypes.LocalImagePath, @"Y:\TestImg.bmp");
                            else
                                testInfo.SetFeatureValue(FeatureTypes.LocalImagePath, imgPath);

                            _dfsQueue.Enqueue(testInfo);
                        }

                        float testLeftUpperMismatch = (rand.Next(1700, 1800) / 100f);
                        float testRightUpperMismatch = (rand.Next(1200, 1300) / 100f);
                        float testLeftLowerMismatch = (rand.Next(1800, 1950) / 100f);
                        float testRightLowerMismatch = (rand.Next(1111, 1222) / 100f);

                        float testCenterLowerMismatch = (rand.Next(1900, 2150) / 100f);
                        float testCenterUpperMismatch = (rand.Next(2300, 2550) / 100f);
                        float testCenterMismatch = Math.Abs(testCenterUpperMismatch - testCenterLowerMismatch);

                        _missmatchDataGraphControl1.AddData(0, testLeftUpperMismatch);
                        _missmatchDataGraphControl1.AddData(1, testRightUpperMismatch);
                        _missmatchDataGraphControl1.AddData(2, testLeftLowerMismatch);
                        _missmatchDataGraphControl1.AddData(3, testRightLowerMismatch, true);
                        
                        _missmatchDataGraphControl2.AddData(0, testCenterLowerMismatch);
                        _missmatchDataGraphControl2.AddData(1, testCenterUpperMismatch, true);
                        _missmatchDataGraphControl2.AddData(2, testCenterMismatch, true);

                        _defectMapControl.MaximumY = yValue;

                        var startTime = stopwatch.ElapsedMilliseconds;

                        if (isMultipleImages)
                        {
                            _upperDrawBoxControl.SetImage(testUpperBitmaps[(yValue / 50000) % testUpperBitmaps.Count], false);
                            _lowerDrawBoxControl.SetImage(testLowerBitmaps[(yValue / 50000) % testLowerBitmaps.Count], false);
                        }
                        else
                        {
                            _upperDrawBoxControl.SetImage(testUpperBitmap, false);
                            _lowerDrawBoxControl.SetImage(testLowerBitmap, false);
                        }
                        _upperDrawBoxControl.FitZoom();
                        _lowerDrawBoxControl.FitZoom();

                        stopwatch.Stop();

                        await Task.Delay(50);
                    }
                    //_upperDrawBoxControl.EnableBrush = true;  //일반 DrawBox일 때
                    //_lowerDrawBoxControl.EnableBrush = true;
                }
                catch (Exception ex)
                {

                }
            });
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _upperDrawBoxControl.Width = pnlUpperImage.Width / 2;
            _lowerDrawBoxControl.Width = pnlLowerImage.Width / 2;
            _defectInfoContainerControl.Size = _pnlDataArea.Size;
            Invalidate(true);
        }
    }
}
