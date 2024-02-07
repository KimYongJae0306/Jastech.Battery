using Jastech.Framework.Winform.Controls;

namespace ESI.UI.Pages
{
    partial class MainPage
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
            this.tlpMainPageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSideBarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCommonFunctionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnTest = new System.Windows.Forms.Button();
            this.tlpStop = new System.Windows.Forms.TableLayoutPanel();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStopText = new System.Windows.Forms.Label();
            this.tlpStart = new System.Windows.Forms.TableLayoutPanel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStartText = new System.Windows.Forms.Label();
            this.tlpFunctionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDefectMap = new System.Windows.Forms.TableLayoutPanel();
            this.lblDefectMap = new System.Windows.Forms.Label();
            this.pnlDefectMap = new System.Windows.Forms.Panel();
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperCam = new System.Windows.Forms.Label();
            this.lblLowerCam = new System.Windows.Forms.Label();
            this.tlpSummaryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpperJudgement = new System.Windows.Forms.Button();
            this.btnLowerJudgement = new System.Windows.Forms.Button();
            this.tlpDataLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpperLowerMismatch = new System.Windows.Forms.Button();
            this.btnDefectImage = new System.Windows.Forms.Button();
            this.btnDefectData = new System.Windows.Forms.Button();
            this.pnlDataArea = new System.Windows.Forms.Panel();
            this.pnlLowerImage = new System.Windows.Forms.Panel();
            this.pnlUpperImage = new System.Windows.Forms.Panel();
            this.tlpLowerMismatch = new System.Windows.Forms.TableLayoutPanel();
            this.lblLowerLeftMismatch = new System.Windows.Forms.Label();
            this.lblLowerLeftMismatchValue = new System.Windows.Forms.Label();
            this.lblLowerCenterMismatch = new System.Windows.Forms.Label();
            this.lblLowerRightMismatch = new System.Windows.Forms.Label();
            this.lblLowerRightMismatchValue = new System.Windows.Forms.Label();
            this.lblLowerCenterMismatchValue = new System.Windows.Forms.Label();
            this.tlpUpperMismatch = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperCenterMismatchValue = new System.Windows.Forms.Label();
            this.lblUpperRightMismatchValue = new System.Windows.Forms.Label();
            this.lblUpperRightMismatch = new System.Windows.Forms.Label();
            this.lblUpperCenterMismatch = new System.Windows.Forms.Label();
            this.lblUpperLeftMismatchValue = new System.Windows.Forms.Label();
            this.lblUpperLeftMismatch = new System.Windows.Forms.Label();
            this.tlpUpperSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperSummaryItem1 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem1Value = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem2 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem2Value = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem3 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem3Value = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem4 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem5 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem6 = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem4Value = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem5Value = new System.Windows.Forms.Label();
            this.lblUpperSummaryItem6Value = new System.Windows.Forms.Label();
            this.tlpLowerSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lblLowerSummaryItem1 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem1Value = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem2 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem2Value = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem3 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem3Value = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem4 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem4Value = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem5 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItemValue = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem6 = new System.Windows.Forms.Label();
            this.lblLowerSummaryItem6Value = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tlpMainPageLayout.SuspendLayout();
            this.tlpSideBarLayout.SuspendLayout();
            this.tlpCommonFunctionLayout.SuspendLayout();
            this.tlpStop.SuspendLayout();
            this.tlpStart.SuspendLayout();
            this.tlpFunctionLayout.SuspendLayout();
            this.tlpDefectMap.SuspendLayout();
            this.tlpImages.SuspendLayout();
            this.tlpSummaryLayout.SuspendLayout();
            this.tlpDataLayout.SuspendLayout();
            this.tlpLowerMismatch.SuspendLayout();
            this.tlpUpperMismatch.SuspendLayout();
            this.tlpUpperSummary.SuspendLayout();
            this.tlpLowerSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainPageLayout
            // 
            this.tlpMainPageLayout.ColumnCount = 2;
            this.tlpMainPageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMainPageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainPageLayout.Controls.Add(this.tlpSideBarLayout, 0, 0);
            this.tlpMainPageLayout.Controls.Add(this.tlpFunctionLayout, 1, 0);
            this.tlpMainPageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainPageLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpMainPageLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainPageLayout.Name = "tlpMainPageLayout";
            this.tlpMainPageLayout.RowCount = 1;
            this.tlpMainPageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainPageLayout.Size = new System.Drawing.Size(1700, 800);
            this.tlpMainPageLayout.TabIndex = 2;
            // 
            // tlpSideBarLayout
            // 
            this.tlpSideBarLayout.ColumnCount = 1;
            this.tlpSideBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSideBarLayout.Controls.Add(this.tlpCommonFunctionLayout, 0, 0);
            this.tlpSideBarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSideBarLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpSideBarLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSideBarLayout.Name = "tlpSideBarLayout";
            this.tlpSideBarLayout.RowCount = 1;
            this.tlpSideBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSideBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tlpSideBarLayout.Size = new System.Drawing.Size(70, 800);
            this.tlpSideBarLayout.TabIndex = 2;
            // 
            // tlpCommonFunctionLayout
            // 
            this.tlpCommonFunctionLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpCommonFunctionLayout.ColumnCount = 1;
            this.tlpCommonFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommonFunctionLayout.Controls.Add(this.btnTest, 0, 2);
            this.tlpCommonFunctionLayout.Controls.Add(this.tlpStop, 0, 1);
            this.tlpCommonFunctionLayout.Controls.Add(this.tlpStart, 0, 0);
            this.tlpCommonFunctionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommonFunctionLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpCommonFunctionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommonFunctionLayout.Name = "tlpCommonFunctionLayout";
            this.tlpCommonFunctionLayout.RowCount = 3;
            this.tlpCommonFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCommonFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCommonFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommonFunctionLayout.Size = new System.Drawing.Size(70, 800);
            this.tlpCommonFunctionLayout.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.Red;
            this.btnTest.Location = new System.Drawing.Point(3, 163);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(64, 64);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.Test_Click);
            // 
            // tlpStop
            // 
            this.tlpStop.ColumnCount = 1;
            this.tlpStop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStop.Controls.Add(this.lblStop, 0, 0);
            this.tlpStop.Controls.Add(this.lblStopText, 0, 1);
            this.tlpStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStop.Location = new System.Drawing.Point(0, 80);
            this.tlpStop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStop.Name = "tlpStop";
            this.tlpStop.RowCount = 2;
            this.tlpStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpStop.Size = new System.Drawing.Size(70, 80);
            this.tlpStop.TabIndex = 2;
            // 
            // lblStop
            // 
            this.lblStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStop.Image = global::ESI.Properties.Resources.Stop_White;
            this.lblStop.Location = new System.Drawing.Point(0, 0);
            this.lblStop.Margin = new System.Windows.Forms.Padding(0);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(70, 50);
            this.lblStop.TabIndex = 3;
            // 
            // lblStopText
            // 
            this.lblStopText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopText.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblStopText.ForeColor = System.Drawing.Color.White;
            this.lblStopText.Location = new System.Drawing.Point(0, 50);
            this.lblStopText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStopText.Name = "lblStopText";
            this.lblStopText.Size = new System.Drawing.Size(70, 30);
            this.lblStopText.TabIndex = 2;
            this.lblStopText.Text = "STOP";
            this.lblStopText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpStart
            // 
            this.tlpStart.ColumnCount = 1;
            this.tlpStart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStart.Controls.Add(this.lblStart, 0, 0);
            this.tlpStart.Controls.Add(this.lblStartText, 0, 1);
            this.tlpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStart.Location = new System.Drawing.Point(0, 0);
            this.tlpStart.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStart.Name = "tlpStart";
            this.tlpStart.RowCount = 2;
            this.tlpStart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpStart.Size = new System.Drawing.Size(70, 80);
            this.tlpStart.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStart.Image = global::ESI.Properties.Resources.Start_White;
            this.lblStart.Location = new System.Drawing.Point(0, 0);
            this.lblStart.Margin = new System.Windows.Forms.Padding(0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(70, 50);
            this.lblStart.TabIndex = 3;
            // 
            // lblStartText
            // 
            this.lblStartText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartText.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblStartText.ForeColor = System.Drawing.Color.White;
            this.lblStartText.Location = new System.Drawing.Point(0, 50);
            this.lblStartText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartText.Name = "lblStartText";
            this.lblStartText.Size = new System.Drawing.Size(70, 30);
            this.lblStartText.TabIndex = 2;
            this.lblStartText.Text = "START";
            this.lblStartText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpFunctionLayout
            // 
            this.tlpFunctionLayout.ColumnCount = 3;
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunctionLayout.Controls.Add(this.tlpDefectMap, 0, 0);
            this.tlpFunctionLayout.Controls.Add(this.tlpImages, 1, 0);
            this.tlpFunctionLayout.Controls.Add(this.pnlSummary, 1, 1);
            this.tlpFunctionLayout.Controls.Add(this.tlpDataLayout, 1, 2);
            this.tlpFunctionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionLayout.Location = new System.Drawing.Point(75, 0);
            this.tlpFunctionLayout.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tlpFunctionLayout.Name = "tlpFunctionLayout";
            this.tlpFunctionLayout.RowCount = 3;
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionLayout.Size = new System.Drawing.Size(1625, 800);
            this.tlpFunctionLayout.TabIndex = 0;
            // 
            // tlpDefectMap
            // 
            this.tlpDefectMap.ColumnCount = 1;
            this.tlpDefectMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.Controls.Add(this.lblDefectMap, 0, 0);
            this.tlpDefectMap.Controls.Add(this.pnlDefectMap, 0, 1);
            this.tlpDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefectMap.Location = new System.Drawing.Point(0, 0);
            this.tlpDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefectMap.Name = "tlpDefectMap";
            this.tlpDefectMap.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tlpDefectMap.RowCount = 2;
            this.tlpFunctionLayout.SetRowSpan(this.tlpDefectMap, 3);
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDefectMap.Size = new System.Drawing.Size(450, 800);
            this.tlpDefectMap.TabIndex = 9;
            // 
            // lblDefectMap
            // 
            this.lblDefectMap.AutoSize = true;
            this.lblDefectMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblDefectMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefectMap.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectMap.ForeColor = System.Drawing.Color.White;
            this.lblDefectMap.Location = new System.Drawing.Point(0, 0);
            this.lblDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectMap.Name = "lblDefectMap";
            this.lblDefectMap.Size = new System.Drawing.Size(445, 35);
            this.lblDefectMap.TabIndex = 8;
            this.lblDefectMap.Tag = "";
            this.lblDefectMap.Text = "DEFECT MAP";
            this.lblDefectMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDefectMap
            // 
            this.pnlDefectMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectMap.Location = new System.Drawing.Point(0, 35);
            this.pnlDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectMap.Name = "pnlDefectMap";
            this.pnlDefectMap.Size = new System.Drawing.Size(445, 765);
            this.pnlDefectMap.TabIndex = 7;
            // 
            // tlpImages
            // 
            this.tlpImages.ColumnCount = 2;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpImages, 2);
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImages.Controls.Add(this.lblUpperCam, 0, 0);
            this.tlpImages.Controls.Add(this.lblLowerCam, 1, 0);
            this.tlpImages.Controls.Add(this.pnlUpperImage, 0, 1);
            this.tlpImages.Controls.Add(this.pnlLowerImage, 1, 1);
            this.tlpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImages.Location = new System.Drawing.Point(450, 0);
            this.tlpImages.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 1;
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpImages.Size = new System.Drawing.Size(1175, 450);
            this.tlpImages.TabIndex = 0;
            // 
            // lblUpperCam
            // 
            this.lblUpperCam.AutoSize = true;
            this.lblUpperCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblUpperCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUpperCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUpperCam.ForeColor = System.Drawing.Color.White;
            this.lblUpperCam.Location = new System.Drawing.Point(0, 0);
            this.lblUpperCam.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperCam.Name = "lblUpperCam";
            this.lblUpperCam.Size = new System.Drawing.Size(587, 35);
            this.lblUpperCam.TabIndex = 7;
            this.lblUpperCam.Tag = "";
            this.lblUpperCam.Text = "UPPER CAM";
            this.lblUpperCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowerCam
            // 
            this.lblLowerCam.AutoSize = true;
            this.lblLowerCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblLowerCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowerCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLowerCam.ForeColor = System.Drawing.Color.White;
            this.lblLowerCam.Location = new System.Drawing.Point(587, 0);
            this.lblLowerCam.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerCam.Name = "lblLowerCam";
            this.lblLowerCam.Size = new System.Drawing.Size(588, 35);
            this.lblLowerCam.TabIndex = 8;
            this.lblLowerCam.Tag = "";
            this.lblLowerCam.Text = "LOWER CAM";
            this.lblLowerCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSummaryLayout
            // 
            this.tlpSummaryLayout.ColumnCount = 6;
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSummaryLayout.Controls.Add(this.tlpUpperMismatch, 0, 0);
            this.tlpSummaryLayout.Controls.Add(this.tlpUpperSummary, 1, 0);
            this.tlpSummaryLayout.Controls.Add(this.btnUpperJudgement, 2, 0);
            this.tlpSummaryLayout.Controls.Add(this.btnLowerJudgement, 5, 0);
            this.tlpSummaryLayout.Controls.Add(this.tlpLowerMismatch, 3, 0);
            this.tlpSummaryLayout.Controls.Add(this.tlpLowerSummary, 4, 0);
            this.tlpSummaryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSummaryLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpSummaryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSummaryLayout.Name = "tlpSummaryLayout";
            this.tlpSummaryLayout.RowCount = 1;
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSummaryLayout.Size = new System.Drawing.Size(1173, 78);
            this.tlpSummaryLayout.TabIndex = 8;
            // 
            // btnUpperJudgement
            // 
            this.btnUpperJudgement.BackColor = System.Drawing.Color.LimeGreen;
            this.btnUpperJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpperJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpperJudgement.FlatAppearance.BorderSize = 2;
            this.btnUpperJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpperJudgement.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpperJudgement.ForeColor = System.Drawing.Color.White;
            this.btnUpperJudgement.Location = new System.Drawing.Point(485, 0);
            this.btnUpperJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpperJudgement.Name = "btnUpperJudgement";
            this.btnUpperJudgement.Size = new System.Drawing.Size(100, 78);
            this.btnUpperJudgement.TabIndex = 10;
            this.btnUpperJudgement.Text = "OK";
            this.btnUpperJudgement.UseVisualStyleBackColor = false;
            // 
            // btnLowerJudgement
            // 
            this.btnLowerJudgement.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLowerJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLowerJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLowerJudgement.FlatAppearance.BorderSize = 2;
            this.btnLowerJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowerJudgement.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLowerJudgement.ForeColor = System.Drawing.Color.White;
            this.btnLowerJudgement.Location = new System.Drawing.Point(1070, 0);
            this.btnLowerJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnLowerJudgement.Name = "btnLowerJudgement";
            this.btnLowerJudgement.Size = new System.Drawing.Size(103, 78);
            this.btnLowerJudgement.TabIndex = 9;
            this.btnLowerJudgement.Text = "OK";
            this.btnLowerJudgement.UseVisualStyleBackColor = false;
            // 
            // tlpDataLayout
            // 
            this.tlpDataLayout.ColumnCount = 7;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpDataLayout, 2);
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.Controls.Add(this.btnUpperLowerMismatch, 2, 0);
            this.tlpDataLayout.Controls.Add(this.btnDefectImage, 1, 0);
            this.tlpDataLayout.Controls.Add(this.btnDefectData, 0, 0);
            this.tlpDataLayout.Controls.Add(this.pnlDataArea, 0, 1);
            this.tlpDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataLayout.ForeColor = System.Drawing.Color.White;
            this.tlpDataLayout.Location = new System.Drawing.Point(450, 545);
            this.tlpDataLayout.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tlpDataLayout.Name = "tlpDataLayout";
            this.tlpDataLayout.RowCount = 2;
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDataLayout.Size = new System.Drawing.Size(1175, 255);
            this.tlpDataLayout.TabIndex = 6;
            // 
            // btnUpperLowerMismatch
            // 
            this.btnUpperLowerMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.btnUpperLowerMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpperLowerMismatch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpperLowerMismatch.FlatAppearance.BorderSize = 0;
            this.btnUpperLowerMismatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpperLowerMismatch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpperLowerMismatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnUpperLowerMismatch.Location = new System.Drawing.Point(320, 0);
            this.btnUpperLowerMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpperLowerMismatch.Name = "btnUpperLowerMismatch";
            this.btnUpperLowerMismatch.Size = new System.Drawing.Size(160, 40);
            this.btnUpperLowerMismatch.TabIndex = 13;
            this.btnUpperLowerMismatch.Text = "U/L MISMATCH";
            this.btnUpperLowerMismatch.UseVisualStyleBackColor = false;
            this.btnUpperLowerMismatch.Click += new System.EventHandler(this.SelectMisMatch_Click);
            // 
            // btnDefectImage
            // 
            this.btnDefectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.btnDefectImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefectImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDefectImage.FlatAppearance.BorderSize = 0;
            this.btnDefectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefectImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDefectImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnDefectImage.Location = new System.Drawing.Point(160, 0);
            this.btnDefectImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnDefectImage.Name = "btnDefectImage";
            this.btnDefectImage.Size = new System.Drawing.Size(160, 40);
            this.btnDefectImage.TabIndex = 12;
            this.btnDefectImage.Text = "DEFECT IMAGE";
            this.btnDefectImage.UseVisualStyleBackColor = false;
            this.btnDefectImage.Click += new System.EventHandler(this.SelectDefectImage_Click);
            // 
            // btnDefectData
            // 
            this.btnDefectData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.btnDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefectData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDefectData.FlatAppearance.BorderSize = 3;
            this.btnDefectData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefectData.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDefectData.ForeColor = System.Drawing.Color.White;
            this.btnDefectData.Location = new System.Drawing.Point(0, 0);
            this.btnDefectData.Margin = new System.Windows.Forms.Padding(0);
            this.btnDefectData.Name = "btnDefectData";
            this.btnDefectData.Size = new System.Drawing.Size(160, 40);
            this.btnDefectData.TabIndex = 11;
            this.btnDefectData.Text = "DEFECT DATA";
            this.btnDefectData.UseVisualStyleBackColor = false;
            this.btnDefectData.Click += new System.EventHandler(this.SelectDefectData_Click);
            // 
            // pnlDataArea
            // 
            this.pnlDataArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpDataLayout.SetColumnSpan(this.pnlDataArea, 7);
            this.pnlDataArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataArea.Location = new System.Drawing.Point(0, 40);
            this.pnlDataArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDataArea.Name = "pnlDataArea";
            this.pnlDataArea.Size = new System.Drawing.Size(1175, 215);
            this.pnlDataArea.TabIndex = 6;
            // 
            // pnlLowerImage
            // 
            this.pnlLowerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLowerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowerImage.Location = new System.Drawing.Point(587, 35);
            this.pnlLowerImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLowerImage.Name = "pnlLowerImage";
            this.pnlLowerImage.Size = new System.Drawing.Size(588, 415);
            this.pnlLowerImage.TabIndex = 9;
            // 
            // pnlUpperImage
            // 
            this.pnlUpperImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpperImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpperImage.Location = new System.Drawing.Point(0, 35);
            this.pnlUpperImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUpperImage.Name = "pnlUpperImage";
            this.pnlUpperImage.Size = new System.Drawing.Size(587, 415);
            this.pnlUpperImage.TabIndex = 5;
            // 
            // tlpLowerMismatch
            // 
            this.tlpLowerMismatch.ColumnCount = 2;
            this.tlpLowerMismatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLowerMismatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLowerMismatch.Controls.Add(this.lblLowerLeftMismatch, 0, 0);
            this.tlpLowerMismatch.Controls.Add(this.lblLowerLeftMismatchValue, 1, 0);
            this.tlpLowerMismatch.Controls.Add(this.lblLowerRightMismatch, 0, 2);
            this.tlpLowerMismatch.Controls.Add(this.lblLowerRightMismatchValue, 1, 2);
            this.tlpLowerMismatch.Controls.Add(this.lblLowerCenterMismatch, 0, 1);
            this.tlpLowerMismatch.Controls.Add(this.lblLowerCenterMismatchValue, 1, 1);
            this.tlpLowerMismatch.Location = new System.Drawing.Point(585, 0);
            this.tlpLowerMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLowerMismatch.Name = "tlpLowerMismatch";
            this.tlpLowerMismatch.RowCount = 3;
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.Size = new System.Drawing.Size(194, 78);
            this.tlpLowerMismatch.TabIndex = 12;
            // 
            // lblLowerLeftMismatch
            // 
            this.lblLowerLeftMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerLeftMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerLeftMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerLeftMismatch.ForeColor = System.Drawing.Color.White;
            this.lblLowerLeftMismatch.Location = new System.Drawing.Point(0, 0);
            this.lblLowerLeftMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerLeftMismatch.Name = "lblLowerLeftMismatch";
            this.lblLowerLeftMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblLowerLeftMismatch.TabIndex = 8;
            this.lblLowerLeftMismatch.Text = "Left :";
            this.lblLowerLeftMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerLeftMismatchValue
            // 
            this.lblLowerLeftMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerLeftMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerLeftMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerLeftMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblLowerLeftMismatchValue.Location = new System.Drawing.Point(97, 0);
            this.lblLowerLeftMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerLeftMismatchValue.Name = "lblLowerLeftMismatchValue";
            this.lblLowerLeftMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerLeftMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblLowerLeftMismatchValue.TabIndex = 9;
            this.lblLowerLeftMismatchValue.Text = "11.8mm";
            this.lblLowerLeftMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerCenterMismatch
            // 
            this.lblLowerCenterMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerCenterMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerCenterMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerCenterMismatch.ForeColor = System.Drawing.Color.White;
            this.lblLowerCenterMismatch.Location = new System.Drawing.Point(0, 26);
            this.lblLowerCenterMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerCenterMismatch.Name = "lblLowerCenterMismatch";
            this.lblLowerCenterMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblLowerCenterMismatch.TabIndex = 10;
            this.lblLowerCenterMismatch.Text = "Center :";
            this.lblLowerCenterMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerRightMismatch
            // 
            this.lblLowerRightMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerRightMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerRightMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerRightMismatch.ForeColor = System.Drawing.Color.White;
            this.lblLowerRightMismatch.Location = new System.Drawing.Point(0, 52);
            this.lblLowerRightMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerRightMismatch.Name = "lblLowerRightMismatch";
            this.lblLowerRightMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblLowerRightMismatch.TabIndex = 11;
            this.lblLowerRightMismatch.Text = "Right :";
            this.lblLowerRightMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerRightMismatchValue
            // 
            this.lblLowerRightMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerRightMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerRightMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerRightMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblLowerRightMismatchValue.Location = new System.Drawing.Point(97, 52);
            this.lblLowerRightMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerRightMismatchValue.Name = "lblLowerRightMismatchValue";
            this.lblLowerRightMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerRightMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblLowerRightMismatchValue.TabIndex = 12;
            this.lblLowerRightMismatchValue.Text = "12.1mm";
            this.lblLowerRightMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerCenterMismatchValue
            // 
            this.lblLowerCenterMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerCenterMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerCenterMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerCenterMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblLowerCenterMismatchValue.Location = new System.Drawing.Point(97, 26);
            this.lblLowerCenterMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerCenterMismatchValue.Name = "lblLowerCenterMismatchValue";
            this.lblLowerCenterMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerCenterMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblLowerCenterMismatchValue.TabIndex = 13;
            this.lblLowerCenterMismatchValue.Text = "23.8mm";
            this.lblLowerCenterMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpUpperMismatch
            // 
            this.tlpUpperMismatch.ColumnCount = 2;
            this.tlpUpperMismatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUpperMismatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUpperMismatch.Controls.Add(this.lblUpperLeftMismatch, 0, 0);
            this.tlpUpperMismatch.Controls.Add(this.lblUpperLeftMismatchValue, 1, 0);
            this.tlpUpperMismatch.Controls.Add(this.lblUpperCenterMismatch, 0, 1);
            this.tlpUpperMismatch.Controls.Add(this.lblUpperCenterMismatchValue, 1, 1);
            this.tlpUpperMismatch.Controls.Add(this.lblUpperRightMismatch, 0, 2);
            this.tlpUpperMismatch.Controls.Add(this.lblUpperRightMismatchValue, 1, 2);
            this.tlpUpperMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUpperMismatch.Location = new System.Drawing.Point(0, 0);
            this.tlpUpperMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUpperMismatch.Name = "tlpUpperMismatch";
            this.tlpUpperMismatch.RowCount = 3;
            this.tlpUpperMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperMismatch.Size = new System.Drawing.Size(194, 78);
            this.tlpUpperMismatch.TabIndex = 14;
            // 
            // lblUpperCenterMismatchValue
            // 
            this.lblUpperCenterMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperCenterMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperCenterMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperCenterMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperCenterMismatchValue.Location = new System.Drawing.Point(97, 26);
            this.lblUpperCenterMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperCenterMismatchValue.Name = "lblUpperCenterMismatchValue";
            this.lblUpperCenterMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperCenterMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblUpperCenterMismatchValue.TabIndex = 13;
            this.lblUpperCenterMismatchValue.Text = "24.0mm";
            this.lblUpperCenterMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperRightMismatchValue
            // 
            this.lblUpperRightMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperRightMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperRightMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperRightMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperRightMismatchValue.Location = new System.Drawing.Point(97, 52);
            this.lblUpperRightMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperRightMismatchValue.Name = "lblUpperRightMismatchValue";
            this.lblUpperRightMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperRightMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblUpperRightMismatchValue.TabIndex = 12;
            this.lblUpperRightMismatchValue.Text = "11.7mm";
            this.lblUpperRightMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperRightMismatch
            // 
            this.lblUpperRightMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperRightMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperRightMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperRightMismatch.ForeColor = System.Drawing.Color.White;
            this.lblUpperRightMismatch.Location = new System.Drawing.Point(0, 52);
            this.lblUpperRightMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperRightMismatch.Name = "lblUpperRightMismatch";
            this.lblUpperRightMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblUpperRightMismatch.TabIndex = 11;
            this.lblUpperRightMismatch.Text = "Right :";
            this.lblUpperRightMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperCenterMismatch
            // 
            this.lblUpperCenterMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperCenterMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperCenterMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperCenterMismatch.ForeColor = System.Drawing.Color.White;
            this.lblUpperCenterMismatch.Location = new System.Drawing.Point(0, 26);
            this.lblUpperCenterMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperCenterMismatch.Name = "lblUpperCenterMismatch";
            this.lblUpperCenterMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblUpperCenterMismatch.TabIndex = 10;
            this.lblUpperCenterMismatch.Text = "Center :";
            this.lblUpperCenterMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperLeftMismatchValue
            // 
            this.lblUpperLeftMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperLeftMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperLeftMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperLeftMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperLeftMismatchValue.Location = new System.Drawing.Point(97, 0);
            this.lblUpperLeftMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperLeftMismatchValue.Name = "lblUpperLeftMismatchValue";
            this.lblUpperLeftMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperLeftMismatchValue.Size = new System.Drawing.Size(97, 26);
            this.lblUpperLeftMismatchValue.TabIndex = 9;
            this.lblUpperLeftMismatchValue.Text = "12.3mm";
            this.lblUpperLeftMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperLeftMismatch
            // 
            this.lblUpperLeftMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperLeftMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperLeftMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperLeftMismatch.ForeColor = System.Drawing.Color.White;
            this.lblUpperLeftMismatch.Location = new System.Drawing.Point(0, 0);
            this.lblUpperLeftMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperLeftMismatch.Name = "lblUpperLeftMismatch";
            this.lblUpperLeftMismatch.Size = new System.Drawing.Size(97, 26);
            this.lblUpperLeftMismatch.TabIndex = 8;
            this.lblUpperLeftMismatch.Text = "Left :";
            this.lblUpperLeftMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpUpperSummary
            // 
            this.tlpUpperSummary.ColumnCount = 4;
            this.tlpUpperSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUpperSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUpperSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUpperSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem1, 0, 0);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem1Value, 1, 0);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem2, 0, 1);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem2Value, 1, 1);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem3, 0, 2);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem3Value, 1, 2);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem4, 2, 0);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem4Value, 3, 0);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem5, 2, 1);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem5Value, 3, 1);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem6, 2, 2);
            this.tlpUpperSummary.Controls.Add(this.lblUpperSummaryItem6Value, 3, 2);
            this.tlpUpperSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUpperSummary.Location = new System.Drawing.Point(194, 0);
            this.tlpUpperSummary.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUpperSummary.Name = "tlpUpperSummary";
            this.tlpUpperSummary.RowCount = 3;
            this.tlpUpperSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpUpperSummary.Size = new System.Drawing.Size(291, 78);
            this.tlpUpperSummary.TabIndex = 15;
            // 
            // lblUpperSummaryItem1
            // 
            this.lblUpperSummaryItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem1.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem1.Location = new System.Drawing.Point(0, 0);
            this.lblUpperSummaryItem1.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem1.Name = "lblUpperSummaryItem1";
            this.lblUpperSummaryItem1.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem1.TabIndex = 8;
            this.lblUpperSummaryItem1.Text = "PinHole :";
            this.lblUpperSummaryItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem1Value
            // 
            this.lblUpperSummaryItem1Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem1Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem1Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem1Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem1Value.Location = new System.Drawing.Point(72, 0);
            this.lblUpperSummaryItem1Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem1Value.Name = "lblUpperSummaryItem1Value";
            this.lblUpperSummaryItem1Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem1Value.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem1Value.TabIndex = 9;
            this.lblUpperSummaryItem1Value.Text = "5ea";
            this.lblUpperSummaryItem1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperSummaryItem2
            // 
            this.lblUpperSummaryItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem2.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem2.Location = new System.Drawing.Point(0, 26);
            this.lblUpperSummaryItem2.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem2.Name = "lblUpperSummaryItem2";
            this.lblUpperSummaryItem2.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem2.TabIndex = 10;
            this.lblUpperSummaryItem2.Text = "Dent :";
            this.lblUpperSummaryItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem2Value
            // 
            this.lblUpperSummaryItem2Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem2Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem2Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem2Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem2Value.Location = new System.Drawing.Point(72, 26);
            this.lblUpperSummaryItem2Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem2Value.Name = "lblUpperSummaryItem2Value";
            this.lblUpperSummaryItem2Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem2Value.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem2Value.TabIndex = 13;
            this.lblUpperSummaryItem2Value.Text = "1ea";
            this.lblUpperSummaryItem2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperSummaryItem3
            // 
            this.lblUpperSummaryItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem3.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem3.Location = new System.Drawing.Point(0, 52);
            this.lblUpperSummaryItem3.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem3.Name = "lblUpperSummaryItem3";
            this.lblUpperSummaryItem3.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem3.TabIndex = 11;
            this.lblUpperSummaryItem3.Text = "Crater :";
            this.lblUpperSummaryItem3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem3Value
            // 
            this.lblUpperSummaryItem3Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem3Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem3Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem3Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem3Value.Location = new System.Drawing.Point(72, 52);
            this.lblUpperSummaryItem3Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem3Value.Name = "lblUpperSummaryItem3Value";
            this.lblUpperSummaryItem3Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem3Value.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem3Value.TabIndex = 12;
            this.lblUpperSummaryItem3Value.Text = "0ea";
            this.lblUpperSummaryItem3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperSummaryItem4
            // 
            this.lblUpperSummaryItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem4.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem4.Location = new System.Drawing.Point(144, 0);
            this.lblUpperSummaryItem4.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem4.Name = "lblUpperSummaryItem4";
            this.lblUpperSummaryItem4.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem4.TabIndex = 14;
            this.lblUpperSummaryItem4.Text = "Island :";
            this.lblUpperSummaryItem4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem5
            // 
            this.lblUpperSummaryItem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem5.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem5.Location = new System.Drawing.Point(144, 26);
            this.lblUpperSummaryItem5.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem5.Name = "lblUpperSummaryItem5";
            this.lblUpperSummaryItem5.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem5.TabIndex = 15;
            this.lblUpperSummaryItem5.Text = "Drag :";
            this.lblUpperSummaryItem5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem6
            // 
            this.lblUpperSummaryItem6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem6.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem6.Location = new System.Drawing.Point(144, 52);
            this.lblUpperSummaryItem6.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem6.Name = "lblUpperSummaryItem6";
            this.lblUpperSummaryItem6.Size = new System.Drawing.Size(72, 26);
            this.lblUpperSummaryItem6.TabIndex = 16;
            this.lblUpperSummaryItem6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperSummaryItem4Value
            // 
            this.lblUpperSummaryItem4Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem4Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem4Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem4Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem4Value.Location = new System.Drawing.Point(216, 0);
            this.lblUpperSummaryItem4Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem4Value.Name = "lblUpperSummaryItem4Value";
            this.lblUpperSummaryItem4Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem4Value.Size = new System.Drawing.Size(75, 26);
            this.lblUpperSummaryItem4Value.TabIndex = 17;
            this.lblUpperSummaryItem4Value.Text = "1ea";
            this.lblUpperSummaryItem4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperSummaryItem5Value
            // 
            this.lblUpperSummaryItem5Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem5Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem5Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem5Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem5Value.Location = new System.Drawing.Point(216, 26);
            this.lblUpperSummaryItem5Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem5Value.Name = "lblUpperSummaryItem5Value";
            this.lblUpperSummaryItem5Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem5Value.Size = new System.Drawing.Size(75, 26);
            this.lblUpperSummaryItem5Value.TabIndex = 18;
            this.lblUpperSummaryItem5Value.Text = "1ea";
            this.lblUpperSummaryItem5Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperSummaryItem6Value
            // 
            this.lblUpperSummaryItem6Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperSummaryItem6Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperSummaryItem6Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperSummaryItem6Value.ForeColor = System.Drawing.Color.White;
            this.lblUpperSummaryItem6Value.Location = new System.Drawing.Point(216, 52);
            this.lblUpperSummaryItem6Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperSummaryItem6Value.Name = "lblUpperSummaryItem6Value";
            this.lblUpperSummaryItem6Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperSummaryItem6Value.Size = new System.Drawing.Size(75, 26);
            this.lblUpperSummaryItem6Value.TabIndex = 19;
            this.lblUpperSummaryItem6Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpLowerSummary
            // 
            this.tlpLowerSummary.ColumnCount = 4;
            this.tlpLowerSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLowerSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLowerSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLowerSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem1, 0, 0);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem1Value, 1, 0);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem2, 0, 1);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem2Value, 1, 1);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem3, 0, 2);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem3Value, 1, 2);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem4, 2, 0);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem4Value, 3, 0);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem5, 2, 1);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItemValue, 3, 1);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem6, 2, 2);
            this.tlpLowerSummary.Controls.Add(this.lblLowerSummaryItem6Value, 3, 2);
            this.tlpLowerSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLowerSummary.Location = new System.Drawing.Point(779, 0);
            this.tlpLowerSummary.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLowerSummary.Name = "tlpLowerSummary";
            this.tlpLowerSummary.RowCount = 3;
            this.tlpLowerSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerSummary.Size = new System.Drawing.Size(291, 78);
            this.tlpLowerSummary.TabIndex = 16;
            // 
            // lblLowerSummaryItem1
            // 
            this.lblLowerSummaryItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem1.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem1.Location = new System.Drawing.Point(0, 0);
            this.lblLowerSummaryItem1.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem1.Name = "lblLowerSummaryItem1";
            this.lblLowerSummaryItem1.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem1.TabIndex = 8;
            this.lblLowerSummaryItem1.Text = "PinHole :";
            this.lblLowerSummaryItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItem1Value
            // 
            this.lblLowerSummaryItem1Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem1Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem1Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem1Value.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem1Value.Location = new System.Drawing.Point(72, 0);
            this.lblLowerSummaryItem1Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem1Value.Name = "lblLowerSummaryItem1Value";
            this.lblLowerSummaryItem1Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItem1Value.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem1Value.TabIndex = 9;
            this.lblLowerSummaryItem1Value.Text = "5ea";
            this.lblLowerSummaryItem1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummaryItem2
            // 
            this.lblLowerSummaryItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem2.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem2.Location = new System.Drawing.Point(0, 26);
            this.lblLowerSummaryItem2.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem2.Name = "lblLowerSummaryItem2";
            this.lblLowerSummaryItem2.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem2.TabIndex = 10;
            this.lblLowerSummaryItem2.Text = "Dent :";
            this.lblLowerSummaryItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItem2Value
            // 
            this.lblLowerSummaryItem2Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem2Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem2Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem2Value.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem2Value.Location = new System.Drawing.Point(72, 26);
            this.lblLowerSummaryItem2Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem2Value.Name = "lblLowerSummaryItem2Value";
            this.lblLowerSummaryItem2Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItem2Value.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem2Value.TabIndex = 13;
            this.lblLowerSummaryItem2Value.Text = "1ea";
            this.lblLowerSummaryItem2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummaryItem3
            // 
            this.lblLowerSummaryItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem3.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem3.Location = new System.Drawing.Point(0, 52);
            this.lblLowerSummaryItem3.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem3.Name = "lblLowerSummaryItem3";
            this.lblLowerSummaryItem3.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem3.TabIndex = 11;
            this.lblLowerSummaryItem3.Text = "Crater :";
            this.lblLowerSummaryItem3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItem3Value
            // 
            this.lblLowerSummaryItem3Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem3Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem3Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem3Value.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem3Value.Location = new System.Drawing.Point(72, 52);
            this.lblLowerSummaryItem3Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem3Value.Name = "lblLowerSummaryItem3Value";
            this.lblLowerSummaryItem3Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItem3Value.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem3Value.TabIndex = 12;
            this.lblLowerSummaryItem3Value.Text = "0ea";
            this.lblLowerSummaryItem3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummaryItem4
            // 
            this.lblLowerSummaryItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem4.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem4.Location = new System.Drawing.Point(144, 0);
            this.lblLowerSummaryItem4.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem4.Name = "lblLowerSummaryItem4";
            this.lblLowerSummaryItem4.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem4.TabIndex = 14;
            this.lblLowerSummaryItem4.Text = "Island :";
            this.lblLowerSummaryItem4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItem4Value
            // 
            this.lblLowerSummaryItem4Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem4Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem4Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem4Value.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem4Value.Location = new System.Drawing.Point(216, 0);
            this.lblLowerSummaryItem4Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem4Value.Name = "lblLowerSummaryItem4Value";
            this.lblLowerSummaryItem4Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItem4Value.Size = new System.Drawing.Size(75, 26);
            this.lblLowerSummaryItem4Value.TabIndex = 17;
            this.lblLowerSummaryItem4Value.Text = "1ea";
            this.lblLowerSummaryItem4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummaryItem5
            // 
            this.lblLowerSummaryItem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem5.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem5.Location = new System.Drawing.Point(144, 26);
            this.lblLowerSummaryItem5.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem5.Name = "lblLowerSummaryItem5";
            this.lblLowerSummaryItem5.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem5.TabIndex = 15;
            this.lblLowerSummaryItem5.Text = "Drag :";
            this.lblLowerSummaryItem5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItemValue
            // 
            this.lblLowerSummaryItemValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItemValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItemValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItemValue.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItemValue.Location = new System.Drawing.Point(216, 26);
            this.lblLowerSummaryItemValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItemValue.Name = "lblLowerSummaryItemValue";
            this.lblLowerSummaryItemValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItemValue.Size = new System.Drawing.Size(75, 26);
            this.lblLowerSummaryItemValue.TabIndex = 18;
            this.lblLowerSummaryItemValue.Text = "1ea";
            this.lblLowerSummaryItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummaryItem6
            // 
            this.lblLowerSummaryItem6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem6.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem6.Location = new System.Drawing.Point(144, 52);
            this.lblLowerSummaryItem6.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem6.Name = "lblLowerSummaryItem6";
            this.lblLowerSummaryItem6.Size = new System.Drawing.Size(72, 26);
            this.lblLowerSummaryItem6.TabIndex = 16;
            this.lblLowerSummaryItem6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerSummaryItem6Value
            // 
            this.lblLowerSummaryItem6Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummaryItem6Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummaryItem6Value.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummaryItem6Value.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummaryItem6Value.Location = new System.Drawing.Point(216, 52);
            this.lblLowerSummaryItem6Value.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummaryItem6Value.Name = "lblLowerSummaryItem6Value";
            this.lblLowerSummaryItem6Value.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerSummaryItem6Value.Size = new System.Drawing.Size(75, 26);
            this.lblLowerSummaryItem6Value.TabIndex = 19;
            this.lblLowerSummaryItem6Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpFunctionLayout.SetColumnSpan(this.pnlSummary, 2);
            this.pnlSummary.Controls.Add(this.tlpSummaryLayout);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(450, 450);
            this.pnlSummary.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1175, 80);
            this.pnlSummary.TabIndex = 10;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpMainPageLayout);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1700, 800);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.SizeChanged += new System.EventHandler(this.MainPage_SizeChanged);
            this.tlpMainPageLayout.ResumeLayout(false);
            this.tlpSideBarLayout.ResumeLayout(false);
            this.tlpCommonFunctionLayout.ResumeLayout(false);
            this.tlpStop.ResumeLayout(false);
            this.tlpStart.ResumeLayout(false);
            this.tlpFunctionLayout.ResumeLayout(false);
            this.tlpDefectMap.ResumeLayout(false);
            this.tlpDefectMap.PerformLayout();
            this.tlpImages.ResumeLayout(false);
            this.tlpImages.PerformLayout();
            this.tlpSummaryLayout.ResumeLayout(false);
            this.tlpDataLayout.ResumeLayout(false);
            this.tlpLowerMismatch.ResumeLayout(false);
            this.tlpUpperMismatch.ResumeLayout(false);
            this.tlpUpperSummary.ResumeLayout(false);
            this.tlpLowerSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainPageLayout;
        private System.Windows.Forms.TableLayoutPanel tlpSideBarLayout;
        private System.Windows.Forms.TableLayoutPanel tlpCommonFunctionLayout;
        private System.Windows.Forms.TableLayoutPanel tlpStop;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStopText;
        private System.Windows.Forms.TableLayoutPanel tlpStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblStartText;
        private System.Windows.Forms.TableLayoutPanel tlpFunctionLayout;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TableLayoutPanel tlpDataLayout;
        private System.Windows.Forms.Panel pnlDataArea;
        private System.Windows.Forms.Panel pnlDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
        private System.Windows.Forms.Label lblLowerCam;
        private System.Windows.Forms.Label lblUpperCam;
        private System.Windows.Forms.TableLayoutPanel tlpDefectMap;
        private System.Windows.Forms.Label lblDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpSummaryLayout;
        private System.Windows.Forms.Button btnUpperJudgement;
        private System.Windows.Forms.Button btnLowerJudgement;
        private System.Windows.Forms.Button btnUpperLowerMismatch;
        private System.Windows.Forms.Button btnDefectImage;
        private System.Windows.Forms.Button btnDefectData;
        private System.Windows.Forms.Panel pnlUpperImage;
        private System.Windows.Forms.Panel pnlLowerImage;
        private System.Windows.Forms.TableLayoutPanel tlpLowerMismatch;
        private System.Windows.Forms.Label lblLowerCenterMismatchValue;
        private System.Windows.Forms.Label lblLowerRightMismatchValue;
        private System.Windows.Forms.Label lblLowerRightMismatch;
        private System.Windows.Forms.Label lblLowerCenterMismatch;
        private System.Windows.Forms.Label lblLowerLeftMismatchValue;
        private System.Windows.Forms.Label lblLowerLeftMismatch;
        private System.Windows.Forms.TableLayoutPanel tlpUpperMismatch;
        private System.Windows.Forms.Label lblUpperCenterMismatchValue;
        private System.Windows.Forms.Label lblUpperRightMismatchValue;
        private System.Windows.Forms.Label lblUpperRightMismatch;
        private System.Windows.Forms.Label lblUpperCenterMismatch;
        private System.Windows.Forms.Label lblUpperLeftMismatchValue;
        private System.Windows.Forms.Label lblUpperLeftMismatch;
        private System.Windows.Forms.TableLayoutPanel tlpUpperSummary;
        private System.Windows.Forms.Label lblUpperSummaryItem1;
        private System.Windows.Forms.Label lblUpperSummaryItem1Value;
        private System.Windows.Forms.Label lblUpperSummaryItem2;
        private System.Windows.Forms.Label lblUpperSummaryItem2Value;
        private System.Windows.Forms.Label lblUpperSummaryItem3;
        private System.Windows.Forms.Label lblUpperSummaryItem3Value;
        private System.Windows.Forms.Label lblUpperSummaryItem6Value;
        private System.Windows.Forms.Label lblUpperSummaryItem5Value;
        private System.Windows.Forms.Label lblUpperSummaryItem4Value;
        private System.Windows.Forms.Label lblUpperSummaryItem6;
        private System.Windows.Forms.Label lblUpperSummaryItem5;
        private System.Windows.Forms.Label lblUpperSummaryItem4;
        private System.Windows.Forms.TableLayoutPanel tlpLowerSummary;
        private System.Windows.Forms.Label lblLowerSummaryItem1;
        private System.Windows.Forms.Label lblLowerSummaryItem1Value;
        private System.Windows.Forms.Label lblLowerSummaryItem2;
        private System.Windows.Forms.Label lblLowerSummaryItem2Value;
        private System.Windows.Forms.Label lblLowerSummaryItem3;
        private System.Windows.Forms.Label lblLowerSummaryItem3Value;
        private System.Windows.Forms.Label lblLowerSummaryItem4;
        private System.Windows.Forms.Label lblLowerSummaryItem4Value;
        private System.Windows.Forms.Label lblLowerSummaryItem5;
        private System.Windows.Forms.Label lblLowerSummaryItemValue;
        private System.Windows.Forms.Label lblLowerSummaryItem6;
        private System.Windows.Forms.Label lblLowerSummaryItem6Value;
        private System.Windows.Forms.Panel pnlSummary;
    }
}
