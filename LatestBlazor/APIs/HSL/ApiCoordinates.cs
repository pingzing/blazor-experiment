using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public struct ApiCoordinates
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }
        [JsonProperty("lon")]
        public float Lon { get; set; }
    }
}