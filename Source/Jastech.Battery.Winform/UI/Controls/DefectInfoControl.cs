using Jastech.Battery.Structure.Data;
using Jastech.Framework.Util.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Jastech.Battery.Structure.Data.DefectDefine;
using static Jastech.Battery.Winform.UI.Controls.DefectInfoContainerControl;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class DefectInfoControl : UserControl
    {
        #region 속성
        DefectInfo @DefectInfo { get; set; }
        #endregion

        #region 이벤트
        public event SelectedIndexChangedHandler SelectedDefectIndexChanged;
        #endregion

        #region 생성자
        public DefectInfoControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetDefectInfo(DefectInfo defectInfo)
        {
            if(defectInfo == null)
            {
                Logger.Write(LogType.Error, "DefectInfo object cant not be null");
                return;
            }
            DefectInfo = defectInfo;
            lblCamDirection.Text = $"{DefectInfo.CameraName}";
            lblDefectType.Text = $"{DefectInfo.DefectType}";
            lblDefectType.ForeColor = Colors[DefectInfo.DefectType];
            lblDefectInfo.Text = $"W:{DefectInfo.Size.Width}mm, H:{DefectInfo.Size.Height}mm";

            string imagePath = DefectInfo.ImagePath;
            if (imagePath != null)
                pbxCropImage.LoadAsync(imagePath);
        }

        public void SetBorderColor()
        {
            pnlDefectInfoControl.BackColor = Color.FromArgb(208,52,52);
        }

        public void ResetBorderColor()
        {
            pnlDefectInfoControl.BackColor = Color.Transparent;
        }

        private void ClickControlEvent(object sender, EventArgs e)
        {
            SelectedDefectIndexChanged?.Invoke(DefectInfo.Index);
        }

        public int GetDefectIndex()
        {
            if (DefectInfo == null)
                return -1;
            else
                return DefectInfo.Index;
        }
        #endregion
    }
}
