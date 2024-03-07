using Jastech.Battery.Structure.Data;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class DefectInfoContainerControl : UserControl
    {
        #region 속성
        public bool IsVertical { get; set; } = true;

        DoubleBufferedPanel dpnlContainer { get; set; } = null;
        #endregion

        #region 이벤트
        public event SelectedIndexChangedHandler SelectedDefectChanged;
        #endregion

        #region 델리게이트
        public delegate void SelectedIndexChangedHandler(int index);
        #endregion

        #region 생성자
        public DefectInfoContainerControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void DefectInfoContainerControl_Load(object sender, System.EventArgs e)
        {
            dpnlContainer = new DoubleBufferedPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            Controls.Add(dpnlContainer);
        }

        public void AddDefectInfo(DefectInfo defectInfo)
        {
            if (defectInfo == null)
            {
                Logger.Write(LogType.Error, "DefectInfo object cant not be null");
                return;
            }
            DefectInfoControl defectInfoControl = new DefectInfoControl();
            defectInfoControl.SetDefectInfo(defectInfo);
            defectInfoControl.SelectedDefectIndexChanged += SelectedControlIndexChanged;

            const int scrollBarSize = 20;
            Point controlLocation = new Point();
            Size controlSize = new Size();
            if (IsVertical)
            {
                int drawingCount = Width / defectInfoControl.Width;
                if (drawingCount == 0)
                    drawingCount = 1;
                controlSize.Width =(dpnlContainer.Width - scrollBarSize) / drawingCount;
                controlSize.Height = defectInfoControl.Height;
                controlLocation.X = (dpnlContainer.Controls.Count % drawingCount) * controlSize.Width;
                controlLocation.Y = (dpnlContainer.Controls.Count / drawingCount) * controlSize.Height + dpnlContainer.AutoScrollPosition.Y;
            }
            else
            {
                int drawingCount = Height / defectInfoControl.Height;
                if (drawingCount == 0)
                    drawingCount = 1;
                controlSize.Width = defectInfoControl.Width;
                controlSize.Height = (dpnlContainer.Height - scrollBarSize) / drawingCount;
                controlLocation.X = (dpnlContainer.Controls.Count / drawingCount) * (defectInfoControl.Width / drawingCount) + dpnlContainer.AutoScrollPosition.X;
                controlLocation.Y = (dpnlContainer.Controls.Count % drawingCount) * (defectInfoControl.Height / drawingCount);
            }
            defectInfoControl.Size = controlSize;
            defectInfoControl.Location = controlLocation;
            dpnlContainer.Controls.Add(defectInfoControl);
        }

        public void AddDefectInfo(List<DefectInfo> defectInfos)
        {
            dpnlContainer.SuspendLayout();
            defectInfos.ForEach(defectInfo => AddDefectInfo(defectInfo));
            dpnlContainer.ResumeLayout(true);
        }

        public void Clear()
        {
            dpnlContainer.SuspendLayout();
            foreach (Control control in dpnlContainer.Controls)
            {
                if (control is DefectInfoControl defectInfoControl)
                {
                    ControlHelper.DisposeDisplay(defectInfoControl);
                    ControlHelper.DisposeChildControls(defectInfoControl);
                }
            }
            dpnlContainer.Controls.Clear();
            dpnlContainer.VerticalScroll.Value = 0;
            dpnlContainer.HorizontalScroll.Value = 0;
            dpnlContainer.ResumeLayout(true);
        }

        public void SelectedControlIndexChanged(int index)
        {
            SelectedDefectChanged?.Invoke(index);
            foreach (Control control in dpnlContainer.Controls)
            {
                if (control is DefectInfoControl defectInfoControl)
                {
                    if (index == defectInfoControl.GetDefectIndex())
                    { 
                        defectInfoControl.SetBorderColor();
                        defectInfoControl.Focus();
                    }
                    else
                        defectInfoControl.ResetBorderColor();
                }
            }
        }
        #endregion
    }
}
