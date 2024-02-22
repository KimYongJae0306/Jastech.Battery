using Jastech.Battery.Structure.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.VisionTool
{
    public class AlgorithmTool
    {
        public void Inspect()
        {
        }
        
        private void FindFoilEnd(bool inTeachingArea)
        {

        }

        public void SetParam()
        {

        }

        public RectangleF GetInspectionArea(int maxLaneCount)
        {
            RectangleF rect = new RectangleF();

            int x1 = 0;
            int y1 = 0;

            int x2 = 0;
            int y2 = 0;


            return rect;
        }

        private List<RectangleF> GetCoatingArea(int maxLaneCount)
        {
            List<RectangleF> rectList = new List<RectangleF>();

            for (int laneIndex = 0; laneIndex < maxLaneCount; laneIndex++)
            {
                int startX = 0;
                int startY = 0;
            }

            return rectList;
        }

        public void CoatringArea_Line()
        {
            int workRatioX = 2;
            int workRatioY = 6;
        }

        public void CoatingArea_LineBlack(CoatingParam param)
        {
            int threshold = 128 - param.LineParam.LineLevel;

            int workRatioX = 3;
            int workRatioY = 10;

            int tapePosY1 = 0;
            int tapePosY2 = param.ImageHeight;
        }
    }
}
