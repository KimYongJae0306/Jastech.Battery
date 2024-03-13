using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class SliceInspResult
    {
        public InspDirection InspDirection { get; set; }

        public DistanceResult DistanceResult { get; set; }

        public bool CoatingVerticalEdgesExist { get; set; } = false;

        public bool CoatingWidthSufficient { get; set; } = false;

        public bool CoatingROIFound { get; set; } = false;
    }

    public class DistanceResult
    {
        public int Index { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public List<byte> VerticalSamplingResults { get; set; } = new List<byte>();

        public List<Rectangle> CoatingAreas { get; private set; } = new List<Rectangle>();

        public Rectangle LargestCoatingArea { get; set; } = Rectangle.Empty;

        public int ScanStartX { get; set; } = 0;

        public int ScanStartY { get; set; } = 0;

        public int ScanEndX { get; set; } = 0;

        public int ScanEndY { get; set; } = 0;

        public bool IsValidScanWidth => ScanStartX < ScanEndX && ScanStartX > 0 && ScanEndX > 0;

        public bool IsValidScanHeight => ScanStartY < ScanEndY && ScanStartY > 0 && ScanEndY > 0;
    }
}
