using Microsoft.AspNetCore.Components;
using BlazorComponentUtilities;

namespace BlazorLeafletMap
{
    public partial class MapComponent
    {
        private string backgroundColor;

        [Parameter]
        public string BackgroundColor
        {
            get => $"background-color: {backgroundColor}";
            set => backgroundColor = value;
        }

        [Parameter]
        public bool IsRounded { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

        CssBuilder CssClass =>
            new CssBuilder("map")
                .AddClass("map--backgroundDefault", when: string.IsNullOrEmpty(backgroundColor))
                .AddClass("map--rounded", when: IsRounded)
                .AddClassFromAttributes(AdditionalAttributes);
    }
}