namespace ESI
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMainForm = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBottomCamState = new System.Windows.Forms.Label();
            this.lblTopCamState = new System.Windows.Forms.Label();
            this.lblLightState = new System.Windows.Forms.Label();
            this.lblTopCamStateText = new System.Windows.Forms.Label();
            this.lblBottomCamStateText = new System.Windows.Forms.Label();
            this.lblPLCState = new System.Windows.Forms.Label();
            this.lblPlcStateText = new System.Windows.Forms.Label();
            this.lblLightStateText = new System.Windows.Forms.Label();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.tlpFunctionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tlpSelectLogPage = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogPageImage = new System.Windows.Forms.Label();
            this.lblLogPage = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tlpSelectDataPage = new System.Windows.Forms.TableLayoutPanel();
            this.lblDataPageImage = new System.Windows.Forms.Label();
            this.lblDataPage = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tlpSelectMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.lblInspectionPageImage = new System.Windows.Forms.Label();
            this.lblMainPage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpSelectTeachPage = new System.Windows.Forms.TableLayoutPanel();
            this.lblTeachingPageImage = new System.Windows.Forms.Label();
            this.lblTeachingPage = new System.Windows.Forms.Label();
            this.pnlMachineStatus = new System.Windows.Forms.Panel();
            this.tlpMachineStatus = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblCurrentModel = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblDoorlockState = new System.Windows.Forms.Label();
            this.tlpMainForm.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpFunctionButtons.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tlpSelectLogPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tlpSelectDataPage.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tlpSelectMainPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpSelectTeachPage.SuspendLayout();
            this.pnlMachineStatus.SuspendLayout();
            this.tlpMachineStatus.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMainForm
            // 
            this.tlpMainForm.ColumnCount = 1;
            this.tlpMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainForm.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tlpMainForm.Controls.Add(this.pnlPage, 0, 2);
            this.tlpMainForm.Controls.Add(this.tlpFunctionButtons, 0, 1);
            this.tlpMainForm.Controls.Add(this.pnlMachineStatus, 0, 0);
            this.tlpMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainForm.Location = new System.Drawing.Point(0, 0);
            this.tlpMainForm.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainForm.Name = "tlpMainForm";
            this.tlpMainForm.RowCount = 4;
            this.tlpMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpMainForm.Size = new System.Drawing.Size(1373, 678);
            this.tlpMainForm.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.Controls.Add(this.lblBottomCamState, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTopCamState, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLightState, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTopCamStateText, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBottomCamStateText, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPLCState, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPlcStateText, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLightStateText, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 651);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1373, 27);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblBottomCamState
            // 
            this.lblBottomCamState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBottomCamState.Image = global::ESI.Properties.Resources.Circle_Red;
            this.lblBottomCamState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBottomCamState.Location = new System.Drawing.Point(1352, 0);
            this.lblBottomCamState.Margin = new System.Windows.Forms.Padding(0);
            this.lblBottomCamState.Name = "lblBottomCamState";
            this.lblBottomCamState.Size = new System.Drawing.Size(21, 27);
            this.lblBottomCamState.TabIndex = 5;
            this.lblBottomCamState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopCamState
            // 
            this.lblTopCamState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopCamState.Image = global::ESI.Properties.Resources.Circle_Red;
            this.lblTopCamState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTopCamState.Location = new System.Drawing.Point(1245, 0);
            this.lblTopCamState.Margin = new System.Windows.Forms.Padding(0);
            this.lblTopCamState.Name = "lblTopCamState";
            this.lblTopCamState.Size = new System.Drawing.Size(21, 27);
            this.lblTopCamState.TabIndex = 9;
            this.lblTopCamState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLightState
            // 
            this.lblLightState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightState.Image = global::ESI.Properties.Resources.Circle_Red;
            this.lblLightState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLightState.Location = new System.Drawing.Point(1138, 0);
            this.lblLightState.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightState.Name = "lblLightState";
            this.lblLightState.Size = new System.Drawing.Size(21, 27);
            this.lblLightState.TabIndex = 8;
            this.lblLightState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopCamStateText
            // 
            this.lblTopCamStateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopCamStateText.Location = new System.Drawing.Point(1159, 0);
            this.lblTopCamStateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblTopCamStateText.Name = "lblTopCamStateText";
            this.lblTopCamStateText.Size = new System.Drawing.Size(86, 27);
            this.lblTopCamStateText.TabIndex = 6;
            this.lblTopCamStateText.Text = "TopCam";
            this.lblTopCamStateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBottomCamStateText
            // 
            this.lblBottomCamStateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBottomCamStateText.Location = new System.Drawing.Point(1266, 0);
            this.lblBottomCamStateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblBottomCamStateText.Name = "lblBottomCamStateText";
            this.lblBottomCamStateText.Size = new System.Drawing.Size(86, 27);
            this.lblBottomCamStateText.TabIndex = 4;
            this.lblBottomCamStateText.Text = "BottomCam";
            this.lblBottomCamStateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPLCState
            // 
            this.lblPLCState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCState.Image = ((System.Drawing.Image)(resources.GetObject("lblPLCState.Image")));
            this.lblPLCState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPLCState.Location = new System.Drawing.Point(1057, 0);
            this.lblPLCState.Margin = new System.Windows.Forms.Padding(0);
            this.lblPLCState.Name = "lblPLCState";
            this.lblPLCState.Size = new System.Drawing.Size(21, 27);
            this.lblPLCState.TabIndex = 1;
            this.lblPLCState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlcStateText
            // 
            this.lblPlcStateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlcStateText.Location = new System.Drawing.Point(997, 0);
            this.lblPlcStateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlcStateText.Name = "lblPlcStateText";
            this.lblPlcStateText.Size = new System.Drawing.Size(60, 27);
            this.lblPlcStateText.TabIndex = 0;
            this.lblPlcStateText.Text = "PLC";
            this.lblPlcStateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLightStateText
            // 
            this.lblLightStateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightStateText.Location = new System.Drawing.Point(1078, 0);
            this.lblLightStateText.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightStateText.Name = "lblLightStateText";
            this.lblLightStateText.Size = new System.Drawing.Size(60, 27);
            this.lblLightStateText.TabIndex = 7;
            this.lblLightStateText.Text = "Light";
            this.lblLightStateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPage
            // 
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(0, 108);
            this.pnlPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(1373, 543);
            this.pnlPage.TabIndex = 3;
            // 
            // tlpFunctionButtons
            // 
            this.tlpFunctionButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpFunctionButtons.ColumnCount = 9;
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtons.Controls.Add(this.lblCurrentTime, 8, 0);
            this.tlpFunctionButtons.Controls.Add(this.panel4, 3, 0);
            this.tlpFunctionButtons.Controls.Add(this.panel3, 2, 0);
            this.tlpFunctionButtons.Controls.Add(this.panel8, 0, 0);
            this.tlpFunctionButtons.Controls.Add(this.panel1, 1, 0);
            this.tlpFunctionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionButtons.Location = new System.Drawing.Point(0, 54);
            this.tlpFunctionButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunctionButtons.Name = "tlpFunctionButtons";
            this.tlpFunctionButtons.RowCount = 1;
            this.tlpFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtons.Size = new System.Drawing.Size(1373, 54);
            this.tlpFunctionButtons.TabIndex = 0;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTime.Font = new System.Drawing.Font("맑은 고딕", 12.2F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTime.Location = new System.Drawing.Point(1603, 3);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(1, 48);
            this.lblCurrentTime.TabIndex = 3;
            this.lblCurrentTime.Text = "DateTime";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tlpSelectLogPage);
            this.panel4.Location = new System.Drawing.Point(603, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(165, 48);
            this.panel4.TabIndex = 20;
            // 
            // tlpSelectLogPage
            // 
            this.tlpSelectLogPage.ColumnCount = 2;
            this.tlpSelectLogPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSelectLogPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectLogPage.Controls.Add(this.lblLogPageImage, 0, 0);
            this.tlpSelectLogPage.Controls.Add(this.lblLogPage, 1, 0);
            this.tlpSelectLogPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectLogPage.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectLogPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectLogPage.Name = "tlpSelectLogPage";
            this.tlpSelectLogPage.RowCount = 1;
            this.tlpSelectLogPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectLogPage.Size = new System.Drawing.Size(165, 48);
            this.tlpSelectLogPage.TabIndex = 0;
            this.tlpSelectLogPage.Tag = "3";
            // 
            // lblLogPageImage
            // 
            this.lblLogPageImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogPageImage.Image = global::ESI.Properties.Resources.Log;
            this.lblLogPageImage.Location = new System.Drawing.Point(3, 0);
            this.lblLogPageImage.Name = "lblLogPageImage";
            this.lblLogPageImage.Size = new System.Drawing.Size(44, 48);
            this.lblLogPageImage.TabIndex = 1;
            // 
            // lblLogPage
            // 
            this.lblLogPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogPage.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogPage.ForeColor = System.Drawing.Color.White;
            this.lblLogPage.Location = new System.Drawing.Point(53, 0);
            this.lblLogPage.Name = "lblLogPage";
            this.lblLogPage.Size = new System.Drawing.Size(109, 48);
            this.lblLogPage.TabIndex = 0;
            this.lblLogPage.Text = "LOG";
            this.lblLogPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tlpSelectDataPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(403, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 48);
            this.panel3.TabIndex = 20;
            // 
            // tlpSelectDataPage
            // 
            this.tlpSelectDataPage.ColumnCount = 2;
            this.tlpSelectDataPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSelectDataPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectDataPage.Controls.Add(this.lblDataPageImage, 0, 0);
            this.tlpSelectDataPage.Controls.Add(this.lblDataPage, 1, 0);
            this.tlpSelectDataPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectDataPage.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectDataPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectDataPage.Name = "tlpSelectDataPage";
            this.tlpSelectDataPage.RowCount = 1;
            this.tlpSelectDataPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectDataPage.Size = new System.Drawing.Size(194, 48);
            this.tlpSelectDataPage.TabIndex = 0;
            this.tlpSelectDataPage.Tag = "2";
            // 
            // lblDataPageImage
            // 
            this.lblDataPageImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataPageImage.Image = global::ESI.Properties.Resources.Settings;
            this.lblDataPageImage.Location = new System.Drawing.Point(3, 0);
            this.lblDataPageImage.Name = "lblDataPageImage";
            this.lblDataPageImage.Size = new System.Drawing.Size(44, 48);
            this.lblDataPageImage.TabIndex = 1;
            // 
            // lblDataPage
            // 
            this.lblDataPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataPage.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataPage.ForeColor = System.Drawing.Color.White;
            this.lblDataPage.Location = new System.Drawing.Point(53, 0);
            this.lblDataPage.Name = "lblDataPage";
            this.lblDataPage.Size = new System.Drawing.Size(138, 48);
            this.lblDataPage.TabIndex = 0;
            this.lblDataPage.Text = "DATA";
            this.lblDataPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tlpSelectMainPage);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(194, 48);
            this.panel8.TabIndex = 6;
            // 
            // tlpSelectMainPage
            // 
            this.tlpSelectMainPage.ColumnCount = 2;
            this.tlpSelectMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSelectMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectMainPage.Controls.Add(this.lblInspectionPageImage, 0, 0);
            this.tlpSelectMainPage.Controls.Add(this.lblMainPage, 1, 0);
            this.tlpSelectMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectMainPage.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectMainPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectMainPage.Name = "tlpSelectMainPage";
            this.tlpSelectMainPage.RowCount = 1;
            this.tlpSelectMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectMainPage.Size = new System.Drawing.Size(194, 48);
            this.tlpSelectMainPage.TabIndex = 0;
            this.tlpSelectMainPage.Tag = "0";
            // 
            // lblInspectionPageImage
            // 
            this.lblInspectionPageImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionPageImage.Image = global::ESI.Properties.Resources.Inspection;
            this.lblInspectionPageImage.Location = new System.Drawing.Point(3, 0);
            this.lblInspectionPageImage.Name = "lblInspectionPageImage";
            this.lblInspectionPageImage.Size = new System.Drawing.Size(44, 48);
            this.lblInspectionPageImage.TabIndex = 1;
            this.lblInspectionPageImage.Click += new System.EventHandler(this.lblMainPage_Click);
            // 
            // lblMainPage
            // 
            this.lblMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainPage.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblMainPage.ForeColor = System.Drawing.Color.White;
            this.lblMainPage.Location = new System.Drawing.Point(53, 0);
            this.lblMainPage.Name = "lblMainPage";
            this.lblMainPage.Size = new System.Drawing.Size(138, 48);
            this.lblMainPage.TabIndex = 0;
            this.lblMainPage.Text = "MAIN";
            this.lblMainPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMainPage.Click += new System.EventHandler(this.lblMainPage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpSelectTeachPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(203, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 48);
            this.panel1.TabIndex = 18;
            // 
            // tlpSelectTeachPage
            // 
            this.tlpSelectTeachPage.ColumnCount = 2;
            this.tlpSelectTeachPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSelectTeachPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectTeachPage.Controls.Add(this.lblTeachingPageImage, 0, 0);
            this.tlpSelectTeachPage.Controls.Add(this.lblTeachingPage, 1, 0);
            this.tlpSelectTeachPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectTeachPage.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectTeachPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectTeachPage.Name = "tlpSelectTeachPage";
            this.tlpSelectTeachPage.RowCount = 1;
            this.tlpSelectTeachPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectTeachPage.Size = new System.Drawing.Size(194, 48);
            this.tlpSelectTeachPage.TabIndex = 0;
            this.tlpSelectTeachPage.Tag = "1";
            // 
            // lblTeachingPageImage
            // 
            this.lblTeachingPageImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeachingPageImage.Image = global::ESI.Properties.Resources.Teaching;
            this.lblTeachingPageImage.Location = new System.Drawing.Point(3, 0);
            this.lblTeachingPageImage.Name = "lblTeachingPageImage";
            this.lblTeachingPageImage.Size = new System.Drawing.Size(44, 48);
            this.lblTeachingPageImage.TabIndex = 1;
            this.lblTeachingPageImage.Click += new System.EventHandler(this.lblTeachingPage_Click);
            // 
            // lblTeachingPage
            // 
            this.lblTeachingPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeachingPage.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblTeachingPage.ForeColor = System.Drawing.Color.White;
            this.lblTeachingPage.Location = new System.Drawing.Point(53, 0);
            this.lblTeachingPage.Name = "lblTeachingPage";
            this.lblTeachingPage.Size = new System.Drawing.Size(138, 48);
            this.lblTeachingPage.TabIndex = 0;
            this.lblTeachingPage.Text = "TEACH";
            this.lblTeachingPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTeachingPage.Click += new System.EventHandler(this.lblTeachingPage_Click);
            // 
            // pnlMachineStatus
            // 
            this.pnlMachineStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMachineStatus.Controls.Add(this.tlpMachineStatus);
            this.pnlMachineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachineStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlMachineStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMachineStatus.Name = "pnlMachineStatus";
            this.pnlMachineStatus.Size = new System.Drawing.Size(1373, 54);
            this.pnlMachineStatus.TabIndex = 2;
            // 
            // tlpMachineStatus
            // 
            this.tlpMachineStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpMachineStatus.ColumnCount = 4;
            this.tlpMachineStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tlpMachineStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMachineStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tlpMachineStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tlpMachineStatus.Controls.Add(this.tableLayoutPanel5, 3, 0);
            this.tlpMachineStatus.Controls.Add(this.lblCurrentModel, 2, 0);
            this.tlpMachineStatus.Controls.Add(this.lblMachineName, 1, 0);
            this.tlpMachineStatus.Controls.Add(this.lblDoorlockState, 0, 0);
            this.tlpMachineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMachineStatus.Location = new System.Drawing.Point(0, 0);
            this.tlpMachineStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMachineStatus.Name = "tlpMachineStatus";
            this.tlpMachineStatus.RowCount = 1;
            this.tlpMachineStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMachineStatus.Size = new System.Drawing.Size(1371, 52);
            this.tlpMachineStatus.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel5.Controls.Add(this.lblCurrentUser, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1217, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(154, 52);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentUser.Font = new System.Drawing.Font("맑은 고딕", 12.2F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Location = new System.Drawing.Point(3, 3);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(109, 46);
            this.lblCurrentUser.TabIndex = 2;
            this.lblCurrentUser.Text = "Maker";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::ESI.Properties.Resources.People;
            this.pictureBox2.Location = new System.Drawing.Point(115, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pictureBox2.Size = new System.Drawing.Size(39, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lblCurrentModel
            // 
            this.lblCurrentModel.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentModel.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblCurrentModel.ForeColor = System.Drawing.Color.White;
            this.lblCurrentModel.Location = new System.Drawing.Point(943, 3);
            this.lblCurrentModel.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentModel.Name = "lblCurrentModel";
            this.lblCurrentModel.Size = new System.Drawing.Size(271, 46);
            this.lblCurrentModel.TabIndex = 3;
            this.lblCurrentModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMachineName
            // 
            this.lblMachineName.BackColor = System.Drawing.Color.Transparent;
            this.lblMachineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMachineName.Font = new System.Drawing.Font("맑은 고딕", 20.2F, System.Drawing.FontStyle.Bold);
            this.lblMachineName.ForeColor = System.Drawing.Color.White;
            this.lblMachineName.Location = new System.Drawing.Point(192, 3);
            this.lblMachineName.Margin = new System.Windows.Forms.Padding(3);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(745, 46);
            this.lblMachineName.TabIndex = 1;
            this.lblMachineName.Text = "ESI";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoorlockState
            // 
            this.lblDoorlockState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDoorlockState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoorlockState.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoorlockState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDoorlockState.Location = new System.Drawing.Point(3, 0);
            this.lblDoorlockState.Name = "lblDoorlockState";
            this.lblDoorlockState.Size = new System.Drawing.Size(183, 52);
            this.lblDoorlockState.TabIndex = 4;
            this.lblDoorlockState.Text = "Doorlock Opened";
            this.lblDoorlockState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1373, 678);
            this.Controls.Add(this.tlpMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMainForm.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpFunctionButtons.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tlpSelectLogPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tlpSelectDataPage.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tlpSelectMainPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpSelectTeachPage.ResumeLayout(false);
            this.pnlMachineStatus.ResumeLayout(false);
            this.tlpMachineStatus.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTopCamState;
        private System.Windows.Forms.Label lblLightState;
        private System.Windows.Forms.Label lblLightStateText;
        private System.Windows.Forms.Label lblTopCamStateText;
        private System.Windows.Forms.Label lblPLCState;
        private System.Windows.Forms.Label lblPlcStateText;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.TableLayoutPanel tlpFunctionButtons;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tlpSelectLogPage;
        private System.Windows.Forms.Label lblLogPageImage;
        private System.Windows.Forms.Label lblLogPage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tlpSelectDataPage;
        private System.Windows.Forms.Label lblDataPageImage;
        private System.Windows.Forms.Label lblDataPage;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TableLayoutPanel tlpSelectMainPage;
        private System.Windows.Forms.Label lblInspectionPageImage;
        private System.Windows.Forms.Label lblMainPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpSelectTeachPage;
        private System.Windows.Forms.Label lblTeachingPageImage;
        private System.Windows.Forms.Label lblTeachingPage;
        private System.Windows.Forms.Panel pnlMachineStatus;
        private System.Windows.Forms.TableLayoutPanel tlpMachineStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblCurrentModel;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblDoorlockState;
        private System.Windows.Forms.Label lblBottomCamStateText;
        private System.Windows.Forms.Label lblBottomCamState;
    }
}

