using LatestBlazor.Extensions;
using LatestBlazor.GraphQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LatestBlazor.APIs.HSL
{
    public class TransitAPI
    {        
        private readonly HttpClient _httpClient;

        public string DefaultGqlRequestUrl { get; } = "https://api.digitransit.fi/routing/v1/routers/hsl/index/graphql";        

        public TransitAPI(HttpClient client)
        {
            Console.WriteLine("Creating new TransitAPI");
            _httpClient = client;
        }

        public async Task<IEnumerable<TransitStop>> GetStopsByBoundingRadius(float lat, float lon, int radiusMeters,
            CancellationToken token = default)
        {
            GqlQuery query = new GqlQuery(ApiGqlMembers.stopsByRadius)
                .WithParameters(
                    new GqlParameter(ApiGqlMembers.lat, lat),
                    new GqlParameter(ApiGqlMembers.lon, lon),
                    new GqlParameter(ApiGqlMembers.radius, radiusMeters)
                )
                .WithReturnValues(
                    new GqlReturnValue(ApiGqlMembers.edges,
                        new GqlReturnValue(ApiGqlMembers.node,
                            new GqlReturnValue(ApiGqlMembers.stop,
                                new GqlReturnValue(ApiGqlMembers.gtfsId),
                                new GqlReturnValue(ApiGqlMembers.name),
                                new GqlReturnValue(ApiGqlMembers.code),
                                new GqlReturnValue(ApiGqlMembers.lat),
                                new GqlReturnValue(ApiGqlMembers.lon),
                                new GqlReturnValue(ApiGqlMembers.patterns,
                                    new GqlReturnValue(ApiGqlMembers.name),
                                    new GqlReturnValue(ApiGqlMembers.route,
                                        new GqlReturnValue(ApiGqlMembers.shortName),
                                        new GqlReturnValue(ApiGqlMembers.longName)
                                    )
                                )
                            )
                        )
                    )
                );

            var response = await GetGraphQLAsync<ApiStopAtDistanceConnection>(query, token).ConfigureAwait(false);
            if (response != null)
            {
                IEnumerable<TransitStop> stops = response.Edges?.Select(x => new TransitStop
                {
                    GtfsId = x.Node.Stop.GtfsId,
                    Coords = new BasicLatLon(x.Node.Stop.Lat, x.Node.Stop.Lon),
                    Code = x.Node.Stop.Code,
                    Name = x.Node.Stop.Name,                    
                });
                if (stops == null)
                {
                    Console.WriteLine("Stops was null.");
                    return null;
                }
                if (!stops.Any())
                {
                    Console.WriteLine("Stops was an empty array.");
                    return null;
                }
                return stops;
            }
            else
            {
                return null;
            }
        }

        private async Task<T> GetGraphQLAsync<T>(GqlQuery query, CancellationToken token = default(CancellationToken))
        {
            string parsedQuery = query.ParseToJsonString(DateParsingStrategy.NoSeparators);
            StringContent stringContent = new StringContent(parsedQuery, Encoding.UTF8, " application/json");
            Uri uri = new Uri(DefaultGqlRequestUrl);

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(uri, stringContent, token).ConfigureAwait(false);
                if (response == null || !response.IsSuccessStatusCode)
                {
                    Console.WriteLine("No response or non-success received from server.");
                    return default;
                }

                return await UnwrapGqlResposne<T>(response).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is OperationCanceledException)
            {
                Console.WriteLine($"Exception getting GraphQL response: {ex}");
                return default;
            }
        }

        private async Task<T> UnwrapGqlResposne<T>(HttpResponseMessage response)
        {
            string respString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(respString);
            ApiDataContainer container = JsonConvert.DeserializeObject<ApiDataContainer>(respString);
            Console.WriteLine("Deserialized!");
            return container.data.First.First.ToObject<T>();

            return (await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                .DeseriaizeJsonFromStream<ApiDataContainer>()
                .data.First.First.ToObject<T>();
        }
    }
}
