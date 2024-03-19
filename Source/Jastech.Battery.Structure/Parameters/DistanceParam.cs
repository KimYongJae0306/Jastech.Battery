using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Parameters
{
    public class DistanceParam
    {
        #region 속성
        public int ROIMarginLeft { get; set; } = 0;

        public int ROIMarginRight { get; set; } = 0;

        public int ROIMarginTop { get; set; } = 0;

        public int ROIMarginBottom { get; set; } = 0;


        public int CoatingThreshold { get; set; } = 40;

        public int CoatingMinimumSize { get; set; } = 5;

        public int CoatingMaximumSize { get; set; } = 10;

        public int NonCoatingThreshold { get; set; } = 40;

        public int NonCoatingMinimumSize { get; set; } = 5;

        public int NonCoatingMaximumSize { get; set; } = 10;


        public int WidthSamplingScale { get; set; } = 300;

        public int HeightSamplingScale { get; set; } = 300;
        #endregion

        #region 메서드
        public DistanceParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as DistanceParam;
        }
        #endregion
    }
}
