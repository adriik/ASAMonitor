using Newtonsoft.Json;

namespace PracaDyplomowa
{
    /// <summary>
    /// Klasa wykorzystywana przy przekształceniu JSON-Object.
    /// Reprezentuje limit danych.
    /// </summary>
    public class RangeInfo
    {
        [JsonProperty("offset")]
        public int offset { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }

        [JsonProperty("total")]
        public int total { get; set; }
    }
}