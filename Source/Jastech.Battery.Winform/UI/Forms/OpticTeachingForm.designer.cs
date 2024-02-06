using Jastech.Framework.Winform.Controls;

namespace Jastech.Battery.Winform.Forms
{
    partial class OpticTeachingForm
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
            this.components = new System.ComponentModel.Container();
            this.tlpLinescanTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTeachingItem = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlLinescanTeach = new System.Windows.Forms.Panel();
            this.tlpTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCommon = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUnit = new System.Windows.Forms.TableLayoutPanel();
            this.btnMotionPopup = new System.Windows.Forms.Button();
            this.lblCamInfo = new System.Windows.Forms.Label();
            this.tlpLoadImage = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnGrabStop = new System.Windows.Forms.Button();
            this.btnGrabStart = new System.Windows.Forms.Button();
            this.pnlTeach = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHistogram = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlDrawBox = new System.Windows.Forms.Panel();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.tlpLinescanTeach.SuspendLayout();
            this.tlpTeachingItem.SuspendLayout();
            this.pnlLinescanTeach.SuspendLayout();
            this.tlpTeach.SuspendLayout();
            this.tlpCommon.SuspendLayout();
            this.tlpUnit.SuspendLayout();
            this.tlpLoadImage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLinescanTeach
            // 
            this.tlpLinescanTeach.ColumnCount = 3;
            this.tlpLinescanTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinescanTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinescanTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tlpLinescanTeach.Controls.Add(this.tlpTeachingItem, 2, 0);
            this.tlpLinescanTeach.Controls.Add(this.pnlLinescanTeach, 1, 0);
            this.tlpLinescanTeach.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpLinescanTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLinescanTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpLinescanTeach.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLinescanTeach.Name = "tlpLinescanTeach";
            this.tlpLinescanTeach.RowCount = 1;
            this.tlpLinescanTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLinescanTeach.Size = new System.Drawing.Size(1847, 861);
            this.tlpLinescanTeach.TabIndex = 298;
            // 
            // tlpTeachingItem
            // 
            this.tlpTeachingItem.ColumnCount = 1;
            this.tlpTeachingItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachingItem.Controls.Add(this.btnCancel, 0, 2);
            this.tlpTeachingItem.Controls.Add(this.btnSave, 0, 1);
            this.tlpTeachingItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachingItem.Location = new System.Drawing.Point(1702, 0);
            this.tlpTeachingItem.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachingItem.Name = "tlpTeachingItem";
            this.tlpTeachingItem.RowCount = 3;
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachingItem.Size = new System.Drawing.Size(145, 861);
            this.tlpTeachingItem.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(2, 763);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 96);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(2, 663);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 96);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlLinescanTeach
            // 
            this.pnlLinescanTeach.Controls.Add(this.tlpTeach);
            this.pnlLinescanTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLinescanTeach.Location = new System.Drawing.Point(851, 0);
            this.pnlLinescanTeach.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLinescanTeach.Name = "pnlLinescanTeach";
            this.pnlLinescanTeach.Size = new System.Drawing.Size(851, 861);
            this.pnlLinescanTeach.TabIndex = 0;
            // 
            // tlpTeach
            // 
            this.tlpTeach.ColumnCount = 1;
            this.tlpTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Controls.Add(this.tlpCommon, 0, 0);
            this.tlpTeach.Controls.Add(this.pnlTeach, 0, 1);
            this.tlpTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpTeach.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTeach.Name = "tlpTeach";
            this.tlpTeach.RowCount = 2;
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Size = new System.Drawing.Size(851, 861);
            this.tlpTeach.TabIndex = 2;
            // 
            // tlpCommon
            // 
            this.tlpCommon.ColumnCount = 1;
            this.tlpCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommon.Controls.Add(this.tlpUnit, 0, 0);
            this.tlpCommon.Controls.Add(this.tlpLoadImage, 0, 1);
            this.tlpCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommon.Location = new System.Drawing.Point(0, 0);
            this.tlpCommon.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommon.Name = "tlpCommon";
            this.tlpCommon.RowCount = 2;
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommon.Size = new System.Drawing.Size(851, 80);
            this.tlpCommon.TabIndex = 3;
            // 
            // tlpUnit
            // 
            this.tlpUnit.ColumnCount = 2;
            this.tlpUnit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66F));
            this.tlpUnit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpUnit.Controls.Add(this.btnMotionPopup, 0, 0);
            this.tlpUnit.Controls.Add(this.lblCamInfo, 0, 0);
            this.tlpUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUnit.Location = new System.Drawing.Point(0, 0);
            this.tlpUnit.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUnit.Name = "tlpUnit";
            this.tlpUnit.RowCount = 1;
            this.tlpUnit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnit.Size = new System.Drawing.Size(851, 40);
            this.tlpUnit.TabIndex = 287;
            // 
            // btnMotionPopup
            // 
            this.btnMotionPopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnMotionPopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMotionPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMotionPopup.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnMotionPopup.ForeColor = System.Drawing.Color.White;
            this.btnMotionPopup.Location = new System.Drawing.Point(567, 0);
            this.btnMotionPopup.Margin = new System.Windows.Forms.Padding(0);
            this.btnMotionPopup.Name = "btnMotionPopup";
            this.btnMotionPopup.Size = new System.Drawing.Size(284, 40);
            this.btnMotionPopup.TabIndex = 295;
            this.btnMotionPopup.Text = "MOTION";
            this.btnMotionPopup.UseVisualStyleBackColor = false;
            this.btnMotionPopup.Click += new System.EventHandler(this.btnMotionPopup_Click);
            // 
            // lblCamInfo
            // 
            this.lblCamInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblCamInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCamInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamInfo.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCamInfo.ForeColor = System.Drawing.Color.White;
            this.lblCamInfo.Location = new System.Drawing.Point(0, 0);
            this.lblCamInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblCamInfo.Name = "lblCamInfo";
            this.lblCamInfo.Size = new System.Drawing.Size(567, 40);
            this.lblCamInfo.TabIndex = 294;
            this.lblCamInfo.Text = "CAM :";
            this.lblCamInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLoadImage
            // 
            this.tlpLoadImage.ColumnCount = 3;
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoadImage.Controls.Add(this.btnLoadImage, 0, 0);
            this.tlpLoadImage.Controls.Add(this.btnGrabStop, 0, 0);
            this.tlpLoadImage.Controls.Add(this.btnGrabStart, 0, 0);
            this.tlpLoadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoadImage.Location = new System.Drawing.Point(0, 40);
            this.tlpLoadImage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLoadImage.Name = "tlpLoadImage";
            this.tlpLoadImage.RowCount = 1;
            this.tlpLoadImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoadImage.Size = new System.Drawing.Size(851, 40);
            this.tlpLoadImage.TabIndex = 2;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnLoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadImage.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.ForeColor = System.Drawing.Color.White;
            this.btnLoadImage.Location = new System.Drawing.Point(566, 0);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(285, 40);
            this.btnLoadImage.TabIndex = 201;
            this.btnLoadImage.Text = "LOAD IMAGE";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnGrabStop
            // 
            this.btnGrabStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnGrabStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStop.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrabStop.ForeColor = System.Drawing.Color.White;
            this.btnGrabStop.Location = new System.Drawing.Point(283, 0);
            this.btnGrabStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnGrabStop.Name = "btnGrabStop";
            this.btnGrabStop.Size = new System.Drawing.Size(283, 40);
            this.btnGrabStop.TabIndex = 200;
            this.btnGrabStop.Text = "GRAB STOP";
            this.btnGrabStop.UseVisualStyleBackColor = false;
            this.btnGrabStop.Click += new System.EventHandler(this.btnGrabStop_Click);
            // 
            // btnGrabStart
            // 
            this.btnGrabStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnGrabStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStart.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrabStart.ForeColor = System.Drawing.Color.White;
            this.btnGrabStart.Location = new System.Drawing.Point(0, 0);
            this.btnGrabStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnGrabStart.Name = "btnGrabStart";
            this.btnGrabStart.Size = new System.Drawing.Size(283, 40);
            this.btnGrabStart.TabIndex = 199;
            this.btnGrabStart.Text = "GRAB START";
            this.btnGrabStart.UseVisualStyleBackColor = false;
            this.btnGrabStart.Click += new System.EventHandler(this.btnGrabStart_Click);
            // 
            // pnlTeach
            // 
            this.pnlTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeach.Location = new System.Drawing.Point(0, 80);
            this.pnlTeach.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeach.Name = "pnlTeach";
            this.pnlTeach.Size = new System.Drawing.Size(851, 781);
            this.pnlTeach.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlHistogram, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlDisplay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 861);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlHistogram
            // 
            this.pnlHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistogram.Location = new System.Drawing.Point(0, 602);
            this.pnlHistogram.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHistogram.Name = "pnlHistogram";
            this.pnlHistogram.Size = new System.Drawing.Size(851, 259);
            this.pnlHistogram.TabIndex = 0;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.pnlDrawBox);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(851, 602);
            this.pnlDisplay.TabIndex = 1;
            // 
            // pnlDrawBox
            // 
            this.pnlDrawBox.Location = new System.Drawing.Point(68, 70);
            this.pnlDrawBox.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDrawBox.Name = "pnlDrawBox";
            this.pnlDrawBox.Size = new System.Drawing.Size(227, 120);
            this.pnlDrawBox.TabIndex = 0;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 300;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // OpticTeachingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1847, 861);
            this.Controls.Add(this.tlpLinescanTeach);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpticTeachingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpticTeachingForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpticTeachingForm_FormClosed);
            this.Load += new System.EventHandler(this.OpticTeachingForm_Load);
            this.tlpLinescanTeach.ResumeLayout(false);
            this.tlpTeachingItem.ResumeLayout(false);
            this.pnlLinescanTeach.ResumeLayout(false);
            this.tlpTeach.ResumeLayout(false);
            this.tlpCommon.ResumeLayout(false);
            this.tlpUnit.ResumeLayout(false);
            this.tlpLoadImage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlDisplay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpLinescanTeach;
        private System.Windows.Forms.Panel pnlLinescanTeach;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlDrawBox;
        private System.Windows.Forms.Panel pnlHistogram;
        private System.Windows.Forms.TableLayoutPanel tlpTeachingItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpTeach;
        private System.Windows.Forms.TableLayoutPanel tlpCommon;
        private System.Windows.Forms.TableLayoutPanel tlpUnit;
        private System.Windows.Forms.Button btnMotionPopup;
        private System.Windows.Forms.Label lblCamInfo;
        private System.Windows.Forms.TableLayoutPanel tlpLoadImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnGrabStop;
        private System.Windows.Forms.Button btnGrabStart;
        private System.Windows.Forms.Panel pnlTeach;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Panel pnlDisplay;
    }
}
