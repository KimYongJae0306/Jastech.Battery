using Jastech.Framework.Winform.Controls;
using Jastech.Framework.Winform.Data;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class GLDrawBoxControl : UserControl
    {

        private readonly Color _selectedColor = Color.FromArgb(104, 104, 104);

        private readonly Color _nonSelectedColor = Color.FromArgb(52, 52, 52);
        public DisplayMode DisplayMode { get; set; } = DisplayMode.None;
        public object _lock = new object();

        private double ZoomScale { get; set; } = 1.0;

        private double OffsetX { get; set; } = 0.0;

        private double OffsetY { get; set; } = 0.0;

        GLControl glDisplay { get; set; } = null;

        public Bitmap OrgImage { get; set; } = null;

        private int ImageWidth { get; set; } = 0;

        private int ImageHeight { get; set; } = 0;

        public GLDrawBoxControl()
        {
            InitializeComponent();
        }

        private void GLDrawBoxControl_Load(object sender, EventArgs e)
        {
            glDisplay = new GLControl();
            glDisplay.BackColor = Color.FromArgb(26,255,26);
            glDisplay.Dock = DockStyle.Fill;
            glDisplay.Paint += glDisplay_Paint;
            glDisplay.MouseWheel += glDisplay_MouseWheel;
            pnlDisplay.Controls.Add(glDisplay);

            GL.ClearColor(Color.Red);
        }

        private void glDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
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
                DrawTexture(textureID);
                glDisplay.SwapBuffers();
            }
        }

        private void UpdateViewPort()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            float widthScaleFactor = 2f;
            float heightScaleFactor = 2f;
            float testWidth = DisplayRectangle.Width * widthScaleFactor;
            float testHeight = DisplayRectangle.Height * heightScaleFactor;

            float testX = 0 - DisplayRectangle.Width;
            float testY = 0 - DisplayRectangle.Y;

            RectangleF viewRect = new RectangleF(testX, testY, testWidth, testHeight);
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

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(
                left: 1,
                bottom: 1,
                right: 1,
                top: 1,
                zNear: -1,
                zFar: 1);
            GL.PushMatrix();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.TexCoord2(1, 0); GL.Vertex2(1, 0);
            GL.TexCoord2(1, 1); GL.Vertex2(1, -1);
            GL.TexCoord2(0, 1); GL.Vertex2(0, -1);
            GL.End();

            GL.Disable(EnableCap.Texture2D);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);

            GL.DeleteTexture(textureID);
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

        public void DisableFunctionButtons() { }
        public void EnableInteractive(bool temp) { }
        public void FitZoom() { }

        private void ctxDisplayMode_Opening(object sender, CancelEventArgs e)
        {
            MenuStripSelectedNone();
            //if (DisplayMode == DisplayMode.None)
            //{
            //    menuPointerMode.Checked = true;
            //}
            //else if (DisplayMode == DisplayMode.Panning)
            //{
            //    menuPanningMode.Checked = true;
            //}
            //else if (DisplayMode == DisplayMode.Drawing)
            //{
            //    menuROIMode.Checked = true;
            //}
        }

        private void MenuStripSelectedNone()
        {
            //menuPointerMode.Checked = false;
            //menuPanningMode.Checked = false;
            //menuROIMode.Checked = false;
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
    }
}
