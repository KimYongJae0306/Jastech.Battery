namespace Jastech.Battery.Winform.UI.Controls
{
    partial class SurfaceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurfaceControl));
            this.tlpControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblParameter = new System.Windows.Forms.Label();
            this.pnlTeachingParameter = new System.Windows.Forms.Panel();
            this.pnlDataSpecContainer = new System.Windows.Forms.Panel();
            this.tlpROILayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTitleROIMarginContainer = new System.Windows.Forms.Panel();
            this.pnlROIMarginDecorativeBar = new System.Windows.Forms.Panel();
            this.lblTitleROIMargin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblROIMarginLeft = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblROIMarginRight = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.label69 = new System.Windows.Forms.Label();
            this.lblROIMarginTop = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.label74 = new System.Windows.Forms.Label();
            this.lblROIMarginBottom = new System.Windows.Forms.Label();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.label77 = new System.Windows.Forms.Label();
            this.lblROIMarginCorner = new System.Windows.Forms.Label();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pnlTitleDefectSpecification = new System.Windows.Forms.Panel();
            this.lblTitleDefectSpecification = new System.Windows.Forms.Label();
            this.pnlDefectSpecificationDecoBar = new System.Windows.Forms.Panel();
            this.tlpDefectSpecificationLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControlLayout.SuspendLayout();
            this.pnlTeachingParameter.SuspendLayout();
            this.tlpROILayout.SuspendLayout();
            this.pnlTitleROIMarginContainer.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.pnlTitleDefectSpecification.SuspendLayout();
            this.tlpDefectSpecificationLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpControlLayout
            // 
            this.tlpControlLayout.ColumnCount = 1;
            this.tlpControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlLayout.Controls.Add(this.lblParameter, 0, 0);
            this.tlpControlLayout.Controls.Add(this.pnlTeachingParameter, 0, 1);
            this.tlpControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControlLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpControlLayout.Name = "tlpControlLayout";
            this.tlpControlLayout.RowCount = 2;
            this.tlpControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlLayout.Size = new System.Drawing.Size(888, 900);
            this.tlpControlLayout.TabIndex = 3;
            // 
            // lblParameter
            // 
            this.lblParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParameter.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblParameter.Location = new System.Drawing.Point(0, 0);
            this.lblParameter.Margin = new System.Windows.Forms.Padding(0);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(888, 40);
            this.lblParameter.TabIndex = 1;
            this.lblParameter.Text = "Parameter";
            this.lblParameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTeachingParameter
            // 
            this.pnlTeachingParameter.Controls.Add(this.tlpROILayout);
            this.pnlTeachingParameter.Controls.Add(this.tlpDefectSpecificationLayout);
            this.pnlTeachingParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachingParameter.Location = new System.Drawing.Point(0, 40);
            this.pnlTeachingParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeachingParameter.Name = "pnlTeachingParameter";
            this.pnlTeachingParameter.Size = new System.Drawing.Size(888, 860);
            this.pnlTeachingParameter.TabIndex = 2;
            // 
            // pnlDataSpecContainer
            // 
            this.pnlDataSpecContainer.AutoScroll = true;
            this.tlpDefectSpecificationLayout.SetColumnSpan(this.pnlDataSpecContainer, 2);
            this.pnlDataSpecContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataSpecContainer.Location = new System.Drawing.Point(0, 40);
            this.pnlDataSpecContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDataSpecContainer.Name = "pnlDataSpecContainer";
            this.pnlDataSpecContainer.Size = new System.Drawing.Size(450, 720);
            this.pnlDataSpecContainer.TabIndex = 1;
            // 
            // tlpROILayout
            // 
            this.tlpROILayout.ColumnCount = 3;
            this.tlpROILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpROILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpROILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpROILayout.Controls.Add(this.pnlTitleROIMarginContainer, 0, 0);
            this.tlpROILayout.Controls.Add(this.label6, 0, 1);
            this.tlpROILayout.Controls.Add(this.tableLayoutPanel14, 1, 1);
            this.tlpROILayout.Controls.Add(this.tableLayoutPanel15, 1, 2);
            this.tlpROILayout.Controls.Add(this.tableLayoutPanel16, 1, 3);
            this.tlpROILayout.Controls.Add(this.tableLayoutPanel17, 1, 4);
            this.tlpROILayout.Controls.Add(this.tableLayoutPanel18, 1, 5);
            this.tlpROILayout.Location = new System.Drawing.Point(5, 0);
            this.tlpROILayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROILayout.Name = "tlpROILayout";
            this.tlpROILayout.RowCount = 7;
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpROILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpROILayout.Size = new System.Drawing.Size(360, 250);
            this.tlpROILayout.TabIndex = 0;
            // 
            // pnlTitleROIMarginContainer
            // 
            this.pnlTitleROIMarginContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpROILayout.SetColumnSpan(this.pnlTitleROIMarginContainer, 2);
            this.pnlTitleROIMarginContainer.Controls.Add(this.pnlROIMarginDecorativeBar);
            this.pnlTitleROIMarginContainer.Controls.Add(this.lblTitleROIMargin);
            this.pnlTitleROIMarginContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitleROIMarginContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleROIMarginContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitleROIMarginContainer.Name = "pnlTitleROIMarginContainer";
            this.pnlTitleROIMarginContainer.Size = new System.Drawing.Size(350, 40);
            this.pnlTitleROIMarginContainer.TabIndex = 52;
            // 
            // pnlROIMarginDecorativeBar
            // 
            this.pnlROIMarginDecorativeBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlROIMarginDecorativeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlROIMarginDecorativeBar.Location = new System.Drawing.Point(0, 33);
            this.pnlROIMarginDecorativeBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlROIMarginDecorativeBar.Name = "pnlROIMarginDecorativeBar";
            this.pnlROIMarginDecorativeBar.Size = new System.Drawing.Size(350, 2);
            this.pnlROIMarginDecorativeBar.TabIndex = 50;
            // 
            // lblTitleROIMargin
            // 
            this.lblTitleROIMargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleROIMargin.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleROIMargin.ForeColor = System.Drawing.Color.White;
            this.lblTitleROIMargin.Location = new System.Drawing.Point(0, 0);
            this.lblTitleROIMargin.Name = "lblTitleROIMargin";
            this.lblTitleROIMargin.Size = new System.Drawing.Size(350, 33);
            this.lblTitleROIMargin.TabIndex = 51;
            this.lblTitleROIMargin.Text = "ROI";
            this.lblTitleROIMargin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(0, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.label6.Name = "label6";
            this.tlpROILayout.SetRowSpan(this.label6, 5);
            this.label6.Size = new System.Drawing.Size(98, 198);
            this.label6.TabIndex = 53;
            this.label6.Text = "Margin\r\n(mm)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.lblROIMarginLeft, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(100, 42);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(250, 38);
            this.tableLayoutPanel14.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 38);
            this.label2.TabIndex = 57;
            this.label2.Text = "Left";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIMarginLeft
            // 
            this.lblROIMarginLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblROIMarginLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMarginLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMarginLeft.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblROIMarginLeft.Location = new System.Drawing.Point(125, 0);
            this.lblROIMarginLeft.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMarginLeft.Name = "lblROIMarginLeft";
            this.lblROIMarginLeft.Size = new System.Drawing.Size(125, 38);
            this.lblROIMarginLeft.TabIndex = 57;
            this.lblROIMarginLeft.Text = "0.0";
            this.lblROIMarginLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblROIMarginRight, 1, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(100, 82);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(250, 38);
            this.tableLayoutPanel15.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 38);
            this.label11.TabIndex = 57;
            this.label11.Text = "Right";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIMarginRight
            // 
            this.lblROIMarginRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblROIMarginRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMarginRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMarginRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblROIMarginRight.Location = new System.Drawing.Point(125, 0);
            this.lblROIMarginRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMarginRight.Name = "lblROIMarginRight";
            this.lblROIMarginRight.Size = new System.Drawing.Size(125, 38);
            this.lblROIMarginRight.TabIndex = 57;
            this.lblROIMarginRight.Text = "0.0";
            this.lblROIMarginRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.Controls.Add(this.label69, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.lblROIMarginTop, 1, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(100, 122);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(250, 38);
            this.tableLayoutPanel16.TabIndex = 59;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label69.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label69.Location = new System.Drawing.Point(0, 0);
            this.label69.Margin = new System.Windows.Forms.Padding(0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(125, 38);
            this.label69.TabIndex = 57;
            this.label69.Text = "Top";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIMarginTop
            // 
            this.lblROIMarginTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblROIMarginTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMarginTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMarginTop.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblROIMarginTop.Location = new System.Drawing.Point(125, 0);
            this.lblROIMarginTop.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMarginTop.Name = "lblROIMarginTop";
            this.lblROIMarginTop.Size = new System.Drawing.Size(125, 38);
            this.lblROIMarginTop.TabIndex = 57;
            this.lblROIMarginTop.Text = "0.0";
            this.lblROIMarginTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Controls.Add(this.label74, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.lblROIMarginBottom, 1, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(100, 162);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(250, 38);
            this.tableLayoutPanel17.TabIndex = 59;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label74.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label74.Location = new System.Drawing.Point(0, 0);
            this.label74.Margin = new System.Windows.Forms.Padding(0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(125, 38);
            this.label74.TabIndex = 57;
            this.label74.Text = "Bottom";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIMarginBottom
            // 
            this.lblROIMarginBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblROIMarginBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMarginBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMarginBottom.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblROIMarginBottom.Location = new System.Drawing.Point(125, 0);
            this.lblROIMarginBottom.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMarginBottom.Name = "lblROIMarginBottom";
            this.lblROIMarginBottom.Size = new System.Drawing.Size(125, 38);
            this.lblROIMarginBottom.TabIndex = 57;
            this.lblROIMarginBottom.Text = "0.0";
            this.lblROIMarginBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel18.Controls.Add(this.label77, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.lblROIMarginCorner, 1, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(100, 202);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(250, 38);
            this.tableLayoutPanel18.TabIndex = 59;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label77.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label77.Location = new System.Drawing.Point(0, 0);
            this.label77.Margin = new System.Windows.Forms.Padding(0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(125, 38);
            this.label77.TabIndex = 57;
            this.label77.Text = "Corner";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIMarginCorner
            // 
            this.lblROIMarginCorner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblROIMarginCorner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIMarginCorner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIMarginCorner.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblROIMarginCorner.Location = new System.Drawing.Point(125, 0);
            this.lblROIMarginCorner.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIMarginCorner.Name = "lblROIMarginCorner";
            this.lblROIMarginCorner.Size = new System.Drawing.Size(125, 38);
            this.lblROIMarginCorner.TabIndex = 57;
            this.lblROIMarginCorner.Text = "0.0";
            this.lblROIMarginCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblROIMarginCorner.Click += new System.EventHandler(this.lblROIMarginCorner_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "No_Red.png");
            this.imgList.Images.SetKeyName(1, "Yes_Green.png");
            // 
            // pnlTitleDefectSpecification
            // 
            this.pnlTitleDefectSpecification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpDefectSpecificationLayout.SetColumnSpan(this.pnlTitleDefectSpecification, 2);
            this.pnlTitleDefectSpecification.Controls.Add(this.pnlDefectSpecificationDecoBar);
            this.pnlTitleDefectSpecification.Controls.Add(this.lblTitleDefectSpecification);
            this.pnlTitleDefectSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitleDefectSpecification.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleDefectSpecification.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitleDefectSpecification.Name = "pnlTitleDefectSpecification";
            this.pnlTitleDefectSpecification.Size = new System.Drawing.Size(450, 40);
            this.pnlTitleDefectSpecification.TabIndex = 53;
            // 
            // lblTitleDefectSpecification
            // 
            this.lblTitleDefectSpecification.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleDefectSpecification.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleDefectSpecification.ForeColor = System.Drawing.Color.White;
            this.lblTitleDefectSpecification.Location = new System.Drawing.Point(0, 0);
            this.lblTitleDefectSpecification.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleDefectSpecification.Name = "lblTitleDefectSpecification";
            this.lblTitleDefectSpecification.Size = new System.Drawing.Size(450, 33);
            this.lblTitleDefectSpecification.TabIndex = 51;
            this.lblTitleDefectSpecification.Text = "Defect Specification";
            this.lblTitleDefectSpecification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDefectSpecificationDecoBar
            // 
            this.pnlDefectSpecificationDecoBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDefectSpecificationDecoBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefectSpecificationDecoBar.Location = new System.Drawing.Point(0, 33);
            this.pnlDefectSpecificationDecoBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDefectSpecificationDecoBar.Name = "pnlDefectSpecificationDecoBar";
            this.pnlDefectSpecificationDecoBar.Size = new System.Drawing.Size(450, 2);
            this.pnlDefectSpecificationDecoBar.TabIndex = 50;
            // 
            // tlpDefectSpecificationLayout
            // 
            this.tlpDefectSpecificationLayout.ColumnCount = 3;
            this.tlpDefectSpecificationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpDefectSpecificationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpDefectSpecificationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectSpecificationLayout.Controls.Add(this.pnlTitleDefectSpecification, 0, 0);
            this.tlpDefectSpecificationLayout.Controls.Add(this.pnlDataSpecContainer, 0, 1);
            this.tlpDefectSpecificationLayout.Location = new System.Drawing.Point(375, 0);
            this.tlpDefectSpecificationLayout.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tlpDefectSpecificationLayout.Name = "tlpDefectSpecificationLayout";
            this.tlpDefectSpecificationLayout.RowCount = 3;
            this.tlpDefectSpecificationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDefectSpecificationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 720F));
            this.tlpDefectSpecificationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefectSpecificationLayout.Size = new System.Drawing.Size(460, 770);
            this.tlpDefectSpecificationLayout.TabIndex = 0;
            // 
            // SurfaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.tlpControlLayout);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SurfaceControl";
            this.Size = new System.Drawing.Size(888, 900);
            this.Load += new System.EventHandler(this.SurfaceControl_Load);
            this.tlpControlLayout.ResumeLayout(false);
            this.pnlTeachingParameter.ResumeLayout(false);
            this.tlpROILayout.ResumeLayout(false);
            this.pnlTitleROIMarginContainer.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.pnlTitleDefectSpecification.ResumeLayout(false);
            this.tlpDefectSpecificationLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpControlLayout;
        private System.Windows.Forms.Label lblParameter;
        private System.Windows.Forms.Panel pnlTeachingParameter;
        private System.Windows.Forms.TableLayoutPanel tlpROILayout;
        private System.Windows.Forms.Panel pnlTitleROIMarginContainer;
        private System.Windows.Forms.Panel pnlROIMarginDecorativeBar;
        private System.Windows.Forms.Label lblTitleROIMargin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblROIMarginLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblROIMarginRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label lblROIMarginTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label lblROIMarginBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label lblROIMarginCorner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Panel pnlDataSpecContainer;
        private System.Windows.Forms.TableLayoutPanel tlpDefectSpecificationLayout;
        private System.Windows.Forms.Panel pnlTitleDefectSpecification;
        private System.Windows.Forms.Panel pnlDefectSpecificationDecoBar;
        private System.Windows.Forms.Label lblTitleDefectSpecification;
    }
}
