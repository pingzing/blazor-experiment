using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public struct ApiDebugOutput
    {
        [JsonProperty("totalTime")]
        public long? TotalTime { get; set; }
    }
}