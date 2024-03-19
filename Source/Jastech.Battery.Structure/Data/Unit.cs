using Emgu.CV.Alphamat;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Structure;
using Newtonsoft.Json;
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

        public DistanceParam UpperDistanceParam { get; set; } = new DistanceParam();

        public DistanceParam LowerDistanceParam { get; set; } = new DistanceParam();

        public SurfaceParam SurfaceParam { get; set; } = new SurfaceParam();
        #endregion

        #region 메서드
        public void Dispose()
        {
            // TODO : Disposing Image buffers, Device handles
        }

        public Unit DeepCopy()
        {
            Unit unit = new Unit();

            unit.Name = Name;
            unit.CameraData = CameraData?.DeepCopy();
            unit.LightParam = LightParam?.DeepCopy();
            unit.UpperDistanceParam = UpperDistanceParam?.DeepCopy();
            unit.LowerDistanceParam = LowerDistanceParam?.DeepCopy();
            unit.SurfaceParam = SurfaceParam?.DeepCopy();

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
