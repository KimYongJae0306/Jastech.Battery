using Jastech.Framework.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Jastech.Battery.Structure.Parameters
{
    public class CoatingParam
    {
        #region 필드
        #endregion

        #region 속성
        public int ImageWidth { get; set; } = 0;

        public int ImageHeight { get; set; } = 0;

        public LineParam LineParam = new LineParam();

        public LineParam LineBlackParam = new LineParam();

        public PinHoleParam PinHoleParam = new PinHoleParam();

        public PinHoleParam PinHoleEdgeParam = new PinHoleParam();

        public DentParam DentParam = new DentParam();

        public DentParam DentEdgeParam = new DentParam();

        public CraterParam CraterParam = new CraterParam();

        public CraterParam CraterEdgeParam = new CraterParam();

        public ScratchParam ScratchWhiteParam = new ScratchParam();

        public ScratchParam ScratchBlackParam = new ScratchParam();

        public TapeParam TapeParam = new TapeParam();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public CoatingParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as CoatingParam;
        }
        #endregion
    }
}
