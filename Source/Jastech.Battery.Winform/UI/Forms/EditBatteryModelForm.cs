﻿using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Config;
using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Helper;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Forms;
using Jastech.Framework.Winform.Helper;
using System;
using System.IO;
using System.Windows.Forms;
using static Jastech.Framework.Modeller.Controls.ModelControl;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class EditBatteryModelForm : Form
    {
        #region 속성
        private AppsInspModel PrevModel { get; set; } = new AppsInspModel();

        public string PrevModelName { get; set; }

        public string ModelPath { get; set; }
        #endregion

        #region 이벤트
        public event EditModelDelegate EditModelEvent;
        #endregion

        #region 생성자
        public EditBatteryModelForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void EditATTModelForm_Load(object sender, EventArgs e)
        {
            txtModelName.Text = PrevModelName;

            string filePath = Path.Combine(ModelPath, PrevModelName, InspModel.FileName);

            JsonConvertHelper.LoadToExistingTarget<AppsInspModel>(filePath, PrevModel);

            txtDescription.Text = PrevModel.Description;
            txtLaneCount.Text = PrevModel.LaneCount.ToString();
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            if (PrevModelName != txtModelName.Text)
            {
                if (ModelFileHelper.IsExistModel(ModelPath, txtModelName.Text))
                {
                    MessageConfirmForm form = new MessageConfirmForm();
                    form.Message = "The same model exists.";
                    form.ShowDialog();
                    return;
                }
            }

            AppsInspModel inspModel = new AppsInspModel
            {
                Name = txtModelName.Text,
                Description = txtDescription.Text,
                LaneCount = Convert.ToInt32(txtLaneCount.Text),
            };
            if (AppsConfig.Instance().UseMaterialInfo)
            {
                //BatteryMaterialInfoForm form = new BatteryMaterialInfoForm();
                //form.ModelName = inspModel?.Name;
                //form.PrevMaterialInfo = PrevModel.MaterialInfo;
                //form.LaneCount = Convert.ToInt32(txtLaneCount.Text);

                //if (form.ShowDialog() == DialogResult.OK)
                //    inspModel.MaterialInfo = form.NewMaterialInfo;
                //else
                //    return;
            }

            DialogResult = DialogResult.OK;
            Close();

            EditModelEvent?.Invoke(PrevModelName, inspModel);

            Logger.Write(LogType.GUI, "Clicked EditATTModelForm Apply Button");
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            ParamTrackingLogger.ClearChangedLog();
            DialogResult = DialogResult.Cancel;
            Close();

            Logger.Write(LogType.GUI, "Clicked EditATTModelForm Cancle Button");
        }

        private void textbox_KeyBoard_Click(object sender, EventArgs e)
        {
            if (OperationConfig.UseKeyboard)
            {
                KeyBoardForm form = new KeyBoardForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var textBox = (TextBox)sender;
                    textBox.Text = form.KeyValue;
                }
            }
        }

        private void textbox_KeyPad_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                    textBox.Text = "0";

                double oldValue = Convert.ToDouble(textBox.Text);
                double newValue = KeyPadHelper.SetLabelDoubleData(textBox);

                ParamTrackingLogger.AddChangeHistory("Inspection Model Spec", textBox.Name.Replace("txt", ""), oldValue, newValue);
            }
        }

        private void txtKeyPad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자, 백스페이스, '.' 를 제외한 나머지를 바로 처리             
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar('.')))
            {
                e.Handled = true;
            }
        }

        private void txtKeyPad_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (double.TryParse(textBox.Text, out double value))
                textBox.Text = string.Format("{0:0.000}", value);
            else
                textBox.Text = "0.000";
        }
        #endregion
    }
}
