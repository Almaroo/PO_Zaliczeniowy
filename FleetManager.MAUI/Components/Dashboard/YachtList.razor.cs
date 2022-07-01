using BlazorComponentUtilities;
using FleetManager.Data.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace FleetManager.MAUI.Components.Dashboard
{
    public partial class YachtList
    {
        [Parameter]
        public List<Yacht> Yachts { get; set; }

        [Parameter]
        public Yacht SelectedYacht { get; set; }

        [Parameter]
        public EventCallback<Yacht> OnYachtSelected { get; set; }

        private async Task SelectActiveYacht(EventArgs e, Yacht yacht)
        {
            Debug.WriteLine(yacht.Name);
            Debug.WriteLine($"{yacht.Latitude:##.######}, {yacht.Longitude:###.######}");
            await OnYachtSelected.InvokeAsync(yacht);
        }

        CssBuilder CssClassYachtListItem(Yacht yacht) =>
            new CssBuilder("YachtList__item")
            .AddClass("YachtList__item--active", when: yacht == SelectedYacht);
    }
}
