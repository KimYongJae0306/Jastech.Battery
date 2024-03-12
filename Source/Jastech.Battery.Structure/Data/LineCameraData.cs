using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class LineCameraData
    {
        #region 속성
        public string Name { get; set; } = string.Empty;

        public int AnalogGain { get; set; } = 1;

        public double DigitalGain { get; set; } = 1.0;
        #endregion

        #region 메서드
        public LineCameraData DeepCopy()
        {
            LineCameraData lineCameraData = new LineCameraData();

            lineCameraData.Name = Name;
            lineCameraData.AnalogGain = AnalogGain;
            lineCameraData.DigitalGain = DigitalGain;

            return lineCameraData;
        }
        #endregion
    }
}
