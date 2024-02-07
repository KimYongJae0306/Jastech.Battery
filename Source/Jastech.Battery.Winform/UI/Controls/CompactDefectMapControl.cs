﻿using Jastech.Battery.Structure.Data;
using Jastech.Framework.Winform.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Jastech.Battery.Structure.Data.DefectDefine;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class CompactDefectMapControl : UserControl
    {
        #region 필드
        private RectangleF DisplayArea;
        private DoubleBufferedPanel pnlMapArea = new DoubleBufferedPanel { Dock = DockStyle.Fill };
        #endregion

        #region 속성
        public int maximumMeter = 600;

        public float maximumY { get; set; } = 50000; // TODO: Resolution 참고하여 Meter 단위로 환산, Model에서 가져올 것

        public readonly List<DefectInfo> _defectInfos = new List<DefectInfo>();

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
            pnlMapArea.Paint += pnlMapArea_Paint;
            Controls.Add(pnlMapArea);
        }

        public void Clear()
        {
            _defectInfos.Clear();
            pnlMapArea.CreateGraphics().Clear(Color.FromArgb(52, 52, 52));
            Invalidate();
        }

        private RectangleF GetDisplayArea() => new RectangleF(new PointF(pnlMapArea.Left + 70, pnlMapArea.Top + 20), new SizeF(pnlMapArea.DisplayRectangle.Width - 90, pnlMapArea.DisplayRectangle.Height - 60));

        private void DrawDefectShape(Graphics g, DefectInfo defectInfo)
        {
            var coord = GetScaledLocation(defectInfo.GetCoord(), 16383);

            var color = Colors[defectInfo.DefectType];
            var brush = new SolidBrush(color);
            var area = new RectangleF(coord.X, coord.Y - 3.5f, 7, 7);

            g.DrawString($"{defectInfo.DefectType}", Font, new SolidBrush(Color.Crimson), new PointF(coord.X + 4.5f, coord.Y + 4.5f));
            g.FillEllipse(brush, area);
        }

        public void AddCoordinates(DefectInfo[] defectInfos)
        {
            pnlMapArea.SuspendLayout();

            _defectInfos.AddRange(defectInfos);     //test code
            foreach (DefectInfo defectInfo in defectInfos)
            {
                var defectCoord = defectInfo.GetCoord();
                var defectSize = defectInfo.GetSize();
                if (defectCoord.Y + defectSize.Height > maximumY)
                    maximumY = defectCoord.Y + defectSize.Height;
            }
            pnlMapArea.Invalidate();
        }

        private PointF GetScaledLocation(PointF coordinates, float ImageMaxWidth /*추후 모델에서 가져올 것*/) => new PointF
        {
            X = Convert.ToSingle(DisplayArea.Left + coordinates.X * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Y = Convert.ToSingle(DisplayArea.Top + DisplayArea.Height - (coordinates.Y * DisplayArea.Height / maximumY)),
        };

        private Size GetScaledSize(Size size, float ImageMaxWidth /*추후 모델에서 가져올 것*/) => new Size
        {
            Width = Convert.ToInt32(size.Width * ((DisplayArea.Width - 9f) / ImageMaxWidth) + 1f),
            Height = Convert.ToInt32(size.Height * (DisplayArea.Height / maximumY)),
        };
        
        private void pnlMapArea_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.FromArgb(52, 52, 52));
            e.Graphics.TranslateTransform(pnlMapArea.AutoScrollPosition.X, pnlMapArea.AutoScrollPosition.Y);
            DisplayArea = GetDisplayArea();

            foreach (var defectInfo in _defectInfos)
                DrawDefectShape(e.Graphics, defectInfo);

            // Drawing Grid and Length
            double maximumHeight = maximumY / 1000;;
            double gridMargin = maximumHeight / 10;
            for (int count = 0; count <= 10; count++)
            {
                int drawingHeight = (int)(count * (DisplayArea.Height / 10)) + (int)DisplayArea.Top;
                var dashPen = new Pen(Color.FromArgb(208, 208, 208))
                {
                    DashStyle = DashStyle.Dash,
                    Width = 0.3f
                };
                e.Graphics.DrawLine(dashPen, new Point((int)DisplayArea.Left, drawingHeight), new Point((int)DisplayArea.Left + (int)DisplayArea.Width, drawingHeight));
                Font stringFont = new Font(Font.FontFamily, 9, FontStyle.Bold);
                e.Graphics.DrawString($"{((maximumHeight - (count * gridMargin)) * PixelResolution) / 1000:N2}m", stringFont, Brushes.White, new PointF(5, drawingHeight - Font.Size / 2));
            }

            //var dispRect = new Rectangle((int)DisplayArea.Left, (int)DisplayArea.Top - 15, (int)DisplayArea.Width, (int)DisplayArea.Height + 30);
            //e.Graphics.DrawRectangle(Pens.White, dispRect);
            Pen sideLinePen = new Pen(Color.FromArgb(208,208,208))
            {
                Width = 5,
                StartCap = LineCap.ArrowAnchor
            };
            e.Graphics.DrawLine(sideLinePen, new Point((int)DisplayArea.Left, 5), new Point((int)DisplayArea.Left, Height));
            e.Graphics.DrawLine(sideLinePen, new Point((int)DisplayArea.Right, 5), new Point((int)DisplayArea.Right, Height));

            pnlMapArea.ResumeLayout(true);
        }
        #endregion
    }
}