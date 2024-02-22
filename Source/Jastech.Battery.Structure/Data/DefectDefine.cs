using System;
using System.Collections.Generic;
using System.Drawing;

namespace Jastech.Battery.Structure.Data
{
    public static class DefectDefine
    {
        #region 필드
        public static Dictionary<DefectTypes, Color> Colors = new Dictionary<DefectTypes, Color>    // TODO : Json File I/O 확인 (Load, Save)
        {
            { DefectTypes.Undefined, Color.Red },
            // 표면 형상계 (극판)
            { DefectTypes.Pinhole, Color.DodgerBlue},
            { DefectTypes.Crater, Color.LightCoral},
            { DefectTypes.Dent, Color.White},
            { DefectTypes.Island, Color.Orange},
            { DefectTypes.Drag, Color.Lime},
            { DefectTypes.Mismatch, Color.Red},
        };
        #endregion

        #region 열거자
        [Flags]
        public enum DefectJudge
        {
            None = 0,
            Good = 1 << 1,
            NG = 1 << 2,
            Acceptable = 1 << 3,
            Passed = 1 << 4,
        }

        public enum FeatureTypes        // TODO : DefectInfo Feature Dictionary와 함께 정리
        {
            X,                      // X좌표
            Y,                      // Y좌표
            Width,                  // 너비
            Height,                 // 높이
            Area,                   // 면적
            Circularity,            // 원형도
            Eccentricity,           // 편심도
            Brightness,             // 밝기
            AspectRatio,            // 종횡비
            Elongation,             // 연장도
            Solidity,               // 결속도
            NeighborPixels,         // 인접 픽셀
            Kurtosis,               // 분포 첨도
            EdgeDensity,            // 가장자리 밀도
            Compactness,            // 조밀도
            Skewness,               // 비대칭도
            Gabor,                  // Gabor 기반 질감
            Fourier,                // 푸리에 변환
            Wavelet,                // 웨이블릿 변환
            IntensityHistogram,     // GrayLevel 히스토그램
            ColorHistogram,         // Channel별 히스토그램(Color 이미지일 때)

            LocalImagePath,
        }

        public enum DefectTypes
        {
            Undefined,
            Pinhole,
            Crater,
            Dent,
            Island,
            Drag,
            Mismatch,
        }
        #endregion

        #region 메서드
        public static dynamic ConvertFeature(object value, Type type)
        {
            dynamic result = null;
            try
            {
                result = Convert.ChangeType(value, type);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine($"GetFeatureValue({value}, {type}) => Trying Invalid Cast, Check the datatype");
                return false;
            }

            return result;
        }
        #endregion
    }
}
