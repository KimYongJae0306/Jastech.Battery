using Jastech.Battery.Structure.Data;
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
        public MaterialInfo MaterialInfo { get; set; } = new MaterialInfo();

        public int InspThreadCount { get; set; } = 10;
    }
}
