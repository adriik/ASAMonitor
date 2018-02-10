using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Reprezentuje ip obiektu.
    /// </summary>
    public class Ip
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }
}