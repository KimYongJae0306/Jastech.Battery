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
        private RectangleF _displayArea;

        public double _pixelResolution = 20; // TODO : Config에서 가져올 것

        private float _maximumY = 50000;

        private int _selectedDefectIndex = -1;

        public List<DefectInfo> _defectInfos = new List<DefectInfo>();
        #endregion

        #region 속성
        private DoubleBufferedPanel dpnlMapArea { get; set; } = null;

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
            dpnlMapArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };

            _displayArea = GetDisplayArea();
            SelectedDefectChanged += ChangeSelectedDefect;
            dpnlMapArea.Paint += pnlMapArea_Paint;
            Controls.Add(dpnlMapArea);
        }

        public void Clear()
        {
            MaximumY = 0;
            _defectInfos.Clear();
            dpnlMapArea.Invalidate();
        }

        private RectangleF GetDisplayArea()
        {
            return new RectangleF(new PointF(dpnlMapArea.Left + 70, dpnlMapArea.Top + 20), new SizeF(dpnlMapArea.DisplayRectangle.Width - 90, dpnlMapArea.DisplayRectangle.Height - 60));
        }

        private void DrawDefectShape(Graphics g, DefectInfo defectInfo)
        {
            var coord = GetScaledLocation(defectInfo.Coord, ImageMaxWidth: 16383);

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
            if (defectInfo.Coord.Y + defectInfo.Size.Height > MaximumY)
                MaximumY = defectInfo.Coord.Y + defectInfo.Size.Height;
        }

        public void AddCoordinate(List<DefectInfo> defectInfos)
        {
            defectInfos.ForEach(defectInfo => AddCoordinate(defectInfo));
        }

        private PointF GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/)
        {
            return new PointF
            {
                X = Convert.ToSingle(_displayArea.Left + coordinates.X * ((_displayArea.Width - 9f) / ImageMaxWidth) + 1f),
                Y = Convert.ToSingle(_displayArea.Top + _displayArea.Height - (coordinates.Y * _displayArea.Height / MaximumY)),
            };
        }

        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            dpnlMapArea.SuspendLayout();
            var graphics = e.Graphics;
            graphics.TranslateTransform(dpnlMapArea.AutoScrollPosition.X, dpnlMapArea.AutoScrollPosition.Y);

            _displayArea = GetDisplayArea();
            DrawSideLines(graphics);
            DrawGridAndLength(graphics);
            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(graphics, defectInfo);
            dpnlMapArea.ResumeLayout(true);
        }

        private void DrawGridAndLength(Graphics g)
        {
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
                int drawingHeight = (int)(count * (_displayArea.Height / 10)) + (int)_displayArea.Top;

                g.DrawLine(dashPen, new Point((int)_displayArea.Left, drawingHeight), new Point((int)_displayArea.Left + (int)_displayArea.Width, drawingHeight));
                g.DrawString($"{((maximumHeight - (count * gridMargin)) * _pixelResolution) / 1000:N2}m", stringFont, Brushes.White, new PointF(5, drawingHeight - Font.Size / 2));
            }
        }

        private void DrawSideLines(Graphics g)
        {
            Pen sideLinePen = new Pen(Color.FromArgb(208, 208, 208))
            {
                Width = 5,
                StartCap = LineCap.ArrowAnchor
            };
            g.DrawLine(sideLinePen, new Point((int)_displayArea.Left, 5), new Point((int)_displayArea.Left, Height));
            g.DrawLine(sideLinePen, new Point((int)_displayArea.Right, 5), new Point((int)_displayArea.Right, Height));
        }

        private void ChangeSelectedDefect(int index)
        { 
            _selectedDefectIndex = index;
        }
        #endregion
    }
}
