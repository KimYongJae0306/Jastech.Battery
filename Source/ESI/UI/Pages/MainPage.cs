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
        private CompactDefectMapControl _defectMapControl = null;

        private DefectInfoContainerControl _defectInfoContainerControl = null;

        private GLDrawBoxControl _upperDrawBoxControl = null;

        private GLDrawBoxControl _lowerDrawBoxControl = null;

        private DoubleBufferedPanel _pnlDataArea = null;

        private DataGridView _dgvDefectData = null;

        private DataGraphControl _dataGraphControl = null;

        private readonly BindingList<DefectInfo> _defectInfos = new BindingList<DefectInfo>();      // UI 클래스말고 외부로 빼야함

        private Queue<DefectInfo> _dfsQueue = new Queue<DefectInfo>();

        private Task _defectHandlingTask = null;      // UI 클래스말고 외부로 빼야함

        public CancellationTokenSource _cancellationDefectHandling = null;
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
            AddControls();
            ClearDatas();
            InitializeTasks();
        }

        private void AddControls()
        {
            _upperDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            _lowerDrawBoxControl = new GLDrawBoxControl { Dock = DockStyle.Fill };
            _defectMapControl = new CompactDefectMapControl { Dock = DockStyle.Fill };
            _pnlDataArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };
            _defectInfoContainerControl = new DefectInfoContainerControl { Dock = DockStyle.Fill };
            _dataGraphControl = new DataGraphControl {  Dock = DockStyle.Fill };
            _dgvDefectData = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                AllowUserToResizeRows = false,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                Dock = DockStyle.Fill,
                GridColor = Color.FromArgb(52, 52, 52),
                BackgroundColor = Color.FromArgb(52, 52, 52),
                EditMode = DataGridViewEditMode.EditProgrammatically,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ColumnHeadersHeight = 25,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("맑은고딕", 13, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(26, 26, 26),
                    SelectionBackColor = Color.FromArgb(26, 26, 26),
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = SystemColors.Window,
                    ForeColor = Color.Black,
                    SelectionForeColor = Color.White,
                    SelectionBackColor = Color.MediumPurple,
                }
            };

            _upperDrawBoxControl.DisableFunctionButtons();
            _lowerDrawBoxControl.DisableFunctionButtons();

            _dataGraphControl.Initialize();
            _dataGraphControl.SetCaption("m", "mm");
            _dataGraphControl.AddLegend("Left", 0, Color.LightSalmon);
            _dataGraphControl.AddLegend("Center", 1, Color.DodgerBlue);
            _dataGraphControl.AddLegend("Right", 2, Color.LimeGreen);

            _dgvDefectData.DataSource = _defectInfos;
            _defectInfoContainerControl.isVertical = false;
            _defectMapControl.SelectedDefectChanged += _defectInfoContainerControl.SelectedControlIndexChanged;

            pnlDefectMap.Controls.Add(_defectMapControl);
            pnlUpperImage.Controls.Add(_upperDrawBoxControl);
            pnlLowerImage.Controls.Add(_lowerDrawBoxControl);
            tlpDataLayout.Controls.Add(_pnlDataArea, 0, 1);
            tlpDataLayout.SetColumnSpan(_pnlDataArea, 7);
            SelectDefectData_Click(null, null); 
        }

        private void ClearDatas()
        {
            _defectInfos.Clear();
            _defectMapControl.Clear();
            _defectInfoContainerControl.Clear();
            _dataGraphControl.Clear();
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

                _defectInfos.Add(defectInfo);
                _defectInfoContainerControl.AddDefectInfo(defectInfo);
                _defectMapControl.AddCoordinate(defectInfo);

                _defectInfoContainerControl.AddDefectInfo(defectInfo);
                _defectMapControl.AddCoordinate(defectInfo);

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
            }
        }

        private void Test_Click(object sender, EventArgs e)
        {
            string imgPath = string.Empty;
            Random rand = new Random();

            Bitmap testUpperBitmap = null;
            Bitmap testLowerBitmap = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ReadOnlyChecked = true;
            ofd.Filter = "BMP Files (*.bmp)|*.bmp; | "
                + "JPG Files (*.jpg, *.jpeg)|*.jpg; *.jpeg; |"
                + "모든 파일(*.*) | *.*;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
                imgPath = ofd.FileName;

            if (imgPath == string.Empty)
                return;

            testUpperBitmap = new Bitmap(imgPath);
            testLowerBitmap = new Bitmap(imgPath);

            ClearDatas();

            Task.Run(async () =>
            {
                try
                {
                    List<long> ttimes = new List<long>();
                    //_upperDrawBoxControl.EnableBrush = false;
                    //_lowerDrawBoxControl.EnableBrush = false;
                    for (int yValue = 0; yValue <= _defectMapControl.maximumMeter * 50000; yValue += 50000)
                    {
                        Stopwatch stopwatch = Stopwatch.StartNew();

                        if (rand.Next(1) == 0)
                        {
                            var testInfo = new DefectInfo
                            {
                                Index = _defectInfos.Count,
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

                        float testLeftMismatch = (rand.Next(1000, 1150) / 100f);
                        float testCenterMismatch = (rand.Next(2300, 2550) / 100f);
                        float testRightMismatch = (rand.Next(1200, 1300) / 100f);

                        _dataGraphControl.AddData("Left", testLeftMismatch);
                        _dataGraphControl.AddData("Center", testCenterMismatch);
                        _dataGraphControl.AddData("Right", testRightMismatch, true);

                        _defectMapControl.MaximumY = yValue;

                        var startTime = stopwatch.ElapsedMilliseconds;

                        _upperDrawBoxControl.SetImage(testUpperBitmap, false);
                        var setImage1TT = stopwatch.ElapsedMilliseconds - startTime;

                        _lowerDrawBoxControl.SetImage(testLowerBitmap, false);
                        var setImage2TT = stopwatch.ElapsedMilliseconds - setImage1TT;

                        //_upperDrawBoxControl.FitZoom();
                        //_lowerDrawBoxControl.FitZoom();

                        stopwatch.Stop();

                        ttimes.Add(setImage1TT);
                        ttimes.Add(setImage2TT);

                        await Task.Delay(100 - (int)stopwatch.ElapsedMilliseconds);
                    }
                    //_upperDrawBoxControl.EnableBrush = true;
                    //_lowerDrawBoxControl.EnableBrush = true;


                    MessageBox.Show($"SetImage 평균 소요시간 {ttimes.Average()}ms, 최대 소요시간 {ttimes.Max()}, 최소 소요시간 {ttimes.Min()}");
                }
                catch (Exception ex)
                {

                }
            });
        }

        private void ClearDataViewSelection()
        {
            foreach (Control control in tlpDataLayout.Controls)
            {
                if (control is Button button)
                {
                    button.ForeColor = Color.FromArgb(52, 52, 52);
                    button.FlatAppearance.BorderSize = 0;
                }
            }
            _pnlDataArea.Controls.Clear();
        }

        private void SelectDefectData_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            _pnlDataArea.Controls.Add(_dgvDefectData);
            btnDefectData.ForeColor = Color.White;
            btnDefectData.FlatAppearance.BorderSize = 3;
        }

        private void SelectDefectImage_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            _pnlDataArea.Controls.Add(_defectInfoContainerControl);
            btnDefectImage.ForeColor = Color.White;
            btnDefectImage.FlatAppearance.BorderSize = 3;
        }

        private void SelectMisMatch_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            _pnlDataArea.Controls.Add(_dataGraphControl);
            btnUpperLowerMismatch.ForeColor = Color.White;
            btnUpperLowerMismatch.FlatAppearance.BorderSize = 3;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _upperDrawBoxControl.Width = pnlUpperImage.Width / 2;
            _lowerDrawBoxControl.Width = pnlLowerImage.Width / 2;
            _defectInfoContainerControl.Size = _pnlDataArea.Size;
            _defectMapControl.Invalidate();
        }
    }
}
