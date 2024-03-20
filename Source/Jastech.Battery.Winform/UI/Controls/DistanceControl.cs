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
using Jastech.Framework.Winform.Helper;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Parameters;
using OpenTK.Platform.Windows;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class DistanceControl : UserControl
    {

        #region 필드
        private DistanceParam _distanceParam = null;
        #endregion

        #region 속성
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public DistanceControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void DistanceControl_Load(object sender, EventArgs e)
        {
            UpdateCaptions();
        }

        private void UpdateCaptions()
        {
            if (_distanceParam == null)
                return;

            lblCoatingMinimumLength.Text = _distanceParam.CoatingMinimumLength.ToString();
            lblCoatingThreshold.Text = _distanceParam.CoatingThreshold.ToString();
            lblCoatingMinimumWidth.Text = _distanceParam.CoatingMinimumWidth.ToString();
            lblCoatingMaximumWidth.Text = _distanceParam.CoatingMaximumWidth.ToString();

            lblNonCoatingThreshold.Text = _distanceParam.NonCoatingThreshold.ToString();
            lblNonCoatingMinimumWidth.Text = _distanceParam.NonCoatingMinimumWidth.ToString();
            lblNonCoatingMaximumWidth.Text = _distanceParam.NonCoatingMaximumWidth.ToString();

            lblROIThreshold.Text = _distanceParam.ROIThreshold.ToString();
            lblROIMarginLeft.Text = _distanceParam.ROIMarginLeft.ToString();
            lblROIMarginTop.Text = _distanceParam.ROIMarginTop.ToString();
            lblROIMarginRight.Text = _distanceParam.ROIMarginRight.ToString();
            lblROIMarginBottom.Text = _distanceParam.ROIMarginBottom.ToString();
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

        public void SetParam(DistanceParam param)
        {
            if (param != null)
                _distanceParam = param;
            UpdateCaptions();
        }

        private void lblCoatingThreshold_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control =  sender as Control;
            _distanceParam.CoatingThreshold = KeyPadHelper.SetLabelIntegerData(control) ;
        }

        private void lblNonCoatingThreshold_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.NonCoatingThreshold = KeyPadHelper.SetLabelIntegerData(control);
        }

        private void lblMarginLeft_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.ROIMarginLeft = KeyPadHelper.SetLabelIntegerData(control);
        }

        private void lblMarginRight_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.ROIMarginRight = KeyPadHelper.SetLabelIntegerData(control);
        }

        private void lblMarginTop_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.ROIMarginTop = KeyPadHelper.SetLabelIntegerData(control);
        }

        private void lblMarginBottom_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.ROIMarginBottom = KeyPadHelper.SetLabelIntegerData(control);
        }
        #endregion

        private void lblCoatingMinimumWidth_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.CoatingMinimumWidth= KeyPadHelper.SetLabelDoubleData(control);
        }

        private void lblCoatingMaximumWidth_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.CoatingMaximumWidth = KeyPadHelper.SetLabelDoubleData(control);
        }

        private void lblNonCoatingMinimumWidth_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.NonCoatingMinimumWidth = KeyPadHelper.SetLabelDoubleData(control);
        }

        private void lblNonCoatingMaximumWidth_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.NonCoatingMaximumWidth = KeyPadHelper.SetLabelDoubleData(control);
        }

        private void lblCoatingMinimumLength_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.CoatingMinimumLength = KeyPadHelper.SetLabelDoubleData(control);
        }

        private void lblROIThreshold_Click(object sender, EventArgs e)
        {
            if (_distanceParam == null)
                return;

            var control = sender as Control;
            _distanceParam.ROIThreshold = KeyPadHelper.SetLabelIntegerData(control);
        }
    }
}
