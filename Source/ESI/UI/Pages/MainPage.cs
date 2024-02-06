using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Structure.Defect;
using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Helper;

namespace ESI.UI.Pages
{
    public partial class MainPage : UserControl
    {
        #region 필드
        private CompactDefectMapControl _defectMap = null;

        private DefectInfoContainerControl _defectInfoContainer = null;

        private DrawBoxControl _leftDrawBox = null;

        private DrawBoxControl _rightDrawBox = null;

        private DataGridView _dgvDefectData = null;

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
            _leftDrawBox = new DrawBoxControl { Dock = DockStyle.Right };
            _rightDrawBox = new DrawBoxControl { Dock = DockStyle.Right };
            _defectInfoContainer = new DefectInfoContainerControl { Dock = DockStyle.Fill };
            _defectMap = new CompactDefectMapControl { Dock = DockStyle.Fill};
            _dgvDefectData = preCreatedDefectDataGridView;

            _leftDrawBox.DisableFunctionButtons();
            _rightDrawBox.DisableFunctionButtons();

            _dgvDefectData.DataSource = _defectInfos;
            _defectInfoContainer.isVertical = false;
            _defectMap.SelectedDefectChanged += _defectInfoContainer.SelectedControlIndexChanged;

            pnlDefectMap.Controls.Add(_defectMap);
            pnlImages.Controls.Add(_leftDrawBox);
            pnlImages.Controls.Add(_rightDrawBox);
            pnlDataArea.Controls.Add(_dgvDefectData);
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

            _leftDrawBox.EnableBitmapBrush(false);
            _rightDrawBox.EnableBitmapBrush(false);

            for (int yValue = 0; yValue <= _defectMap.maximumMeter * 50000; yValue += 50000)
            {
                if (rand.Next(40) == 0)
                {
                    var testInfo = new ElectrodeDefectInfo
                    {
                        Index = _defectInfos.Count,
                        Judgement = "NG",
                        DefectLevel = rand.Next(1, 6),
                        DefectType = (DefectDefine.DefectTypes)rand.Next(1, 6),
                        CamDirection = rand.Next(2) == 0 ? "Upper" : "Lower",
                        Lane = 1
                    };

                    #region 보기싫은 if문
                    if (testInfo.CamDirection == "Upper")
                    {
                        lblUpperJudgement.Text = "NG";
                        lblUpperJudgement.BackColor = Color.Red;
                    }
                    else
                    {
                        lblUpperJudgement.Text = "OK";
                        lblUpperJudgement.BackColor = Color.LimeGreen;
                    }

                    if (testInfo.CamDirection == "Lower")
                    {
                        lblLowerJudgement.Text = "NG";
                        lblLowerJudgement.BackColor = Color.Red;
                    }
                    else
                    {
                        lblLowerJudgement.Text = "OK";
                        lblLowerJudgement.BackColor = Color.LimeGreen;
                    }
                    #endregion

                    testInfo.SetFeatureDataType(DefectDefine.FeatureTypes.X, typeof(float));
                    testInfo.SetFeatureDataType(DefectDefine.FeatureTypes.Y, typeof(float));

                    testInfo.SetFeatureValue(DefectDefine.FeatureTypes.X, rand.Next(16383));            // TODO: maximage width 받을 것
                    testInfo.SetFeatureValue(DefectDefine.FeatureTypes.Y, yValue);

                    testInfo.SetFeatureDataType(DefectDefine.FeatureTypes.Width, typeof(float));
                    testInfo.SetFeatureDataType(DefectDefine.FeatureTypes.Height, typeof(float));
                    testInfo.SetFeatureValue(DefectDefine.FeatureTypes.Width, 7f + rand.Next(0, 10) / 10f);
                    testInfo.SetFeatureValue(DefectDefine.FeatureTypes.Height, 3f + rand.Next(70, 150) / 10f);

                    testInfo.SetFeatureDataType(DefectDefine.FeatureTypes.LocalImagePath, typeof(string));

                    testInfo.SetFeatureValue(DefectDefine.FeatureTypes.LocalImagePath, imgPath);

                    _defectInfos.Add(testInfo);
                    _defectInfoContainer.AddDefectInfo(testInfo);
                    _defectMap.AddCoordinates(new ElectrodeDefectInfo[] { testInfo });
                }

                _defectMap.maximumY = yValue;
                _defectMap.Invalidate();

                _leftDrawBox.SetImage((Bitmap)testBitmap.Clone());
                _leftDrawBox.FitZoom();
                _rightDrawBox.SetImage((Bitmap)testBitmap.Clone());
                _rightDrawBox.FitZoom();

                Application.DoEvents();
            }

            _leftDrawBox.EnableBitmapBrush(true);
            _rightDrawBox.EnableBitmapBrush(true);
        }

        private void pnlImages_SizeChanged(object sender, EventArgs e)
        {
            _leftDrawBox.Width = pnlImages.Width / 2;
            _rightDrawBox.Width = pnlImages.Width / 2;
        }

        private void lblSelectDataType_Click(object sender, EventArgs e)
        {
            var clickedLabel = sender as Label;
            pnlDataArea.Controls.Clear();

            if (clickedLabel.Tag is "DefectData")
                pnlDataArea.Controls.Add(_dgvDefectData);
            else if (clickedLabel.Tag is "DefectImage")
                pnlDataArea.Controls.Add(_defectInfoContainer);
        }
    }
}
