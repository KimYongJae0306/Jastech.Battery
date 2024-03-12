using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Parameters
{
    public class NonCoatingParam
    {
        public bool CheckNonCoatingWidth { get; set; } = false;

        public int FoldingLevel { get; set; } = 20;

        public DentParam DentParam = new DentParam();

        public double MinWidth { get; set; } = 0.0;

        public double MaxWidth { get; set; } = 0.0;

        public int WidthCount { get; set; } = 3;
    }
}
