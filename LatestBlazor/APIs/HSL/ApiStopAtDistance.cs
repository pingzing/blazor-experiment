using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public class ApiStopAtDistance
    {
        /// <summary>
        /// Non-nullable.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("stop")]
        public ApiStop Stop { get; set; }
        [JsonProperty("distance")]
        public int Distance { get; set; }
    }
}