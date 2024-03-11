using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace Jastech.Battery.Structure.Parameters
{
    public class TestClass
    {
        public List<int> FoilLevel { get; set; } = null;

        public List<int> CoatingLevel { get; set; } = null;

        /////////////////////
        
        public int m_ImgW=0;
        public int m_ImgH = 0;

        public byte[] m_pImgBuff = null;

        public double[] m_pW = null;
        public double[] m_pTmpW1 = null;
        public double[] m_pTmpW2 = null;
        public double[] m_pDiffW = null;
        public double[] m_pProfileW = null;   // 수평방향 Profile, 외부에서 그래프로 그리기 위해 가지고 있음  

        public double[] m_pH = null;
        public double[] m_pTmpH1 = null;
        public double[] m_pTmpH2 = null;
        public double[] m_pDiffH = null;
        public double[] m_pProfileH = null;   // 수직방향 Profile

        public int m_VertCoatNum = 0;
        public Rectangle[] m_VertCoatArea = new Rectangle[5];   // Y방향으로 코팅영역을 전부 찾음
        public Rectangle m_MaxVertCoatArea = new Rectangle();          // Y방향의 코팅영역중 가장 큰 영역을 저장함. 
    }

    public class DistanceParam
    {
        public ModelType ModelType { get; set; } = ModelType.Pouch;

        public int FRAME_COUNT_TOTAL
        {
            get { return 30; }
        }

        public int FrameCountTotal { get; set; } = 0;

        public int FRAME_COUNT_POUCH
        {
            get { return 5; }
        }

        public int FrameCountPouch { get; set; } = 0;



        public int CopperNum { get; set; } = 0;

        public int VerticalCoatingNum { get; set; } = 0;
        
        public List<Rectangle> VerticalCoatingArea = new List<Rectangle>();

        public int ImageWidth { get; set; } = 0;

        public int ImageHeight { get; set; } = 0;

        public byte[] ImageData { get; set; } = null;

        public Bitmap ImageBitmap { get; set; } = null;
    }

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

        public int IslandLevel { get; set;} = 0;

        public double IslandSize { get; set; } = 1.0;
    }

    public class Drag
    {
        public bool EnableDrag { get; set; } = false;

        public int DragLevel { get; set; } = 0;

        public double DragSize { get; set; } = 0.0;
    }

    public enum ModelType
    {
        None,
        Pouch,
        Pattern,
    }
}
