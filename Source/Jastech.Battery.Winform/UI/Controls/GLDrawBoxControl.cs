using Jastech.Framework.Winform.Controls;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class GLDrawBoxControl : UserControl
    {

        #region 필드
        private readonly Color _selectedColor = Color.FromArgb(104, 104, 104);

        private readonly Color _nonSelectedColor = Color.FromArgb(52, 52, 52);

        public object _lock = new object();
        #endregion

        #region 속성
        private PointF PanningStartPoint = new PointF();

        private Point MouseLocation = new Point();

        public DisplayMode DisplayMode { get; set; } = DisplayMode.None;

        private float ZoomScale { get; set; } = 1.0f;

        private float OffsetX { get; set; } = 0f;

        private float OffsetY { get; set; } = 0f;

        GLControl glDisplay { get; set; } = null;

        public Bitmap OrgImage { get; set; } = null;

        private int ImageWidth { get; set; } = 0;

        private int ImageHeight { get; set; } = 0;
        #endregion

        #region 생성자
        public GLDrawBoxControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드

        private void GLDrawBoxControl_Load(object sender, EventArgs e)
        {
            glDisplay = new GLControl();
            glDisplay.BackColor = Color.FromArgb(52, 52, 52);
            glDisplay.Dock = DockStyle.Fill;
            glDisplay.Paint += glDisplay_Paint;
            glDisplay.MouseWheel += glDisplay_MouseWheel;
            glDisplay.MouseMove += glDisplay_MouseMove;
            glDisplay.MouseDown += glDisplay_MouseDown;
            glDisplay.DoubleClick += glDisplay_DoubleClick;
            pnlDisplay.Controls.Add(glDisplay);

            GL.ClearColor(Color.FromArgb(26,26,26));
        }

        private void glDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            double calcX = (e.X) - OffsetX;
            double calcY = (e.Y) - OffsetY;
            PointF calcPoint = new PointF((float)calcX, (float)calcY);
            PanningStartPoint = calcPoint;
        }

        private void glDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                if (DisplayMode == DisplayMode.Panning)
                {
                    OffsetX = e.X - PanningStartPoint.X;
                    OffsetY = e.Y - PanningStartPoint.Y;
                }
                glDisplay.Invalidate();
            }
        }

        private void glDisplay_DoubleClick(object sender, EventArgs e)
        {
            FitZoom();
        }

        private void glDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            var zoomAmount = e.Delta * (float)Math.Sqrt(Math.Abs(e.Delta)) / 10000;
            if (ZoomScale + zoomAmount > 0)
                ZoomScale += zoomAmount;

            //PointF glControlCenter = new PointF(0,0);
            //OffsetX = e.X - glControlCenter.X * ZoomScale;
            //OffsetY = e.Y - glControlCenter.Y * ZoomScale;

            glDisplay.Invalidate();
        }

        private void glDisplay_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock)
            {
                if (OrgImage == null)
                    return;

                glDisplay.MakeCurrent();
                UpdateViewPort();
                GetTexture(out int textureID);
                SetTranslatedModelView();
                SetOrthographicalProjection();
                DrawTexture(textureID);
                glDisplay.SwapBuffers();
            }
        }

        private void UpdateViewPort()
        {
            RectangleF viewRect = new RectangleF(0, 0, glDisplay.Width, glDisplay.Height);
            GL.Viewport(Rectangle.Round(viewRect));
        }

        private void GetTexture(out int textureID)
        {
            BitmapData bmpData = OrgImage.LockBits(
                rect: new Rectangle(0, 0, ImageWidth, ImageHeight),
                flags: ImageLockMode.ReadOnly,
                format: System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            GL.TexImage2D(
                target: TextureTarget.Texture2D,
                level: 0,
                internalformat: PixelInternalFormat.Luminance,
                width: ImageWidth,
                height: ImageHeight,
                border: 0,
                format: OpenTK.Graphics.OpenGL.PixelFormat.Luminance,
                type: PixelType.UnsignedByte,
                pixels: bmpData.Scan0);
            OrgImage.UnlockBits(bmpData);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        }

        private void DrawTexture(int textureID)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.Begin(PrimitiveType.Quads);

            PlaceVertex(new Point(0, 0), new Point(0, 0));
            PlaceVertex(new Point(1, 0), new Point(glDisplay.Width, 0));
            PlaceVertex(new Point(1, 1), new Point(glDisplay.Width, glDisplay.Height));
            PlaceVertex(new Point(0, 1), new Point(0, glDisplay.Height));

            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.DeleteTexture(textureID);
        }

        private static void PlaceVertex(Point textureCoord, Point vertextCoord)
        {
            GL.TexCoord2(textureCoord.X, textureCoord.Y);
            GL.Vertex2(vertextCoord.X, vertextCoord.Y);
        }

        private void SetOrthographicalProjection()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(
                left: 0,
                right: glDisplay.Width,
                bottom: 0,
                top: glDisplay.Height,
                zNear: -1,
                zFar: 1);
        }

        private void SetTranslatedModelView()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 translationCenter = Matrix4.CreateTranslation(MouseLocation.X, -MouseLocation.Y , 0);
            Matrix4 scale = Matrix4.CreateScale(ZoomScale, ZoomScale, 0);
            Matrix4 translationOriginal = Matrix4.CreateTranslation(-MouseLocation.X, MouseLocation.Y, 0);
            Matrix4 translationToOffset = Matrix4.CreateTranslation(0, 0, 0);

            Matrix4 modelViewMatrix = translationCenter * scale * translationOriginal * translationToOffset;
            GL.LoadMatrix(ref modelViewMatrix);
        }

        public void SetImage(Bitmap bmp, bool dataDispose = true)
        {
            lock (_lock)
            {
                if (bmp == null)
                {
                    ImageWidth = 0;
                    ImageHeight = 0;
                    return;
                }
                if (dataDispose == true && OrgImage != null)
                {
                    OrgImage.Dispose();
                    OrgImage = null;
                }

                OrgImage = bmp;
                ImageWidth = bmp.Width;
                ImageHeight = bmp.Height;
            }

            glDisplay.Invalidate();
        }

        public void DisableFunctionButtons()
        {
            tableLayoutPanel3.Controls.Remove(tableLayoutPanel4);
            tableLayoutPanel3.ColumnStyles.RemoveAt(0);
            tableLayoutPanel3.ColumnCount--;

            tableLayoutPanel1.Controls.Remove(pnlText);
            tableLayoutPanel1.RowStyles.RemoveAt(1);
            tableLayoutPanel1.RowCount--;
        }

        public void FitZoom()
        {
            ZoomScale = 1f;
            OffsetX = 0f;
            OffsetY = 0f;
            glDisplay.Invalidate();
        }

        private void ctxDisplayMode_Opening(object sender, CancelEventArgs e)
        {
            MenuStripSelectedNone();
            if (DisplayMode == DisplayMode.None)
                menuPointerMode.Checked = true;
            else if (DisplayMode == DisplayMode.Panning)
                menuPanningMode.Checked = true;
            else if (DisplayMode == DisplayMode.Drawing)
                menuROIMode.Checked = true;
        }

        private void MenuStripSelectedNone()
        {
            menuPointerMode.Checked = false;
            menuPanningMode.Checked = false;
            menuROIMode.Checked = false;
        }

        private void menuPointerMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.None;
            this.Cursor = Cursors.Default;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuPanningMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Panning;
            this.Cursor = Cursors.Hand;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void menuROIMode_Click(object sender, EventArgs e)
        {
            MenuStripSelectedNone();
            DisplayMode = DisplayMode.Drawing;
            this.Cursor = Cursors.Default;
            UpdateDisplayModeUI(DisplayMode);
        }

        private void UpdateDisplayModeUI(DisplayMode mode)
        {
            btnDrawNone.BackColor = _nonSelectedColor;
            btnPanning.BackColor = _nonSelectedColor;
            btnDrawLine.BackColor = _nonSelectedColor;

            if (mode == DisplayMode.None)
            {
                btnDrawNone.BackColor = _selectedColor;
                this.Cursor = Cursors.Default;
            }
            else if (mode == DisplayMode.Panning)
            {
                btnPanning.BackColor = _selectedColor;
                this.Cursor = Cursors.Hand;
            }
            else if (mode == DisplayMode.Drawing)
            {
                btnDrawLine.BackColor = _selectedColor;
                this.Cursor = Cursors.Default;
            }
        }

        private void menuFitZoom_Click(object sender, EventArgs e)
        {
            FitZoom();
        }
        private void menuSaveImage_Click(object sender, EventArgs e)
        {
            if (OrgImage == null)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BMP File(*.bmp)|*.bmp;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OrgImage.Save(dialog.FileName);
            }
        }
        #endregion
    }
}
