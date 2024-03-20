﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class SliceInspResult
    {
        public InspDirection InspDirection { get; set; }

        public DistanceInspResult DistanceResult { get; set; }

        public SurfaceInspResult SurfaceInspResult { get; set; }
    }
}
