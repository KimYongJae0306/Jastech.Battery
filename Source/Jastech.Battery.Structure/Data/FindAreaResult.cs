using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Jastech.Battery.Structure.Data
{
    public class DistanceInspResult
    {

    }

    public class FindAreaResult
    {
        #region 속성
        public List<byte> VerticalSamplingResults { get; set; } = new List<byte>();

        public List<byte> HorizontalSamplingResults { get; set; } = new List<byte>();

        public List<byte> VerticalDifferentials { get; set; } = new List<byte>();

        public List<byte> HorizontalDifferentials { get; set; } = new List<byte>();

        public List<Rectangle> SearchAreas { get; set ; } = new List<Rectangle>();

        public List<SurfaceInfo> CoatingInfoList { get; set; } = new List<SurfaceInfo>();

        public List<SurfaceInfo> NonCoatingInfoList { get; set; } = new List<SurfaceInfo>();
        #endregion
    }

    public class SurfaceInfo
    {
        #region 속성
        public int Lane { get; set; }

        public string Type { get; set; }

        public Rectangle Area { get; set; }

        public double LevelAverage { get; set; }
        #endregion
    }
}
