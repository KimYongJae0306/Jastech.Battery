using Jastech.Framework.Structure.Defect;
using System;
using System.Collections.Generic;
using System.Drawing;
using static Jastech.Framework.Structure.Defect.DefectDefine;

namespace Jastech.Battery.Structure.Data
{
    public class ElectrodeDefectInfo : DefectInfo
    {
        #region 속성
        public int Lane { get; set; }

        public SizeF Size => GetSize();

        public PointF Coord => GetCoord();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public override PointF GetCoord() => new PointF(GetFeatureValue(FeatureTypes.X), GetFeatureValue(FeatureTypes.Y));

        public override SizeF GetSize() => new SizeF(GetFeatureValue(FeatureTypes.Width), GetFeatureValue(FeatureTypes.Height));
        #endregion
    }
}