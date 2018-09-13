using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LatestBlazor.APIs.HSL
{
    public class ApiDataContainer
    {
        [JsonProperty("data")]
        public JObject data { get; set; }
    }
}
