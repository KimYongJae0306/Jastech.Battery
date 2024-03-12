using System;
using System.Collections.Generic;
using System.Drawing;
using static Jastech.Battery.Structure.Data.DefectDefine;

namespace Jastech.Battery.Structure.Data
{
    public class DefectInfo
    {
        #region 속성
        public DateTime InspectionTime { get; set; }

        public int Index { get; set; }

        public DefectTypes DefectType { get; set; }

        public DefectJudge Judgement { get; set; }

        public int Lane { get; set; }

        public string CameraName { get; set; }

        public PointF Coord { get; set; }

        public SizeF Size { get; set; }

        public int DefectLevel { get; set; }

        public string ImagePath { get; set; }
        #endregion
    }
}