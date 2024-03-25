using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Jastech.Battery.Structure.Data
{
    public class DistanceInspResult
    {
        #region 속성
        public bool IsCoatingAreaOK { get; set; }

        public bool IsNonCoatingAreaOK { get; set; }

        public List<byte> VerticalSamplingResults { get; set; } = new List<byte>();

        public List<byte> HorizontalSamplingResults { get; set; } = new List<byte>();

        public List<byte> VerticalDifferentials { get; set; } = new List<byte>();

        public List<byte> HorizontalDifferentials { get; set; } = new List<byte>();

        public List<Rectangle> SearchAreas { get; set ; } = new List<Rectangle>();

        public List<Rectangle> CoatingAreas { get; set; } = new List<Rectangle>();

        public List<Rectangle> NonCoatingAreas { get; set; } = new List<Rectangle>();

        ///<summary>코팅 영역의 레벨 평균, 영역별로 저장하여 </summary>
        public List<double> CoatingAreaAverages { get; set; } = new List<double>();

        public List<double> NonCoatingAreaAverages { get; set; } = new List<double>();
        #endregion
    }
}
