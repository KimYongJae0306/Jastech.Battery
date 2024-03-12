using Jastech.Framework.Device.LightCtrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class Unit
    {
        #region 속성
        public string Name { get; set; } = string.Empty;

        public LineCameraData CameraData { get; set; } = null;

        public LightParameter LightParam { get; set; } = null;
        #endregion

        #region 메서드
        public Unit DeepCopy()
        {
            Unit unit = new Unit();

            unit.Name = Name;
            unit.CameraData = CameraData?.DeepCopy();
            unit.LightParam = LightParam?.DeepCopy();

            return unit;
        }

        public LineCameraData GetLineCameraData(string name)
        {
            if (CameraData != null)
            {
                if (CameraData.Name == name)
                    return CameraData;
            }

            return null;
        }
        #endregion
    }
}
