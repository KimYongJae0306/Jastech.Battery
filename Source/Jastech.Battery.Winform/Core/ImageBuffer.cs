using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Winform.Core
{
    public class ImageBuffer
    {
        #region 속성
        public int Index { get; set; }

        public Mat Image { get; set; } = null;
        #endregion

        #region 메서드
        public void Dispose()
        {
            Image?.Dispose();
            Image = null;
        }
        #endregion
    }
}
