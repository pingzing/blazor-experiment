using Newtonsoft.Json;
using System.Collections.Generic;

namespace LatestBlazor.APIs.HSL
{
    public class ApiStoptimesInPattern
    {
        [JsonProperty("pattern")]
        public ApiPattern Pattern { get; set; }

        [JsonProperty("stoptimes")]
        public List<ApiStoptime> Stoptimes { get; set; }
    }
}