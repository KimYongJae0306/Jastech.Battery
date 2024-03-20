using Emgu.CV;
using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Imaging.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Winform
{
    public class LineCamera
    {
        #region 필드
        private object _lock { get; set; } = new object();

        private Mat _prevCropMat { get; set; } = null;

        private int _curGrabCount { get; set; } = 0;
        #endregion

        #region 속성
        public Camera Camera { get; private set; } = null;

        public int StartIndex { get; private set; } = 0;

        public int EndIndex { get; private set; } = 0;

        public int OverlapHeight { get; private set; } = 0;

        private Queue<ImageBuffer> ImageBufferQueue { get; set; } = new Queue<ImageBuffer>();
        #endregion

        #region 이벤트
        public event GrabDoneDelegate GrabDoneEventHandler;
        #endregion

        #region 델리게이트
        public delegate void GrabDoneDelegate(Camera camera);
        #endregion

        #region 생성자
        public LineCamera(Camera camera)
        {
            Camera = camera;
        }
        #endregion

        #region 메서드
        public bool InitGrabSettings()
        {
            ClearBuffer();

            AppsInspModel inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;

            if (inspModel == null)
                return false;

            double ignoreStartGap_mm = inspModel.MaterialInfo.IgnoreStartGap_mm;
            double pancakeLength_mm = inspModel.MaterialInfo.PancakeLength_mm;

            if (pancakeLength_mm == 0 || Camera.ImageHeight < inspModel.MaterialInfo.OverlapHeight)
                return false;

            float resolution_mm = (float)(Camera.PixelResolution_um / Camera.LensScale / 1000.0);

            StartIndex = (int)(ignoreStartGap_mm / resolution_mm / Camera.ImageHeight);
            int tempEndIndex = (int)Math.Ceiling(pancakeLength_mm / resolution_mm / Camera.ImageHeight);
            EndIndex = tempEndIndex + ((tempEndIndex - StartIndex) / 2);

            OverlapHeight = inspModel.MaterialInfo.OverlapHeight;

            return true;
        }

        private void ClearBuffer()
        {
            _curGrabCount = 0;

            foreach (var buffer in ImageBufferQueue)
                buffer.Dispose();
            ImageBufferQueue.Clear();
        }

        public void AddSubImage(byte[] data, int grabCount)
        {
            //if (IsLive)
            //{
            //    lock (_lock)
            //        LiveDataQueue.Enqueue(data);
            //}
            //else
            {
                if(StartIndex <= grabCount && grabCount <= EndIndex)
                {
                    Mat image = MatHelper.ByteArrayToMat(data, Camera.ImageWidth, Camera.ImageHeight, 1);
                    AddImageBuffer(image);

                    if(_prevCropMat != null && OverlapHeight != 0)
                    {
                        Mat cropMat = MatHelper.CropRoi(image, new System.Drawing.Rectangle
                        {
                            X = 0,
                            Y = 0,
                            Width = image.Width,
                            Height = OverlapHeight,
                        });

                        Mat mergeMat = new Mat();
                        CvInvoke.VConcat(_prevCropMat, cropMat, mergeMat);

                        AddImageBuffer(mergeMat);

                        cropMat.Dispose();
                        cropMat = null;
                    }

                    _prevCropMat?.Dispose();
                    _prevCropMat = null;
                    _prevCropMat = MatHelper.CropRoi(image, new System.Drawing.Rectangle
                    {
                        X = 0,
                        Y = image.Height - OverlapHeight,
                        Width = image.Width,
                        Height = OverlapHeight,
                    });
                }

                if(grabCount == EndIndex)
                {
                    Camera.Stop();
                    GrabDoneEventHandler?.Invoke(Camera);
                }
            }
        }

        private void AddImageBuffer(Mat image)
        {
            lock (_lock)
            {
                ImageBufferQueue.Enqueue(new ImageBuffer
                {
                    Index = _curGrabCount,
                    Image = image,
                });
                _curGrabCount++;
            }
        }

        public ImageBuffer GetImageBuffer()
        {
            ImageBuffer buffer = null;

            lock (_lock)
                buffer = ImageBufferQueue.Dequeue();

            return buffer;
        }

        public string GetCameraName()
        {
            if (Camera == null)
                return "";

            return Camera.Name;
        }
        #endregion
    }
}
