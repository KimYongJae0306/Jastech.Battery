using System;
using System.Collections.Generic;
using System.Drawing;
using static Jastech.Battery.Structure.Data.DefectDefine;

namespace Jastech.Battery.Structure.Data
{
    public class DefectInfo
    {
        #region 필드
        private readonly Dictionary<FeatureTypes, object> _defectFeatures = new Dictionary<FeatureTypes, object>();

        private readonly Dictionary<FeatureTypes, Type> _defectFeatureDatatypes = new Dictionary<FeatureTypes, Type>();
        #endregion

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
        public PointF GetCoord() => new PointF(GetFeatureValue(FeatureTypes.X), GetFeatureValue(FeatureTypes.Y));

        public SizeF GetSize() => new SizeF(GetFeatureValue(FeatureTypes.Width), GetFeatureValue(FeatureTypes.Height));

        public dynamic GetFeatureValue(FeatureTypes featureType)
        {
            var result = ConvertFeature(_defectFeatures[featureType], _defectFeatureDatatypes[featureType]);
            if (result is bool && result == false)
                return null;
            return result;
        }

        public void SetFeatureValue(FeatureTypes featureType, object value)
        {
            _defectFeatures[featureType] = value;
        }

        public void SetFeatureDataType(FeatureTypes featureType, Type value)
        {
            _defectFeatureDatatypes[featureType] = value;
        }
        #endregion
    }
}