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

        public int CornerMargin { get; set; } = 0;

        public int CoatingEdgeLevel { get; set; } = 0;

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

        public NonCoatingDentParam NonCoatingDentParam = new NonCoatingDentParam();

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
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int Level { get; set; } = 0;

        [JsonProperty]
        public double SizeX { get; set; } = 0.1;

        [JsonProperty]
        public double SizeY { get; set; } = 5;

        [JsonProperty]
        public int EdgeLevel { get; set; } = 0;

        [JsonProperty]
        public int WorkRatioX { get; set; } = 2;

        [JsonProperty]
        public int WorkRatioY { get; set; } = 6;
    }

    public class PinHoleParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int MarginIn { get; set; } = 0;

        [JsonProperty]
        public int MarginOut { get; set; } = 0;

        [JsonProperty]
        public int Level { get; set; } = 0;

        [JsonProperty]
        public double Size { get; set; } = 0.2;
    }

    public class CraterParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int Level { get; set; } = 0;

        [JsonProperty]
        public double LargeSize { get; set; } = 2.0;

        [JsonProperty]
        public double LargeCount { get; set; } = 1;

        [JsonProperty]
        public double SmallSize { get; set; } = 2.0;

        [JsonProperty]
        public double SmallCount { get; set; } = 3;
    }

    public class DentParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int Level { get; set; } = 0;

        [JsonProperty]
        public double LargeSize { get; set; } = 0.5;

        [JsonProperty]
        public int LargeCount { get; set; } = 1;

        [JsonProperty]
        public double SmallSize { get; set; } = 1.0;

        [JsonProperty]
        public int SmallCount { get; set; } = 1;
    }

    public class NonCoatingDentParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public double Size { get; set; } = 1.0;
    }

    public class ScratchParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int Level { get; set; } = 0;

        [JsonProperty]
        public double Size { get; set; } = 10.0;

        [JsonProperty]
        public double Width { get; set; } = 2.0;
    }

    public class TapeParam
    {
        [JsonProperty]
        public bool Enable { get; set; } = false;

        [JsonProperty]
        public int Level { get; set; } = 0;
    }

    public class CopperParam
    {
        public double MarginX { get; set; } = 1;

        public double MarginY { get; set; } = 1;
    }

    public class IslandParam
    {
        public bool Enable { get; set; } = false;

        public int Level { get; set; } = 0;

        public double Size { get; set; } = 1.0;
    }

    public class DragParam
    {
        public bool Enable { get; set; } = false;

        public int Level { get; set; } = 0;

        public double Size { get; set; } = 0.0;
    }
    #endregion
}
