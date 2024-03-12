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
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperCam = new System.Windows.Forms.Label();
            this.lblLowerCam = new System.Windows.Forms.Label();
            this.pnlUpperImage = new System.Windows.Forms.Panel();
            this.pnlLowerImage = new System.Windows.Forms.Panel();
            this.pnlMismatch = new System.Windows.Forms.Panel();
            this.tlpMismatchLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUpperMismatch = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperLeftMismatch = new System.Windows.Forms.Label();
            this.lblUpperLeftMismatchValue = new System.Windows.Forms.Label();
            this.lblUpperCenterMismatch = new System.Windows.Forms.Label();
            this.lblUpperCenterMismatchValue = new System.Windows.Forms.Label();
            this.lblUpperRightMismatch = new System.Windows.Forms.Label();
            this.lblUpperRightMismatchValue = new System.Windows.Forms.Label();
            this.btnUpperJudgement = new System.Windows.Forms.Button();
            this.tlpLowerMismatch = new System.Windows.Forms.TableLayoutPanel();
            this.lblLowerLeftMismatch = new System.Windows.Forms.Label();
            this.lblLowerLeftMismatchValue = new System.Windows.Forms.Label();
            this.lblLowerRightMismatch = new System.Windows.Forms.Label();
            this.lblLowerRightMismatchValue = new System.Windows.Forms.Label();
            this.lblLowerCenterMismatch = new System.Windows.Forms.Label();
            this.lblLowerCenterMismatchValue = new System.Windows.Forms.Label();
            this.btnLowerJudgement = new System.Windows.Forms.Button();
            this.tlpDefectInfos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDefectInfoArea = new System.Windows.Forms.Panel();
            this.lblDefectInfos = new System.Windows.Forms.Label();
            this.tlpDefectMap = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tlpSummaryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDefectSummaryPinholeEllipse = new System.Windows.Forms.Label();
            this.lblDefectSummaryPinhole = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDefectSummaryDentEllipse = new System.Windows.Forms.Label();
            this.lblDefectSummaryDent = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDefectSummaryCraterEllipse = new System.Windows.Forms.Label();
            this.lblDefectSummaryCrater = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDefectSummaryIslandEllipse = new System.Windows.Forms.Label();
            this.lblDefectSummaryIsland = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblDefectSummaryDragEllipse = new System.Windows.Forms.Label();
            this.lblDefectSummaryDrag = new System.Windows.Forms.Label();
            this.lblDefectSummaryPinholeValue = new System.Windows.Forms.Label();
            this.lblDefectSummaryDentValue = new System.Windows.Forms.Label();
            this.lblDefectSummaryCraterValue = new System.Windows.Forms.Label();
            this.lblDefectSummaryIslandValue = new System.Windows.Forms.Label();
            this.lblDefectSummaryDragValue = new System.Windows.Forms.Label();
            this.lblDefectMap = new System.Windows.Forms.Label();
            this.pnlDefectMap = new System.Windows.Forms.Panel();
            this.tlpMismatchChartLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblMismatchChart1 = new System.Windows.Forms.Label();
            this.lblMismatchChart2 = new System.Windows.Forms.Label();
            this.pnlMismatchChart1 = new System.Windows.Forms.Panel();
            this.pnlMismatchChart2 = new System.Windows.Forms.Panel();
            this.tlpMainPageLayout.SuspendLayout();
            this.tlpSideBarLayout.SuspendLayout();
            this.tlpCommonFunctionLayout.SuspendLayout();
            this.tlpStop.SuspendLayout();
            this.tlpStart.SuspendLayout();
            this.tlpFunctionLayout.SuspendLayout();
            this.tlpImages.SuspendLayout();
            this.pnlMismatch.SuspendLayout();
            this.tlpMismatchLayout.SuspendLayout();
            this.tlpUpperMismatch.SuspendLayout();
            this.tlpLowerMismatch.SuspendLayout();
            this.tlpDefectInfos.SuspendLayout();
            this.tlpDefectMap.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.tlpSummaryLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpMismatchChartLayout.SuspendLayout();
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
            this.tlpMainPageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainPageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainPageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tlpFunctionLayout.ColumnCount = 4;
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tlpFunctionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpFunctionLayout.Controls.Add(this.tlpImages, 0, 0);
            this.tlpFunctionLayout.Controls.Add(this.pnlMismatch, 0, 1);
            this.tlpFunctionLayout.Controls.Add(this.tlpDefectInfos, 2, 0);
            this.tlpFunctionLayout.Controls.Add(this.tlpDefectMap, 3, 0);
            this.tlpFunctionLayout.Controls.Add(this.tlpMismatchChartLayout, 0, 2);
            this.tlpFunctionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionLayout.Location = new System.Drawing.Point(75, 0);
            this.tlpFunctionLayout.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tlpFunctionLayout.Name = "tlpFunctionLayout";
            this.tlpFunctionLayout.RowCount = 3;
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFunctionLayout.Size = new System.Drawing.Size(1625, 800);
            this.tlpFunctionLayout.TabIndex = 0;
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
            this.tlpImages.Location = new System.Drawing.Point(0, 0);
            this.tlpImages.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 1;
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpImages.Size = new System.Drawing.Size(864, 450);
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
            this.lblUpperCam.Size = new System.Drawing.Size(432, 35);
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
            this.lblLowerCam.Location = new System.Drawing.Point(432, 0);
            this.lblLowerCam.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerCam.Name = "lblLowerCam";
            this.lblLowerCam.Size = new System.Drawing.Size(432, 35);
            this.lblLowerCam.TabIndex = 8;
            this.lblLowerCam.Tag = "";
            this.lblLowerCam.Text = "LOWER CAM";
            this.lblLowerCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUpperImage
            // 
            this.pnlUpperImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpperImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpperImage.Location = new System.Drawing.Point(0, 35);
            this.pnlUpperImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUpperImage.Name = "pnlUpperImage";
            this.pnlUpperImage.Size = new System.Drawing.Size(432, 415);
            this.pnlUpperImage.TabIndex = 5;
            // 
            // pnlLowerImage
            // 
            this.pnlLowerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLowerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowerImage.Location = new System.Drawing.Point(432, 35);
            this.pnlLowerImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLowerImage.Name = "pnlLowerImage";
            this.pnlLowerImage.Size = new System.Drawing.Size(432, 415);
            this.pnlLowerImage.TabIndex = 9;
            // 
            // pnlMismatch
            // 
            this.pnlMismatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpFunctionLayout.SetColumnSpan(this.pnlMismatch, 2);
            this.pnlMismatch.Controls.Add(this.tlpMismatchLayout);
            this.pnlMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMismatch.Location = new System.Drawing.Point(0, 450);
            this.pnlMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMismatch.Name = "pnlMismatch";
            this.pnlMismatch.Size = new System.Drawing.Size(864, 80);
            this.pnlMismatch.TabIndex = 10;
            // 
            // tlpMismatchLayout
            // 
            this.tlpMismatchLayout.ColumnCount = 6;
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMismatchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlpMismatchLayout.Controls.Add(this.tlpUpperMismatch, 0, 0);
            this.tlpMismatchLayout.Controls.Add(this.btnUpperJudgement, 2, 0);
            this.tlpMismatchLayout.Controls.Add(this.tlpLowerMismatch, 3, 0);
            this.tlpMismatchLayout.Controls.Add(this.btnLowerJudgement, 5, 0);
            this.tlpMismatchLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMismatchLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpMismatchLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMismatchLayout.Name = "tlpMismatchLayout";
            this.tlpMismatchLayout.RowCount = 1;
            this.tlpMismatchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMismatchLayout.Size = new System.Drawing.Size(862, 78);
            this.tlpMismatchLayout.TabIndex = 8;
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
            this.tlpUpperMismatch.Size = new System.Drawing.Size(145, 78);
            this.tlpUpperMismatch.TabIndex = 14;
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
            this.lblUpperLeftMismatch.Size = new System.Drawing.Size(72, 26);
            this.lblUpperLeftMismatch.TabIndex = 8;
            this.lblUpperLeftMismatch.Text = "Left :";
            this.lblUpperLeftMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperLeftMismatchValue
            // 
            this.lblUpperLeftMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperLeftMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperLeftMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperLeftMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperLeftMismatchValue.Location = new System.Drawing.Point(72, 0);
            this.lblUpperLeftMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperLeftMismatchValue.Name = "lblUpperLeftMismatchValue";
            this.lblUpperLeftMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperLeftMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblUpperLeftMismatchValue.TabIndex = 9;
            this.lblUpperLeftMismatchValue.Text = "12.3mm";
            this.lblUpperLeftMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblUpperCenterMismatch.Size = new System.Drawing.Size(72, 26);
            this.lblUpperCenterMismatch.TabIndex = 10;
            this.lblUpperCenterMismatch.Text = "Center :";
            this.lblUpperCenterMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperCenterMismatchValue
            // 
            this.lblUpperCenterMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperCenterMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperCenterMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperCenterMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperCenterMismatchValue.Location = new System.Drawing.Point(72, 26);
            this.lblUpperCenterMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperCenterMismatchValue.Name = "lblUpperCenterMismatchValue";
            this.lblUpperCenterMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperCenterMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblUpperCenterMismatchValue.TabIndex = 13;
            this.lblUpperCenterMismatchValue.Text = "24.0mm";
            this.lblUpperCenterMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblUpperRightMismatch.Size = new System.Drawing.Size(72, 26);
            this.lblUpperRightMismatch.TabIndex = 11;
            this.lblUpperRightMismatch.Text = "Right :";
            this.lblUpperRightMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpperRightMismatchValue
            // 
            this.lblUpperRightMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperRightMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperRightMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperRightMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblUpperRightMismatchValue.Location = new System.Drawing.Point(72, 52);
            this.lblUpperRightMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperRightMismatchValue.Name = "lblUpperRightMismatchValue";
            this.lblUpperRightMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUpperRightMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblUpperRightMismatchValue.TabIndex = 12;
            this.lblUpperRightMismatchValue.Text = "11.7mm";
            this.lblUpperRightMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpperJudgement
            // 
            this.btnUpperJudgement.BackColor = System.Drawing.Color.LimeGreen;
            this.btnUpperJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpperJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpperJudgement.FlatAppearance.BorderSize = 2;
            this.btnUpperJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpperJudgement.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpperJudgement.ForeColor = System.Drawing.Color.White;
            this.btnUpperJudgement.Location = new System.Drawing.Point(290, 0);
            this.btnUpperJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpperJudgement.Name = "btnUpperJudgement";
            this.btnUpperJudgement.Size = new System.Drawing.Size(140, 78);
            this.btnUpperJudgement.TabIndex = 10;
            this.btnUpperJudgement.Text = "Good";
            this.btnUpperJudgement.UseVisualStyleBackColor = false;
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
            this.tlpLowerMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLowerMismatch.Location = new System.Drawing.Point(430, 0);
            this.tlpLowerMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLowerMismatch.Name = "tlpLowerMismatch";
            this.tlpLowerMismatch.RowCount = 3;
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLowerMismatch.Size = new System.Drawing.Size(145, 78);
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
            this.lblLowerLeftMismatch.Size = new System.Drawing.Size(72, 26);
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
            this.lblLowerLeftMismatchValue.Location = new System.Drawing.Point(72, 0);
            this.lblLowerLeftMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerLeftMismatchValue.Name = "lblLowerLeftMismatchValue";
            this.lblLowerLeftMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerLeftMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblLowerLeftMismatchValue.TabIndex = 9;
            this.lblLowerLeftMismatchValue.Text = "11.8mm";
            this.lblLowerLeftMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblLowerRightMismatch.Size = new System.Drawing.Size(72, 26);
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
            this.lblLowerRightMismatchValue.Location = new System.Drawing.Point(72, 52);
            this.lblLowerRightMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerRightMismatchValue.Name = "lblLowerRightMismatchValue";
            this.lblLowerRightMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerRightMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblLowerRightMismatchValue.TabIndex = 12;
            this.lblLowerRightMismatchValue.Text = "12.1mm";
            this.lblLowerRightMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblLowerCenterMismatch.Size = new System.Drawing.Size(72, 26);
            this.lblLowerCenterMismatch.TabIndex = 10;
            this.lblLowerCenterMismatch.Text = "Center :";
            this.lblLowerCenterMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLowerCenterMismatchValue
            // 
            this.lblLowerCenterMismatchValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerCenterMismatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerCenterMismatchValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerCenterMismatchValue.ForeColor = System.Drawing.Color.White;
            this.lblLowerCenterMismatchValue.Location = new System.Drawing.Point(72, 26);
            this.lblLowerCenterMismatchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerCenterMismatchValue.Name = "lblLowerCenterMismatchValue";
            this.lblLowerCenterMismatchValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblLowerCenterMismatchValue.Size = new System.Drawing.Size(73, 26);
            this.lblLowerCenterMismatchValue.TabIndex = 13;
            this.lblLowerCenterMismatchValue.Text = "23.8mm";
            this.lblLowerCenterMismatchValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLowerJudgement
            // 
            this.btnLowerJudgement.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLowerJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLowerJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLowerJudgement.FlatAppearance.BorderSize = 2;
            this.btnLowerJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowerJudgement.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLowerJudgement.ForeColor = System.Drawing.Color.White;
            this.btnLowerJudgement.Location = new System.Drawing.Point(720, 0);
            this.btnLowerJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnLowerJudgement.Name = "btnLowerJudgement";
            this.btnLowerJudgement.Size = new System.Drawing.Size(142, 78);
            this.btnLowerJudgement.TabIndex = 9;
            this.btnLowerJudgement.Text = "Good";
            this.btnLowerJudgement.UseVisualStyleBackColor = false;
            // 
            // tlpDefectInfos
            // 
            this.tlpDefectInfos.ColumnCount = 1;
            this.tlpDefectInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectInfos.Controls.Add(this.pnlDefectInfoArea, 0, 0);
            this.tlpDefectInfos.Controls.Add(this.lblDefectInfos, 0, 0);
            this.tlpDefectInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefectInfos.Location = new System.Drawing.Point(864, 0);
            this.tlpDefectInfos.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefectInfos.Name = "tlpDefectInfos";
            this.tlpDefectInfos.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tlpDefectInfos.RowCount = 1;
            this.tlpFunctionLayout.SetRowSpan(this.tlpDefectInfos, 3);
            this.tlpDefectInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefectInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDefectInfos.Size = new System.Drawing.Size(310, 800);
            this.tlpDefectInfos.TabIndex = 15;
            // 
            // pnlDefectInfoArea
            // 
            this.pnlDefectInfoArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectInfoArea.Location = new System.Drawing.Point(5, 35);
            this.pnlDefectInfoArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectInfoArea.Name = "pnlDefectInfoArea";
            this.tlpDefectInfos.SetRowSpan(this.pnlDefectInfoArea, 2);
            this.pnlDefectInfoArea.Size = new System.Drawing.Size(305, 765);
            this.pnlDefectInfoArea.TabIndex = 14;
            // 
            // lblDefectInfos
            // 
            this.lblDefectInfos.AutoSize = true;
            this.lblDefectInfos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblDefectInfos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDefectInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefectInfos.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectInfos.ForeColor = System.Drawing.Color.White;
            this.lblDefectInfos.Location = new System.Drawing.Point(5, 0);
            this.lblDefectInfos.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectInfos.Name = "lblDefectInfos";
            this.lblDefectInfos.Size = new System.Drawing.Size(305, 35);
            this.lblDefectInfos.TabIndex = 8;
            this.lblDefectInfos.Tag = "";
            this.lblDefectInfos.Text = "DEFECT IMAGES";
            this.lblDefectInfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDefectMap
            // 
            this.tlpDefectMap.ColumnCount = 1;
            this.tlpDefectMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.Controls.Add(this.pnlSummary, 0, 1);
            this.tlpDefectMap.Controls.Add(this.lblDefectMap, 0, 0);
            this.tlpDefectMap.Controls.Add(this.pnlDefectMap, 0, 2);
            this.tlpDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefectMap.Location = new System.Drawing.Point(1174, 0);
            this.tlpDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefectMap.Name = "tlpDefectMap";
            this.tlpDefectMap.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tlpDefectMap.RowCount = 3;
            this.tlpFunctionLayout.SetRowSpan(this.tlpDefectMap, 3);
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.Size = new System.Drawing.Size(451, 800);
            this.tlpDefectMap.TabIndex = 9;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.tlpSummaryLayout);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Location = new System.Drawing.Point(5, 35);
            this.pnlSummary.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(446, 80);
            this.pnlSummary.TabIndex = 17;
            // 
            // tlpSummaryLayout
            // 
            this.tlpSummaryLayout.ColumnCount = 4;
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSummaryLayout.Controls.Add(this.panel1, 0, 0);
            this.tlpSummaryLayout.Controls.Add(this.panel2, 0, 1);
            this.tlpSummaryLayout.Controls.Add(this.panel3, 0, 2);
            this.tlpSummaryLayout.Controls.Add(this.panel4, 2, 0);
            this.tlpSummaryLayout.Controls.Add(this.panel5, 2, 1);
            this.tlpSummaryLayout.Controls.Add(this.lblDefectSummaryPinholeValue, 1, 0);
            this.tlpSummaryLayout.Controls.Add(this.lblDefectSummaryDentValue, 1, 1);
            this.tlpSummaryLayout.Controls.Add(this.lblDefectSummaryCraterValue, 1, 2);
            this.tlpSummaryLayout.Controls.Add(this.lblDefectSummaryIslandValue, 3, 0);
            this.tlpSummaryLayout.Controls.Add(this.lblDefectSummaryDragValue, 3, 1);
            this.tlpSummaryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSummaryLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpSummaryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSummaryLayout.Name = "tlpSummaryLayout";
            this.tlpSummaryLayout.RowCount = 3;
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSummaryLayout.Size = new System.Drawing.Size(444, 78);
            this.tlpSummaryLayout.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDefectSummaryPinholeEllipse);
            this.panel1.Controls.Add(this.lblDefectSummaryPinhole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 26);
            this.panel1.TabIndex = 20;
            // 
            // lblDefectSummaryPinholeEllipse
            // 
            this.lblDefectSummaryPinholeEllipse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryPinholeEllipse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryPinholeEllipse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryPinholeEllipse.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryPinholeEllipse.Location = new System.Drawing.Point(5, 0);
            this.lblDefectSummaryPinholeEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryPinholeEllipse.Name = "lblDefectSummaryPinholeEllipse";
            this.lblDefectSummaryPinholeEllipse.Size = new System.Drawing.Size(26, 26);
            this.lblDefectSummaryPinholeEllipse.TabIndex = 9;
            this.lblDefectSummaryPinholeEllipse.Text = "●";
            this.lblDefectSummaryPinholeEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryPinhole
            // 
            this.lblDefectSummaryPinhole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryPinhole.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryPinhole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryPinhole.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryPinhole.Location = new System.Drawing.Point(31, 0);
            this.lblDefectSummaryPinhole.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryPinhole.Name = "lblDefectSummaryPinhole";
            this.lblDefectSummaryPinhole.Size = new System.Drawing.Size(80, 26);
            this.lblDefectSummaryPinhole.TabIndex = 8;
            this.lblDefectSummaryPinhole.Text = "PinHole :";
            this.lblDefectSummaryPinhole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDefectSummaryDentEllipse);
            this.panel2.Controls.Add(this.lblDefectSummaryDent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 26);
            this.panel2.TabIndex = 21;
            // 
            // lblDefectSummaryDentEllipse
            // 
            this.lblDefectSummaryDentEllipse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDentEllipse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryDentEllipse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDentEllipse.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDentEllipse.Location = new System.Drawing.Point(5, 0);
            this.lblDefectSummaryDentEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDentEllipse.Name = "lblDefectSummaryDentEllipse";
            this.lblDefectSummaryDentEllipse.Size = new System.Drawing.Size(26, 26);
            this.lblDefectSummaryDentEllipse.TabIndex = 9;
            this.lblDefectSummaryDentEllipse.Text = "●";
            this.lblDefectSummaryDentEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryDent
            // 
            this.lblDefectSummaryDent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDent.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryDent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDent.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDent.Location = new System.Drawing.Point(31, 0);
            this.lblDefectSummaryDent.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDent.Name = "lblDefectSummaryDent";
            this.lblDefectSummaryDent.Size = new System.Drawing.Size(80, 26);
            this.lblDefectSummaryDent.TabIndex = 10;
            this.lblDefectSummaryDent.Text = "Dent :";
            this.lblDefectSummaryDent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDefectSummaryCraterEllipse);
            this.panel3.Controls.Add(this.lblDefectSummaryCrater);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 26);
            this.panel3.TabIndex = 22;
            // 
            // lblDefectSummaryCraterEllipse
            // 
            this.lblDefectSummaryCraterEllipse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryCraterEllipse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryCraterEllipse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryCraterEllipse.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryCraterEllipse.Location = new System.Drawing.Point(5, 0);
            this.lblDefectSummaryCraterEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryCraterEllipse.Name = "lblDefectSummaryCraterEllipse";
            this.lblDefectSummaryCraterEllipse.Size = new System.Drawing.Size(26, 26);
            this.lblDefectSummaryCraterEllipse.TabIndex = 9;
            this.lblDefectSummaryCraterEllipse.Text = "●";
            this.lblDefectSummaryCraterEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryCrater
            // 
            this.lblDefectSummaryCrater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryCrater.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryCrater.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryCrater.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryCrater.Location = new System.Drawing.Point(31, 0);
            this.lblDefectSummaryCrater.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryCrater.Name = "lblDefectSummaryCrater";
            this.lblDefectSummaryCrater.Size = new System.Drawing.Size(80, 26);
            this.lblDefectSummaryCrater.TabIndex = 11;
            this.lblDefectSummaryCrater.Text = "Crater :";
            this.lblDefectSummaryCrater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblDefectSummaryIslandEllipse);
            this.panel4.Controls.Add(this.lblDefectSummaryIsland);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(222, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(111, 26);
            this.panel4.TabIndex = 23;
            // 
            // lblDefectSummaryIslandEllipse
            // 
            this.lblDefectSummaryIslandEllipse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryIslandEllipse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryIslandEllipse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryIslandEllipse.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryIslandEllipse.Location = new System.Drawing.Point(5, 0);
            this.lblDefectSummaryIslandEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryIslandEllipse.Name = "lblDefectSummaryIslandEllipse";
            this.lblDefectSummaryIslandEllipse.Size = new System.Drawing.Size(26, 26);
            this.lblDefectSummaryIslandEllipse.TabIndex = 9;
            this.lblDefectSummaryIslandEllipse.Text = "●";
            this.lblDefectSummaryIslandEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryIsland
            // 
            this.lblDefectSummaryIsland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryIsland.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryIsland.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryIsland.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryIsland.Location = new System.Drawing.Point(31, 0);
            this.lblDefectSummaryIsland.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryIsland.Name = "lblDefectSummaryIsland";
            this.lblDefectSummaryIsland.Size = new System.Drawing.Size(80, 26);
            this.lblDefectSummaryIsland.TabIndex = 14;
            this.lblDefectSummaryIsland.Text = "Island :";
            this.lblDefectSummaryIsland.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblDefectSummaryDragEllipse);
            this.panel5.Controls.Add(this.lblDefectSummaryDrag);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(222, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(111, 26);
            this.panel5.TabIndex = 24;
            // 
            // lblDefectSummaryDragEllipse
            // 
            this.lblDefectSummaryDragEllipse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDragEllipse.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryDragEllipse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDragEllipse.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDragEllipse.Location = new System.Drawing.Point(5, 0);
            this.lblDefectSummaryDragEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDragEllipse.Name = "lblDefectSummaryDragEllipse";
            this.lblDefectSummaryDragEllipse.Size = new System.Drawing.Size(26, 26);
            this.lblDefectSummaryDragEllipse.TabIndex = 9;
            this.lblDefectSummaryDragEllipse.Text = "●";
            this.lblDefectSummaryDragEllipse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryDrag
            // 
            this.lblDefectSummaryDrag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDrag.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDefectSummaryDrag.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDrag.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDrag.Location = new System.Drawing.Point(31, 0);
            this.lblDefectSummaryDrag.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDrag.Name = "lblDefectSummaryDrag";
            this.lblDefectSummaryDrag.Size = new System.Drawing.Size(80, 26);
            this.lblDefectSummaryDrag.TabIndex = 15;
            this.lblDefectSummaryDrag.Text = "Drag :";
            this.lblDefectSummaryDrag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectSummaryPinholeValue
            // 
            this.lblDefectSummaryPinholeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryPinholeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectSummaryPinholeValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryPinholeValue.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryPinholeValue.Location = new System.Drawing.Point(111, 0);
            this.lblDefectSummaryPinholeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryPinholeValue.Name = "lblDefectSummaryPinholeValue";
            this.lblDefectSummaryPinholeValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDefectSummaryPinholeValue.Size = new System.Drawing.Size(111, 26);
            this.lblDefectSummaryPinholeValue.TabIndex = 9;
            this.lblDefectSummaryPinholeValue.Text = "0ea";
            this.lblDefectSummaryPinholeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefectSummaryDentValue
            // 
            this.lblDefectSummaryDentValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectSummaryDentValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDentValue.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDentValue.Location = new System.Drawing.Point(111, 26);
            this.lblDefectSummaryDentValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDentValue.Name = "lblDefectSummaryDentValue";
            this.lblDefectSummaryDentValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDefectSummaryDentValue.Size = new System.Drawing.Size(111, 26);
            this.lblDefectSummaryDentValue.TabIndex = 13;
            this.lblDefectSummaryDentValue.Text = "0ea";
            this.lblDefectSummaryDentValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefectSummaryCraterValue
            // 
            this.lblDefectSummaryCraterValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryCraterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectSummaryCraterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryCraterValue.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryCraterValue.Location = new System.Drawing.Point(111, 52);
            this.lblDefectSummaryCraterValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryCraterValue.Name = "lblDefectSummaryCraterValue";
            this.lblDefectSummaryCraterValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDefectSummaryCraterValue.Size = new System.Drawing.Size(111, 26);
            this.lblDefectSummaryCraterValue.TabIndex = 12;
            this.lblDefectSummaryCraterValue.Text = "0ea";
            this.lblDefectSummaryCraterValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefectSummaryIslandValue
            // 
            this.lblDefectSummaryIslandValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryIslandValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectSummaryIslandValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryIslandValue.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryIslandValue.Location = new System.Drawing.Point(333, 0);
            this.lblDefectSummaryIslandValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryIslandValue.Name = "lblDefectSummaryIslandValue";
            this.lblDefectSummaryIslandValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDefectSummaryIslandValue.Size = new System.Drawing.Size(111, 26);
            this.lblDefectSummaryIslandValue.TabIndex = 17;
            this.lblDefectSummaryIslandValue.Text = "0ea";
            this.lblDefectSummaryIslandValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefectSummaryDragValue
            // 
            this.lblDefectSummaryDragValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectSummaryDragValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectSummaryDragValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectSummaryDragValue.ForeColor = System.Drawing.Color.White;
            this.lblDefectSummaryDragValue.Location = new System.Drawing.Point(333, 26);
            this.lblDefectSummaryDragValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectSummaryDragValue.Name = "lblDefectSummaryDragValue";
            this.lblDefectSummaryDragValue.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDefectSummaryDragValue.Size = new System.Drawing.Size(111, 26);
            this.lblDefectSummaryDragValue.TabIndex = 18;
            this.lblDefectSummaryDragValue.Text = "0ea";
            this.lblDefectSummaryDragValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblDefectMap.Location = new System.Drawing.Point(5, 0);
            this.lblDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.lblDefectMap.Name = "lblDefectMap";
            this.lblDefectMap.Size = new System.Drawing.Size(446, 35);
            this.lblDefectMap.TabIndex = 8;
            this.lblDefectMap.Tag = "";
            this.lblDefectMap.Text = "DEFECT MAP";
            this.lblDefectMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDefectMap
            // 
            this.pnlDefectMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectMap.Location = new System.Drawing.Point(5, 115);
            this.pnlDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectMap.Name = "pnlDefectMap";
            this.pnlDefectMap.Size = new System.Drawing.Size(446, 685);
            this.pnlDefectMap.TabIndex = 7;
            // 
            // tlpMismatchChartLayout
            // 
            this.tlpMismatchChartLayout.ColumnCount = 2;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpMismatchChartLayout, 2);
            this.tlpMismatchChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMismatchChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMismatchChartLayout.Controls.Add(this.lblMismatchChart1, 0, 0);
            this.tlpMismatchChartLayout.Controls.Add(this.lblMismatchChart2, 1, 0);
            this.tlpMismatchChartLayout.Controls.Add(this.pnlMismatchChart1, 0, 1);
            this.tlpMismatchChartLayout.Controls.Add(this.pnlMismatchChart2, 1, 1);
            this.tlpMismatchChartLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMismatchChartLayout.Location = new System.Drawing.Point(0, 530);
            this.tlpMismatchChartLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMismatchChartLayout.Name = "tlpMismatchChartLayout";
            this.tlpMismatchChartLayout.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tlpMismatchChartLayout.RowCount = 2;
            this.tlpMismatchChartLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMismatchChartLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMismatchChartLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMismatchChartLayout.Size = new System.Drawing.Size(864, 270);
            this.tlpMismatchChartLayout.TabIndex = 16;
            // 
            // lblMismatchChart1
            // 
            this.lblMismatchChart1.AutoSize = true;
            this.lblMismatchChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblMismatchChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMismatchChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMismatchChart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMismatchChart1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMismatchChart1.ForeColor = System.Drawing.Color.White;
            this.lblMismatchChart1.Location = new System.Drawing.Point(0, 5);
            this.lblMismatchChart1.Margin = new System.Windows.Forms.Padding(0);
            this.lblMismatchChart1.Name = "lblMismatchChart1";
            this.lblMismatchChart1.Size = new System.Drawing.Size(432, 35);
            this.lblMismatchChart1.TabIndex = 9;
            this.lblMismatchChart1.Tag = "";
            this.lblMismatchChart1.Text = "FOIL WIDTH";
            this.lblMismatchChart1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMismatchChart2
            // 
            this.lblMismatchChart2.AutoSize = true;
            this.lblMismatchChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblMismatchChart2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMismatchChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMismatchChart2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMismatchChart2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMismatchChart2.ForeColor = System.Drawing.Color.White;
            this.lblMismatchChart2.Location = new System.Drawing.Point(432, 5);
            this.lblMismatchChart2.Margin = new System.Windows.Forms.Padding(0);
            this.lblMismatchChart2.Name = "lblMismatchChart2";
            this.lblMismatchChart2.Size = new System.Drawing.Size(432, 35);
            this.lblMismatchChart2.TabIndex = 10;
            this.lblMismatchChart2.Tag = "";
            this.lblMismatchChart2.Text = "MISMATCH";
            this.lblMismatchChart2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMismatchChart1
            // 
            this.pnlMismatchChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMismatchChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMismatchChart1.Location = new System.Drawing.Point(0, 40);
            this.pnlMismatchChart1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMismatchChart1.Name = "pnlMismatchChart1";
            this.pnlMismatchChart1.Size = new System.Drawing.Size(432, 230);
            this.pnlMismatchChart1.TabIndex = 0;
            // 
            // pnlMismatchChart2
            // 
            this.pnlMismatchChart2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMismatchChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMismatchChart2.Location = new System.Drawing.Point(432, 40);
            this.pnlMismatchChart2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMismatchChart2.Name = "pnlMismatchChart2";
            this.pnlMismatchChart2.Size = new System.Drawing.Size(432, 230);
            this.pnlMismatchChart2.TabIndex = 1;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpMainPageLayout);
            this.DoubleBuffered = true;
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
            this.tlpImages.ResumeLayout(false);
            this.tlpImages.PerformLayout();
            this.pnlMismatch.ResumeLayout(false);
            this.tlpMismatchLayout.ResumeLayout(false);
            this.tlpUpperMismatch.ResumeLayout(false);
            this.tlpLowerMismatch.ResumeLayout(false);
            this.tlpDefectInfos.ResumeLayout(false);
            this.tlpDefectInfos.PerformLayout();
            this.tlpDefectMap.ResumeLayout(false);
            this.tlpDefectMap.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.tlpSummaryLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tlpMismatchChartLayout.ResumeLayout(false);
            this.tlpMismatchChartLayout.PerformLayout();
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
        private System.Windows.Forms.Panel pnlDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
        private System.Windows.Forms.Label lblLowerCam;
        private System.Windows.Forms.Label lblUpperCam;
        private System.Windows.Forms.TableLayoutPanel tlpDefectMap;
        private System.Windows.Forms.Label lblDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpMismatchLayout;
        private System.Windows.Forms.Button btnUpperJudgement;
        private System.Windows.Forms.Button btnLowerJudgement;
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
        private System.Windows.Forms.Panel pnlMismatch;
        private System.Windows.Forms.Panel pnlDefectInfoArea;
        private System.Windows.Forms.Panel pnlMismatchChart1;
        private System.Windows.Forms.TableLayoutPanel tlpDefectInfos;
        private System.Windows.Forms.Label lblDefectInfos;
        private System.Windows.Forms.TableLayoutPanel tlpSummaryLayout;
        private System.Windows.Forms.Label lblDefectSummaryPinhole;
        private System.Windows.Forms.Label lblDefectSummaryPinholeValue;
        private System.Windows.Forms.Label lblDefectSummaryDent;
        private System.Windows.Forms.Label lblDefectSummaryDentValue;
        private System.Windows.Forms.Label lblDefectSummaryCrater;
        private System.Windows.Forms.Label lblDefectSummaryCraterValue;
        private System.Windows.Forms.Label lblDefectSummaryIsland;
        private System.Windows.Forms.Label lblDefectSummaryIslandValue;
        private System.Windows.Forms.Label lblDefectSummaryDrag;
        private System.Windows.Forms.Label lblDefectSummaryDragValue;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.TableLayoutPanel tlpMismatchChartLayout;
        private System.Windows.Forms.Panel pnlMismatchChart2;
        private System.Windows.Forms.Label lblMismatchChart1;
        private System.Windows.Forms.Label lblMismatchChart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDefectSummaryPinholeEllipse;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDefectSummaryCraterEllipse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDefectSummaryDentEllipse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDefectSummaryIslandEllipse;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblDefectSummaryDragEllipse;
    }
}
