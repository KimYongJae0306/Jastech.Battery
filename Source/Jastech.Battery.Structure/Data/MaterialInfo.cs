using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public partial class MaterialInfo
    {
        #region 속성
        public double PancakeLength_mm { get; set; } = 1500;

        public double IgnoreStartGap_mm { get; set; } = 0;

        public int OverlapHeight { get; set; } = 100; // pixel

        public int LeftScanMargin { get; set; } = 200;

        public int RightScanMargin { get; set; } = 200;
        #endregion

        #region 메소드
        public MaterialInfo ShallowCopy() => (MaterialInfo)MemberwiseClone();
        #endregion
    }

    //public partial class  MaterialInfo
    //{
    //    public CopperInfo Copper { get; set; } = null;

    //    public CoatingInfo Coating { get; set; } = null;

    //    public InsulationInfo InsulationLeft = null;

    //    public InsulationInfo InsulationRight = null;
    //}

    //public class CoatingInfo
    //{
    //    public double StartX { get; set; } = 0.0;

    //    public double EndX { get; set; } = 0.0;

    //    public double StartLevel { get; set; } = 0.0;

    //    public double EndLevel { get; set; } = 0.0;

    //    public double Width { get; set; } = 0.0;

    //    public double Length {  get; set; } = 0.0;

    //    public int PatternNo { get; set; } = 0;

    //    public double Mismatch { get; set; } = 0.0;

    //    public double MismatchResult { get; set; } = 0.0;
    //}

    //public class CopperInfo
    //{
    //    public double StartX { get; set; } = 0.0;

    //    public double EndX { get; set; } = 0.0;

    //    public double StartLevel { get; set; } = 0.0;

    //    public double EndLevel { get; set; } = 0.0;

    //    public double Width { get; set; } = 0.0;

    //    public double Length { get; set; } = 0.0;

    //    public int PatternNo { get; set; } = 0;

    //    public double Mismatch { get; set; } = 0.0;

    //    public double MismatchResult { get; set; } = 0.0;
    //}

    //public class InsulationInfo
    //{
    //    public bool EnableInsulation { get; set; } = false;

    //    public double StartX { get; set; } = 0.0;

    //    public double EndX { get; set; } = 0.0;

    //    public double OverlayStartX { get; set; } = 0.0;

    //    public double OverlayEndX { get; set; } = 0.0;

    //    public double Width { get; set; } = 0.0;

    //    public double Gap { get; set; } = 0.0;

    //    public double OverlayWidth { get; set; } = 0.0;

    //    public double AverageLevel { get; set; } = 0.0;

    //    public double Result { get; set; } = 0.0;
    //}
}
