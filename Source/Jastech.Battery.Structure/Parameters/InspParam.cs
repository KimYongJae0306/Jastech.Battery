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

        public int coatingRowCount = 0;
        public Rectangle[] verticalCoatArea = new Rectangle[5];   // Y방향으로 코팅영역을 전부 찾음
        public Rectangle m_MaxVertCoatArea = new Rectangle();          // Y방향의 코팅영역중 가장 큰 영역을 저장함. 

        public double CornerMargin { get; set; }
    }


    public class CopperInfo
    {
        public int Init = 0;

        public double LocationEncoder = 0;
        public double LocationRewinder = 0;

        public double CopperStX = 0;
        public double CopperEndX = 0;
        public double CoatStX = 0, CoatEndX = 0;
        public double InsulationLeftStX = 0, InsulationLeftEndX = 0, InsulationLeftOverlayStX = 0, InsulationLeftOverlayEndX = 0;      // 코팅면 기준 왼쪽
        public double InsulationRightStX = 0, InsulationRightEndX = 0, InsulationRightOverlayStX = 0, InsulationRightOverlayEndX = 0;  // 코팅면 기준 오른쪽

        public double CopperStLv = 0, CopperEndLv = 0;  // Gray Lv값을 나타냄 (Chart에 점찍기 위해서)
        public double CoatStLv = 0, CoatEndLv = 0;      // Slitter장비에서는 CoatStX, CoatEndX를 잡기 때문에

        public double CopperWidth = 0;
        public double CoatWidth = 0;

        public double CopperLength = 0;
        public double CoatLength = 0;

        public int CopperPatternNo = 0;
        public int CoatPatternNo = 0;

        public double CoatMismatch = 0;      // Mismatch값을 계산하여 기억함.
        public double CopperMismatch = 0;

        public int CoatMismatchResult = 0;
        public int CopperMismatchResult = 0;

        public int bInsulationLeft = 0, bInsulationRight = 0;        // 절연이 왼쪽, 오른쪽에 있는지 검사  (미코팅 기준)
        public double InsulationLeftWidth = 0, InsulationLeftGap = 0, InsulationLeftOverlayWidth = 0;
        public double InsulationRightWidth = 0, InsulationRightGap = 0, InsulationRightOverlayWidth = 0;
        public int InsulationLeftAvgLv = 0, InsulationRightAvgLv = 0;      // 절연 영역의 평균 밝기
        public int InsulationLeftResult = 0, InsulationRightResult = 0;
    }


    public enum ProcessType
    {
        None,
        Coating,
        Press,
        Slitting,
    }

    public enum ModelType
    {
        None,
        Pouch,
        Pattern,
    }
}
