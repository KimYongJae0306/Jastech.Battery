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
using static Jastech.Framework.Structure.Defect.DefectDefine;   //테스트 후 삭제
using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Helper;
using System.Drawing.Drawing2D;

namespace ESI.UI.Pages
{
    public partial class MainPage : UserControl
    {
        #region 필드
        private CompactDefectMapControl _defectMap = null;

        private DefectInfoContainerControl _defectInfoContainer = null;

        private DrawBoxControl _upperDrawBox = null;

        private DrawBoxControl _lowerDrawBox = null;

        private DataGridView _dgvDefectData = null;

        private PixelValueGraphControl _pixelValueGraph = null;

        private readonly BindingList<ElectrodeDefectInfo> _defectInfos = new BindingList<ElectrodeDefectInfo>();
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
            _upperDrawBox = new DrawBoxControl { Dock = DockStyle.Fill };
            _lowerDrawBox = new DrawBoxControl { Dock = DockStyle.Fill };
            _defectInfoContainer = new DefectInfoContainerControl { Dock = DockStyle.Fill };
            _defectMap = new CompactDefectMapControl { Dock = DockStyle.Fill };
            _dgvDefectData = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                AllowUserToResizeRows = false,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                Dock = DockStyle.Fill,
                Size = new Size(1168, 188),
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
                    BackColor = Color.AliceBlue,
                    ForeColor = Color.Black,
                    SelectionForeColor = Color.White,
                    SelectionBackColor = Color.MediumPurple,
                }
            };

            _upperDrawBox.DisableFunctionButtons();
            _lowerDrawBox.DisableFunctionButtons();

            _dgvDefectData.DataSource = _defectInfos;
            _defectInfoContainer.isVertical = false;
            _defectMap.SelectedDefectChanged += _defectInfoContainer.SelectedControlIndexChanged;

            pnlDefectMap.Controls.Add(_defectMap);
            pnlUpperImage.Controls.Add(_upperDrawBox);
            pnlLowerImage.Controls.Add(_lowerDrawBox);
            SelectDefectData_Click(lblSelectDefectData, null);
        }

        private void ClearDatas()
        {
            _defectInfos.Clear();
            _defectMap.Clear();
            _defectInfoContainer.ClearDefectInfo();
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

            Bitmap testBitmap = new Bitmap(imgPath);
            Random rand = new Random();

            ClearDatas();

            _upperDrawBox.EnableBitmapBrush(false);
            _lowerDrawBox.EnableBitmapBrush(false);

            for (int yValue = 0; yValue <= _defectMap.maximumMeter * 50000; yValue += 50000)
            {
                if (rand.Next(40) == 0)
                {
                    var testInfo = new ElectrodeDefectInfo
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
                    #endregion

                    testInfo.SetFeatureDataType(FeatureTypes.X, typeof(float));
                    testInfo.SetFeatureDataType(FeatureTypes.Y, typeof(float));

                    testInfo.SetFeatureValue(FeatureTypes.X, rand.Next(16383));            // TODO: maximage width 받을 것
                    testInfo.SetFeatureValue(FeatureTypes.Y, yValue);

                    testInfo.SetFeatureDataType(FeatureTypes.Width, typeof(float));
                    testInfo.SetFeatureDataType(FeatureTypes.Height, typeof(float));
                    testInfo.SetFeatureValue(FeatureTypes.Width, 7f + rand.Next(0, 10) / 10f);
                    testInfo.SetFeatureValue(FeatureTypes.Height, 3f + rand.Next(70, 150) / 10f);

                    testInfo.SetFeatureDataType(FeatureTypes.LocalImagePath, typeof(string));

                    testInfo.SetFeatureValue(FeatureTypes.LocalImagePath, imgPath);

                    _defectInfos.Add(testInfo);
                    _defectInfoContainer.AddDefectInfo(testInfo);
                    _defectMap.AddCoordinates(new ElectrodeDefectInfo[] { testInfo });
                }

                _defectMap.maximumY = yValue;
                _defectMap.Invalidate();

                _upperDrawBox.SetImage((Bitmap)testBitmap.Clone());
                _upperDrawBox.FitZoom();
                _lowerDrawBox.SetImage((Bitmap)testBitmap.Clone());
                _lowerDrawBox.FitZoom();

                Application.DoEvents();
            }

            _upperDrawBox.EnableBitmapBrush(true);
            _lowerDrawBox.EnableBitmapBrush(true);
        }

        private void ClearDataViewSelection()
        {
            foreach (Control control in tlpDataLayout.Controls)
            {
                if (control.Name.Contains("Select"))
                    control.ForeColor = Color.Black;
                else if (control.Name.Contains("Highlight"))
                    control.BackColor = Color.FromArgb(104, 104, 104);
            }
            pnlDataArea.Controls.Clear();
        }

        private void SelectDefectData_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_dgvDefectData);
            lblSelectDefectData.ForeColor = Color.White;
            lblHighlightDefectData.BackColor = Color.Tomato;
        }

        private void SelectDefectImage_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_defectInfoContainer);
            lblSelectDefectImage.ForeColor = Color.White;
            lblHighlightDefectImage.BackColor = Color.Tomato;
        }

        private void SelectMisMatch_Click(object sender, EventArgs e)
        {
            ClearDataViewSelection();
            pnlDataArea.Controls.Add(_pixelValueGraph);
            lblSelectMismatch.ForeColor = Color.White;
            lblHighlightMismatch.BackColor = Color.Tomato;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            _upperDrawBox.Width = pnlUpperImage.Width / 2;
            _lowerDrawBox.Width = pnlLowerImage.Width / 2;
            _defectMap.Invalidate();
        }
    }
}
