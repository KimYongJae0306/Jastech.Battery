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
    }
}
