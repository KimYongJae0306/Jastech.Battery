using Jastech.Framework.Util.Helper;
using System.Drawing;

namespace Jastech.Battery.Structure.Parameters
{
    public class FindAreaParam
    {
        #region 필드
        public Rectangle _Roi = Rectangle.Empty;
        #endregion

        #region 속성
        public int LaneCount { get; set; } = 1;

        public int ROIThreshold { get; set; } = 50;

        #region 2024.03.26 + 안쓸 것 같음, 삭제 대기
        public int ROIMarginLeft { get; set; } = 0;

        public int ROIMarginRight { get; set; } = 0;

        public int ROIMarginTop { get; set; } = 0;

        public int ROIMarginBottom { get; set; } = 0;
        #endregion


        public int CoatingThreshold { get; set; } = 30;

        public double CoatingLengthMin { get; set; } = 10.0;

        public double CoatingWidthMin { get; set; } = 280.0;

        public double CoatingWidthMax { get; set; } = 310.0;

        public int NonCoatingThreshold { get; set; } = 30;

        public double NonCoatingWidthMin { get; set; } = 15.0;

        public double NonCoatingWidthMax { get; set; } = 50.0;


        public int WidthSamplingScale { get; set; } = 100;

        public int HeightSamplingScale { get; set; } = 100;

        /// <summary>Slitting 후 좌측 전극이 없는 이미지에서 사용</summary>
        public bool LeftElectrodeSlitted { get; set; } = false;

        /// <summary>Slitting 후 우측 전극이 없는 이미지에서 사용</summary>
        public bool RightElectrodeSlitted { get; set; } = false;
        #endregion

        #region 메서드
        public FindAreaParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as FindAreaParam;
        }
        #endregion
    }
}
