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

        public List<byte> VerticalSamplingResults { get; set; } = new List<byte>();

        public List<byte> HorizontalSamplingResults { get; set; } = new List<byte>();

        public List<byte> VerticalDifferentials { get; set; } = new List<byte>();

        public List<byte> HorizontalDifferentials { get; set; } = new List<byte>();

        public List<Rectangle> CoatingAreas { get; set; } = new List<Rectangle>();

        public List<Rectangle> NonCoatingAreas { get; set; } = new List<Rectangle>();
        #endregion
    }
}
