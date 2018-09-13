using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public struct ApiFare
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cents")]
        public int Cents { get; set; }
    }
}