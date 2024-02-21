namespace Jastech.Battery.Winform.UI.Controls
{
    partial class GLDrawBoxControl
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
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisplayAreaLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlGrayText = new System.Windows.Forms.Panel();
            this.tlpGrayLevelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblGrayPoint = new System.Windows.Forms.Label();
            this.lblGrayLevel = new System.Windows.Forms.Label();
            this.lblGrayText = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.tlpFunctionButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteFigure = new System.Windows.Forms.Button();
            this.btnFitZoom = new System.Windows.Forms.Button();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawNone = new System.Windows.Forms.Button();
            this.btnPanning = new System.Windows.Forms.Button();
            this.ctxDisplayMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPointerMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPanningMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuROIMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFitZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMainLayout.SuspendLayout();
            this.tlpDisplayAreaLayout.SuspendLayout();
            this.pnlGrayText.SuspendLayout();
            this.tlpGrayLevelLayout.SuspendLayout();
            this.tlpFunctionButtonsLayout.SuspendLayout();
            this.ctxDisplayMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainLayout
            // 
            this.tlpMainLayout.ColumnCount = 2;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Controls.Add(this.tlpDisplayAreaLayout, 1, 0);
            this.tlpMainLayout.Controls.Add(this.tlpFunctionButtonsLayout, 0, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpMainLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Size = new System.Drawing.Size(407, 433);
            this.tlpMainLayout.TabIndex = 4;
            // 
            // tlpDisplayAreaLayout
            // 
            this.tlpDisplayAreaLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpDisplayAreaLayout.ColumnCount = 1;
            this.tlpDisplayAreaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplayAreaLayout.Controls.Add(this.pnlDisplay, 0, 0);
            this.tlpDisplayAreaLayout.Controls.Add(this.pnlGrayText, 0, 1);
            this.tlpDisplayAreaLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisplayAreaLayout.Location = new System.Drawing.Point(40, 0);
            this.tlpDisplayAreaLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisplayAreaLayout.Name = "tlpDisplayAreaLayout";
            this.tlpDisplayAreaLayout.RowCount = 2;
            this.tlpDisplayAreaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplayAreaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDisplayAreaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplayAreaLayout.Size = new System.Drawing.Size(367, 433);
            this.tlpDisplayAreaLayout.TabIndex = 1;
            // 
            // pnlGrayText
            // 
            this.pnlGrayText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.pnlGrayText.Controls.Add(this.tlpGrayLevelLayout);
            this.pnlGrayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrayText.Location = new System.Drawing.Point(0, 403);
            this.pnlGrayText.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGrayText.Name = "pnlGrayText";
            this.pnlGrayText.Size = new System.Drawing.Size(367, 30);
            this.pnlGrayText.TabIndex = 2;
            // 
            // tlpGrayLevelLayout
            // 
            this.tlpGrayLevelLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpGrayLevelLayout.ColumnCount = 3;
            this.tlpGrayLevelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrayLevelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpGrayLevelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpGrayLevelLayout.Controls.Add(this.lblGrayPoint, 0, 0);
            this.tlpGrayLevelLayout.Controls.Add(this.lblGrayText, 1, 0);
            this.tlpGrayLevelLayout.Controls.Add(this.lblGrayLevel, 2, 0);
            this.tlpGrayLevelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGrayLevelLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpGrayLevelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGrayLevelLayout.Name = "tlpGrayLevelLayout";
            this.tlpGrayLevelLayout.RowCount = 1;
            this.tlpGrayLevelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrayLevelLayout.Size = new System.Drawing.Size(367, 30);
            this.tlpGrayLevelLayout.TabIndex = 3;
            // 
            // lblGrayPoint
            // 
            this.lblGrayPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblGrayPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrayPoint.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrayPoint.ForeColor = System.Drawing.Color.White;
            this.lblGrayPoint.Location = new System.Drawing.Point(0, 0);
            this.lblGrayPoint.Margin = new System.Windows.Forms.Padding(0);
            this.lblGrayPoint.Name = "lblGrayPoint";
            this.lblGrayPoint.Size = new System.Drawing.Size(267, 30);
            this.lblGrayPoint.TabIndex = 1;
            this.lblGrayPoint.Text = "(0,0)";
            this.lblGrayPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrayLevel
            // 
            this.lblGrayLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrayLevel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrayLevel.ForeColor = System.Drawing.Color.White;
            this.lblGrayLevel.Location = new System.Drawing.Point(317, 0);
            this.lblGrayLevel.Margin = new System.Windows.Forms.Padding(0);
            this.lblGrayLevel.Name = "lblGrayLevel";
            this.lblGrayLevel.Size = new System.Drawing.Size(50, 30);
            this.lblGrayLevel.TabIndex = 1;
            this.lblGrayLevel.Text = "255";
            this.lblGrayLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrayText
            // 
            this.lblGrayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrayText.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrayText.ForeColor = System.Drawing.Color.White;
            this.lblGrayText.Location = new System.Drawing.Point(267, 0);
            this.lblGrayText.Margin = new System.Windows.Forms.Padding(0);
            this.lblGrayText.Name = "lblGrayText";
            this.lblGrayText.Size = new System.Drawing.Size(50, 30);
            this.lblGrayText.TabIndex = 0;
            this.lblGrayText.Text = "Gray :";
            this.lblGrayText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(367, 403);
            this.pnlDisplay.TabIndex = 2;
            // 
            // tlpFunctionButtonsLayout
            // 
            this.tlpFunctionButtonsLayout.ColumnCount = 1;
            this.tlpFunctionButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtonsLayout.Controls.Add(this.btnDeleteFigure, 0, 4);
            this.tlpFunctionButtonsLayout.Controls.Add(this.btnFitZoom, 0, 3);
            this.tlpFunctionButtonsLayout.Controls.Add(this.btnDrawLine, 0, 2);
            this.tlpFunctionButtonsLayout.Controls.Add(this.btnDrawNone, 0, 0);
            this.tlpFunctionButtonsLayout.Controls.Add(this.btnPanning, 0, 1);
            this.tlpFunctionButtonsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunctionButtonsLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpFunctionButtonsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunctionButtonsLayout.Name = "tlpFunctionButtonsLayout";
            this.tlpFunctionButtonsLayout.RowCount = 7;
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunctionButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFunctionButtonsLayout.Size = new System.Drawing.Size(40, 433);
            this.tlpFunctionButtonsLayout.TabIndex = 1;
            // 
            // btnDeleteFigure
            // 
            this.btnDeleteFigure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnDeleteFigure.BackgroundImage = global::Jastech.Battery.Winform.Properties.Resources.Delete_White;
            this.btnDeleteFigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteFigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteFigure.Location = new System.Drawing.Point(0, 160);
            this.btnDeleteFigure.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteFigure.Name = "btnDeleteFigure";
            this.btnDeleteFigure.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteFigure.TabIndex = 4;
            this.btnDeleteFigure.TabStop = false;
            this.btnDeleteFigure.UseVisualStyleBackColor = false;
            // 
            // btnFitZoom
            // 
            this.btnFitZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnFitZoom.BackgroundImage = global::Jastech.Battery.Winform.Properties.Resources.Fit_White;
            this.btnFitZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFitZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFitZoom.Location = new System.Drawing.Point(0, 120);
            this.btnFitZoom.Margin = new System.Windows.Forms.Padding(0);
            this.btnFitZoom.Name = "btnFitZoom";
            this.btnFitZoom.Size = new System.Drawing.Size(40, 40);
            this.btnFitZoom.TabIndex = 3;
            this.btnFitZoom.TabStop = false;
            this.btnFitZoom.UseVisualStyleBackColor = false;
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnDrawLine.BackgroundImage = global::Jastech.Battery.Winform.Properties.Resources.Line_arrow_White;
            this.btnDrawLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDrawLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawLine.Location = new System.Drawing.Point(0, 80);
            this.btnDrawLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(40, 40);
            this.btnDrawLine.TabIndex = 2;
            this.btnDrawLine.TabStop = false;
            this.btnDrawLine.UseVisualStyleBackColor = false;
            // 
            // btnDrawNone
            // 
            this.btnDrawNone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnDrawNone.BackgroundImage = global::Jastech.Battery.Winform.Properties.Resources.Pointer_White;
            this.btnDrawNone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDrawNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawNone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnDrawNone.Location = new System.Drawing.Point(0, 0);
            this.btnDrawNone.Margin = new System.Windows.Forms.Padding(0);
            this.btnDrawNone.Name = "btnDrawNone";
            this.btnDrawNone.Size = new System.Drawing.Size(40, 40);
            this.btnDrawNone.TabIndex = 1;
            this.btnDrawNone.TabStop = false;
            this.btnDrawNone.UseVisualStyleBackColor = false;
            // 
            // btnPanning
            // 
            this.btnPanning.BackgroundImage = global::Jastech.Battery.Winform.Properties.Resources.Panning_White;
            this.btnPanning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanning.Location = new System.Drawing.Point(0, 40);
            this.btnPanning.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanning.Name = "btnPanning";
            this.btnPanning.Size = new System.Drawing.Size(40, 40);
            this.btnPanning.TabIndex = 3;
            this.btnPanning.TabStop = false;
            this.btnPanning.UseVisualStyleBackColor = false;
            // 
            // ctxDisplayMode
            // 
            this.ctxDisplayMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPointerMode,
            this.menuPanningMode,
            this.menuROIMode,
            this.menuFitZoom,
            this.menuSaveImage});
            this.ctxDisplayMode.Name = "contextMenuStrip";
            this.ctxDisplayMode.Size = new System.Drawing.Size(137, 114);
            this.ctxDisplayMode.Opening += new System.ComponentModel.CancelEventHandler(this.ctxDisplayMode_Opening);
            // 
            // menuPointerMode
            // 
            this.menuPointerMode.Name = "menuPointerMode";
            this.menuPointerMode.Size = new System.Drawing.Size(136, 22);
            this.menuPointerMode.Text = "Pointer";
            this.menuPointerMode.Click += new System.EventHandler(this.menuPointerMode_Click);
            // 
            // menuPanningMode
            // 
            this.menuPanningMode.Name = "menuPanningMode";
            this.menuPanningMode.Size = new System.Drawing.Size(136, 22);
            this.menuPanningMode.Text = "Panning";
            this.menuPanningMode.Click += new System.EventHandler(this.menuPanningMode_Click);
            // 
            // menuROIMode
            // 
            this.menuROIMode.Name = "menuROIMode";
            this.menuROIMode.Size = new System.Drawing.Size(136, 22);
            this.menuROIMode.Text = "ROI";
            this.menuROIMode.Click += new System.EventHandler(this.menuROIMode_Click);
            // 
            // menuFitZoom
            // 
            this.menuFitZoom.Name = "menuFitZoom";
            this.menuFitZoom.Size = new System.Drawing.Size(136, 22);
            this.menuFitZoom.Text = "FitZoom";
            this.menuFitZoom.Click += new System.EventHandler(this.menuFitZoom_Click);
            // 
            // menuSaveImage
            // 
            this.menuSaveImage.Name = "menuSaveImage";
            this.menuSaveImage.Size = new System.Drawing.Size(136, 22);
            this.menuSaveImage.Text = "Save Image";
            this.menuSaveImage.Click += new System.EventHandler(this.menuSaveImage_Click);
            // 
            // GLDrawBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ContextMenuStrip = this.ctxDisplayMode;
            this.Controls.Add(this.tlpMainLayout);
            this.Name = "GLDrawBoxControl";
            this.Size = new System.Drawing.Size(407, 433);
            this.Load += new System.EventHandler(this.GLDrawBoxControl_Load);
            this.tlpMainLayout.ResumeLayout(false);
            this.tlpDisplayAreaLayout.ResumeLayout(false);
            this.pnlGrayText.ResumeLayout(false);
            this.tlpGrayLevelLayout.ResumeLayout(false);
            this.tlpFunctionButtonsLayout.ResumeLayout(false);
            this.ctxDisplayMode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;
        private System.Windows.Forms.TableLayoutPanel tlpDisplayAreaLayout;
        private System.Windows.Forms.Panel pnlGrayText;
        private System.Windows.Forms.TableLayoutPanel tlpGrayLevelLayout;
        private System.Windows.Forms.Label lblGrayPoint;
        private System.Windows.Forms.Label lblGrayLevel;
        private System.Windows.Forms.Label lblGrayText;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpFunctionButtonsLayout;
        private System.Windows.Forms.Button btnDeleteFigure;
        private System.Windows.Forms.Button btnFitZoom;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawNone;
        private System.Windows.Forms.Button btnPanning;
        private System.Windows.Forms.ContextMenuStrip ctxDisplayMode;
        private System.Windows.Forms.ToolStripMenuItem menuPointerMode;
        private System.Windows.Forms.ToolStripMenuItem menuPanningMode;
        private System.Windows.Forms.ToolStripMenuItem menuROIMode;
        private System.Windows.Forms.ToolStripMenuItem menuFitZoom;
        private System.Windows.Forms.ToolStripMenuItem menuSaveImage;
    }
}
