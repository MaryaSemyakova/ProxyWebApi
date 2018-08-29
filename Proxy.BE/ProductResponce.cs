﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxy.BE
{
    [Serializable]
    public class ProductResponce
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "products")]
        public List<Product> Products { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string NextUrl { get; set; }
    }
}
