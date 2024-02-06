﻿using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Config;
using Jastech.Framework.Imaging;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Forms;
using Jastech.Framework.Winform.Helper;
using MetroFramework.Controls;
using System;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class OperationSettingsForm : Form
    {
        #region 속성
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public bool NeedProgramRebot { get; set; } = false;
        #endregion

        #region 생성자
        public OperationSettingsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void OperationSettingsForm_Load(object sender, EventArgs e)
        {
            foreach (ImageExtension type in Enum.GetValues(typeof(ImageExtension)))
            {
                if (type == ImageExtension.Jpg)
                    continue;

                mcbxOKExtension.Items.Add(type.ToString());
                mcbxNGExtension.Items.Add(type.ToString());
            }
            NeedProgramRebot = false;
            LoadData();
        }

        private void OperationSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO: Tracking Text Params
            ParamTrackingLogger.ClearChangedLog();
        }

        private void LoadData()
        {
            var operation = ConfigSet.Instance().Operation;
            var appsConfig = AppsConfig.Instance();

            txtDataStoringDays.Text = operation.DataStoringDuration.ToString();
            txtDataStoringCapacity.Text = operation.DataStoringCapacity.ToString();

            mtgSaveOK.Checked = operation.SaveImageOK;
            mtgSaveNG.Checked = operation.SaveImageNG;

            for (int i = 0; i < mcbxOKExtension.Items.Count; i++)
            {
                ImageExtension type = (ImageExtension)Enum.Parse(typeof(ImageExtension), mcbxOKExtension.Items[i] as string);
                if (type == operation.ExtensionOKImage)
                    mcbxOKExtension.SelectedIndex = i;
            }

            for (int i = 0; i < mcbxNGExtension.Items.Count; i++)
            {
                ImageExtension type = (ImageExtension)Enum.Parse(typeof(ImageExtension), mcbxNGExtension.Items[i] as string);
                if (type == operation.ExtensionNGImage)
                    mcbxNGExtension.SelectedIndex = i;
            }
        }

        public void UpdateCurrentData()
        {
            var operation = ConfigSet.Instance().Operation;
            var appsConfig = AppsConfig.Instance();

            appsConfig.EnablePLCTime = mtgEnablePlcTime.Checked;

            operation.DataStoringDuration = (int)Convert.ToDouble(GetValue(txtDataStoringDays.Text));
            operation.DataStoringCapacity = (int)Convert.ToDouble(GetValue(txtDataStoringCapacity.Text));

            operation.SaveImageOK = mtgSaveOK.Checked;
            operation.SaveImageNG = mtgSaveNG.Checked;

            operation.ExtensionOKImage = (ImageExtension)Enum.Parse(typeof(ImageExtension), mcbxOKExtension.SelectedItem as string);
            operation.ExtensionNGImage = (ImageExtension)Enum.Parse(typeof(ImageExtension), mcbxNGExtension.SelectedItem as string);
        }

        public string GetValue(string value)
        {
            if (value == "")
                value = "0";

            return value;
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentData();

            ConfigSet.Instance().Save();
            AppsConfig.Instance().Save();

            if (ParamTrackingLogger.IsEmpty == false)
            {
                ParamTrackingLogger.AddLog("Operation Setting Saved.");
                ParamTrackingLogger.WriteLogToFile();
            }

            MessageConfirmForm form = new MessageConfirmForm();
            form.Message = "Save Completed.";
            form.ShowDialog();

            if (NeedProgramRebot)
            {
                form.Message = "Changing the Device settings will require you to restart the program.";
                form.ShowDialog();
                NeedProgramRebot = false;
            }

            Logger.Write(LogType.GUI, "Clicked OperationSettingsForm Save Button");
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Logger.Write(LogType.GUI, "Clicked OperationSettingsForm Cancle Button");
        }

        private void txtKeyPad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자, 백스페이스, '.' 를 제외한 나머지를 바로 처리             
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar('.')))
                e.Handled = true;
        }

        private void txtDataStoringDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자, 백스페이스 를 제외한 나머지를 바로 처리             
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void txtDataStoringCapcity_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (double.TryParse(textBox.Text, out double value))
                textBox.Text = string.Format("{0:0.00}", value);
            else
                textBox.Text = "0.00";
        }

        private void txtKeyPad_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (double.TryParse(textBox.Text, out double value))
                textBox.Text = string.Format("{0:0.000}", value);
            else
                textBox.Text = "0.000";
        }

        private void textbox_KeyPad_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                    textBox.Text = "0";

                double oldValue = Convert.ToDouble(textBox.Text);
                double newValue = KeyPadHelper.SetLabelDoubleData(textBox);

                ParamTrackingLogger.AddChangeHistory("Operation Setting", textBox.Name.Replace("txt", ""), oldValue, newValue);
            }
        }

        private void txtDataStoringDays_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (double.TryParse(textBox.Text, out double value))
                textBox.Text = string.Format("{0:0}", value);
            else
                textBox.Text = "0";
        }

        private void mtgOperationSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroToggle toggleButton)
                ParamTrackingLogger.AddChangeHistory("OperationSetting", toggleButton.Name.Replace("mtg", ""), !toggleButton.Checked, toggleButton.Checked);
            else if (sender is RadioButton radioButton)
                ParamTrackingLogger.AddChangeHistory("OperationSetting", radioButton.Name.Replace("rdo", ""), !radioButton.Checked, radioButton.Checked);
        }
        #endregion
    }
}
