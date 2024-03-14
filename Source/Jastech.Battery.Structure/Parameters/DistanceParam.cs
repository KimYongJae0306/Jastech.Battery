using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Parameters
{
    public class DistanceParam
    {
        public int LeftScanMargin { get; set; } = 200;

        public int RightScanMargin { get; set; } = 200;

        public int TopScanMargin { get; set; } = 5;

        public int BottomScanMargin { get; set; } = 5;

        public int MinimumFoilLength { get; set; } = 5;
    }
}
