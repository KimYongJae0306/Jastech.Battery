using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Winform
{
    public class LineCameraManager
    {
        #region 필드
        private static LineCameraManager _instance = null;
        #endregion

        #region 속성
        private List<LineCamera> CameraList = new List<LineCamera>();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        public static LineCameraManager Instance()
        {
            if (_instance == null)
            {
                _instance = new LineCameraManager();
            }

            return _instance;
        }
        #endregion

        #region 메서드
        #endregion
    }
}
