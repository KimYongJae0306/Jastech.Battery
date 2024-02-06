using ESI.Core;
using Jastech.Battery.Winform.UI.Forms;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform;
using System;
using System.Windows.Forms;
using static Jastech.Framework.Modeller.Controls.ModelControl;

namespace ESI.UI.Pages
{
    public partial class DataPage : UserControl
    {
        #region 속성
        private ESIInspModelService ESIInspModelService { get; set; } = null;

        private PlcStatusForm PlcStatusForm { get; set; } = null;
        #endregion

        #region 이벤트
        public event ApplyModelDelegate ApplyModelEventHandler;
        #endregion

        #region 생성자
        public DataPage()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void btnModelPage_Click(object sender, EventArgs e)
        {
            //ATTModellerForm form = new ATTModellerForm();
            //form.InspModelService = ATTInspModelService;
            //form.ApplyModelEventHandler += Form_ApplyModelEventHandler;
            //form.ShowDialog();

            Logger.Write(LogType.GUI, "Clicked Model List Dialog");
        }

        private void Form_ApplyModelEventHandler(string modelName)
        {
            ApplyModelEventHandler?.Invoke(modelName);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OperationSettingsForm form = new OperationSettingsForm();
            form.ShowDialog();

            Logger.Write(LogType.GUI, "Clicked System Data Dialog");
        }

        public void SetInspModelService(ESIInspModelService inspModelService)
        {
            ESIInspModelService = inspModelService;
        }

        private void btnOpenPLCViewer_Click(object sender, EventArgs e)
        {
            if (PlcStatusForm == null)
            {
                var camera = DeviceManager.Instance().CameraHandler.First();

                PlcStatusForm = new PlcStatusForm();
                PlcStatusForm.Resolution_um = camera.PixelResolution_um / camera.LensScale;
                PlcStatusForm.CloseEventDelegate = () => this.PlcStatusForm = null;
                PlcStatusForm.Show();
            }
            else
                PlcStatusForm.Focus();

            Logger.Write(LogType.GUI, "Clicked PLC Viewer Dialog");
        }
        #endregion
    }
}
