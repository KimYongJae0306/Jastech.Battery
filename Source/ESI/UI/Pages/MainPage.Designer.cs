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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStopText = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStartText = new System.Windows.Forms.Label();
            this.tlpFunctionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDefectMap = new System.Windows.Forms.Panel();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.lblLowerJudgement = new System.Windows.Forms.Label();
            this.lblUpperJudgement = new System.Windows.Forms.Label();
            this.tlpDataLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDataArea = new System.Windows.Forms.Panel();
            this.lblSelectMismatch = new System.Windows.Forms.Label();
            this.lblSelectDefectImage = new System.Windows.Forms.Label();
            this.lblSelectDefectData = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tlpFunctionLayout.SuspendLayout();
            this.tlpDataLayout.SuspendLayout();
            this.pnlDataArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tlpFunctionLayout, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1700, 800);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 800F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(70, 800);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.btnTest, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(70, 800);
            this.tableLayoutPanel4.TabIndex = 1;
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
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblStop, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblStopText, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(70, 80);
            this.tableLayoutPanel5.TabIndex = 2;
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
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.lblStart, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblStartText, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(70, 80);
            this.tableLayoutPanel6.TabIndex = 1;
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
            this.tlpFunctionLayout.Controls.Add(this.pnlDefectMap, 0, 0);
            this.tlpFunctionLayout.Controls.Add(this.pnlImages, 1, 0);
            this.tlpFunctionLayout.Controls.Add(this.lblLowerJudgement, 1, 1);
            this.tlpFunctionLayout.Controls.Add(this.lblUpperJudgement, 1, 1);
            this.tlpFunctionLayout.Controls.Add(this.tlpDataLayout, 1, 2);
            this.tlpFunctionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionLayout.Location = new System.Drawing.Point(70, 0);
            this.tlpFunctionLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunctionLayout.Name = "tlpFunctionLayout";
            this.tlpFunctionLayout.RowCount = 3;
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFunctionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionLayout.Size = new System.Drawing.Size(1630, 800);
            this.tlpFunctionLayout.TabIndex = 0;
            // 
            // pnlDefectMap
            // 
            this.pnlDefectMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectMap.Location = new System.Drawing.Point(3, 3);
            this.pnlDefectMap.Name = "pnlDefectMap";
            this.tlpFunctionLayout.SetRowSpan(this.pnlDefectMap, 3);
            this.pnlDefectMap.Size = new System.Drawing.Size(444, 794);
            this.pnlDefectMap.TabIndex = 7;
            // 
            // pnlImages
            // 
            this.tlpFunctionLayout.SetColumnSpan(this.pnlImages, 2);
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImages.Location = new System.Drawing.Point(453, 3);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(1174, 444);
            this.pnlImages.TabIndex = 5;
            this.pnlImages.SizeChanged += new System.EventHandler(this.pnlImages_SizeChanged);
            // 
            // lblLowerJudgement
            // 
            this.lblLowerJudgement.AutoSize = true;
            this.lblLowerJudgement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblLowerJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLowerJudgement.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowerJudgement.ForeColor = System.Drawing.Color.White;
            this.lblLowerJudgement.Location = new System.Drawing.Point(1043, 450);
            this.lblLowerJudgement.Name = "lblLowerJudgement";
            this.lblLowerJudgement.Size = new System.Drawing.Size(584, 100);
            this.lblLowerJudgement.TabIndex = 8;
            this.lblLowerJudgement.Text = "Judgement";
            this.lblLowerJudgement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpperJudgement
            // 
            this.lblUpperJudgement.AutoSize = true;
            this.lblUpperJudgement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblUpperJudgement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpperJudgement.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpperJudgement.ForeColor = System.Drawing.Color.White;
            this.lblUpperJudgement.Location = new System.Drawing.Point(453, 450);
            this.lblUpperJudgement.Name = "lblUpperJudgement";
            this.lblUpperJudgement.Size = new System.Drawing.Size(584, 100);
            this.lblUpperJudgement.TabIndex = 7;
            this.lblUpperJudgement.Text = "Judgement";
            this.lblUpperJudgement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDataLayout
            // 
            this.tlpDataLayout.ColumnCount = 3;
            this.tlpFunctionLayout.SetColumnSpan(this.tlpDataLayout, 2);
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDataLayout.Controls.Add(this.pnlDataArea, 0, 1);
            this.tlpDataLayout.Controls.Add(this.lblSelectMismatch, 2, 0);
            this.tlpDataLayout.Controls.Add(this.lblSelectDefectImage, 1, 0);
            this.tlpDataLayout.Controls.Add(this.lblSelectDefectData, 0, 0);
            this.tlpDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataLayout.ForeColor = System.Drawing.Color.White;
            this.tlpDataLayout.Location = new System.Drawing.Point(453, 553);
            this.tlpDataLayout.Name = "tlpDataLayout";
            this.tlpDataLayout.RowCount = 2;
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDataLayout.Size = new System.Drawing.Size(1174, 244);
            this.tlpDataLayout.TabIndex = 6;
            // 
            // pnlDataArea
            // 
            this.tlpDataLayout.SetColumnSpan(this.pnlDataArea, 3);
            this.pnlDataArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataArea.Location = new System.Drawing.Point(3, 53);
            this.pnlDataArea.Name = "pnlDataArea";
            this.pnlDataArea.Size = new System.Drawing.Size(1168, 188);
            this.pnlDataArea.TabIndex = 6;
            // 
            // lblSelectMismatch
            // 
            this.lblSelectMismatch.AutoSize = true;
            this.lblSelectMismatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblSelectMismatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectMismatch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectMismatch.ForeColor = System.Drawing.Color.White;
            this.lblSelectMismatch.Location = new System.Drawing.Point(785, 0);
            this.lblSelectMismatch.Name = "lblSelectMismatch";
            this.lblSelectMismatch.Size = new System.Drawing.Size(386, 50);
            this.lblSelectMismatch.TabIndex = 8;
            this.lblSelectMismatch.Tag = "MissMatchData";
            this.lblSelectMismatch.Text = "U/L Mismatch";
            this.lblSelectMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectMismatch.Click += new System.EventHandler(this.SelectMisMatch_Click);
            // 
            // lblSelectDefectImage
            // 
            this.lblSelectDefectImage.AutoSize = true;
            this.lblSelectDefectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblSelectDefectImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectDefectImage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectDefectImage.ForeColor = System.Drawing.Color.White;
            this.lblSelectDefectImage.Location = new System.Drawing.Point(394, 0);
            this.lblSelectDefectImage.Name = "lblSelectDefectImage";
            this.lblSelectDefectImage.Size = new System.Drawing.Size(385, 50);
            this.lblSelectDefectImage.TabIndex = 7;
            this.lblSelectDefectImage.Tag = "DefectImage";
            this.lblSelectDefectImage.Text = "Defect Image";
            this.lblSelectDefectImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectDefectImage.Click += new System.EventHandler(this.SelectDefectImage_Click);
            // 
            // lblSelectDefectData
            // 
            this.lblSelectDefectData.AutoSize = true;
            this.lblSelectDefectData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblSelectDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectDefectData.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectDefectData.ForeColor = System.Drawing.Color.White;
            this.lblSelectDefectData.Location = new System.Drawing.Point(3, 0);
            this.lblSelectDefectData.Name = "lblSelectDefectData";
            this.lblSelectDefectData.Size = new System.Drawing.Size(385, 50);
            this.lblSelectDefectData.TabIndex = 6;
            this.lblSelectDefectData.Tag = "DefectData";
            this.lblSelectDefectData.Text = "Defect Data";
            this.lblSelectDefectData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelectDefectData.Click += new System.EventHandler(this.SelectDefectData_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1700, 800);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tlpFunctionLayout.ResumeLayout(false);
            this.tlpFunctionLayout.PerformLayout();
            this.tlpDataLayout.ResumeLayout(false);
            this.tlpDataLayout.PerformLayout();
            this.pnlDataArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStopText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblStartText;
        private System.Windows.Forms.TableLayoutPanel tlpFunctionLayout;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Panel pnlImages;
        private System.Windows.Forms.TableLayoutPanel tlpDataLayout;
        private System.Windows.Forms.Label lblSelectDefectImage;
        private System.Windows.Forms.Label lblSelectDefectData;
        private System.Windows.Forms.Label lblSelectMismatch;
        private System.Windows.Forms.Label lblLowerJudgement;
        private System.Windows.Forms.Label lblUpperJudgement;
        private System.Windows.Forms.Panel pnlDataArea;
        private System.Windows.Forms.Panel pnlDefectMap;
    }
}
