using Microsoft.AspNetCore.Components;
using FleetManager.Data.Models;
using FleetManager.DAL.Utilities;
using BlazorLeafletMap;

namespace FleetManager.MAUI.Pages
{
    public partial class Index
    {
        [Inject]
        public UnitOfWork unitOfWork { get; set; }

        [Inject]
        private BlazorLeafletMapModule BlazorLeafletMap { get; set; }

        public List<Yacht> Yachts { get; set; } = new();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Yachts = await unitOfWork.Yachts.Get();

                await BlazorLeafletMap.InitializeMap(options =>
                {
                    options
                        .WithLatitude(37.913251m)
                        .WithLongitude(23.703336m)
                        .WithZoomLevel(20);
                });

                if(Yachts.Count > 0)
                    await YachtSelected(Yachts.First());

                StateHasChanged();
            }
        }

        protected async Task YachtSelected(Yacht selectedYacht)
        {
            await BlazorLeafletMap.FlyTo(selectedYacht.Latitude, selectedYacht.Longitude);
        }
    }
}
