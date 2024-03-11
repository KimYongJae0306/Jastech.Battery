using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class SliceInspResult
    {
        public InspDirection InspDirection { get; set; }

        public DistanceResult DistanceResult { get; set; }

        public bool IsCoating { get; set; } = false;
    }

    public class DistanceResult
    {
        public int Index { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public bool IsWhiteBackGround { get; set; } = false;

        public int FoilStartX { get; set; } = 0;

        public int FoilEndX { get; set; } = 0;
    }
}
