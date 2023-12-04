using Emgu.CV;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jastech.Battery.Winform
{
    public class LineCameraManager
    {
        #region 필드
        private static LineCameraManager _instance = null;

        private object _objLock { get; set; } = new object();
        #endregion

        #region 속성
        private List<LineCamera> CameraList = new List<LineCamera>();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자

        #endregion

        #region 메서드
        public static LineCameraManager Instance()
        {
            if (_instance == null)
                _instance = new LineCameraManager();

            return _instance;
        }

        public bool Initialize()
        {
            // Program 시작 후 처음 Mat을 할당하면 로딩 시간이 필요
            Mat initialImage = new Mat();
            initialImage.Dispose();

            var cameraCtrlHandler = DeviceManager.Instance().CameraHandler;
            if (cameraCtrlHandler == null)
                return false;

            foreach (var camera in cameraCtrlHandler)
            {
                camera.ImageGrabbed += LinescanImageGrabbed;
                CameraList.Add(new LineCamera(camera));
            }

            return true;
        }

        public void LinescanImageGrabbed(Camera camera)
        {
            if (camera is CameraVirtual)
                return;

            lock (_objLock)
            {
                byte[] data = camera.GetGrabbedImage();
                if (data != null)
                {
                    if (GetLineCamera(camera.Name) is LineCamera lineCamera)
                    {
                        GetLineCamera(camera.Name).AddSubImage(data, camera.GrabCount);
                    }
                }
            }
        }

        public LineCamera GetLineCamera(string cameraName)
        {
            return CameraList.Where(x => x.Camera.Name == cameraName.ToString()).FirstOrDefault();
        }
        #endregion
    }
}
