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

        public string Judgement { get; set; }       // TODO : String -> Enum OK,NG(진성, 가성)
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