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
            UpdateCaptions();
        }
        #endregion

        #region 메서드
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
    }
}
