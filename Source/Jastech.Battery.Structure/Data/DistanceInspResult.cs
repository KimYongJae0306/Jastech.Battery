using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Jastech.Battery.Structure.Data
{
    public class DistanceInspResult
    {
        #region 속성
        public int Index { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public List<byte> VerticalSamplingResults { get; private set; } = new List<byte>();

        public List<byte> HorizontalSamplingResults { get; private set; } = new List<byte>();

        public List<byte> DerivedHorizontalSamplingResults { get; private set; } = new List<byte>();

        public List<Rectangle> CoatingAreas { get; private set; } = new List<Rectangle>();

        public List<Rectangle> NonCoatingAreas { get; private set; } = new List<Rectangle>();

        public Rectangle LargestCoatingArea { get; private set; } = Rectangle.Empty;

        public int ScanStartX { get; set; } = 0;

        public int ScanStartY { get; set; } = 0;

        public int ScanEndX { get; set; } = 0;

        public int ScanEndY { get; set; } = 0;

        #endregion

        #region 메소드
        public bool IsValidScanWidth()
        {
            return ScanStartX < ScanEndX && ScanStartX > 0 && ScanEndX > 0;
        }

        public bool IsValidScanHeight()
        {
            return ScanStartY < ScanEndY && ScanStartY > 0 && ScanEndY > 0;
        }

        public void UpdateLargestCoatingArea()
        {
            LargestCoatingArea = CoatingAreas.Aggregate((maxRect, nextRect) => (maxRect.Width * maxRect.Height >= nextRect.Width * nextRect.Height) ? maxRect : nextRect);
        }
        #endregion
    }
}
