using Jastech.Battery.Structure.Data;
using Jastech.Framework.Winform.Controls;
using OpenTK.Graphics;
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

        private float _pixelResolution = 20; // TODO : MaterialInfo에서 가져올 것

        private float _maximumY = 50000;

        private int _selectedDefectIndex = -1;

        private List<DefectInfo> _defectInfos = new List<DefectInfo>();
        #endregion

        #region 속성
        private DoubleBufferedPanel dpnlMapArea { get; set; } = null;

        public int MaximumMeter { get; set; } = 600; // TODO: MaterialInfo에 넣기

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
        } // TODO: MaterialInfo 참고하여 Meter 단위로 환산, Model에서 가져올 것
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
            dpnlMapArea.Paint += dpnlMapArea_Paint;
            dpnlMapArea.MouseClick += dpnlMapArea_MouseClick;
            Controls.Add(dpnlMapArea);
        }

        public void Clear()
        {
            _maximumY = 0;
            _selectedDefectIndex = -1;
            _defectInfos.Clear();
            dpnlMapArea.Invalidate();
        }

        private RectangleF GetDisplayArea()
        {
            (int left, int top, int right, int bottom) margin = (70, 20, 90, 60);
            var location = new PointF(dpnlMapArea.Left + margin.left, dpnlMapArea.Top + margin.top);
            var size = new SizeF(dpnlMapArea.DisplayRectangle.Width - margin.right, dpnlMapArea.DisplayRectangle.Height - margin.bottom);

            return new RectangleF(location, size);
        }

        private void DrawDefectShape(Graphics g, DefectInfo defectInfo)
        {
            var scaledDefectLocation = GetScaledLocation(defectInfo.Coord, ImageMaxWidth: 16384);
            var brush = new SolidBrush(Colors[defectInfo.DefectType]);
            var shapeSize = 7f;
            var shapeArea = new RectangleF(scaledDefectLocation.X, scaledDefectLocation.Y - shapeSize / 2, shapeSize, shapeSize);
            g.FillEllipse(brush, shapeArea);

            if (defectInfo.Index == _selectedDefectIndex)
            {
                var ellipseSize = 13f;
                var ellipseMargin = (ellipseSize - shapeArea.Width) / 2f ;
                Pen dashPen = new Pen(Color.White, 1) { DashStyle = DashStyle.Dash, DashOffset = ellipseMargin };
                g.DrawEllipse(dashPen, shapeArea.X - ellipseMargin, shapeArea.Y - ellipseMargin, ellipseSize, ellipseSize);

                var stringLocation = new PointF(scaledDefectLocation.X + ellipseSize / 2, scaledDefectLocation.Y + ellipseSize / 2);
                g.DrawString($"{defectInfo.DefectType}", base.Font, brush, stringLocation);
            }
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

        private void dpnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            _displayArea = GetDisplayArea();

            dpnlMapArea.SuspendLayout();
            e.Graphics.TranslateTransform(dpnlMapArea.AutoScrollPosition.X, dpnlMapArea.AutoScrollPosition.Y);

            DrawSideLines(e.Graphics);
            DrawGridAndLength(e.Graphics);
            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(e.Graphics, defectInfo);
            dpnlMapArea.ResumeLayout(true);
        }

        private void dpnlMapArea_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var defectInfo in _defectInfos)
            {
                var coord = GetScaledLocation(defectInfo.Coord, ImageMaxWidth: 16384);
                float shapeSize = 7;
                var shapeArea = new RectangleF(coord.X, coord.Y - shapeSize / 2, shapeSize, shapeSize);
                if (shapeArea.Contains(e.Location))
                {
                    SelectedDefectChanged?.Invoke(defectInfo.Index);
                    dpnlMapArea.Invalidate();
                    break;
                }
            }
        }

        private void DrawGridAndLength(Graphics g)
        {
            int gridCount = 10;
            float maximumHeight = MaximumY / 1000;
            float gridMargin = maximumHeight / gridCount;
            var dashPen = new Pen(Color.FromArgb(208, 208, 208))
            {
                DashStyle = DashStyle.Dash,
                Width = 0.3f
            };
            for (int count = 0; count <= gridCount; count++)
            {
                int drawingHeight = (int)(count * (_displayArea.Height / gridCount)) + (int)_displayArea.Top;

                var lineStartLocation = new Point((int)_displayArea.Left, drawingHeight);
                var lineEndLocation = new Point((int)_displayArea.Left + (int)_displayArea.Width, drawingHeight);
                g.DrawLine(dashPen, lineStartLocation, lineEndLocation);

                var stringLocation = new PointF(5, drawingHeight - Font.Size / 2);
                var currentHeight = (maximumHeight - (count * gridMargin)) * _pixelResolution;
                g.DrawString($"{currentHeight / 1000:N2}m", base.Font, Brushes.White, stringLocation);
            }
        }

        private void DrawSideLines(Graphics g)
        {
            Pen sideLinePen = new Pen(Color.FromArgb(208, 208, 208))
            {
                Width = 5,
                StartCap = LineCap.ArrowAnchor
            };

            var horizontalOffset = 5;
            var leftLineStartLocation = new Point((int)_displayArea.Left, horizontalOffset);
            var rightLineStartLocation = new Point((int)_displayArea.Right, horizontalOffset);
            var leftLineEndLocation = new Point((int)_displayArea.Left, Height);
            var rightLineEndLocation = new Point((int)_displayArea.Right, Height);

            g.DrawLine(sideLinePen, leftLineStartLocation, leftLineEndLocation);
            g.DrawLine(sideLinePen, rightLineStartLocation, rightLineEndLocation);
        }

        public void ChangeSelectedDefect(int index)
        { 
            _selectedDefectIndex = index;
            dpnlMapArea.Invalidate();
        }
        #endregion
    }
}
