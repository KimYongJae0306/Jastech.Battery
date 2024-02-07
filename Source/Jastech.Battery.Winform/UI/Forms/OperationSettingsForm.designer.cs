namespace Jastech.Battery.Winform.UI.Forms
{
    partial class OperationSettingsForm
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpConfigure = new System.Windows.Forms.TableLayoutPanel();
            this.pnlConfigureGroup1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInspectionEdge = new System.Windows.Forms.Label();
            this.lblInspectionCoating = new System.Windows.Forms.Label();
            this.lblInspectionNonCoating = new System.Windows.Forms.Label();
            this.mtgInspectionUsageEdge = new MetroFramework.Controls.MetroToggle();
            this.mtgInspectionUsageCoating = new MetroFramework.Controls.MetroToggle();
            this.mtgInspectionUsageNonCoating = new MetroFramework.Controls.MetroToggle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpLogSaveInspectionResult = new System.Windows.Forms.TableLayoutPanel();
            this.metroToggle2 = new MetroFramework.Controls.MetroToggle();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.mtgLogAkkonLead = new MetroFramework.Controls.MetroToggle();
            this.label30 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.pnlConfigureGroup2 = new System.Windows.Forms.Panel();
            this.tlpImageSaveNG = new System.Windows.Forms.TableLayoutPanel();
            this.mcbxNGExtension = new MetroFramework.Controls.MetroComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.mtgSaveNG = new MetroFramework.Controls.MetroToggle();
            this.tlpImageSaveOK = new System.Windows.Forms.TableLayoutPanel();
            this.mcbxOKExtension = new MetroFramework.Controls.MetroComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.mtgSaveOK = new MetroFramework.Controls.MetroToggle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.tlpDataStoreCapacity = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDataStoringCapacity = new System.Windows.Forms.TextBox();
            this.tlpDataStoreDuration = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDataStoringDays = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.pnlConfigureGroup3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label41 = new System.Windows.Forms.Label();
            this.mtgEnablePlcTime = new MetroFramework.Controls.MetroToggle();
            this.label42 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.pnlConfigureGroup4 = new System.Windows.Forms.Panel();
            this.tlpOperationSettingLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCommonFunction = new System.Windows.Forms.Panel();
            this.tlpCommonFunction = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCancel = new System.Windows.Forms.Panel();
            this.tlpCancel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCancelImage = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.tlpSave = new System.Windows.Forms.TableLayoutPanel();
            this.lblSaveImage = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.tlpConfigure.SuspendLayout();
            this.pnlConfigureGroup1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpLogSaveInspectionResult.SuspendLayout();
            this.pnlConfigureGroup2.SuspendLayout();
            this.tlpImageSaveNG.SuspendLayout();
            this.tlpImageSaveOK.SuspendLayout();
            this.tlpDataStoreCapacity.SuspendLayout();
            this.tlpDataStoreDuration.SuspendLayout();
            this.pnlConfigureGroup3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tlpOperationSettingLayout.SuspendLayout();
            this.pnlCommonFunction.SuspendLayout();
            this.tlpCommonFunction.SuspendLayout();
            this.pnlCancel.SuspendLayout();
            this.tlpCancel.SuspendLayout();
            this.pnlSave.SuspendLayout();
            this.tlpSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpConfigure
            // 
            this.tlpConfigure.ColumnCount = 4;
            this.tlpConfigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConfigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConfigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConfigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConfigure.Controls.Add(this.pnlConfigureGroup1, 0, 0);
            this.tlpConfigure.Controls.Add(this.pnlConfigureGroup2, 1, 0);
            this.tlpConfigure.Controls.Add(this.pnlConfigureGroup3, 2, 0);
            this.tlpConfigure.Controls.Add(this.pnlConfigureGroup4, 3, 0);
            this.tlpConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConfigure.Location = new System.Drawing.Point(3, 3);
            this.tlpConfigure.Name = "tlpConfigure";
            this.tlpConfigure.RowCount = 1;
            this.tlpConfigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConfigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 808F));
            this.tlpConfigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 808F));
            this.tlpConfigure.Size = new System.Drawing.Size(1554, 808);
            this.tlpConfigure.TabIndex = 6;
            // 
            // pnlConfigureGroup1
            // 
            this.pnlConfigureGroup1.Controls.Add(this.tableLayoutPanel2);
            this.pnlConfigureGroup1.Controls.Add(this.panel2);
            this.pnlConfigureGroup1.Controls.Add(this.label3);
            this.pnlConfigureGroup1.Controls.Add(this.tlpLogSaveInspectionResult);
            this.pnlConfigureGroup1.Controls.Add(this.label30);
            this.pnlConfigureGroup1.Controls.Add(this.panel14);
            this.pnlConfigureGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigureGroup1.Location = new System.Drawing.Point(3, 3);
            this.pnlConfigureGroup1.Name = "pnlConfigureGroup1";
            this.pnlConfigureGroup1.Size = new System.Drawing.Size(382, 802);
            this.pnlConfigureGroup1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblInspectionEdge, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblInspectionCoating, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblInspectionNonCoating, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mtgInspectionUsageEdge, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mtgInspectionUsageCoating, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.mtgInspectionUsageNonCoating, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(68, 57);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(298, 108);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // lblInspectionEdge
            // 
            this.lblInspectionEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionEdge.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspectionEdge.ForeColor = System.Drawing.Color.White;
            this.lblInspectionEdge.Location = new System.Drawing.Point(3, 72);
            this.lblInspectionEdge.Name = "lblInspectionEdge";
            this.lblInspectionEdge.Size = new System.Drawing.Size(114, 36);
            this.lblInspectionEdge.TabIndex = 14;
            this.lblInspectionEdge.Text = "NonCoating";
            this.lblInspectionEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectionCoating
            // 
            this.lblInspectionCoating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionCoating.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspectionCoating.ForeColor = System.Drawing.Color.White;
            this.lblInspectionCoating.Location = new System.Drawing.Point(3, 36);
            this.lblInspectionCoating.Name = "lblInspectionCoating";
            this.lblInspectionCoating.Size = new System.Drawing.Size(114, 36);
            this.lblInspectionCoating.TabIndex = 13;
            this.lblInspectionCoating.Text = "Coating";
            this.lblInspectionCoating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectionNonCoating
            // 
            this.lblInspectionNonCoating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionNonCoating.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInspectionNonCoating.ForeColor = System.Drawing.Color.White;
            this.lblInspectionNonCoating.Location = new System.Drawing.Point(3, 0);
            this.lblInspectionNonCoating.Name = "lblInspectionNonCoating";
            this.lblInspectionNonCoating.Size = new System.Drawing.Size(114, 36);
            this.lblInspectionNonCoating.TabIndex = 5;
            this.lblInspectionNonCoating.Text = "Edge";
            this.lblInspectionNonCoating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtgInspectionUsageEdge
            // 
            this.mtgInspectionUsageEdge.AutoSize = true;
            this.mtgInspectionUsageEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgInspectionUsageEdge.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgInspectionUsageEdge.Location = new System.Drawing.Point(123, 3);
            this.mtgInspectionUsageEdge.Name = "mtgInspectionUsageEdge";
            this.mtgInspectionUsageEdge.Size = new System.Drawing.Size(72, 30);
            this.mtgInspectionUsageEdge.TabIndex = 16;
            this.mtgInspectionUsageEdge.Text = "Off";
            this.mtgInspectionUsageEdge.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgInspectionUsageEdge.UseSelectable = true;
            // 
            // mtgInspectionUsageCoating
            // 
            this.mtgInspectionUsageCoating.AutoSize = true;
            this.mtgInspectionUsageCoating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgInspectionUsageCoating.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgInspectionUsageCoating.Location = new System.Drawing.Point(123, 39);
            this.mtgInspectionUsageCoating.Name = "mtgInspectionUsageCoating";
            this.mtgInspectionUsageCoating.Size = new System.Drawing.Size(72, 30);
            this.mtgInspectionUsageCoating.TabIndex = 15;
            this.mtgInspectionUsageCoating.Text = "Off";
            this.mtgInspectionUsageCoating.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgInspectionUsageCoating.UseSelectable = true;
            // 
            // mtgInspectionUsageNonCoating
            // 
            this.mtgInspectionUsageNonCoating.AutoSize = true;
            this.mtgInspectionUsageNonCoating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgInspectionUsageNonCoating.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgInspectionUsageNonCoating.Location = new System.Drawing.Point(123, 75);
            this.mtgInspectionUsageNonCoating.Name = "mtgInspectionUsageNonCoating";
            this.mtgInspectionUsageNonCoating.Size = new System.Drawing.Size(72, 30);
            this.mtgInspectionUsageNonCoating.TabIndex = 12;
            this.mtgInspectionUsageNonCoating.Text = "Off";
            this.mtgInspectionUsageNonCoating.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgInspectionUsageNonCoating.UseSelectable = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Location = new System.Drawing.Point(21, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 2);
            this.panel2.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 33);
            this.label3.TabIndex = 26;
            this.label3.Text = "Inspection Options";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpLogSaveInspectionResult
            // 
            this.tlpLogSaveInspectionResult.ColumnCount = 3;
            this.tlpLogSaveInspectionResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpLogSaveInspectionResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogSaveInspectionResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpLogSaveInspectionResult.Controls.Add(this.metroToggle2, 1, 2);
            this.tlpLogSaveInspectionResult.Controls.Add(this.metroToggle1, 1, 1);
            this.tlpLogSaveInspectionResult.Controls.Add(this.label2, 0, 2);
            this.tlpLogSaveInspectionResult.Controls.Add(this.label1, 0, 1);
            this.tlpLogSaveInspectionResult.Controls.Add(this.label29, 0, 0);
            this.tlpLogSaveInspectionResult.Controls.Add(this.mtgLogAkkonLead, 1, 0);
            this.tlpLogSaveInspectionResult.Location = new System.Drawing.Point(68, 230);
            this.tlpLogSaveInspectionResult.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tlpLogSaveInspectionResult.Name = "tlpLogSaveInspectionResult";
            this.tlpLogSaveInspectionResult.RowCount = 3;
            this.tlpLogSaveInspectionResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpLogSaveInspectionResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpLogSaveInspectionResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpLogSaveInspectionResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLogSaveInspectionResult.Size = new System.Drawing.Size(298, 108);
            this.tlpLogSaveInspectionResult.TabIndex = 33;
            // 
            // metroToggle2
            // 
            this.metroToggle2.AutoSize = true;
            this.metroToggle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroToggle2.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggle2.Location = new System.Drawing.Point(123, 75);
            this.metroToggle2.Name = "metroToggle2";
            this.metroToggle2.Size = new System.Drawing.Size(72, 30);
            this.metroToggle2.TabIndex = 16;
            this.metroToggle2.Text = "Off";
            this.metroToggle2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle2.UseSelectable = true;
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroToggle1.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroToggle1.Location = new System.Drawing.Point(123, 39);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(72, 30);
            this.metroToggle1.TabIndex = 15;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle1.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 36);
            this.label2.TabIndex = 14;
            this.label2.Text = "Non-Coating";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 36);
            this.label1.TabIndex = 13;
            this.label1.Text = "Coating";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(114, 36);
            this.label29.TabIndex = 5;
            this.label29.Text = "Edge";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtgLogAkkonLead
            // 
            this.mtgLogAkkonLead.AutoSize = true;
            this.mtgLogAkkonLead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgLogAkkonLead.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgLogAkkonLead.Location = new System.Drawing.Point(123, 3);
            this.mtgLogAkkonLead.Name = "mtgLogAkkonLead";
            this.mtgLogAkkonLead.Size = new System.Drawing.Size(72, 30);
            this.mtgLogAkkonLead.TabIndex = 12;
            this.mtgLogAkkonLead.Text = "Off";
            this.mtgLogAkkonLead.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgLogAkkonLead.UseSelectable = true;
            this.mtgLogAkkonLead.CheckedChanged += new System.EventHandler(this.mtgOperationSetting_CheckedChanged);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(16, 187);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(323, 33);
            this.label30.TabIndex = 24;
            this.label30.Text = "Log Save Options";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel14.Location = new System.Drawing.Point(21, 220);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(345, 2);
            this.panel14.TabIndex = 23;
            // 
            // pnlConfigureGroup2
            // 
            this.pnlConfigureGroup2.Controls.Add(this.tlpImageSaveNG);
            this.pnlConfigureGroup2.Controls.Add(this.tlpImageSaveOK);
            this.pnlConfigureGroup2.Controls.Add(this.panel6);
            this.pnlConfigureGroup2.Controls.Add(this.label22);
            this.pnlConfigureGroup2.Controls.Add(this.tlpDataStoreCapacity);
            this.pnlConfigureGroup2.Controls.Add(this.tlpDataStoreDuration);
            this.pnlConfigureGroup2.Controls.Add(this.panel5);
            this.pnlConfigureGroup2.Controls.Add(this.label19);
            this.pnlConfigureGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigureGroup2.Location = new System.Drawing.Point(391, 3);
            this.pnlConfigureGroup2.Name = "pnlConfigureGroup2";
            this.pnlConfigureGroup2.Size = new System.Drawing.Size(382, 802);
            this.pnlConfigureGroup2.TabIndex = 1;
            // 
            // tlpImageSaveNG
            // 
            this.tlpImageSaveNG.ColumnCount = 3;
            this.tlpImageSaveNG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpImageSaveNG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageSaveNG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpImageSaveNG.Controls.Add(this.mcbxNGExtension, 2, 0);
            this.tlpImageSaveNG.Controls.Add(this.label23, 0, 0);
            this.tlpImageSaveNG.Controls.Add(this.mtgSaveNG, 1, 0);
            this.tlpImageSaveNG.Location = new System.Drawing.Point(60, 279);
            this.tlpImageSaveNG.Name = "tlpImageSaveNG";
            this.tlpImageSaveNG.RowCount = 1;
            this.tlpImageSaveNG.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageSaveNG.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpImageSaveNG.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpImageSaveNG.Size = new System.Drawing.Size(298, 36);
            this.tlpImageSaveNG.TabIndex = 26;
            // 
            // mcbxNGExtension
            // 
            this.mcbxNGExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcbxNGExtension.ForeColor = System.Drawing.Color.White;
            this.mcbxNGExtension.FormattingEnabled = true;
            this.mcbxNGExtension.ItemHeight = 23;
            this.mcbxNGExtension.Location = new System.Drawing.Point(201, 3);
            this.mcbxNGExtension.Name = "mcbxNGExtension";
            this.mcbxNGExtension.Size = new System.Drawing.Size(94, 29);
            this.mcbxNGExtension.TabIndex = 28;
            this.mcbxNGExtension.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mcbxNGExtension.UseSelectable = true;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(114, 36);
            this.label23.TabIndex = 5;
            this.label23.Text = "NG";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtgSaveNG
            // 
            this.mtgSaveNG.AutoSize = true;
            this.mtgSaveNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgSaveNG.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgSaveNG.Location = new System.Drawing.Point(123, 3);
            this.mtgSaveNG.Name = "mtgSaveNG";
            this.mtgSaveNG.Size = new System.Drawing.Size(72, 30);
            this.mtgSaveNG.TabIndex = 12;
            this.mtgSaveNG.Text = "Off";
            this.mtgSaveNG.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgSaveNG.UseSelectable = true;
            this.mtgSaveNG.CheckedChanged += new System.EventHandler(this.mtgOperationSetting_CheckedChanged);
            // 
            // tlpImageSaveOK
            // 
            this.tlpImageSaveOK.ColumnCount = 3;
            this.tlpImageSaveOK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpImageSaveOK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageSaveOK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpImageSaveOK.Controls.Add(this.mcbxOKExtension, 2, 0);
            this.tlpImageSaveOK.Controls.Add(this.label24, 0, 0);
            this.tlpImageSaveOK.Controls.Add(this.mtgSaveOK, 1, 0);
            this.tlpImageSaveOK.Location = new System.Drawing.Point(60, 233);
            this.tlpImageSaveOK.Name = "tlpImageSaveOK";
            this.tlpImageSaveOK.RowCount = 1;
            this.tlpImageSaveOK.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImageSaveOK.Size = new System.Drawing.Size(298, 36);
            this.tlpImageSaveOK.TabIndex = 25;
            // 
            // mcbxOKExtension
            // 
            this.mcbxOKExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcbxOKExtension.ForeColor = System.Drawing.Color.White;
            this.mcbxOKExtension.FormattingEnabled = true;
            this.mcbxOKExtension.ItemHeight = 23;
            this.mcbxOKExtension.Location = new System.Drawing.Point(201, 3);
            this.mcbxOKExtension.Name = "mcbxOKExtension";
            this.mcbxOKExtension.Size = new System.Drawing.Size(94, 29);
            this.mcbxOKExtension.TabIndex = 27;
            this.mcbxOKExtension.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mcbxOKExtension.UseSelectable = true;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 36);
            this.label24.TabIndex = 5;
            this.label24.Text = "OK";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtgSaveOK
            // 
            this.mtgSaveOK.AutoSize = true;
            this.mtgSaveOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgSaveOK.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgSaveOK.Location = new System.Drawing.Point(123, 3);
            this.mtgSaveOK.Name = "mtgSaveOK";
            this.mtgSaveOK.Size = new System.Drawing.Size(72, 30);
            this.mtgSaveOK.TabIndex = 12;
            this.mtgSaveOK.Text = "Off";
            this.mtgSaveOK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgSaveOK.UseSelectable = true;
            this.mtgSaveOK.CheckedChanged += new System.EventHandler(this.mtgOperationSetting_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Location = new System.Drawing.Point(16, 220);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(345, 2);
            this.panel6.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(11, 187);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(323, 33);
            this.label22.TabIndex = 22;
            this.label22.Text = "Image Save Options";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDataStoreCapacity
            // 
            this.tlpDataStoreCapacity.ColumnCount = 3;
            this.tlpDataStoreCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpDataStoreCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataStoreCapacity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDataStoreCapacity.Controls.Add(this.label15, 2, 0);
            this.tlpDataStoreCapacity.Controls.Add(this.label16, 0, 0);
            this.tlpDataStoreCapacity.Controls.Add(this.txtDataStoringCapacity, 1, 0);
            this.tlpDataStoreCapacity.Location = new System.Drawing.Point(63, 101);
            this.tlpDataStoreCapacity.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tlpDataStoreCapacity.Name = "tlpDataStoreCapacity";
            this.tlpDataStoreCapacity.RowCount = 1;
            this.tlpDataStoreCapacity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataStoreCapacity.Size = new System.Drawing.Size(298, 40);
            this.tlpDataStoreCapacity.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 10.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(251, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 40);
            this.label15.TabIndex = 11;
            this.label15.Text = "%";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 40);
            this.label16.TabIndex = 5;
            this.label16.Text = "Capcity";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDataStoringCapacity
            // 
            this.txtDataStoringCapacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.txtDataStoringCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataStoringCapacity.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDataStoringCapacity.ForeColor = System.Drawing.Color.White;
            this.txtDataStoringCapacity.Location = new System.Drawing.Point(103, 3);
            this.txtDataStoringCapacity.Name = "txtDataStoringCapacity";
            this.txtDataStoringCapacity.ReadOnly = true;
            this.txtDataStoringCapacity.Size = new System.Drawing.Size(142, 33);
            this.txtDataStoringCapacity.TabIndex = 8;
            this.txtDataStoringCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataStoringCapacity.Click += new System.EventHandler(this.textbox_KeyPad_Click);
            this.txtDataStoringCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataStoringDays_KeyPress);
            this.txtDataStoringCapacity.Leave += new System.EventHandler(this.txtDataStoringDays_Leave);
            // 
            // tlpDataStoreDuration
            // 
            this.tlpDataStoreDuration.ColumnCount = 3;
            this.tlpDataStoreDuration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpDataStoreDuration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataStoreDuration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDataStoreDuration.Controls.Add(this.label17, 2, 0);
            this.tlpDataStoreDuration.Controls.Add(this.label18, 0, 0);
            this.tlpDataStoreDuration.Controls.Add(this.txtDataStoringDays, 1, 0);
            this.tlpDataStoreDuration.Location = new System.Drawing.Point(63, 55);
            this.tlpDataStoreDuration.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tlpDataStoreDuration.Name = "tlpDataStoreDuration";
            this.tlpDataStoreDuration.RowCount = 1;
            this.tlpDataStoreDuration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataStoreDuration.Size = new System.Drawing.Size(298, 40);
            this.tlpDataStoreDuration.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 10.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(251, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 40);
            this.label17.TabIndex = 11;
            this.label17.Text = "days";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 40);
            this.label18.TabIndex = 5;
            this.label18.Text = "Duration";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDataStoringDays
            // 
            this.txtDataStoringDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.txtDataStoringDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataStoringDays.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDataStoringDays.ForeColor = System.Drawing.Color.White;
            this.txtDataStoringDays.Location = new System.Drawing.Point(103, 3);
            this.txtDataStoringDays.Name = "txtDataStoringDays";
            this.txtDataStoringDays.ReadOnly = true;
            this.txtDataStoringDays.Size = new System.Drawing.Size(142, 33);
            this.txtDataStoringDays.TabIndex = 8;
            this.txtDataStoringDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataStoringDays.Click += new System.EventHandler(this.textbox_KeyPad_Click);
            this.txtDataStoringDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataStoringDays_KeyPress);
            this.txtDataStoringDays.Leave += new System.EventHandler(this.txtDataStoringDays_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel5.Location = new System.Drawing.Point(16, 47);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(345, 2);
            this.panel5.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(11, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(320, 33);
            this.label19.TabIndex = 18;
            this.label19.Text = "Data Store Options";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlConfigureGroup3
            // 
            this.pnlConfigureGroup3.Controls.Add(this.tableLayoutPanel8);
            this.pnlConfigureGroup3.Controls.Add(this.label42);
            this.pnlConfigureGroup3.Controls.Add(this.panel19);
            this.pnlConfigureGroup3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigureGroup3.Location = new System.Drawing.Point(779, 3);
            this.pnlConfigureGroup3.Name = "pnlConfigureGroup3";
            this.pnlConfigureGroup3.Size = new System.Drawing.Size(382, 802);
            this.pnlConfigureGroup3.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label41, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.mtgEnablePlcTime, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(68, 57);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(298, 36);
            this.tableLayoutPanel8.TabIndex = 41;
            // 
            // label41
            // 
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(3, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(114, 36);
            this.label41.TabIndex = 5;
            this.label41.Text = "PLC Time";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtgEnablePlcTime
            // 
            this.mtgEnablePlcTime.AutoSize = true;
            this.mtgEnablePlcTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtgEnablePlcTime.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mtgEnablePlcTime.Location = new System.Drawing.Point(123, 3);
            this.mtgEnablePlcTime.Name = "mtgEnablePlcTime";
            this.mtgEnablePlcTime.Size = new System.Drawing.Size(72, 30);
            this.mtgEnablePlcTime.TabIndex = 12;
            this.mtgEnablePlcTime.Text = "Off";
            this.mtgEnablePlcTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtgEnablePlcTime.UseSelectable = true;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(16, 14);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(347, 33);
            this.label42.TabIndex = 40;
            this.label42.Text = "PLC";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel19.Location = new System.Drawing.Point(21, 47);
            this.panel19.Margin = new System.Windows.Forms.Padding(0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(345, 2);
            this.panel19.TabIndex = 39;
            // 
            // pnlConfigureGroup4
            // 
            this.pnlConfigureGroup4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfigureGroup4.Location = new System.Drawing.Point(1167, 3);
            this.pnlConfigureGroup4.Name = "pnlConfigureGroup4";
            this.pnlConfigureGroup4.Size = new System.Drawing.Size(384, 802);
            this.pnlConfigureGroup4.TabIndex = 27;
            // 
            // tlpOperationSettingLayout
            // 
            this.tlpOperationSettingLayout.ColumnCount = 1;
            this.tlpOperationSettingLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOperationSettingLayout.Controls.Add(this.pnlCommonFunction, 0, 1);
            this.tlpOperationSettingLayout.Controls.Add(this.tlpConfigure, 0, 0);
            this.tlpOperationSettingLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOperationSettingLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOperationSettingLayout.Name = "tlpOperationSettingLayout";
            this.tlpOperationSettingLayout.RowCount = 2;
            this.tlpOperationSettingLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOperationSettingLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpOperationSettingLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOperationSettingLayout.Size = new System.Drawing.Size(1560, 884);
            this.tlpOperationSettingLayout.TabIndex = 7;
            // 
            // pnlCommonFunction
            // 
            this.pnlCommonFunction.Controls.Add(this.tlpCommonFunction);
            this.pnlCommonFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommonFunction.Location = new System.Drawing.Point(3, 817);
            this.pnlCommonFunction.Name = "pnlCommonFunction";
            this.pnlCommonFunction.Size = new System.Drawing.Size(1554, 64);
            this.pnlCommonFunction.TabIndex = 1;
            // 
            // tlpCommonFunction
            // 
            this.tlpCommonFunction.ColumnCount = 3;
            this.tlpCommonFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommonFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCommonFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCommonFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCommonFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCommonFunction.Controls.Add(this.pnlCancel, 2, 0);
            this.tlpCommonFunction.Controls.Add(this.pnlSave, 1, 0);
            this.tlpCommonFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommonFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpCommonFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommonFunction.Name = "tlpCommonFunction";
            this.tlpCommonFunction.RowCount = 1;
            this.tlpCommonFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommonFunction.Size = new System.Drawing.Size(1554, 64);
            this.tlpCommonFunction.TabIndex = 3;
            // 
            // pnlCancel
            // 
            this.pnlCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCancel.Controls.Add(this.tlpCancel);
            this.pnlCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCancel.Location = new System.Drawing.Point(1357, 3);
            this.pnlCancel.Name = "pnlCancel";
            this.pnlCancel.Size = new System.Drawing.Size(194, 58);
            this.pnlCancel.TabIndex = 4;
            // 
            // tlpCancel
            // 
            this.tlpCancel.ColumnCount = 2;
            this.tlpCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCancel.Controls.Add(this.lblCancelImage, 0, 0);
            this.tlpCancel.Controls.Add(this.lblCancel, 1, 0);
            this.tlpCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCancel.Location = new System.Drawing.Point(0, 0);
            this.tlpCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCancel.Name = "tlpCancel";
            this.tlpCancel.RowCount = 1;
            this.tlpCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCancel.Size = new System.Drawing.Size(192, 56);
            this.tlpCancel.TabIndex = 0;
            // 
            // lblCancelImage
            // 
            this.lblCancelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCancelImage.Location = new System.Drawing.Point(3, 0);
            this.lblCancelImage.Name = "lblCancelImage";
            this.lblCancelImage.Size = new System.Drawing.Size(44, 56);
            this.lblCancelImage.TabIndex = 1;
            this.lblCancelImage.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // lblCancel
            // 
            this.lblCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCancel.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(53, 0);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(136, 56);
            this.lblCancel.TabIndex = 0;
            this.lblCancel.Text = "Cancel";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // pnlSave
            // 
            this.pnlSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSave.Controls.Add(this.tlpSave);
            this.pnlSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSave.Location = new System.Drawing.Point(1157, 3);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(194, 58);
            this.pnlSave.TabIndex = 5;
            // 
            // tlpSave
            // 
            this.tlpSave.ColumnCount = 2;
            this.tlpSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSave.Controls.Add(this.lblSaveImage, 0, 0);
            this.tlpSave.Controls.Add(this.lblSave, 1, 0);
            this.tlpSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSave.Location = new System.Drawing.Point(0, 0);
            this.tlpSave.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSave.Name = "tlpSave";
            this.tlpSave.RowCount = 1;
            this.tlpSave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSave.Size = new System.Drawing.Size(192, 56);
            this.tlpSave.TabIndex = 0;
            // 
            // lblSaveImage
            // 
            this.lblSaveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSaveImage.Location = new System.Drawing.Point(3, 0);
            this.lblSaveImage.Name = "lblSaveImage";
            this.lblSaveImage.Size = new System.Drawing.Size(44, 56);
            this.lblSaveImage.TabIndex = 1;
            this.lblSaveImage.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblSave
            // 
            this.lblSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSave.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblSave.ForeColor = System.Drawing.Color.White;
            this.lblSave.Location = new System.Drawing.Point(53, 0);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(136, 56);
            this.lblSave.TabIndex = 0;
            this.lblSave.Text = "Save";
            this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // OperationSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1560, 884);
            this.Controls.Add(this.tlpOperationSettingLayout);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperationSettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.OperationSettingsForm_Load);
            this.tlpConfigure.ResumeLayout(false);
            this.pnlConfigureGroup1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpLogSaveInspectionResult.ResumeLayout(false);
            this.tlpLogSaveInspectionResult.PerformLayout();
            this.pnlConfigureGroup2.ResumeLayout(false);
            this.tlpImageSaveNG.ResumeLayout(false);
            this.tlpImageSaveNG.PerformLayout();
            this.tlpImageSaveOK.ResumeLayout(false);
            this.tlpImageSaveOK.PerformLayout();
            this.tlpDataStoreCapacity.ResumeLayout(false);
            this.tlpDataStoreCapacity.PerformLayout();
            this.tlpDataStoreDuration.ResumeLayout(false);
            this.tlpDataStoreDuration.PerformLayout();
            this.pnlConfigureGroup3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tlpOperationSettingLayout.ResumeLayout(false);
            this.pnlCommonFunction.ResumeLayout(false);
            this.tlpCommonFunction.ResumeLayout(false);
            this.pnlCancel.ResumeLayout(false);
            this.tlpCancel.ResumeLayout(false);
            this.pnlSave.ResumeLayout(false);
            this.tlpSave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpConfigure;
        private System.Windows.Forms.Panel pnlConfigureGroup1;
        private System.Windows.Forms.Panel pnlConfigureGroup2;
        private System.Windows.Forms.TableLayoutPanel tlpDataStoreCapacity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDataStoringCapacity;
        private System.Windows.Forms.TableLayoutPanel tlpDataStoreDuration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDataStoringDays;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TableLayoutPanel tlpImageSaveOK;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TableLayoutPanel tlpImageSaveNG;
        private System.Windows.Forms.Label label23;
        private MetroFramework.Controls.MetroToggle mtgSaveNG;
        private MetroFramework.Controls.MetroToggle mtgSaveOK;
        private MetroFramework.Controls.MetroComboBox mcbxOKExtension;
        private MetroFramework.Controls.MetroComboBox mcbxNGExtension;
        private System.Windows.Forms.TableLayoutPanel tlpOperationSettingLayout;
        private System.Windows.Forms.Panel pnlCommonFunction;
        private System.Windows.Forms.TableLayoutPanel tlpCommonFunction;
        private System.Windows.Forms.Panel pnlCancel;
        private System.Windows.Forms.TableLayoutPanel tlpCancel;
        private System.Windows.Forms.Label lblCancelImage;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.TableLayoutPanel tlpSave;
        private System.Windows.Forms.Label lblSaveImage;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Panel pnlConfigureGroup4;
        private System.Windows.Forms.Panel pnlConfigureGroup3;
        private System.Windows.Forms.TableLayoutPanel tlpLogSaveInspectionResult;
        private System.Windows.Forms.Label label29;
        private MetroFramework.Controls.MetroToggle mtgLogAkkonLead;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label41;
        private MetroFramework.Controls.MetroToggle mtgEnablePlcTime;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroToggle mtgInspectionUsageEdge;
        private MetroFramework.Controls.MetroToggle mtgInspectionUsageCoating;
        private System.Windows.Forms.Label lblInspectionEdge;
        private System.Windows.Forms.Label lblInspectionCoating;
        private System.Windows.Forms.Label lblInspectionNonCoating;
        private MetroFramework.Controls.MetroToggle mtgInspectionUsageNonCoating;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroToggle metroToggle2;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
