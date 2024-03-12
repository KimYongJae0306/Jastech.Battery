using Jastech.Framework.Winform.Controls;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
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

        private List<OverlayGraphic> _overlays = new List<OverlayGraphic>();

        private object _lock = new object();
        #endregion

        #region 속성
        private PointF PanningStartPoint = new PointF();

        public DisplayMode DisplayMode { get; set; } = DisplayMode.None;

        private float ZoomScale { get; set; } = 1.0f;

        private float OffsetX { get; set; } = 0f;

        private float OffsetY { get; set; } = 0f;

        GLControl DisplayControl { get; set; } = null;

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
            DisplayControl = new GLControl { Dock = DockStyle.Fill };
            DisplayControl.Paint += DisplayControl_Paint;
            DisplayControl.MouseWheel += DisplayControl_MouseWheel;
            DisplayControl.MouseDown += DisplayControl_MouseDown;
            DisplayControl.MouseMove += DisplayControl_MouseMove;
            pnlDisplay.Controls.Add(DisplayControl);

            GL.ClearColor(Color.FromArgb(26, 26, 26));
        }

        private void DisplayControl_Paint(object sender, PaintEventArgs e)
        {
            lock (_lock)
            {
                if (OrgImage == null)
                    return;

                DisplayControl.MakeCurrent();
                UpdateViewPort();
                SetTranslatedModelView();
                SetOrthographicalProjection();
                GetTexture(out int textureID);
                DrawTexture(textureID);;
                DisplayControl.SwapBuffers();
            }
        }

        public void SetOverlay(List<OverlayGraphic> overlays)
        {
            _overlays = overlays;
        }

        private void DrawOverlay()
        {
            GL.GenFramebuffers(1, out int frameBufferID);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, frameBufferID);

            GL.Color3(255, 0, 0);
            foreach (var overlay in _overlays)
            {
                GL.Begin(PrimitiveType.LineStrip);
                GL.Vertex2(overlay.Start.X, overlay.Start.Y);
                GL.Vertex2(overlay.End.X, overlay.Start.Y);
                GL.Vertex2(overlay.End.X, overlay.End.Y);
                GL.Vertex2(overlay.Start.X, overlay.End.Y);
                GL.End();
            }
            GL.Color3(0, 0, 0);
        }

        private void UpdateViewPort()
        {
            RectangleF viewRect = new RectangleF(0, 0, DisplayControl.Width, DisplayControl.Height);
            GL.Viewport(Rectangle.Round(viewRect));
        }

        private void SetOrthographicalProjection()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(
                left: 0,
                right: DisplayControl.Width,
                bottom: DisplayControl.Height,
                top: 0,
                zNear: -1,
                zFar: 1);
        }

        private void SetTranslatedModelView()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 scale = Matrix4.CreateScale(ZoomScale, ZoomScale, 0);
            Matrix4 translationOffset = Matrix4.CreateTranslation(OffsetX * ZoomScale, OffsetY * ZoomScale, 0);

            Matrix4 modelViewMatrix = scale * translationOffset;
            GL.LoadMatrix(ref modelViewMatrix);
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

            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.Enable(EnableCap.Texture2D);
            GL.Begin(PrimitiveType.Quads);

            PlaceVertex(new Point(0, 0), new Point(0, 0));
            PlaceVertex(new Point(1, 0), new Point(DisplayControl.Width, 0));
            PlaceVertex(new Point(1, 1), new Point(DisplayControl.Width, DisplayControl.Height));
            PlaceVertex(new Point(0, 1), new Point(0, DisplayControl.Height));

            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.DeleteTexture(textureID);
        }

        private static void PlaceVertex(Point textureCoord, Point vertextCoord)
        {
            GL.TexCoord2(textureCoord.X, textureCoord.Y);
            GL.Vertex2(vertextCoord.X, vertextCoord.Y);
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

            DisplayControl.Invalidate();
        }

        public void DisableFunctionButtons()
        {
            tlpMainLayout.Controls.Remove(tlpFunctionButtonsLayout);
            tlpMainLayout.ColumnStyles.RemoveAt(0);
            tlpMainLayout.ColumnCount--;

            tlpDisplayAreaLayout.Controls.Remove(pnlGrayText);
            tlpDisplayAreaLayout.RowStyles.RemoveAt(1);
            tlpDisplayAreaLayout.RowCount--;
        }

        public void FitZoom()
        {
            ZoomScale = 1f;
            OffsetX = 0f;
            OffsetY = 0f;
            DisplayControl.Invalidate();
        }

        private void DisplayControl_MouseWheel(object sender, MouseEventArgs e)
        {
            float imageX = e.X / ZoomScale - OffsetX;
            float imageY = e.Y / ZoomScale - OffsetY;

            var zoomAmount = e.Delta * (float)Math.Sqrt(Math.Abs(e.Delta)) / 10000;
            ZoomScale += zoomAmount;

            const float minimumScale = 0.2f;
            if (ZoomScale < minimumScale)
                ZoomScale = minimumScale;

            OffsetX = e.X / ZoomScale - imageX;
            OffsetY = e.Y / ZoomScale - imageY;

            DisplayControl.Invalidate();
        }

        private void DisplayControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            float imageX = e.X / ZoomScale - OffsetX;
            float imageY = e.Y / ZoomScale - OffsetY;
            PanningStartPoint = new PointF(imageX, imageY);
        }

        private void DisplayControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (DisplayMode == DisplayMode.Panning)
                {
                    OffsetX = e.X / ZoomScale - PanningStartPoint.X;
                    OffsetY = e.Y / ZoomScale - PanningStartPoint.Y;
                }
                DisplayControl.Invalidate();
            }
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

    public class OverlayGraphic
    {
        public Point Start { get; set; }
        
        public Point End { get; set; }

        public OverlayGraphic(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
