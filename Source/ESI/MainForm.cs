using ESI.Core;
using ESI.UI.Pages;
using Jastech.Battery.Structure;
using Jastech.Battery.Winform;
using Jastech.Battery.Winform.Forms;
using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Config;
using Jastech.Framework.Structure;
using Jastech.Framework.Users;
using Jastech.Framework.Winform;
using Jastech.Framework.Winform.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESI
{
    public partial class MainForm : Form
    {
        #region 필드
        #endregion

        #region 속성
        private List<UserControl> PageControlList { get; set; } = null;

        private MainPage MainPageControl { get; set; } = null;

        private TeachingPage TeachingPageControl { get; set; } = null;

        private DataPage DataPageControl { get; set; } = null;

        private LogForm LogForm { get; set; } = null;

        public ESIInspModelService ESIInspModelService { get; set; } = new ESIInspModelService();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (UserManager.Instance().CurrentUser.Type == AuthorityType.Maker)
                Text = " ";

            lblMachineName.Text = AppsConfig.Instance().MachineName;

            AddControls();
            SelectMainPage();

            TeachingPageControl.SetInspModelService(ESIInspModelService);
            DataPageControl.SetInspModelService(ESIInspModelService);
            DataPageControl.ApplyModelEventHandler += ModelPageControl_ApplyModelEventHandler;
            ModelManager.Instance().CurrentModelChangedEvent += MainForm_CurrentModelChangedEvent;

            if (ModelManager.Instance().CurrentModel != null)
            {
                lblCurrentModel.Text = ModelManager.Instance().CurrentModel.Name;
                ModelManager.Instance().ApplyChangedEvent();
            }

            SystemManager.Instance().InitializeInspRunner();

            ESIInspRunner test = new ESIInspRunner();
            test.Initialize();
        }   

        private void AddControls()
        {
            // Page Control List
            PageControlList = new List<UserControl>();

            MainPageControl = new MainPage();
            MainPageControl.Dock = DockStyle.Fill;
            PageControlList.Add(MainPageControl);

            TeachingPageControl = new TeachingPage();
            TeachingPageControl.Dock = DockStyle.Fill;
            PageControlList.Add(TeachingPageControl);

            DataPageControl = new DataPage();
            DataPageControl.Dock = DockStyle.Fill;
            PageControlList.Add(DataPageControl);

            LogForm = new LogForm();
        }

        private void ModelPageControl_ApplyModelEventHandler(string modelName)
        {
            string modelDir = ConfigSet.Instance().Path.Model;
            string filePath = Path.Combine(modelDir, modelName, InspModel.FileName);

            ModelManager.Instance().CurrentModel = ESIInspModelService.Load(filePath);
            SelectMainPage();

            ConfigSet.Instance().Operation.LastModelName = modelName;
            ConfigSet.Instance().Operation.Save(ConfigSet.Instance().Path.Config);
        }

        private void MainForm_CurrentModelChangedEvent(InspModel inspModel)
        {

        }

        private void SelectMainPage()
        {
            SetSelectLabel(lblMainPage);
            SetSelectPage(MainPageControl);
        }

        private void SetSelectLabel(object sender)
        {
            foreach (Control control in ControlHelper.GetAllControlsUsingRecursive(tlpFunctionButtons))
                control.ForeColor = Color.White;

            Label currentLabel = sender as Label;
            currentLabel.ForeColor = Color.DodgerBlue;
        }

        private void SetSelectPage(UserControl selectedControl)
        {
            foreach (UserControl control in PageControlList)
                control.Visible = false;

            selectedControl.Visible = true;
            selectedControl.Dock = DockStyle.Fill;
            pnlPage.Controls.Add(selectedControl);
        }

        private void lblMainPage_Click(object sender, EventArgs e)
        {
            SetSelectLabel(sender);
            SetSelectPage(MainPageControl);
        }

        private void lblTeachingPage_Click(object sender, EventArgs e)
        {
            SetSelectLabel(sender);
            SetSelectPage(TeachingPageControl);
        }

        private void lblDataPage_Click(object sender, EventArgs e)
        {
            SetSelectLabel(sender);
            SetSelectPage(DataPageControl);
        }

        private void lblLogPage_Click(object sender, EventArgs e)
        {
            SetSelectLabel(sender);
            LogForm.ShowDialog();
        }
        #endregion

        private void StopProgramEventFunction()
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeviceManager.Instance().Release();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemManager.Instance().ReleaseInspRunner();
            SystemManager.Instance().StopRun();
        }
    }
}
