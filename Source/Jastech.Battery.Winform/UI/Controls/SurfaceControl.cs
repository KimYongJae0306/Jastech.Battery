using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Framework.Util.Helper;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Winform.Helper;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class SurfaceControl : UserControl
    {
        #region 필드
        private SurfaceParam _surfaceParam = null;
        #endregion

        #region 생성자
        public SurfaceControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void SurfaceControl_Load(object sender, EventArgs e)
        {
            UpdateCaptions();
        }

        public void SetParam(SurfaceParam param)
        {
            if (param != null)
                _surfaceParam = param;
            UpdateCaptions();

            var test = new EditParameterControl { Dock = DockStyle.Fill };
            test.SetData(_surfaceParam, 40);
            pnlDataSpecContainer.Controls.Add(test);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;

                if (cmb != null)
                {
                    e.DrawBackground();

                    cmb.ItemHeight = lblParameter.Height;

                    if (e.Index >= 0)
                    {
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;

                        Brush brush = new SolidBrush(cmb.ForeColor);

                        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                            brush = SystemBrushes.HighlightText;

                        e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brush, e.Bounds, sf); 
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                throw;
            }
        }

        private void UpdateCaptions()
        {
            if (_surfaceParam == null)
                return;

            
        }
        #endregion

        private void lblROIMarginCorner_Click(object sender, EventArgs e)
        {
            if (_surfaceParam == null)
                return;

            var control = sender as Control;
            _surfaceParam.CornerMargin = KeyPadHelper.SetLabelIntegerData(control);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (_surfaceParam == null)
                return;

            var control = sender as Control;
            int value = KeyPadHelper.SetLabelIntegerData(control);
            _surfaceParam.LineParam.Level = value;
            _surfaceParam.LineParam.EdgeLevel= KeyPadHelper.SetLabelIntegerData(control);
        }

        private void cbxSpecificationLineUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpeicificationLineDarkUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpecificationPinholeUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpecificationCraterUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpecificationDentUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpecificationScratchUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void cbxSpecificationTapeUsage_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            UpdateCheckBox(checkBox);
        }

        private void UpdateCheckBox(CheckBox checkBox)
        {
            if (checkBox.Checked)
                checkBox.ImageIndex = 1;
            else
                checkBox.ImageIndex = 0;
        }
    }
}
