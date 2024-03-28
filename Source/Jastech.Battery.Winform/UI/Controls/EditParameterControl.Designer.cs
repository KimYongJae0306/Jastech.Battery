namespace Jastech.Battery.Winform.UI.Controls
{
    partial class EditParameterControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditParameterControl));
            this.tlpDataLayout = new System.Windows.Forms.TableLayoutPanel();
            this.StateImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tlpDataLayout
            // 
            this.tlpDataLayout.AutoScroll = true;
            this.tlpDataLayout.ColumnCount = 3;
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpDataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpDataLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpDataLayout.Name = "tlpDataLayout";
            this.tlpDataLayout.RowCount = 1;
            this.tlpDataLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataLayout.Size = new System.Drawing.Size(40, 40);
            this.tlpDataLayout.TabIndex = 0;
            // 
            // StateImageList
            // 
            this.StateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StateImageList.ImageStream")));
            this.StateImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StateImageList.Images.SetKeyName(0, "No_Red.png");
            this.StateImageList.Images.SetKeyName(1, "Yes_Green.png");
            // 
            // EditParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpDataLayout);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EditParameterControl";
            this.Size = new System.Drawing.Size(40, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpDataLayout;
        private System.Windows.Forms.ImageList StateImageList;
    }
}
