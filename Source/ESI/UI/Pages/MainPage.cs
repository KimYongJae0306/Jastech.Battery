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

namespace ESI.UI.Pages
{
    public partial class MainPage : UserControl
    {
        #region 필드
        private CompactDefectMapControl _defectMapControl = null;

        private DefectInfoContainerControl _defectInfoContainerControl = null;

        private DrawBoxControl _upperDrawBoxControl = null;

        private DrawBoxControl _lowerDrawBoxControl = null;

        private DataGridView _dgvDefectData = null;

        private DataGraphControl _dataGraphControl = null;

        private readonly BindingList<DefectInfo> _defectInfos = new BindingList<DefectInfo>();
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
        }

        private void AddControls()
        {
            _upperDrawBoxControl = new DrawBoxControl { Dock = DockStyle.Fill };
            _lowerDrawBoxControl = new DrawBoxControl { Dock = DockStyle.Fill };
            _defectMapControl = new CompactDefectMapControl { Dock = DockStyle.Fill };
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
            SelectDefectData_Click(null, null); 
        }

        private void ClearDatas()
        {
            _defectInfos.Clear();
            _defectMapControl.Clear();
            _defectInfoContainerControl.Clear();
            _dataGraphControl.Clear();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            string imgPath = string.Empty;

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

            Bitmap testUpperBitmap = new Bitmap(imgPath);
            Bitmap testLowerBitmap = (Bitmap)testUpperBitmap.Clone();
            Random rand = new Random();

            ClearDatas();

            Task.Run(async () =>
            {
                _upperDrawBoxControl.EnableInteractive(false);
                _lowerDrawBoxControl.EnableInteractive(false);

                for (int yValue = 0; yValue <= _defectMapControl.maximumMeter * 50000; yValue += 50000)
                {
                    if (rand.Next(40) == 0)
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

                        #region 보기싫은 if문
                        BeginInvoke(new Action(() =>
                        {
                            if (testInfo.CameraName == "Upper")
                            {
                                btnUpperJudgement.Text = "NG";
                                btnUpperJudgement.BackColor = Color.Red;
                            }
                            else
                            {
                                btnUpperJudgement.Text = "OK";
                                btnUpperJudgement.BackColor = Color.LimeGreen;
                            }

                            if (testInfo.CameraName == "Lower")
                            {
                                btnLowerJudgement.Text = "NG";
                                btnLowerJudgement.BackColor = Color.Red;
                            }
                            else
                            {
                                btnLowerJudgement.Text = "OK";
                                btnLowerJudgement.BackColor = Color.LimeGreen;
                            }
                        }));
                        #endregion

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

                        BeginInvoke(new Action(() =>
                        {
                            _defectInfos.Add(testInfo);
                            _defectInfoContainerControl.AddDefectInfo(testInfo);
                            _defectMapControl.AddCoordinates(new DefectInfo[] { testInfo });
                        }));
                    }

                    float testLeftMismatch = (rand.Next(1000, 1150) / 100f);
                    float testCenterMismatch = (rand.Next(2300, 2550) / 100f);
                    float testRightMismatch = (rand.Next(1200, 1300) / 100f);

                    _dataGraphControl.AddData("Left", testLeftMismatch);
                    _dataGraphControl.AddData("Center", testCenterMismatch);
                    _dataGraphControl.AddData("Right", testRightMismatch, true);

                    _defectMapControl.maximumY = yValue;

                    _upperDrawBoxControl.SetImage(testUpperBitmap, false);
                    _lowerDrawBoxControl.SetImage(testLowerBitmap, false);
                    _upperDrawBoxControl.FitZoom();
                    _lowerDrawBoxControl.FitZoom();
                }
                _upperDrawBoxControl.EnableInteractive(true);
                _lowerDrawBoxControl.EnableInteractive(true);
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
            pnlDataArea.Controls.Clear();
        }

        private void SelectDefectData_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_dgvDefectData);
            btnDefectData.ForeColor = Color.White;
            btnDefectData.FlatAppearance.BorderSize = 3;
            //lblHighlightDefectData.BackColor = Color.Tomato;
        }

        private void SelectDefectImage_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_defectInfoContainerControl);
            btnDefectImage.ForeColor = Color.White;
            btnDefectImage.FlatAppearance.BorderSize = 3;
            //lblHighlightDefectImage.BackColor = Color.Tomato;
        }

        private void SelectMisMatch_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_dataGraphControl);
            btnUpperLowerMismatch.ForeColor = Color.White;
            btnUpperLowerMismatch.FlatAppearance.BorderSize = 3;
            //lblHighlightMismatch.BackColor = Color.Tomato;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _upperDrawBoxControl.Width = pnlUpperImage.Width / 2;
            _lowerDrawBoxControl.Width = pnlLowerImage.Width / 2;
            _defectInfoContainerControl.Size = pnlDataArea.Size;
            _defectMapControl.Invalidate();
        }
    }
}
