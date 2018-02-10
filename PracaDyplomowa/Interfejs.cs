using Newtonsoft.Json;
using System.Collections.Generic;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Reprezentuje stan interfejsu.
    /// </summary>
    public class Interfejs
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("selfLink")]
        public string selfLink { get; set; }

        [JsonProperty("rangeInfo")]
        public RangeInfo rangeInfo { get; set; }

        [JsonProperty("items")]
        public IList<Item> items { get; set; }

        [JsonProperty("refLink")]
        public string refLink { get; set; }

        [JsonProperty("objectId")]
        public string objectId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}