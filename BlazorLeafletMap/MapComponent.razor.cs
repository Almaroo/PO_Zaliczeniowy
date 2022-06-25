using Microsoft.AspNetCore.Components;

namespace BlazorLeafletMap
{
    public partial class MapComponent
    {
        [Inject]
        private BlazorLeafletMapModule BlazorLeafletMap { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await BlazorLeafletMap.InitializeMap();

                StateHasChanged();
            }
        }
    }
}
