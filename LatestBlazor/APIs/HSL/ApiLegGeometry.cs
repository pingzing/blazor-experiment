using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public struct ApiLegGeometry
    {
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("points")]
        public string Points { get; set; }
    }
}