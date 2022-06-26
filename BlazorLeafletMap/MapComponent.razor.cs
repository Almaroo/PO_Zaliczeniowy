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
                await BlazorLeafletMap.InitializeMap();

                StateHasChanged();
            }
        }

        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(BackgroundColor)) BackgroundColor = "azure";
        }
    }
}