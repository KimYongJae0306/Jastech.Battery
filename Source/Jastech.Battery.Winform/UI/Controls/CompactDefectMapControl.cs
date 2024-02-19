using Jastech.Battery.Structure.Data;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Jastech.Battery.Structure.Data.DefectDefine;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class CompactDefectMapControl : UserControl
    {
        #region 필드
        private RectangleF DisplayArea; // TODO : _소문자

        private float _maximumY = 50000;

        private int _selectedDefectIndex = -1;
        #endregion

        #region 속성
        private DoubleBufferedPanel pnlMapArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };     // TODO : Load 이벤트로 빼기, 대문자로

        public int maximumMeter = 600;

        public float MaximumY {
            get
            {
                return _maximumY;
            }
            set
            {
                _maximumY = value;
                Invalidate();
            }
        } // TODO: Resolution 참고하여 Meter 단위로 환산, Model에서 가져올 것

        public List<DefectInfo> _defectInfos = new List<DefectInfo>();

        public double PixelResolution = 20; // TODO : Config에서 가져올 것
        #endregion

        #region 이벤트
        public SelectedDefectChangedHandler SelectedDefectChanged;
        #endregion

        #region 대리자
        public delegate void SelectedDefectChangedHandler(int index);
        #endregion

        #region 생성자
        public CompactDefectMapControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void CompactDefectMapControl_Load(object sender, EventArgs e)
        {
            DisplayArea = GetDisplayArea();
            SelectedDefectChanged += ChangeSelectedDefect;
            pnlMapArea.Paint += pnlMapArea_Paint;
            Controls.Add(pnlMapArea);
        }

        public void Clear()
        {
            MaximumY = 0;
            _defectInfos.Clear();
            pnlMapArea.Invalidate();
        }

        private RectangleF GetDisplayArea()
        {
            return new RectangleF(new PointF(pnlMapArea.Left + 70, pnlMapArea.Top + 20), new SizeF(pnlMapArea.DisplayRectangle.Width - 90, pnlMapArea.DisplayRectangle.Height - 60));
        }

        private void DrawDefectShape(Graphics g, DefectInfo defectInfo)
        {
            var coord = GetScaledLocation(defectInfo.GetCoord(), ImageMaxWidth: 16383);

            var color = Colors[defectInfo.DefectType];
            var brush = new SolidBrush(color);
            var area = new RectangleF(coord.X, coord.Y - 3.5f, 7, 7);

            if (defectInfo.Index == _selectedDefectIndex)
                g.DrawString($"{defectInfo.DefectType}", Font, new SolidBrush(Color.Crimson), new PointF(coord.X + 4.5f, coord.Y + 4.5f));
            g.FillEllipse(brush, area);
        }

        public void AddCoordinate(DefectInfo defectInfo)
        {
            _defectInfos.Add(defectInfo);
            var defectCoord = defectInfo.GetCoord();
            var defectSize = defectInfo.GetSize();
            if (defectCoord.Y + defectSize.Height > MaximumY)
                MaximumY = defectCoord.Y + defectSize.Height;
        }

        public void AddCoordinate(List<DefectInfo> defectInfos)
        {
            defectInfos.ForEach(defectInfo => AddCoordinate(defectInfo));
        }

        private PointF GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/)
        {
            return new PointF
            {
                X = Convert.ToSingle(DisplayArea.Left + coordinates.X * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
                Y = Convert.ToSingle(DisplayArea.Top + DisplayArea.Height - (coordinates.Y * DisplayArea.Height / MaximumY)),
            };
        }

        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);
            DisplayArea = GetDisplayArea();

            // TODO : 주석 남기지 말고 Block 단위 메서드 추출

            // Draw Side Lines
            Pen sideLinePen = new Pen(Color.FromArgb(208,208,208))
            {
                Width = 5,
                StartCap = LineCap.ArrowAnchor
            };
            e.Graphics.DrawLine(sideLinePen, new Point((int)DisplayArea.Left, 5), new Point((int)DisplayArea.Left, Height));
            e.Graphics.DrawLine(sideLinePen, new Point((int)DisplayArea.Right, 5), new Point((int)DisplayArea.Right, Height));

            // Drawing Grid and Length
            double maximumHeight = MaximumY / 1000;
            double gridMargin = maximumHeight / 10;
            Font stringFont = new Font("맑은 고딕", 9, FontStyle.Bold);
            var dashPen = new Pen(Color.FromArgb(208, 208, 208))
            {
                DashStyle = DashStyle.Dash,
                Width = 0.3f
            };
            for (int count = 0; count <= 10; count++)
            {
                int drawingHeight = (int)(count * (DisplayArea.Height / 10)) + (int)DisplayArea.Top;
                
                e.Graphics.DrawLine(dashPen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                e.Graphics.DrawString($"{((maximumHeight - (count * gridMargin)) * PixelResolution) / 1000:N2}m", stringFont, Brushes.White, new PointF(5, drawingHeight - Font.Size / 2));
            }

            pnlMapArea.SuspendLayout();
            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(e.Graphics, defectInfo);
            pnlMapArea.ResumeLayout(true);
        }

        private void ChangeSelectedDefect(int index)
        { 
            _selectedDefectIndex = index;
        }
        #endregion
    }
}
