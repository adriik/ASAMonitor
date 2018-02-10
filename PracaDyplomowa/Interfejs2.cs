using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracaDyplomowa
{
    public class Interfejs2
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("selfLink")]
        public string selfLink { get; set; }

        [JsonProperty("rangeInfo")]
        public RangeInfo rangeInfo { get; set; }

        [JsonProperty("items")]
        public IList<Item2> items { get; set; }
    }
}