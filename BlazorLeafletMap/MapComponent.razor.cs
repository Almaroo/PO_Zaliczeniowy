using Microsoft.AspNetCore.Components;

namespace BlazorLeafletMap
{
    public partial class MapComponent
    {
        [Parameter]
        public string BackgroundColor { get; set; }

        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(BackgroundColor)) BackgroundColor = "azure";
        }
    }
}