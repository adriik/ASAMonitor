using Newtonsoft.Json;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Agreguje wiele obiektów pobieranych z ASA.
    /// </summary>
    public class Item
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("selfLink")]
        public string selfLink { get; set; }

        [JsonProperty("hardwareID")]
        public string hardwareID { get; set; }

        [JsonProperty("interfaceDesc")]
        public string interfaceDesc { get; set; }

        [JsonProperty("channelGroupID")]
        public string channelGroupID { get; set; }

        [JsonProperty("channelGroupMode")]
        public string channelGroupMode { get; set; }

        [JsonProperty("duplex")]
        public string duplex { get; set; }

        [JsonProperty("flowcontrolOn")]
        public bool flowcontrolOn { get; set; }

        [JsonProperty("flowcontrolHigh")]
        public int flowcontrolHigh { get; set; }

        [JsonProperty("flowcontrolLow")]
        public int flowcontrolLow { get; set; }

        [JsonProperty("flowcontrolPeriod")]
        public int flowcontrolPeriod { get; set; }

        [JsonProperty("forwardTrafficCX")]
        public bool forwardTrafficCX { get; set; }

        [JsonProperty("forwardTrafficSFR")]
        public bool forwardTrafficSFR { get; set; }

        [JsonProperty("lacpPriority")]
        public int lacpPriority { get; set; }

        [JsonProperty("activeMacAddress")]
        public string activeMacAddress { get; set; }

        [JsonProperty("standByMacAddress")]
        public string standByMacAddress { get; set; }

        [JsonProperty("managementOnly")]
        public bool managementOnly { get; set; }

        [JsonProperty("mtu")]
        public int mtu { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("securityLevel")]
        public int securityLevel { get; set; }

        [JsonProperty("shutdown")]
        public bool shutdown { get; set; }

        [JsonProperty("speed")]
        public string speed { get; set; }

        [JsonProperty("ipAddress")]
        public object ipAddress { get; set; }

        [JsonProperty("ipv6Info")]
        public Ipv6Info ipv6Info { get; set; }

        [JsonProperty("objectId")]
        public string objectId { get; set; }




 

        [JsonProperty("ip")]
        public Ip ip { get; set; }

        [JsonProperty("emblemEnabled")]
        public bool emblemEnabled { get; set; }

        [JsonProperty("secureEnabled")]
        public bool secureEnabled { get; set; }

        [JsonProperty("interface")]
        public Interfejs interfejs { get; set; }

    [JsonProperty("port")]
    public int port { get; set; }

    [JsonProperty("protocol")]
    public string protocol { get; set; }

    }
}