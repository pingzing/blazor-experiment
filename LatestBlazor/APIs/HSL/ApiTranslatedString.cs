using Newtonsoft.Json;

namespace LatestBlazor.APIs.HSL
{
    public class ApiTranslatedString
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
