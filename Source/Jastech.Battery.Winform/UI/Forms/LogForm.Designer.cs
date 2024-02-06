﻿using Jastech.Battery.Winform.Forms;

namespace Jastech.Battery.Winform.Forms
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.tlpContents = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogType = new System.Windows.Forms.Panel();
            this.btnSelectionImage = new System.Windows.Forms.Button();
            this.btnSelectionLog = new System.Windows.Forms.Button();
            this.pnlContents = new System.Windows.Forms.Panel();
            this.tlpBasicFunction = new System.Windows.Forms.TableLayoutPanel();
            this.tvwLogPath = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpLog.SuspendLayout();
            this.tlpContents.SuspendLayout();
            this.pnlLogType.SuspendLayout();
            this.tlpBasicFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 2;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 283F));
            this.tlpLog.Controls.Add(this.tlpContents, 0, 0);
            this.tlpLog.Controls.Add(this.tlpBasicFunction, 1, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(0, 0);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 1;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 981F));
            this.tlpLog.Size = new System.Drawing.Size(1380, 981);
            this.tlpLog.TabIndex = 0;
            // 
            // tlpContents
            // 
            this.tlpContents.ColumnCount = 1;
            this.tlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContents.Controls.Add(this.pnlLogType, 0, 0);
            this.tlpContents.Controls.Add(this.pnlContents, 0, 1);
            this.tlpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContents.Location = new System.Drawing.Point(0, 0);
            this.tlpContents.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContents.Name = "tlpContents";
            this.tlpContents.RowCount = 2;
            this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContents.Size = new System.Drawing.Size(1097, 981);
            this.tlpContents.TabIndex = 10;
            // 
            // pnlLogType
            // 
            this.pnlLogType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogType.Controls.Add(this.btnSelectionImage);
            this.pnlLogType.Controls.Add(this.btnSelectionLog);
            this.pnlLogType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogType.Location = new System.Drawing.Point(0, 0);
            this.pnlLogType.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogType.Name = "pnlLogType";
            this.pnlLogType.Size = new System.Drawing.Size(1097, 162);
            this.pnlLogType.TabIndex = 8;
            // 
            // btnSelectionImage
            // 
            this.btnSelectionImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnSelectionImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectionImage.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectionImage.ForeColor = System.Drawing.Color.White;
            this.btnSelectionImage.Location = new System.Drawing.Point(160, 20);
            this.btnSelectionImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectionImage.Name = "btnSelectionImage";
            this.btnSelectionImage.Size = new System.Drawing.Size(120, 80);
            this.btnSelectionImage.TabIndex = 201;
            this.btnSelectionImage.Text = "IMAGE";
            this.btnSelectionImage.UseVisualStyleBackColor = false;
            this.btnSelectionImage.Click += new System.EventHandler(this.btnSelectionImage_Click);
            // 
            // btnSelectionLog
            // 
            this.btnSelectionLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.btnSelectionLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectionLog.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectionLog.ForeColor = System.Drawing.Color.White;
            this.btnSelectionLog.Location = new System.Drawing.Point(20, 20);
            this.btnSelectionLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectionLog.Name = "btnSelectionLog";
            this.btnSelectionLog.Size = new System.Drawing.Size(120, 80);
            this.btnSelectionLog.TabIndex = 200;
            this.btnSelectionLog.Text = "LOG";
            this.btnSelectionLog.UseVisualStyleBackColor = false;
            this.btnSelectionLog.Click += new System.EventHandler(this.btnSelectionLog_Click);
            // 
            // pnlContents
            // 
            this.pnlContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContents.ForeColor = System.Drawing.Color.Black;
            this.pnlContents.Location = new System.Drawing.Point(0, 162);
            this.pnlContents.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(1097, 819);
            this.pnlContents.TabIndex = 9;
            // 
            // tlpBasicFunction
            // 
            this.tlpBasicFunction.ColumnCount = 2;
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tlpBasicFunction.Controls.Add(this.tvwLogPath, 0, 1);
            this.tlpBasicFunction.Controls.Add(this.btnCancel, 1, 3);
            this.tlpBasicFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBasicFunction.Location = new System.Drawing.Point(1097, 0);
            this.tlpBasicFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBasicFunction.Name = "tlpBasicFunction";
            this.tlpBasicFunction.RowCount = 4;
            this.tlpBasicFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpBasicFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasicFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlpBasicFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpBasicFunction.Size = new System.Drawing.Size(283, 981);
            this.tlpBasicFunction.TabIndex = 9;
            // 
            // tvwLogPath
            // 
            this.tvwLogPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.tlpBasicFunction.SetColumnSpan(this.tvwLogPath, 2);
            this.tvwLogPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwLogPath.ForeColor = System.Drawing.Color.White;
            this.tvwLogPath.Location = new System.Drawing.Point(0, 250);
            this.tvwLogPath.Margin = new System.Windows.Forms.Padding(0);
            this.tvwLogPath.Name = "tvwLogPath";
            this.tvwLogPath.Size = new System.Drawing.Size(283, 544);
            this.tvwLogPath.TabIndex = 11;
            this.tvwLogPath.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwLogPath_NodeMouseClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(139, 883);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 96);
            this.btnCancel.TabIndex = 295;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1380, 981);
            this.ControlBox = false;
            this.Controls.Add(this.tlpLog);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogForm_FormClosing);
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.tlpLog.ResumeLayout(false);
            this.tlpContents.ResumeLayout(false);
            this.pnlLogType.ResumeLayout(false);
            this.tlpBasicFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Panel pnlLogType;
        private System.Windows.Forms.TableLayoutPanel tlpBasicFunction;
        private System.Windows.Forms.TableLayoutPanel tlpContents;
        private System.Windows.Forms.Panel pnlContents;
        private System.Windows.Forms.Button btnSelectionImage;
        private System.Windows.Forms.Button btnSelectionLog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView tvwLogPath;
    }
}