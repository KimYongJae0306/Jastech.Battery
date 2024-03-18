﻿//using Jastech.Battery.Winform.Service.Plc.Maps;
//using Jastech.Battery.Winform.Service.Plc;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Config;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Forms
{
    public partial class BatteryMaterialInfoForm : Form
    {
        #region 필드
        private readonly Dictionary<string, List<TextBox>> _textBoxes = new Dictionary<string, List<TextBox>>();

        private readonly Dictionary<string, List<TableLayoutPanel>> _layoutPanels = new Dictionary<string, List<TableLayoutPanel>>();
        #endregion

        #region 속성
        public string ModelName { get; set; }

        public int LaneCount { private get; set; } = 1;

        public MaterialInfo PrevMaterialInfo { get; set; } = null;

        public MaterialInfo NewMaterialInfo { get; set; } = null;
        #endregion

        #region 생성자
        public BatteryMaterialInfoForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void ATTMaterialInfoForm_Load(object sender, EventArgs e)
        {
            InitializeUICollections();
            //var manager = PlcControlManager.Instance();

            ////if (ModelName == PlcControlManager.Instance().ConvertDoubleWordStringFormat_mm(PlcCommonMap.PLC_PPID_ModelName)
            ////    && ConfigSet.Instance().Operation.VirtualMode == false)
            //if (ModelName == manager.GetValue(PlcCommonMap.PLC_PPID_ModelName)
            //      && ConfigSet.Instance().Operation.VirtualMode == false)
            //{
            //    PrevMaterialInfo = PlcScenarioManager.Instance().GetModelMaterialInfo();
            //    LaneCount = Convert.ToInt32(PlcControlManager.Instance().GetValue(PlcCommonMap.PLC_TabCount));
            //    pnlMaterialDatas.Enabled = false;
            //}

            if (PrevMaterialInfo == null)
                PrevMaterialInfo = new MaterialInfo();

            NewMaterialInfo = PrevMaterialInfo.ShallowCopy();
            if (NewMaterialInfo != null)
            {
            }
        }

        private void textbox_KeyPad_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                double oldValue = Convert.ToDouble(textBox.Text);
                double newValue = KeyPadHelper.SetLabelDoubleData(textBox);

                ParamTrackingLogger.AddChangeHistory("MaterialInfo", textBox.Name.Replace("txt", ""), oldValue, newValue);
            }
        }

        private void lblApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

            Logger.Write(LogType.GUI, "Clicked ATTMaterialInfoForm Apply Button");
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            NewMaterialInfo = PrevMaterialInfo;
            DialogResult = DialogResult.Cancel;
            Close();
            Logger.Write(LogType.GUI, "Clicked ATTMaterialInfoForm Cancle Button");
        }
        
        private void InitializeUICollections()
        {
            _textBoxes["TabWidth"] = new List<TextBox>
            {
                txtTab1Width,
                txtTab2Width,
                txtTab3Width,
                txtTab4Width,
                txtTab5Width,
                txtTab6Width,
                txtTab7Width,
                txtTab8Width,
                txtTab9Width,
                txtTab10Width,
            };
            _textBoxes["Distance"] = new List<TextBox>
            {
                txtDistance1,
                txtDistance2,
                txtDistance3,
                txtDistance4,
                txtDistance5,
                txtDistance6,
                txtDistance7,
                txtDistance8,
                txtDistance9,
            };
            _textBoxes["LeftOffset"] = new List<TextBox>
            {
                txtLeftOffset1,
                txtLeftOffset2,
                txtLeftOffset3,
                txtLeftOffset4,
                txtLeftOffset5,
                txtLeftOffset6,
                txtLeftOffset7,
                txtLeftOffset8,
                txtLeftOffset9,
                txtLeftOffset10,
            };
            _textBoxes["RightOffset"] = new List<TextBox>
            {
                txtRightOffset1,
                txtRightOffset2,
                txtRightOffset3,
                txtRightOffset4,
                txtRightOffset5,
                txtRightOffset6,
                txtRightOffset7,
                txtRightOffset8,
                txtRightOffset9,
                txtRightOffset10,
            };

            _layoutPanels["TabWidth"] = new List<TableLayoutPanel>
            {
                tlpTabWidth1,
                tlpTabWidth2,
                tlpTabWidth3,
                tlpTabWidth4,
                tlpTabWidth5,
                tlpTabWidth6,
                tlpTabWidth7,
                tlpTabWidth8,
                tlpTabWidth9,
                tlpTabWidth10,
            };
            _layoutPanels["Distance"] = new List<TableLayoutPanel>
            {
                tlpTab1ToTab2,
                tlpTab2ToTab3,
                tlpTab3ToTab4,
                tlpTab4ToTab5,
                tlpTab5ToTab6,
                tlpTab6ToTab7,
                tlpTab7ToTab8,
                tlpTab8ToTab9,
                tlpTab9ToTab10,
            };
            _layoutPanels["LeftOffset"] = new List<TableLayoutPanel>
            {
                tlpLeftOffset1,
                tlpLeftOffset2,
                tlpLeftOffset3,
                tlpLeftOffset4,
                tlpLeftOffset5,
                tlpLeftOffset6,
                tlpLeftOffset7,
                tlpLeftOffset8,
                tlpLeftOffset9,
                tlpLeftOffset10,
            };
            _layoutPanels["RightOffset"] = new List<TableLayoutPanel>
            {
                tlpRightOffset1,
                tlpRightOffset2,
                tlpRightOffset3,
                tlpRightOffset4,
                tlpRightOffset5,
                tlpRightOffset6,
                tlpRightOffset7,
                tlpRightOffset8,
                tlpRightOffset9,
                tlpRightOffset10,
            };
        }
        #endregion
    }
}
