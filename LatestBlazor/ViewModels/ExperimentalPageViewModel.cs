using LatestBlazor.APIs;
using LatestBlazor.APIs.HSL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace LatestBlazor.ViewModels
{
    public class ExperimentalPageViewModel
    {
        private readonly TransitAPI _transitService;

        public string Background { get; set; } = "red";
        public List<TransitStop> TransitStops { get; set; } = new List<TransitStop>();

        public ExperimentalPageViewModel(TransitAPI transitApi)
        {
            _transitService = transitApi;
        }

        public async Task GetTransitStops()
        {

            var newStops = (await _transitService.GetStopsByBoundingRadius(60.1709f, 24.9413f, 750))
                ?.ToList();

            TransitStops = newStops;           
        }
    }
}
