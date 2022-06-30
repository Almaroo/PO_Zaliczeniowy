using Microsoft.AspNetCore.Components;

namespace BlazorLeafletMap
{
    public partial class MapComponent
    {
        [Parameter]
        public string BackgroundColor { get; set; }

        [Inject]
        private BlazorLeafletMapModule BlazorLeafletMap { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await BlazorLeafletMap.InitializeMap(options =>
                {
                    options
                        .WithLatitude(37.913251m)
                        .WithLongitude(23.703336m)
                        .WithZoomLevel(13);
                });

                StateHasChanged();
            }
        }

        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(BackgroundColor)) BackgroundColor = "azure";
        }
    }
}