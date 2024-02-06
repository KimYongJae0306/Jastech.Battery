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
            this.lblDefectMapDecorativeBar = new System.Windows.Forms.Label();
            this.pnlDefectMap = new System.Windows.Forms.Panel();
            this.tlpImages = new System.Windows.Forms.TableLayoutPanel();
            this.lblImagesDecorativeBar = new System.Windows.Forms.Label();
            this.lblUpperCam = new System.Windows.Forms.Label();
            this.lblLowerCam = new System.Windows.Forms.Label();
            this.pnlUpperImage = new System.Windows.Forms.Panel();
            this.pnlLowerImage = new System.Windows.Forms.Panel();
            this.tlpDataLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDataArea = new System.Windows.Forms.Panel();
            this.lblSelectDefectData = new System.Windows.Forms.Label();
            this.lblHighlightDefectData = new System.Windows.Forms.Label();
            this.lblSelectDefectImage = new System.Windows.Forms.Label();
            this.lblHighlightDefectImage = new System.Windows.Forms.Label();
            this.lblSelectMismatch = new System.Windows.Forms.Label();
            this.lblHighlightMismatch = new System.Windows.Forms.Label();
            this.tlpSummaryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpperMismatch = new System.Windows.Forms.Label();
            this.lblLowerSummary = new System.Windows.Forms.Label();
            this.btnLowerJudgement = new System.Windows.Forms.Button();
            this.btnUpperJudgement = new System.Windows.Forms.Button();
            this.lblLowerMismatch = new System.Windows.Forms.Label();
            this.lblUpperDefectSummary = new System.Windows.Forms.Label();
            this.lblDataDecorativeBar = new System.Windows.Forms.Label();
            this.tlpMainPageLayout.SuspendLayout();
            this.tlpSideBarLayout.SuspendLayout();
            this.tlpCommonFunctionLayout.SuspendLayout();
            this.tlpStop.SuspendLayout();
            this.tlpStart.SuspendLayout();
            this.tlpFunctionLayout.SuspendLayout();
            this.tlpDefectMap.SuspendLayout();
            this.tlpImages.SuspendLayout();
            this.tlpDataLayout.SuspendLayout();
            this.tlpSummaryLayout.SuspendLayout();
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
            this.tlpFunctionLayout.Controls.Add(this.tlpSummaryLayout, 1, 1);
            this.tlpFunctionLayout.Controls.Add(this.tlpDataLayout, 1, 2);
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
            // tlpDefectMap
            // 
            this.tlpDefectMap.ColumnCount = 1;
            this.tlpDefectMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.Controls.Add(this.lblDefectMap, 0, 0);
            this.tlpDefectMap.Controls.Add(this.lblDefectMapDecorativeBar, 1, 0);
            this.tlpDefectMap.Controls.Add(this.pnlDefectMap, 0, 2);
            this.tlpDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefectMap.Location = new System.Drawing.Point(0, 0);
            this.tlpDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDefectMap.Name = "tlpDefectMap";
            this.tlpDefectMap.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tlpDefectMap.RowCount = 3;
            this.tlpFunctionLayout.SetRowSpan(this.tlpDefectMap, 3);
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpDefectMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectMap.Size = new System.Drawing.Size(450, 800);
            this.tlpDefectMap.TabIndex = 9;
            // 
            // lblDefectMap
            // 
            this.lblDefectMap.AutoSize = true;
            this.lblDefectMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectMap.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectMap.ForeColor = System.Drawing.Color.White;
            this.lblDefectMap.Location = new System.Drawing.Point(3, 0);
            this.lblDefectMap.Name = "lblDefectMap";
            this.lblDefectMap.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDefectMap.Size = new System.Drawing.Size(439, 35);
            this.lblDefectMap.TabIndex = 8;
            this.lblDefectMap.Tag = "";
            this.lblDefectMap.Text = "DEFECT MAP";
            this.lblDefectMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDefectMapDecorativeBar
            // 
            this.lblDefectMapDecorativeBar.AutoSize = true;
            this.lblDefectMapDecorativeBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.tlpDefectMap.SetColumnSpan(this.lblDefectMapDecorativeBar, 2);
            this.lblDefectMapDecorativeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectMapDecorativeBar.Location = new System.Drawing.Point(1, 35);
            this.lblDefectMapDecorativeBar.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDefectMapDecorativeBar.Name = "lblDefectMapDecorativeBar";
            this.lblDefectMapDecorativeBar.Size = new System.Drawing.Size(443, 2);
            this.lblDefectMapDecorativeBar.TabIndex = 11;
            // 
            // pnlDefectMap
            // 
            this.pnlDefectMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectMap.Location = new System.Drawing.Point(0, 37);
            this.pnlDefectMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectMap.Name = "pnlDefectMap";
            this.pnlDefectMap.Size = new System.Drawing.Size(445, 763);
            this.pnlDefectMap.TabIndex = 7;
            // 
            // tlpImages
            // 
            this.tlpImages.ColumnCount = 2;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpImages, 2);
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImages.Controls.Add(this.lblImagesDecorativeBar, 0, 1);
            this.tlpImages.Controls.Add(this.lblUpperCam, 0, 0);
            this.tlpImages.Controls.Add(this.lblLowerCam, 1, 0);
            this.tlpImages.Controls.Add(this.pnlUpperImage, 0, 2);
            this.tlpImages.Controls.Add(this.pnlLowerImage, 0, 2);
            this.tlpImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImages.Location = new System.Drawing.Point(450, 0);
            this.tlpImages.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImages.Name = "tlpImages";
            this.tlpImages.RowCount = 2;
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImages.Size = new System.Drawing.Size(1175, 450);
            this.tlpImages.TabIndex = 0;
            // 
            // lblImagesDecorativeBar
            // 
            this.lblImagesDecorativeBar.AutoSize = true;
            this.lblImagesDecorativeBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.tlpImages.SetColumnSpan(this.lblImagesDecorativeBar, 2);
            this.lblImagesDecorativeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImagesDecorativeBar.Location = new System.Drawing.Point(1, 35);
            this.lblImagesDecorativeBar.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblImagesDecorativeBar.Name = "lblImagesDecorativeBar";
            this.lblImagesDecorativeBar.Size = new System.Drawing.Size(1173, 2);
            this.lblImagesDecorativeBar.TabIndex = 10;
            // 
            // lblUpperCam
            // 
            this.lblUpperCam.AutoSize = true;
            this.lblUpperCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUpperCam.ForeColor = System.Drawing.Color.White;
            this.lblUpperCam.Location = new System.Drawing.Point(3, 0);
            this.lblUpperCam.Name = "lblUpperCam";
            this.lblUpperCam.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblUpperCam.Size = new System.Drawing.Size(581, 35);
            this.lblUpperCam.TabIndex = 7;
            this.lblUpperCam.Tag = "";
            this.lblUpperCam.Text = "UPPER CAM";
            this.lblUpperCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowerCam
            // 
            this.lblLowerCam.AutoSize = true;
            this.lblLowerCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLowerCam.ForeColor = System.Drawing.Color.White;
            this.lblLowerCam.Location = new System.Drawing.Point(590, 0);
            this.lblLowerCam.Name = "lblLowerCam";
            this.lblLowerCam.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblLowerCam.Size = new System.Drawing.Size(582, 35);
            this.lblLowerCam.TabIndex = 8;
            this.lblLowerCam.Tag = "";
            this.lblLowerCam.Text = "LOWER CAM";
            this.lblLowerCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUpperImage
            // 
            this.pnlUpperImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpperImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpperImage.Location = new System.Drawing.Point(587, 37);
            this.pnlUpperImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUpperImage.Name = "pnlUpperImage";
            this.pnlUpperImage.Size = new System.Drawing.Size(588, 413);
            this.pnlUpperImage.TabIndex = 5;
            // 
            // pnlLowerImage
            // 
            this.pnlLowerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLowerImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowerImage.Location = new System.Drawing.Point(0, 37);
            this.pnlLowerImage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLowerImage.Name = "pnlLowerImage";
            this.pnlLowerImage.Size = new System.Drawing.Size(587, 413);
            this.pnlLowerImage.TabIndex = 9;
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
            this.tlpDataLayout.Controls.Add(this.pnlDataArea, 0, 3);
            this.tlpDataLayout.Controls.Add(this.lblDataDecorativeBar, 0, 2);
            this.tlpDataLayout.Controls.Add(this.lblSelectDefectData, 0, 0);
            this.tlpDataLayout.Controls.Add(this.lblHighlightDefectData, 0, 1);
            this.tlpDataLayout.Controls.Add(this.lblSelectDefectImage, 1, 0);
            this.tlpDataLayout.Controls.Add(this.lblHighlightDefectImage, 1, 1);
            this.tlpDataLayout.Controls.Add(this.lblSelectMismatch, 2, 0);
            this.tlpDataLayout.Controls.Add(this.lblHighlightMismatch, 2, 1);
            this.tlpDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataLayout.ForeColor = System.Drawing.Color.White;
            this.tlpDataLayout.Location = new System.Drawing.Point(450, 545);
            this.tlpDataLayout.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.tlpDataLayout.Name = "tlpDataLayout";
            this.tlpDataLayout.RowCount = 4;
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.Size = new System.Drawing.Size(1175, 255);
            this.tlpDataLayout.TabIndex = 6;
            // 
            // pnlDataArea
            // 
            this.pnlDataArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpDataLayout.SetColumnSpan(this.pnlDataArea, 7);
            this.pnlDataArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataArea.Location = new System.Drawing.Point(0, 49);
            this.pnlDataArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDataArea.Name = "pnlDataArea";
            this.pnlDataArea.Size = new System.Drawing.Size(1175, 206);
            this.pnlDataArea.TabIndex = 6;
            // 
            // lblSelectDefectData
            // 
            this.lblSelectDefectData.AutoSize = true;
            this.lblSelectDefectData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSelectDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectDefectData.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectDefectData.ForeColor = System.Drawing.Color.Black;
            this.lblSelectDefectData.Location = new System.Drawing.Point(3, 0);
            this.lblSelectDefectData.Name = "lblSelectDefectData";
            this.lblSelectDefectData.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSelectDefectData.Size = new System.Drawing.Size(154, 40);
            this.lblSelectDefectData.TabIndex = 6;
            this.lblSelectDefectData.Tag = "";
            this.lblSelectDefectData.Text = "DEFECT DATA";
            this.lblSelectDefectData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectDefectData.Click += new System.EventHandler(this.SelectDefectData_Click);
            // 
            // lblHighlightDefectData
            // 
            this.lblHighlightDefectData.AutoSize = true;
            this.lblHighlightDefectData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblHighlightDefectData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighlightDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighlightDefectData.Location = new System.Drawing.Point(10, 40);
            this.lblHighlightDefectData.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblHighlightDefectData.Name = "lblHighlightDefectData";
            this.lblHighlightDefectData.Size = new System.Drawing.Size(140, 5);
            this.lblHighlightDefectData.TabIndex = 9;
            // 
            // lblSelectDefectImage
            // 
            this.lblSelectDefectImage.AutoSize = true;
            this.lblSelectDefectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSelectDefectImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectDefectImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectDefectImage.ForeColor = System.Drawing.Color.Black;
            this.lblSelectDefectImage.Location = new System.Drawing.Point(163, 0);
            this.lblSelectDefectImage.Name = "lblSelectDefectImage";
            this.lblSelectDefectImage.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSelectDefectImage.Size = new System.Drawing.Size(154, 40);
            this.lblSelectDefectImage.TabIndex = 7;
            this.lblSelectDefectImage.Tag = "";
            this.lblSelectDefectImage.Text = "DEFECT IMAGE";
            this.lblSelectDefectImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectDefectImage.Click += new System.EventHandler(this.SelectDefectImage_Click);
            // 
            // lblHighlightDefectImage
            // 
            this.lblHighlightDefectImage.AutoSize = true;
            this.lblHighlightDefectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblHighlightDefectImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighlightDefectImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighlightDefectImage.Location = new System.Drawing.Point(165, 40);
            this.lblHighlightDefectImage.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHighlightDefectImage.Name = "lblHighlightDefectImage";
            this.lblHighlightDefectImage.Size = new System.Drawing.Size(150, 5);
            this.lblHighlightDefectImage.TabIndex = 10;
            // 
            // lblSelectMismatch
            // 
            this.lblSelectMismatch.AutoSize = true;
            this.lblSelectMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblSelectMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectMismatch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectMismatch.ForeColor = System.Drawing.Color.Black;
            this.lblSelectMismatch.Location = new System.Drawing.Point(323, 0);
            this.lblSelectMismatch.Name = "lblSelectMismatch";
            this.lblSelectMismatch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSelectMismatch.Size = new System.Drawing.Size(154, 40);
            this.lblSelectMismatch.TabIndex = 8;
            this.lblSelectMismatch.Tag = "";
            this.lblSelectMismatch.Text = "U/L MISMATCH";
            this.lblSelectMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectMismatch.Click += new System.EventHandler(this.SelectMisMatch_Click);
            // 
            // lblHighlightMismatch
            // 
            this.lblHighlightMismatch.AutoSize = true;
            this.lblHighlightMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblHighlightMismatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighlightMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighlightMismatch.Location = new System.Drawing.Point(325, 40);
            this.lblHighlightMismatch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHighlightMismatch.Name = "lblHighlightMismatch";
            this.lblHighlightMismatch.Size = new System.Drawing.Size(150, 5);
            this.lblHighlightMismatch.TabIndex = 11;
            // 
            // tlpSummaryLayout
            // 
            this.tlpSummaryLayout.ColumnCount = 6;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpSummaryLayout, 2);
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSummaryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpSummaryLayout.Controls.Add(this.lblUpperMismatch, 0, 0);
            this.tlpSummaryLayout.Controls.Add(this.lblUpperDefectSummary, 1, 0);
            this.tlpSummaryLayout.Controls.Add(this.btnUpperJudgement, 2, 0);
            this.tlpSummaryLayout.Controls.Add(this.lblLowerSummary, 4, 0);
            this.tlpSummaryLayout.Controls.Add(this.lblLowerMismatch, 3, 0);
            this.tlpSummaryLayout.Controls.Add(this.btnLowerJudgement, 5, 0);
            this.tlpSummaryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSummaryLayout.Location = new System.Drawing.Point(450, 450);
            this.tlpSummaryLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSummaryLayout.Name = "tlpSummaryLayout";
            this.tlpSummaryLayout.RowCount = 1;
            this.tlpSummaryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSummaryLayout.Size = new System.Drawing.Size(1175, 80);
            this.tlpSummaryLayout.TabIndex = 8;
            // 
            // lblUpperMismatch
            // 
            this.lblUpperMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperMismatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUpperMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperMismatch.ForeColor = System.Drawing.Color.White;
            this.lblUpperMismatch.Location = new System.Drawing.Point(0, 0);
            this.lblUpperMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperMismatch.Name = "lblUpperMismatch";
            this.lblUpperMismatch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblUpperMismatch.Size = new System.Drawing.Size(195, 80);
            this.lblUpperMismatch.TabIndex = 7;
            this.lblUpperMismatch.Text = "Left : 0.00mm\r\nCenter : 0.00mm\r\nRight : 0.00mm";
            this.lblUpperMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLowerSummary
            // 
            this.lblLowerSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowerSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerSummary.ForeColor = System.Drawing.Color.White;
            this.lblLowerSummary.Location = new System.Drawing.Point(782, 0);
            this.lblLowerSummary.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerSummary.Name = "lblLowerSummary";
            this.lblLowerSummary.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblLowerSummary.Size = new System.Drawing.Size(292, 80);
            this.lblLowerSummary.TabIndex = 8;
            this.lblLowerSummary.Text = "Pinhole x ea           Dent x ea\r\nDrag x ea               Island x ea\r\nCrater x e" +
    "a";
            this.lblLowerSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLowerJudgement
            // 
            this.btnLowerJudgement.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLowerJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLowerJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLowerJudgement.FlatAppearance.BorderSize = 2;
            this.btnLowerJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowerJudgement.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLowerJudgement.ForeColor = System.Drawing.Color.White;
            this.btnLowerJudgement.Location = new System.Drawing.Point(1074, 0);
            this.btnLowerJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnLowerJudgement.Name = "btnLowerJudgement";
            this.btnLowerJudgement.Size = new System.Drawing.Size(101, 80);
            this.btnLowerJudgement.TabIndex = 9;
            this.btnLowerJudgement.Text = "Judge";
            this.btnLowerJudgement.UseVisualStyleBackColor = false;
            // 
            // btnUpperJudgement
            // 
            this.btnUpperJudgement.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpperJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpperJudgement.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpperJudgement.FlatAppearance.BorderSize = 2;
            this.btnUpperJudgement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpperJudgement.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpperJudgement.ForeColor = System.Drawing.Color.White;
            this.btnUpperJudgement.Location = new System.Drawing.Point(487, 0);
            this.btnUpperJudgement.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpperJudgement.Name = "btnUpperJudgement";
            this.btnUpperJudgement.Size = new System.Drawing.Size(100, 80);
            this.btnUpperJudgement.TabIndex = 10;
            this.btnUpperJudgement.Text = "Judge";
            this.btnUpperJudgement.UseVisualStyleBackColor = false;
            // 
            // lblLowerMismatch
            // 
            this.lblLowerMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLowerMismatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowerMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerMismatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerMismatch.ForeColor = System.Drawing.Color.White;
            this.lblLowerMismatch.Location = new System.Drawing.Point(587, 0);
            this.lblLowerMismatch.Margin = new System.Windows.Forms.Padding(0);
            this.lblLowerMismatch.Name = "lblLowerMismatch";
            this.lblLowerMismatch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblLowerMismatch.Size = new System.Drawing.Size(195, 80);
            this.lblLowerMismatch.TabIndex = 12;
            this.lblLowerMismatch.Text = "Left : 0.00mm\r\nCenter : 0.00mm\r\nRight : 0.00mm";
            this.lblLowerMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpperDefectSummary
            // 
            this.lblUpperDefectSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblUpperDefectSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUpperDefectSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperDefectSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperDefectSummary.ForeColor = System.Drawing.Color.White;
            this.lblUpperDefectSummary.Location = new System.Drawing.Point(195, 0);
            this.lblUpperDefectSummary.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpperDefectSummary.Name = "lblUpperDefectSummary";
            this.lblUpperDefectSummary.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.lblUpperDefectSummary.Size = new System.Drawing.Size(292, 80);
            this.lblUpperDefectSummary.TabIndex = 11;
            this.lblUpperDefectSummary.Text = "Pinhole x ea           Dent x ea\r\nDrag x ea               Island x ea\r\nCrater x e" +
    "a";
            this.lblUpperDefectSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataDecorativeBar
            // 
            this.lblDataDecorativeBar.AutoSize = true;
            this.lblDataDecorativeBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.tlpDataLayout.SetColumnSpan(this.lblDataDecorativeBar, 7);
            this.lblDataDecorativeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataDecorativeBar.Location = new System.Drawing.Point(0, 47);
            this.lblDataDecorativeBar.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDataDecorativeBar.Name = "lblDataDecorativeBar";
            this.lblDataDecorativeBar.Size = new System.Drawing.Size(1175, 2);
            this.lblDataDecorativeBar.TabIndex = 12;
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
            this.tlpDataLayout.ResumeLayout(false);
            this.tlpDataLayout.PerformLayout();
            this.tlpSummaryLayout.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlUpperImage;
        private System.Windows.Forms.TableLayoutPanel tlpDataLayout;
        private System.Windows.Forms.Label lblSelectDefectImage;
        private System.Windows.Forms.Label lblSelectDefectData;
        private System.Windows.Forms.Label lblSelectMismatch;
        private System.Windows.Forms.Label lblLowerSummary;
        private System.Windows.Forms.Label lblUpperMismatch;
        private System.Windows.Forms.Panel pnlDataArea;
        private System.Windows.Forms.Panel pnlDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpImages;
        private System.Windows.Forms.Label lblHighlightDefectData;
        private System.Windows.Forms.Label lblHighlightDefectImage;
        private System.Windows.Forms.Label lblHighlightMismatch;
        private System.Windows.Forms.Label lblLowerCam;
        private System.Windows.Forms.Label lblUpperCam;
        private System.Windows.Forms.Panel pnlLowerImage;
        private System.Windows.Forms.Label lblImagesDecorativeBar;
        private System.Windows.Forms.TableLayoutPanel tlpDefectMap;
        private System.Windows.Forms.Label lblDefectMapDecorativeBar;
        private System.Windows.Forms.Label lblDefectMap;
        private System.Windows.Forms.TableLayoutPanel tlpSummaryLayout;
        private System.Windows.Forms.Label lblUpperDefectSummary;
        private System.Windows.Forms.Button btnUpperJudgement;
        private System.Windows.Forms.Label lblLowerMismatch;
        private System.Windows.Forms.Button btnLowerJudgement;
        private System.Windows.Forms.Label lblDataDecorativeBar;
    }
}
