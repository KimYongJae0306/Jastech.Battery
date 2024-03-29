﻿namespace Jastech.Battery.Winform.UI.Controls
{
    partial class DefectInfoControl
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
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pbxCropImage = new System.Windows.Forms.PictureBox();
            this.lblDefectInfo = new System.Windows.Forms.Label();
            this.lblDefectType = new System.Windows.Forms.Label();
            this.lblCamDirection = new System.Windows.Forms.Label();
            this.pnlDefectInfoControl = new System.Windows.Forms.Panel();
            this.tlpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCropImage)).BeginInit();
            this.pnlDefectInfoControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpLayout.ColumnCount = 2;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLayout.Controls.Add(this.pbxCropImage, 0, 1);
            this.tlpLayout.Controls.Add(this.lblDefectInfo, 0, 2);
            this.tlpLayout.Controls.Add(this.lblDefectType, 1, 0);
            this.tlpLayout.Controls.Add(this.lblCamDirection, 0, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(3, 3);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 3;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLayout.Size = new System.Drawing.Size(144, 184);
            this.tlpLayout.TabIndex = 0;
            // 
            // pbxCropImage
            // 
            this.pbxCropImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpLayout.SetColumnSpan(this.pbxCropImage, 2);
            this.pbxCropImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCropImage.Location = new System.Drawing.Point(0, 20);
            this.pbxCropImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbxCropImage.Name = "pbxCropImage";
            this.pbxCropImage.Size = new System.Drawing.Size(144, 144);
            this.pbxCropImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCropImage.TabIndex = 0;
            this.pbxCropImage.TabStop = false;
            this.pbxCropImage.Click += new System.EventHandler(this.ClickControlEvent);
            // 
            // lblDefectInfo
            // 
            this.lblDefectInfo.AutoSize = true;
            this.tlpLayout.SetColumnSpan(this.lblDefectInfo, 2);
            this.lblDefectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectInfo.ForeColor = System.Drawing.Color.White;
            this.lblDefectInfo.Location = new System.Drawing.Point(3, 164);
            this.lblDefectInfo.Name = "lblDefectInfo";
            this.lblDefectInfo.Size = new System.Drawing.Size(138, 20);
            this.lblDefectInfo.TabIndex = 4;
            this.lblDefectInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDefectInfo.Click += new System.EventHandler(this.ClickControlEvent);
            // 
            // lblDefectType
            // 
            this.lblDefectType.AutoSize = true;
            this.lblDefectType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDefectType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectType.ForeColor = System.Drawing.Color.White;
            this.lblDefectType.Location = new System.Drawing.Point(75, 0);
            this.lblDefectType.Name = "lblDefectType";
            this.lblDefectType.Size = new System.Drawing.Size(66, 20);
            this.lblDefectType.TabIndex = 3;
            this.lblDefectType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDefectType.Click += new System.EventHandler(this.ClickControlEvent);
            // 
            // lblCamDirection
            // 
            this.lblCamDirection.AutoSize = true;
            this.lblCamDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamDirection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamDirection.ForeColor = System.Drawing.Color.White;
            this.lblCamDirection.Location = new System.Drawing.Point(3, 0);
            this.lblCamDirection.Name = "lblCamDirection";
            this.lblCamDirection.Size = new System.Drawing.Size(66, 20);
            this.lblCamDirection.TabIndex = 1;
            this.lblCamDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCamDirection.Click += new System.EventHandler(this.ClickControlEvent);
            // 
            // pnlDefectInfoControl
            // 
            this.pnlDefectInfoControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.pnlDefectInfoControl.Controls.Add(this.tlpLayout);
            this.pnlDefectInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectInfoControl.Location = new System.Drawing.Point(0, 0);
            this.pnlDefectInfoControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectInfoControl.Name = "pnlDefectInfoControl";
            this.pnlDefectInfoControl.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDefectInfoControl.Size = new System.Drawing.Size(150, 190);
            this.pnlDefectInfoControl.TabIndex = 5;
            // 
            // DefectInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlDefectInfoControl);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DefectInfoControl";
            this.Size = new System.Drawing.Size(150, 190);
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCropImage)).EndInit();
            this.pnlDefectInfoControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.PictureBox pbxCropImage;
        private System.Windows.Forms.Label lblCamDirection;
        private System.Windows.Forms.Label lblDefectType;
        private System.Windows.Forms.Label lblDefectInfo;
        private System.Windows.Forms.Panel pnlDefectInfoControl;
    }
}
