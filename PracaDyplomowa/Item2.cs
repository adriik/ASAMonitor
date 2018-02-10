using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracaDyplomowa
{
    public class Item2
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("selfLink")]
        public string selfLink { get; set; }

        [JsonProperty("ipAddress")]
        public string ipAddress { get; set; }

        [JsonProperty("isClusterInterface")]
        public bool isClusterInterface { get; set; }

        [JsonProperty("netmask")]
        public string netmask { get; set; }

        [JsonProperty("interface")]
        public Interfejs interfejs { get; set; }

        [JsonProperty("objectId")]
        public string objectId { get; set; }
    }
}