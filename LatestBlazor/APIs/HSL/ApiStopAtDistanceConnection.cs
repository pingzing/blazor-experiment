using Newtonsoft.Json;
using System.Collections.Generic;

namespace LatestBlazor.APIs.HSL
{
    public class ApiStopAtDistanceConnection
    {
        [JsonProperty("edges")]
        public List<ApiStopAtDistanceEdge> Edges { get; set; }
        /// <summary>
        /// Non-nullable.
        /// </summary>
        [JsonProperty("pageInfo")]
        public ApiPageInfo PageInfo { get; set; }
    }
}
