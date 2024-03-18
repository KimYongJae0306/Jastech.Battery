using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class SurfaceInspResult
    {
        #region 필드
        #endregion

        #region 속성
        public bool IsConnectionTape { get; set; } = false;

        public Rectangle ConnectionTapeArea { get; set; } = new Rectangle();

        public List<int> CoatingAverageLevel { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

    }

    public class BlobContourResult
    {
        #region 필드
        #endregion

        #region 속성
        public int Left { get; set; } = 0;

        public int Top { get; set; } = 0;

        public int Right { get; set; } = 0;

        public int Bottom { get; set; } = 0;

        public int PixelCount { get; set; } = 0;

        public List<Point> ContourPointList { get; set; } = new List<Point>();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion
    }
}
