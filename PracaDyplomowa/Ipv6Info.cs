using Newtonsoft.Json;
using System.Collections.Generic;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Reprezentuje informacje na temat ipv6.
    /// </summary>
    public class Ipv6Info
    {
        [JsonProperty("enabled")]
        public bool enabled { get; set; }

        [JsonProperty("autoConfig")]
        public bool autoConfig { get; set; }

        [JsonProperty("enforceEUI64")]
        public bool enforceEUI64 { get; set; }

        [JsonProperty("managedAddressConfig")]
        public bool managedAddressConfig { get; set; }

        [JsonProperty("nsInterval")]
        public int nsInterval { get; set; }

        [JsonProperty("dadAttempts")]
        public int dadAttempts { get; set; }

        [JsonProperty("nDiscoveryPrefixList")]
        public IList<object> nDiscoveryPrefixList { get; set; }

        [JsonProperty("otherStatefulConfig")]
        public bool otherStatefulConfig { get; set; }

        [JsonProperty("routerAdvertInterval")]
        public int routerAdvertInterval { get; set; }

        [JsonProperty("routerAdvertIntervalUnit")]
        public string routerAdvertIntervalUnit { get; set; }

        [JsonProperty("routerAdvertLifetime")]
        public int routerAdvertLifetime { get; set; }

        [JsonProperty("suppressRouterAdvert")]
        public bool suppressRouterAdvert { get; set; }

        [JsonProperty("reachableTime")]
        public int reachableTime { get; set; }

        [JsonProperty("ipv6Addresses")]
        public IList<object> ipv6Addresses { get; set; }

        [JsonProperty("kind")]
        public string kind { get; set; }
    }
}