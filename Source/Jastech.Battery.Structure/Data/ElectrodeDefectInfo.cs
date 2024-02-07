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
        public DateTime InspectionTime { get; set; }

        public int Index { get; set; }

        public DefectTypes DefectType { get; set; }

        public int Lane { get; set; }

        public string CameraName { get; set; }

        public PointF Coord => GetCoord();

        public SizeF Size => GetSize();

        public int DefectLevel { get; set; }

        public string Judgement { get; set; }

        public int Data1 { get; set; } = 1;
        public int Data2 { get; set; } = 0;
        public int Data3 { get; set; } = 1;
        public int Data4 { get; set; } = 0;
        public int Data5 { get; set; } = 10;
        public int Data6 { get; set; } = 5;
        public int Data7 { get; set; } = 10;
        public int Data8 { get; set; } = 0;
        public int Data9 { get; set; } = 1;
        public int Data10 { get; set; } = 1;
        public int Data11 { get; set; } = 1;
        public int Data12 { get; set; } = 1;
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