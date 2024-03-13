using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure
{
    public class AppsInspModel : InspModel
    {
		public int LaneCount { get; set; } = 1;

        public MaterialInfo MaterialInfo { get; set; } = new MaterialInfo();

        public DistanceParam DistanceParam { get; set; } = new DistanceParam();

        public int InspThreadCount { get; set; } = 10;

        public ModelType ModelType { get; set; } = ModelType.None;

        public ProcessType ProcessType { get; set; } = ProcessType.None;
    }
}
