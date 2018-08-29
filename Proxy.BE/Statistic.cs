﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.BE
{
    public class Statistic
    {
        public int Count { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal HighAveragePrice { get; set; }
        public decimal LowAveragePrice { get; set; }
    }
}
