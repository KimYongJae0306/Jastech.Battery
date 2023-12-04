using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class MaterialInfo
    {
        #region 속성
        public double PancakeLength_mm { get; set; } = 1500;

        public double IgnoreStartGap_mm { get; set; } = 0;

        public int OverlapHeight { get; set; } = 100; // pixel
        #endregion
    }
}
