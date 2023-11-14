using Jastech.Framework.Device.Cameras;
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
        #endregion

        #region 속성
        public Camera Camera { get; private set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public LineCamera(Camera camera)
        {
            Camera = camera;
        }
        #endregion

        #region 메서드
        #endregion
    }
}
