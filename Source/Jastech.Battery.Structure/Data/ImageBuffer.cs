using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class ImageBuffer
    {
        #region 속성
        public int Index { get; set; }

        public Mat Image { get; set; } = null;

        public byte[] ImageData { get; set; } = null;

        public int Width { get; set; }

        public int Height { get; set; }
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
