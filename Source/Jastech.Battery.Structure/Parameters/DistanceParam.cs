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
        public int LaneCount { get; set; } = 0;

        public int ROIMarginLeft { get; set; } = 0;

        public int ROIMarginRight { get; set; } = 0;

        public int ROIMarginTop { get; set; } = 0;

        public int ROIMarginBottom { get; set; } = 0;


        public int ROIThreshold { get; set; } = 20;

        public int CoatingThreshold { get; set; } = 20;

        public int NonCoatingThreshold { get; set; } = 20;

        public double CoatingMinimumLength { get; set; } = 400.0;

        public double CoatingMinimumWidth { get; set; } = 280.0;

        public double CoatingMaximumWidth { get; set; } = 320.0;

        public double NonCoatingMinimumWidth { get; set; } = 5.0;

        public double NonCoatingMaximumWidth { get; set; } = 50.0;


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
