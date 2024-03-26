using System;
using System.Windows.Forms;
using Jastech.Battery.Winform.UI.Forms;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform;
using ESI.Core;
using Jastech.Battery.Structure;

namespace ESI.UI.Pages
{
    public partial class TeachingPage : UserControl
    {
        #region 필드
        #endregion

        #region 속성
        private ESIInspModelService ESIInspModelService { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public TeachingPage()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void btnUpperCameraSetting_Click(object sender, EventArgs e)
        {
            OpticTeachingForm form = new OpticTeachingForm();
            form.UnitName = UnitName.Upper;
            form.InspModelService = ESIInspModelService;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("UpperCamera");
            form.ShowDialog();
        }

        private void btnLowerCameraSetting_Click(object sender, EventArgs e)
        {
            OpticTeachingForm form = new OpticTeachingForm();
            form.UnitName = UnitName.Lower;
            form.InspModelService = ESIInspModelService;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("LowerCamera");
            form.ShowDialog();
        }

        private void btnLowerInspectionPage_Click(object sender, EventArgs e)
        {
            InspectionTeachingForm form = new InspectionTeachingForm();
            //form.InspDirection = InspDirection.Lower;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("LowerCamera");
            form.UnitName = UnitName.Lower;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("LowerCamera");
            form.InspModelService = ESIInspModelService;
            form.ShowDialog();
        }

        private void btnUpperInspectionPage_Click(object sender, EventArgs e)
        {
            InspectionTeachingForm form = new InspectionTeachingForm();
            //form.InspDirection = InspDirection.Upper;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("UpperCamera");
            form.UnitName = UnitName.Upper;
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("UpperCamera");
            form.InspModelService = ESIInspModelService;
            form.ShowDialog();
        }

        internal void SetInspModelService(ESIInspModelService inspModelService)
        {
            ESIInspModelService = inspModelService;
        }
        #endregion
    }
}
