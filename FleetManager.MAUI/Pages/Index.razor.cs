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
        public Yacht SelectedYacht { get; set; }

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
                        .WithZoomLevel(15);
                });

                if(Yachts.Count > 0)
                {
                    await YachtSelected(Yachts.First());
                    await DrawYachtPositions(Yachts);
                }

                StateHasChanged();
            }
        }

        protected async Task YachtSelected(Yacht selectedYacht)
        {
            SelectedYacht = selectedYacht;
            await BlazorLeafletMap.FlyTo(selectedYacht.Latitude, selectedYacht.Longitude);
        }

        protected async Task DrawYachtPositions(List<Yacht> yachts)
        {
            IEnumerable<Task> drawTasks = Yachts.Select(
                        async y => await BlazorLeafletMap.DrawPoint(
                            new MapPoint
                            {
                                Latitude = y.Latitude,
                                Longitude = y.Longitude,
                                Radius = 5,
                                TooltipText = y.Name
                            }
                            )
                        );

            await Task.WhenAll(drawTasks);
        }
    }
}
