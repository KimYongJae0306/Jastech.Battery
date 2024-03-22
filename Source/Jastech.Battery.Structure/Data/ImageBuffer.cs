using Emgu.CV;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class ImageBuffer
    {
        #region 속성
        public int Index { get; set; }

        public Mat Image { get; set; } = null;

        public int ImageWidth { get; set; }

        public int ImageHeight { get; set; }

        public byte[] ImageData { get; set; } = null;
        /////////////////////////////////////////////////////////////////

        public byte[] OriginBuffer = null;

        public byte[] BwBuffer = null;

        public byte[] MasterBuffer = null;

        //public byte[] ProjectionWidth = null;

        //public double[] MagnifyFactor = null;

        public double[] HorizontalData = null;

        public double[] VerticalData = null;

        public double[] AverageHorizontalData = null;

        public double[] AverageVerticalData = null;

        public double[] DifferentialHorizontalData = null;

        public double[] DifferentiaVerticalData = null;

        public WorkBuffer WorkBuffer { get; private set; } = null;

        public SmallBuffer SmallBuffer { get; private set; } = null;

        public BufferType bufferType { get; set; } = BufferType.None;
        #endregion

        #region 메서드
        public void InitializeWorkBuffer(byte[] imageData, int buffWidth, int buffHeight)
        {
            if (imageData == null || buffWidth < 1 || buffHeight < 1)
                return;

            if (OriginBuffer == null)
            {
                OriginBuffer = new byte[buffWidth * buffHeight];
                BwBuffer = new byte[buffWidth * buffHeight];
                MasterBuffer = new byte[buffWidth * buffHeight];

                //ProjectionWidth = new byte[buffWidth];
                //MagnifyFactor = new double[buffWidth];

                HorizontalData = new double[buffWidth];
                VerticalData = new double[buffHeight];

                AverageHorizontalData = new double[buffWidth];
                AverageVerticalData = new double[buffHeight];

                DifferentialHorizontalData = new double[buffWidth];
                DifferentiaVerticalData = new double[buffHeight];
            }
            else
            {
                if (buffWidth != ImageWidth || buffHeight != ImageHeight)
                {
                    Array.Resize(ref OriginBuffer, buffWidth * buffHeight);
                    Array.Resize(ref BwBuffer, buffWidth * buffHeight);
                    Array.Resize(ref MasterBuffer, buffWidth * buffHeight);

                    //Array.Resize(ref ProjectionWidth, buffWidth);
                    //Array.Resize(ref MagnifyFactor, buffWidth);

                    Array.Resize(ref HorizontalData, buffWidth);
                    Array.Resize(ref VerticalData, buffHeight);

                    Array.Resize(ref AverageHorizontalData, buffWidth);
                    Array.Resize(ref AverageVerticalData, buffHeight);

                    Array.Resize(ref DifferentialHorizontalData, buffWidth);
                    Array.Resize(ref DifferentiaVerticalData, buffHeight);
                }
            }

        }

        public void Dispose()
        {
            Image?.Dispose();
            Image = null;

            WorkBuffer?.Dispose();
            WorkBuffer = null;

            SmallBuffer?.Dispose();
            SmallBuffer = null;
        }
        #endregion
    }

    public class SmallBuffer
    {
        public byte[] OriginBuffer = null;

        //public byte[] StretchBuffer = null;

        //public byte[] MagnifiedBuffer = null;

        //public byte[] BwBuffer = null;

        public byte[] AverageBuffer = null;

        public byte[] DifferentialBuffer = null;

        public int BufferWidth = 0;

        public int BufferHeight = 0;

        public void InitializeSmallBuffer(byte[] imageData, int imageWidth, int imageHeight, int smallRatioX, int smallRatioY)
        {
            int buffWidth = imageWidth / smallRatioX;
            int buffHeight = imageHeight / smallRatioY;

            if (OriginBuffer != null)
            {
                OriginBuffer = new byte[buffWidth * buffHeight];
                //StretchBuffer = new byte[buffWidth * buffHeight];
                //MagnifiedBuffer = new byte[buffWidth * buffHeight];
                //BwBuffer = new byte[buffWidth * buffHeight];
                AverageBuffer = new byte[buffWidth * buffHeight];
                DifferentialBuffer = new byte[buffWidth * buffHeight];
            }
            else
            {
                if (buffWidth != BufferWidth || buffHeight != BufferHeight)
                {
                    Array.Resize(ref OriginBuffer, buffWidth * buffHeight);
                    //Array.Resize(ref StretchBuffer, buffWidth * buffHeight);
                    //Array.Resize(ref MagnifiedBuffer, buffWidth * buffHeight);
                    //Array.Resize(ref BwBuffer, buffWidth * buffHeight);
                    Array.Resize(ref AverageBuffer, buffWidth * buffHeight);
                    Array.Resize(ref DifferentialBuffer, buffWidth * buffHeight);
                }
            }

            BufferWidth = buffWidth;
            BufferHeight = buffHeight;

            ClearBuffer();
        }

        private void ClearBuffer()
        {
            Array.Clear(OriginBuffer, 0, BufferWidth * BufferHeight);
            //Array.Clear(StretchBuffer, 0, BufferWidth * BufferHeight);
            //Array.Clear(MagnifiedBuffer, 0, BufferWidth * BufferHeight);
            //Array.Clear(BwBuffer, 0, BufferWidth * BufferHeight);
            Array.Clear(AverageBuffer, 0, BufferWidth * BufferHeight);
            Array.Clear(DifferentialBuffer, 0, BufferWidth * BufferHeight);
        }

        public void Dispose()
        {
            OriginBuffer = null;
            //StretchBuffer = null;
            //MagnifiedBuffer = null;
            //BwBuffer = null;
            AverageBuffer = null;
            DifferentialBuffer = null;
        }
    }

    public class WorkBuffer
    {
        public byte[] OriginBuffer = null;

        public byte[] BwBuffer = null;

        public byte[] StrecthBuffer = null;

        public byte[] MagnifiedBuffer = null;

        //public byte[] AverageBuffer = null;

        //public byte[] DifferentialBuffer = null;

        public int BuffWidth = 0;

        public int BuffHeight = 0;

        public Rectangle WorkArea { get; set; } = new Rectangle();

        public int WorkRatioX { get; set; } = 1;

        public int WorkRatioY { get; set; } = 1;

        public void SetWorkBuffer(byte[] imageData, int imageWidth, Rectangle workRect, int workRatioX, int workRatioY)
        {
            int buffWidth = workRect.Width / workRatioX;
            int buffHeight = workRect.Height / workRatioY;

            if (BuffWidth < 1 || BuffHeight < 1)
                return;

            if (OriginBuffer == null)
            {
                OriginBuffer = new byte[buffWidth * buffHeight];
                StrecthBuffer = new byte[buffWidth * buffHeight];
                MagnifiedBuffer = new byte[buffWidth * buffHeight];
                BwBuffer = new byte[buffWidth * buffHeight];
                //AverageBuffer = new byte[buffWidth * buffHeight];
                //DifferentialBuffer = new byte[buffWidth * buffHeight];
            }
            else
            {
                if (buffWidth != BuffWidth || buffHeight != BuffHeight)
                {
                    Array.Resize(ref OriginBuffer, buffWidth * buffHeight);
                    Array.Resize(ref StrecthBuffer, buffWidth * buffHeight);
                    Array.Resize(ref MagnifiedBuffer, buffWidth * buffHeight);
                    Array.Resize(ref BwBuffer, buffWidth * buffHeight);
                    //Array.Resize(ref AverageBuffer, buffWidth * buffHeight);
                    //Array.Resize(ref DifferentialBuffer, buffWidth * buffHeight);
                }
            }

            BuffWidth = buffWidth;
            BuffHeight = buffHeight;
            WorkArea = workRect;

            WorkRatioX = workRatioX;
            WorkRatioY = workRatioY;

            for (int h = 0; h < buffHeight; h++)
            {
                int y = WorkArea.Top + h * workRatioY;

                for (int w = 0; w < buffWidth; w++)
                {
                    int x = WorkArea.Left + w * workRatioX;

                    OriginBuffer[h * BuffWidth + w] = imageData[y * imageWidth + x];
                }
            }

            return;
        }

        public byte[] GetWorkBuffer()
        {
            if (OriginBuffer == null)
                return null;

            return OriginBuffer;
        }

        private void ClearBuffer()
        {
            Array.Clear(OriginBuffer, 0, BuffWidth * BuffHeight);
            Array.Clear(StrecthBuffer, 0, BuffWidth * BuffHeight);
            Array.Clear(MagnifiedBuffer, 0, BuffWidth * BuffHeight);
            Array.Clear(BwBuffer, 0, BuffWidth * BuffHeight);
            //Array.Clear(AverageBuffer, 0, BuffWidth * BuffHeight);
            //Array.Clear(DifferentialBuffer, 0, BuffWidth * BuffHeight);
        }

        public void Dispose()
        {
            OriginBuffer = null;
            StrecthBuffer = null;
            MagnifiedBuffer = null;
            BwBuffer = null;
            //AverageBuffer = null;
            //DifferentialBuffer = null;
        }

        //public byte[] GetFilledOriginBuffer(Rectangle inputRect, int fillValue)
        //{
        //    return ShapeHelper.FillValue(OriginBuffer, BuffWidth, inputRect, fillValue);
        //}

        //public byte[] GetFillStretchBuffer(Rectangle inputRect, int fillValue)
        //{
        //    return ShapeHelper.FillValue(StrecthBuffer, BuffWidth, inputRect, fillValue);
        //}

        //public byte[] GetFillMagnifiedBuffer(Rectangle inputRect, int fillValue)
        //{
        //    return ShapeHelper.FillValue(MagnifiedBuffer, BuffWidth, inputRect, fillValue);
        //}

        //public byte[] GetFillBwBuffer(Rectangle inputRect, int fillValue)
        //{
        //    return ShapeHelper.FillValue(BwBuffer, BuffWidth, inputRect, fillValue);
        //}

        public byte[] GetFilledBuffer(BufferType workBufferType, Rectangle inputRect, int fillValue)
        {
            switch (workBufferType)
            {
                case BufferType.None:
                    return null;

                case BufferType.Origin:
                    return ShapeHelper.FillValue(OriginBuffer, BuffWidth, inputRect, fillValue);

                case BufferType.Stretch:
                    return ShapeHelper.FillValue(StrecthBuffer, BuffWidth, inputRect, fillValue);

                case BufferType.Magnify:
                    return ShapeHelper.FillValue(MagnifiedBuffer, BuffWidth, inputRect, fillValue);

                case BufferType.BW:
                    return ShapeHelper.FillValue(BwBuffer, BuffWidth, inputRect, fillValue);

                case BufferType.Average:
                    return null;

                case BufferType.Differential:
                    return null;

                default:
                    return null;
            }
        }

        
    }

    public enum BufferType
    {
        None,
        Origin,
        Stretch,
        Magnify,
        BW,
        Average,
        Differential,
    }
}
