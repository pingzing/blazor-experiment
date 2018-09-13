using LatestBlazor.APIs.HSL;
using LatestBlazor.ViewModels;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatestBlazor.Pages
{
    public class ExperimentalPageBase : BlazorComponent
    {
        [Inject]
        protected TransitAPI TransitService { get; set; }
        public ExperimentalPageViewModel ViewModel { get; set; }

        protected override void OnInit()
        {
            ViewModel = new ExperimentalPageViewModel(TransitService);            
        }

        public async Task GetTransitStops()
        {
            Console.WriteLine("Calling GetTransitStops");
            await ViewModel.GetTransitStops();
        }
    }
}
