using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
namespace Jastech.Battery.Structure.Parameters
{
    public class SurfaceParam
    {
        #region 속성
        public int LaneNumber { get; set; } = -1;

        public int ImageWidth { get; set; } = 0;

        public int ImageHeight { get; set; } = 0;

        public bool CheckNonCoatingWidth { get; set; } = false;

        public int FoldingLevel { get; set; } = 20;

        public double MinWidth { get; set; } = 0.0;

        public double MaxWidth { get; set; } = 0.0;

        public int WidthCount { get; set; } = 3;

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

        #region 메서드
        public SurfaceParam DeepCopy()
        {
            return JsonConvertHelper.DeepCopy(this) as SurfaceParam;
        }
        #endregion
    }

    #region 서브 클래스 (개별 파라미터)
    public class LineParam
    {
        [JsonProperty]
        public bool EnableCheckLine { get; set; } = false;

        [JsonProperty]
        public int LineLevel { get; set; } = 0;

        [JsonProperty]
        public double LineSizeX { get; set; } = 0.1;

        [JsonProperty]
        public double LineSizeY { get; set; } = 5;
    }

    public class PinHoleParam
    {
        [JsonProperty]
        public bool EnablePinHole { get; set; } = false;

        [JsonProperty]
        public int PinHoleLevel { get; set; } = 0;

        [JsonProperty]
        public double PinHoleSize { get; set; } = 0.2;
    }

    public class CraterParam
    {
        [JsonProperty]
        public bool EnableCrater { get; set; } = false;

        [JsonProperty]
        public int CraterLevel { get; set; } = 0;

        [JsonProperty]
        public double CraterLargeSize { get; set; } = 2.0;

        [JsonProperty]
        public double CraterLargeCount { get; set; } = 1;

        [JsonProperty]
        public double CraterSmallSize { get; set; } = 2.0;

        [JsonProperty]
        public double CraterSmallCount { get; set; } = 3;
    }

    public class DentParam
    {
        [JsonProperty]
        public bool EnableDent { get; set; } = false;

        [JsonProperty]
        public int DentLevel { get; set; } = 0;

        [JsonProperty]
        public double DentLargeSize { get; set; } = 0.5;

        [JsonProperty]
        public int DentLargetCount { get; set; } = 1;

        [JsonProperty]
        public double DentSmallSize { get; set; } = 1.0;

        [JsonProperty]
        public int DentSmallCount { get; set; } = 1;
    }

    public class ScratchParam
    {
        [JsonProperty]
        public bool EnableScratchBlack { get; set; } = false;

        [JsonProperty]
        public int ScratchBlackLevel { get; set; } = 0;

        [JsonProperty]
        public double ScratchBlackSize { get; set; } = 10.0;

        [JsonProperty]
        public double ScratchBlackWidth { get; set; } = 2.0;
    }

    public class TapeParam
    {
        [JsonProperty]
        public bool EnableConnectionTape { get; set; } = false;

        [JsonProperty]
        public int ConnectionTapeLevel { get; set; } = 0;
    }

    public class CopperParam
    {
        public double CopperMarginX { get; set; } = 1;

        public double CopperMarginY { get; set; } = 1;
    }

    public class IslandParam
    {
        public bool EnableIsland { get; set; } = false;

        public int IslandLevel { get; set; } = 0;

        public double IslandSize { get; set; } = 1.0;
    }

    public class DragParam
    {
        public bool EnableDrag { get; set; } = false;

        public int DragLevel { get; set; } = 0;

        public double DragSize { get; set; } = 0.0;
    }
    #endregion
}
