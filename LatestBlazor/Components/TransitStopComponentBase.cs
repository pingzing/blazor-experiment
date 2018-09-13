using LatestBlazor.APIs;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatestBlazor.Components
{
    public class TransitStopComponentBase : BlazorComponent
    {
        [Parameter] public string Name { get; set; }
        [Parameter] public string Code { get; set; }
        [Parameter] public BasicLatLon Coordinates { get; set; }
        public string CoordinatesString => $"Lat: {Coordinates.Lat}, Lon: {Coordinates.Lon}";

    }
}
