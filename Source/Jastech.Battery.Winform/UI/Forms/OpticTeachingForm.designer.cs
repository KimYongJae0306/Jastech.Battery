﻿using Jastech.Framework.Winform.Controls;

namespace Jastech.Battery.Winform.UI.Forms
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
            this.tlpLight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLightFunction = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLightValueSelector = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTrbDimmingLevelValue = new System.Windows.Forms.Panel();
            this.trbLightLevelValue = new System.Windows.Forms.TrackBar();
            this.lblLightValue = new System.Windows.Forms.Label();
            this.nupdnLightLevel = new System.Windows.Forms.NumericUpDown();
            this.lblLight = new System.Windows.Forms.Label();
            this.tlpLightChannelSelector = new System.Windows.Forms.TableLayoutPanel();
            this.cbxChannelNameList = new System.Windows.Forms.ComboBox();
            this.lblNextChannel = new System.Windows.Forms.Label();
            this.lblPrevChannel = new System.Windows.Forms.Label();
            this.lblChannelValue = new System.Windows.Forms.Label();
            this.tlpLightControllerSelector = new System.Windows.Forms.TableLayoutPanel();
            this.lblNextControl = new System.Windows.Forms.Label();
            this.lblPrevControl = new System.Windows.Forms.Label();
            this.cbxControlNameList = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tlpCameraParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblCamera = new System.Windows.Forms.Label();
            this.pnlCameraParameter = new System.Windows.Forms.Panel();
            this.tlpAnalogGain = new System.Windows.Forms.TableLayoutPanel();
            this.lblAnalogGainValue = new System.Windows.Forms.Label();
            this.lblAnalogGain = new System.Windows.Forms.Label();
            this.tlpDigitalGain = new System.Windows.Forms.TableLayoutPanel();
            this.lblDigitalGainValue = new System.Windows.Forms.Label();
            this.lblDigitalGain = new System.Windows.Forms.Label();
            this.tlpExposure = new System.Windows.Forms.TableLayoutPanel();
            this.lblExposure = new System.Windows.Forms.Label();
            this.lblExposureValue = new System.Windows.Forms.Label();
            this.tlpShading = new System.Windows.Forms.TableLayoutPanel();
            this.lblShading = new System.Windows.Forms.Label();
            this.btnExcuteShading = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHistogram = new System.Windows.Forms.Panel();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.pnlDrawBox = new System.Windows.Forms.Panel();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.btnLightOn = new System.Windows.Forms.Button();
            this.btnLightOff = new System.Windows.Forms.Button();
            this.tlpLinescanTeach.SuspendLayout();
            this.tlpTeachingItem.SuspendLayout();
            this.pnlLinescanTeach.SuspendLayout();
            this.tlpTeach.SuspendLayout();
            this.tlpCommon.SuspendLayout();
            this.tlpUnit.SuspendLayout();
            this.tlpLoadImage.SuspendLayout();
            this.pnlTeach.SuspendLayout();
            this.tlpLight.SuspendLayout();
            this.tlpLightFunction.SuspendLayout();
            this.tlpLightValueSelector.SuspendLayout();
            this.pnlTrbDimmingLevelValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLightLevelValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnLightLevel)).BeginInit();
            this.tlpLightChannelSelector.SuspendLayout();
            this.tlpLightControllerSelector.SuspendLayout();
            this.tlpCameraParameter.SuspendLayout();
            this.pnlCameraParameter.SuspendLayout();
            this.tlpAnalogGain.SuspendLayout();
            this.tlpDigitalGain.SuspendLayout();
            this.tlpExposure.SuspendLayout();
            this.tlpShading.SuspendLayout();
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
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tlpLoadImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
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
            this.pnlTeach.Controls.Add(this.tlpLight);
            this.pnlTeach.Controls.Add(this.tlpCameraParameter);
            this.pnlTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeach.Location = new System.Drawing.Point(0, 80);
            this.pnlTeach.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeach.Name = "pnlTeach";
            this.pnlTeach.Size = new System.Drawing.Size(851, 781);
            this.pnlTeach.TabIndex = 0;
            // 
            // tlpLight
            // 
            this.tlpLight.ColumnCount = 1;
            this.tlpLight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpLight.Controls.Add(this.tlpLightFunction, 0, 4);
            this.tlpLight.Controls.Add(this.tlpLightValueSelector, 0, 3);
            this.tlpLight.Controls.Add(this.lblLight, 0, 0);
            this.tlpLight.Controls.Add(this.tlpLightChannelSelector, 0, 2);
            this.tlpLight.Controls.Add(this.tlpLightControllerSelector, 0, 1);
            this.tlpLight.Location = new System.Drawing.Point(422, 30);
            this.tlpLight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLight.Name = "tlpLight";
            this.tlpLight.RowCount = 6;
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLight.Size = new System.Drawing.Size(350, 190);
            this.tlpLight.TabIndex = 297;
            // 
            // tlpLightFunction
            // 
            this.tlpLightFunction.ColumnCount = 2;
            this.tlpLightFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightFunction.Controls.Add(this.btnLightOff, 1, 0);
            this.tlpLightFunction.Controls.Add(this.btnLightOn, 0, 0);
            this.tlpLightFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightFunction.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpLightFunction.ForeColor = System.Drawing.Color.White;
            this.tlpLightFunction.Location = new System.Drawing.Point(0, 150);
            this.tlpLightFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightFunction.Name = "tlpLightFunction";
            this.tlpLightFunction.RowCount = 1;
            this.tlpLightFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLightFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightFunction.Size = new System.Drawing.Size(350, 40);
            this.tlpLightFunction.TabIndex = 305;
            // 
            // tlpLightValueSelector
            // 
            this.tlpLightValueSelector.ColumnCount = 3;
            this.tlpLightValueSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightValueSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightValueSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpLightValueSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightValueSelector.Controls.Add(this.pnlTrbDimmingLevelValue, 1, 0);
            this.tlpLightValueSelector.Controls.Add(this.lblLightValue, 0, 0);
            this.tlpLightValueSelector.Controls.Add(this.nupdnLightLevel, 2, 0);
            this.tlpLightValueSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightValueSelector.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpLightValueSelector.ForeColor = System.Drawing.Color.White;
            this.tlpLightValueSelector.Location = new System.Drawing.Point(0, 110);
            this.tlpLightValueSelector.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightValueSelector.Name = "tlpLightValueSelector";
            this.tlpLightValueSelector.RowCount = 1;
            this.tlpLightValueSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLightValueSelector.Size = new System.Drawing.Size(350, 40);
            this.tlpLightValueSelector.TabIndex = 305;
            // 
            // pnlTrbDimmingLevelValue
            // 
            this.pnlTrbDimmingLevelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrbDimmingLevelValue.Controls.Add(this.trbLightLevelValue);
            this.pnlTrbDimmingLevelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrbDimmingLevelValue.Location = new System.Drawing.Point(124, 0);
            this.pnlTrbDimmingLevelValue.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTrbDimmingLevelValue.Name = "pnlTrbDimmingLevelValue";
            this.pnlTrbDimmingLevelValue.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.pnlTrbDimmingLevelValue.Size = new System.Drawing.Size(124, 40);
            this.pnlTrbDimmingLevelValue.TabIndex = 209;
            // 
            // trbLightLevelValue
            // 
            this.trbLightLevelValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.trbLightLevelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbLightLevelValue.Location = new System.Drawing.Point(0, 9);
            this.trbLightLevelValue.Margin = new System.Windows.Forms.Padding(0);
            this.trbLightLevelValue.Maximum = 255;
            this.trbLightLevelValue.Name = "trbLightLevelValue";
            this.trbLightLevelValue.Size = new System.Drawing.Size(122, 29);
            this.trbLightLevelValue.TabIndex = 208;
            this.trbLightLevelValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lblLightValue
            // 
            this.lblLightValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblLightValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLightValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLightValue.Location = new System.Drawing.Point(0, 0);
            this.lblLightValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightValue.Name = "lblLightValue";
            this.lblLightValue.Size = new System.Drawing.Size(124, 40);
            this.lblLightValue.TabIndex = 302;
            this.lblLightValue.Text = "Value";
            this.lblLightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupdnLightLevel
            // 
            this.nupdnLightLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.nupdnLightLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupdnLightLevel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.nupdnLightLevel.ForeColor = System.Drawing.Color.White;
            this.nupdnLightLevel.Location = new System.Drawing.Point(248, 0);
            this.nupdnLightLevel.Margin = new System.Windows.Forms.Padding(0);
            this.nupdnLightLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nupdnLightLevel.Name = "nupdnLightLevel";
            this.nupdnLightLevel.ReadOnly = true;
            this.nupdnLightLevel.Size = new System.Drawing.Size(100, 27);
            this.nupdnLightLevel.TabIndex = 303;
            this.nupdnLightLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLight
            // 
            this.lblLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLight.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblLight.ForeColor = System.Drawing.Color.White;
            this.lblLight.Location = new System.Drawing.Point(0, 0);
            this.lblLight.Margin = new System.Windows.Forms.Padding(0);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(350, 30);
            this.lblLight.TabIndex = 299;
            this.lblLight.Text = "LIGHT";
            this.lblLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLightChannelSelector
            // 
            this.tlpLightChannelSelector.ColumnCount = 4;
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightChannelSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightChannelSelector.Controls.Add(this.cbxChannelNameList, 0, 0);
            this.tlpLightChannelSelector.Controls.Add(this.lblNextChannel, 3, 0);
            this.tlpLightChannelSelector.Controls.Add(this.lblPrevChannel, 2, 0);
            this.tlpLightChannelSelector.Controls.Add(this.lblChannelValue, 0, 0);
            this.tlpLightChannelSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightChannelSelector.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpLightChannelSelector.ForeColor = System.Drawing.Color.White;
            this.tlpLightChannelSelector.Location = new System.Drawing.Point(0, 70);
            this.tlpLightChannelSelector.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightChannelSelector.Name = "tlpLightChannelSelector";
            this.tlpLightChannelSelector.RowCount = 1;
            this.tlpLightChannelSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLightChannelSelector.Size = new System.Drawing.Size(350, 40);
            this.tlpLightChannelSelector.TabIndex = 304;
            // 
            // cbxChannelNameList
            // 
            this.cbxChannelNameList.BackColor = System.Drawing.Color.White;
            this.cbxChannelNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxChannelNameList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxChannelNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChannelNameList.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cbxChannelNameList.ForeColor = System.Drawing.Color.Black;
            this.cbxChannelNameList.FormattingEnabled = true;
            this.cbxChannelNameList.Location = new System.Drawing.Point(125, 0);
            this.cbxChannelNameList.Margin = new System.Windows.Forms.Padding(0);
            this.cbxChannelNameList.Name = "cbxChannelNameList";
            this.cbxChannelNameList.Size = new System.Drawing.Size(125, 28);
            this.cbxChannelNameList.TabIndex = 307;
            // 
            // lblNextChannel
            // 
            this.lblNextChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblNextChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNextChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNextChannel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblNextChannel.Location = new System.Drawing.Point(300, 0);
            this.lblNextChannel.Margin = new System.Windows.Forms.Padding(0);
            this.lblNextChannel.Name = "lblNextChannel";
            this.lblNextChannel.Size = new System.Drawing.Size(50, 40);
            this.lblNextChannel.TabIndex = 306;
            this.lblNextChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrevChannel
            // 
            this.lblPrevChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblPrevChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrevChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrevChannel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrevChannel.Location = new System.Drawing.Point(250, 0);
            this.lblPrevChannel.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrevChannel.Name = "lblPrevChannel";
            this.lblPrevChannel.Size = new System.Drawing.Size(50, 40);
            this.lblPrevChannel.TabIndex = 305;
            this.lblPrevChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChannelValue
            // 
            this.lblChannelValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblChannelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChannelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChannelValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblChannelValue.Location = new System.Drawing.Point(0, 0);
            this.lblChannelValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblChannelValue.Name = "lblChannelValue";
            this.lblChannelValue.Size = new System.Drawing.Size(125, 40);
            this.lblChannelValue.TabIndex = 302;
            this.lblChannelValue.Text = "Channel";
            this.lblChannelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLightControllerSelector
            // 
            this.tlpLightControllerSelector.ColumnCount = 4;
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightControllerSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLightControllerSelector.Controls.Add(this.lblNextControl, 3, 0);
            this.tlpLightControllerSelector.Controls.Add(this.lblPrevControl, 2, 0);
            this.tlpLightControllerSelector.Controls.Add(this.cbxControlNameList, 1, 0);
            this.tlpLightControllerSelector.Controls.Add(this.lblType, 0, 0);
            this.tlpLightControllerSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightControllerSelector.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpLightControllerSelector.ForeColor = System.Drawing.Color.White;
            this.tlpLightControllerSelector.Location = new System.Drawing.Point(0, 30);
            this.tlpLightControllerSelector.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightControllerSelector.Name = "tlpLightControllerSelector";
            this.tlpLightControllerSelector.RowCount = 1;
            this.tlpLightControllerSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLightControllerSelector.Size = new System.Drawing.Size(350, 40);
            this.tlpLightControllerSelector.TabIndex = 301;
            // 
            // lblNextControl
            // 
            this.lblNextControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblNextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNextControl.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblNextControl.Location = new System.Drawing.Point(300, 0);
            this.lblNextControl.Margin = new System.Windows.Forms.Padding(0);
            this.lblNextControl.Name = "lblNextControl";
            this.lblNextControl.Size = new System.Drawing.Size(50, 40);
            this.lblNextControl.TabIndex = 307;
            this.lblNextControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrevControl
            // 
            this.lblPrevControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblPrevControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrevControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrevControl.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrevControl.Location = new System.Drawing.Point(250, 0);
            this.lblPrevControl.Margin = new System.Windows.Forms.Padding(0);
            this.lblPrevControl.Name = "lblPrevControl";
            this.lblPrevControl.Size = new System.Drawing.Size(50, 40);
            this.lblPrevControl.TabIndex = 306;
            this.lblPrevControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxControlNameList
            // 
            this.cbxControlNameList.BackColor = System.Drawing.Color.White;
            this.cbxControlNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxControlNameList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxControlNameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxControlNameList.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cbxControlNameList.ForeColor = System.Drawing.Color.Black;
            this.cbxControlNameList.FormattingEnabled = true;
            this.cbxControlNameList.Location = new System.Drawing.Point(125, 0);
            this.cbxControlNameList.Margin = new System.Windows.Forms.Padding(0);
            this.cbxControlNameList.Name = "cbxControlNameList";
            this.cbxControlNameList.Size = new System.Drawing.Size(125, 28);
            this.cbxControlNameList.TabIndex = 304;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblType.Location = new System.Drawing.Point(0, 0);
            this.lblType.Margin = new System.Windows.Forms.Padding(0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(125, 40);
            this.lblType.TabIndex = 302;
            this.lblType.Text = "TYPE";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCameraParameter
            // 
            this.tlpCameraParameter.ColumnCount = 1;
            this.tlpCameraParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCameraParameter.Controls.Add(this.lblCamera, 0, 0);
            this.tlpCameraParameter.Controls.Add(this.pnlCameraParameter, 0, 1);
            this.tlpCameraParameter.Location = new System.Drawing.Point(44, 30);
            this.tlpCameraParameter.Name = "tlpCameraParameter";
            this.tlpCameraParameter.RowCount = 2;
            this.tlpCameraParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpCameraParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCameraParameter.Size = new System.Drawing.Size(350, 190);
            this.tlpCameraParameter.TabIndex = 303;
            // 
            // lblCamera
            // 
            this.lblCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.lblCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamera.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCamera.ForeColor = System.Drawing.Color.White;
            this.lblCamera.Location = new System.Drawing.Point(0, 0);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(350, 30);
            this.lblCamera.TabIndex = 303;
            this.lblCamera.Text = "CAMERA";
            this.lblCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCameraParameter
            // 
            this.pnlCameraParameter.Controls.Add(this.tlpAnalogGain);
            this.pnlCameraParameter.Controls.Add(this.tlpDigitalGain);
            this.pnlCameraParameter.Controls.Add(this.tlpExposure);
            this.pnlCameraParameter.Controls.Add(this.tlpShading);
            this.pnlCameraParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCameraParameter.Location = new System.Drawing.Point(0, 30);
            this.pnlCameraParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCameraParameter.Name = "pnlCameraParameter";
            this.pnlCameraParameter.Size = new System.Drawing.Size(350, 160);
            this.pnlCameraParameter.TabIndex = 302;
            // 
            // tlpAnalogGain
            // 
            this.tlpAnalogGain.ColumnCount = 2;
            this.tlpAnalogGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpAnalogGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpAnalogGain.Controls.Add(this.lblAnalogGainValue, 1, 0);
            this.tlpAnalogGain.Controls.Add(this.lblAnalogGain, 0, 0);
            this.tlpAnalogGain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpAnalogGain.Location = new System.Drawing.Point(0, 0);
            this.tlpAnalogGain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAnalogGain.Name = "tlpAnalogGain";
            this.tlpAnalogGain.RowCount = 1;
            this.tlpAnalogGain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAnalogGain.Size = new System.Drawing.Size(350, 40);
            this.tlpAnalogGain.TabIndex = 302;
            // 
            // lblAnalogGainValue
            // 
            this.lblAnalogGainValue.AutoSize = true;
            this.lblAnalogGainValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAnalogGainValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnalogGainValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnalogGainValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAnalogGainValue.Location = new System.Drawing.Point(160, 0);
            this.lblAnalogGainValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAnalogGainValue.Name = "lblAnalogGainValue";
            this.lblAnalogGainValue.Size = new System.Drawing.Size(190, 40);
            this.lblAnalogGainValue.TabIndex = 208;
            this.lblAnalogGainValue.Text = "0";
            this.lblAnalogGainValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnalogGain
            // 
            this.lblAnalogGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblAnalogGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnalogGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnalogGain.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAnalogGain.Location = new System.Drawing.Point(0, 0);
            this.lblAnalogGain.Margin = new System.Windows.Forms.Padding(0);
            this.lblAnalogGain.Name = "lblAnalogGain";
            this.lblAnalogGain.Size = new System.Drawing.Size(160, 40);
            this.lblAnalogGain.TabIndex = 145;
            this.lblAnalogGain.Text = "Analog GAIN [dB]\r\n(1 ~ 4)";
            this.lblAnalogGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDigitalGain
            // 
            this.tlpDigitalGain.ColumnCount = 2;
            this.tlpDigitalGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDigitalGain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpDigitalGain.Controls.Add(this.lblDigitalGainValue, 1, 0);
            this.tlpDigitalGain.Controls.Add(this.lblDigitalGain, 0, 0);
            this.tlpDigitalGain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpDigitalGain.Location = new System.Drawing.Point(0, 40);
            this.tlpDigitalGain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDigitalGain.Name = "tlpDigitalGain";
            this.tlpDigitalGain.RowCount = 1;
            this.tlpDigitalGain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDigitalGain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDigitalGain.Size = new System.Drawing.Size(350, 40);
            this.tlpDigitalGain.TabIndex = 301;
            // 
            // lblDigitalGainValue
            // 
            this.lblDigitalGainValue.AutoSize = true;
            this.lblDigitalGainValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDigitalGainValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDigitalGainValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDigitalGainValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDigitalGainValue.Location = new System.Drawing.Point(160, 0);
            this.lblDigitalGainValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDigitalGainValue.Name = "lblDigitalGainValue";
            this.lblDigitalGainValue.Size = new System.Drawing.Size(190, 40);
            this.lblDigitalGainValue.TabIndex = 208;
            this.lblDigitalGainValue.Text = "0";
            this.lblDigitalGainValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDigitalGain
            // 
            this.lblDigitalGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblDigitalGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDigitalGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDigitalGain.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDigitalGain.Location = new System.Drawing.Point(0, 0);
            this.lblDigitalGain.Margin = new System.Windows.Forms.Padding(0);
            this.lblDigitalGain.Name = "lblDigitalGain";
            this.lblDigitalGain.Size = new System.Drawing.Size(160, 40);
            this.lblDigitalGain.TabIndex = 145;
            this.lblDigitalGain.Text = "Digital GAIN [dB]\r\n(0.5 ~ 8)";
            this.lblDigitalGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpExposure
            // 
            this.tlpExposure.ColumnCount = 2;
            this.tlpExposure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpExposure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpExposure.Controls.Add(this.lblExposure, 0, 0);
            this.tlpExposure.Controls.Add(this.lblExposureValue, 1, 0);
            this.tlpExposure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpExposure.Location = new System.Drawing.Point(0, 80);
            this.tlpExposure.Margin = new System.Windows.Forms.Padding(0);
            this.tlpExposure.Name = "tlpExposure";
            this.tlpExposure.RowCount = 1;
            this.tlpExposure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpExposure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpExposure.Size = new System.Drawing.Size(350, 40);
            this.tlpExposure.TabIndex = 300;
            // 
            // lblExposure
            // 
            this.lblExposure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblExposure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExposure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExposure.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblExposure.Location = new System.Drawing.Point(0, 0);
            this.lblExposure.Margin = new System.Windows.Forms.Padding(0);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.Size = new System.Drawing.Size(160, 40);
            this.lblExposure.TabIndex = 145;
            this.lblExposure.Text = "EXPOSURE [us]\r\n(1 ~ 200000)";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExposureValue
            // 
            this.lblExposureValue.AutoSize = true;
            this.lblExposureValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblExposureValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExposureValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExposureValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblExposureValue.Location = new System.Drawing.Point(160, 0);
            this.lblExposureValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblExposureValue.Name = "lblExposureValue";
            this.lblExposureValue.Size = new System.Drawing.Size(190, 40);
            this.lblExposureValue.TabIndex = 208;
            this.lblExposureValue.Text = "0";
            this.lblExposureValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpShading
            // 
            this.tlpShading.ColumnCount = 2;
            this.tlpShading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpShading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShading.Controls.Add(this.lblShading, 0, 0);
            this.tlpShading.Controls.Add(this.btnExcuteShading, 1, 0);
            this.tlpShading.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpShading.Location = new System.Drawing.Point(0, 120);
            this.tlpShading.Margin = new System.Windows.Forms.Padding(0);
            this.tlpShading.Name = "tlpShading";
            this.tlpShading.RowCount = 1;
            this.tlpShading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpShading.Size = new System.Drawing.Size(350, 40);
            this.tlpShading.TabIndex = 190;
            // 
            // lblShading
            // 
            this.lblShading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.lblShading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShading.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblShading.Location = new System.Drawing.Point(0, 0);
            this.lblShading.Margin = new System.Windows.Forms.Padding(0);
            this.lblShading.Name = "lblShading";
            this.lblShading.Size = new System.Drawing.Size(160, 40);
            this.lblShading.TabIndex = 145;
            this.lblShading.Text = "Shading";
            this.lblShading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcuteShading
            // 
            this.btnExcuteShading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcuteShading.FlatAppearance.BorderSize = 2;
            this.btnExcuteShading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcuteShading.Location = new System.Drawing.Point(160, 0);
            this.btnExcuteShading.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcuteShading.Name = "btnExcuteShading";
            this.btnExcuteShading.Size = new System.Drawing.Size(190, 40);
            this.btnExcuteShading.TabIndex = 146;
            this.btnExcuteShading.Text = "Excute";
            this.btnExcuteShading.UseVisualStyleBackColor = true;
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
            this.pnlDrawBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrawBox.Location = new System.Drawing.Point(0, 0);
            this.pnlDrawBox.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDrawBox.Name = "pnlDrawBox";
            this.pnlDrawBox.Size = new System.Drawing.Size(851, 602);
            this.pnlDrawBox.TabIndex = 0;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 300;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // btnLightOn
            // 
            this.btnLightOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLightOn.FlatAppearance.BorderSize = 2;
            this.btnLightOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLightOn.Location = new System.Drawing.Point(0, 0);
            this.btnLightOn.Margin = new System.Windows.Forms.Padding(0);
            this.btnLightOn.Name = "btnLightOn";
            this.btnLightOn.Size = new System.Drawing.Size(175, 40);
            this.btnLightOn.TabIndex = 147;
            this.btnLightOn.Text = "Light On";
            this.btnLightOn.UseVisualStyleBackColor = true;
            // 
            // btnLightOff
            // 
            this.btnLightOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLightOff.FlatAppearance.BorderSize = 2;
            this.btnLightOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLightOff.Location = new System.Drawing.Point(175, 0);
            this.btnLightOff.Margin = new System.Windows.Forms.Padding(0);
            this.btnLightOff.Name = "btnLightOff";
            this.btnLightOff.Size = new System.Drawing.Size(175, 40);
            this.btnLightOff.TabIndex = 148;
            this.btnLightOff.Text = "Off";
            this.btnLightOff.UseVisualStyleBackColor = true;
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
            this.pnlTeach.ResumeLayout(false);
            this.tlpLight.ResumeLayout(false);
            this.tlpLightFunction.ResumeLayout(false);
            this.tlpLightValueSelector.ResumeLayout(false);
            this.pnlTrbDimmingLevelValue.ResumeLayout(false);
            this.pnlTrbDimmingLevelValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLightLevelValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdnLightLevel)).EndInit();
            this.tlpLightChannelSelector.ResumeLayout(false);
            this.tlpLightControllerSelector.ResumeLayout(false);
            this.tlpCameraParameter.ResumeLayout(false);
            this.pnlCameraParameter.ResumeLayout(false);
            this.tlpAnalogGain.ResumeLayout(false);
            this.tlpAnalogGain.PerformLayout();
            this.tlpDigitalGain.ResumeLayout(false);
            this.tlpDigitalGain.PerformLayout();
            this.tlpExposure.ResumeLayout(false);
            this.tlpExposure.PerformLayout();
            this.tlpShading.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tlpLight;
        private System.Windows.Forms.TableLayoutPanel tlpLightFunction;
        private System.Windows.Forms.TableLayoutPanel tlpLightValueSelector;
        private System.Windows.Forms.Panel pnlTrbDimmingLevelValue;
        private System.Windows.Forms.TrackBar trbLightLevelValue;
        private System.Windows.Forms.Label lblLightValue;
        private System.Windows.Forms.NumericUpDown nupdnLightLevel;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.TableLayoutPanel tlpLightChannelSelector;
        private System.Windows.Forms.ComboBox cbxChannelNameList;
        private System.Windows.Forms.Label lblNextChannel;
        private System.Windows.Forms.Label lblPrevChannel;
        private System.Windows.Forms.Label lblChannelValue;
        private System.Windows.Forms.TableLayoutPanel tlpLightControllerSelector;
        private System.Windows.Forms.Label lblNextControl;
        private System.Windows.Forms.Label lblPrevControl;
        private System.Windows.Forms.ComboBox cbxControlNameList;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlCameraParameter;
        private System.Windows.Forms.TableLayoutPanel tlpDigitalGain;
        private System.Windows.Forms.Label lblDigitalGainValue;
        private System.Windows.Forms.Label lblDigitalGain;
        private System.Windows.Forms.TableLayoutPanel tlpExposure;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Label lblExposureValue;
        private System.Windows.Forms.TableLayoutPanel tlpAnalogGain;
        private System.Windows.Forms.Label lblAnalogGainValue;
        private System.Windows.Forms.Label lblAnalogGain;
        private System.Windows.Forms.TableLayoutPanel tlpCameraParameter;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.TableLayoutPanel tlpShading;
        private System.Windows.Forms.Label lblShading;
        private System.Windows.Forms.Button btnExcuteShading;
        private System.Windows.Forms.Button btnLightOff;
        private System.Windows.Forms.Button btnLightOn;
    }
}
