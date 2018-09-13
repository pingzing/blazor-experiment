using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using static LatestBlazor.APIs.HSL.ApiEnums;

namespace LatestBlazor.APIs.HSL
{
    public class ApiPlace
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("vertexType")]
        public ApiVertexType? VertexType { get; set; }
        [JsonProperty("lat")]
        public float Lat { get; set; }
        [JsonProperty("lon")]
        public float Lon { get; set; }
        /// <summary>
        /// Nullable.
        /// </summary>
        [JsonProperty("stop")]
        public ApiStop Stop { get; set; }
        /// <summary>
        /// Nullable.
        /// </summary>
        [JsonProperty("bikeRentalStation")]
        public ApiBikeRentalStation BikeRentalStation { get; set; }                
    }
}