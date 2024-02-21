using Jastech.Battery.Structure.Data;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class DefectInfoContainerControl : UserControl
    {
        #region 속성
        public bool IsVertical { get; set; } = true;
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
                controlSize.Width =(pnlContainer.Width - scrollBarSize) / drawingCount;
                controlSize.Height = defectInfoControl.Height;
                controlLocation.X = (pnlContainer.Controls.Count % drawingCount) * controlSize.Width;
                controlLocation.Y = (pnlContainer.Controls.Count / drawingCount) * controlSize.Height + pnlContainer.AutoScrollPosition.Y;
            }
            else
            {
                int drawingCount = Height / defectInfoControl.Height;
                if (drawingCount == 0)
                    drawingCount = 1;
                controlSize.Width = defectInfoControl.Width;
                controlSize.Height = (pnlContainer.Height - scrollBarSize) / drawingCount;
                controlLocation.X = (pnlContainer.Controls.Count / drawingCount) * (defectInfoControl.Width / drawingCount) + pnlContainer.AutoScrollPosition.X;
                controlLocation.Y = (pnlContainer.Controls.Count % drawingCount) * (defectInfoControl.Height / drawingCount);
            }
            defectInfoControl.Size = controlSize;
            defectInfoControl.Location = controlLocation;
            pnlContainer.Controls.Add(defectInfoControl);

            if (IsVertical)
                pnlContainer.VerticalScroll.Value = pnlContainer.VerticalScroll.Maximum;
            else
                pnlContainer.HorizontalScroll.Value = pnlContainer.HorizontalScroll.Maximum;
        }

        public void AddDefectInfo(List<DefectInfo> defectInfos)
        {
            defectInfos.ForEach(defectInfo => AddDefectInfo(defectInfo));
        }

        public void Clear()
        {
            foreach (Control control in pnlContainer.Controls)
            {
                if (control is DefectInfoControl defectInfoControl)
                {
                    ControlHelper.DisposeDisplay(defectInfoControl);
                    ControlHelper.DisposeChildControls(defectInfoControl);
                }
            }
            pnlContainer.Controls.Clear();
            pnlContainer.VerticalScroll.Value = 0;
            pnlContainer.HorizontalScroll.Value = 0;
        }

        public void SelectedControlIndexChanged(int index)
        {
            SelectedDefectChanged?.Invoke(index);
            foreach (Control control in pnlContainer.Controls)
            {
                if (control is DefectInfoControl defectInfoControl)
                {
                    if (index == defectInfoControl.GetDefectIndex())
                        defectInfoControl.SetBorderColor();
                    else
                        defectInfoControl.ResetBorderColor();
                }
            }
        }
        #endregion
    }
}
