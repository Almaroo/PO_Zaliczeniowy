using Microsoft.AspNetCore.Components;
namespace FleetManager.MAUI.Shared.ListView
{
    public partial class ListView<TItem>
    {
        [Parameter]
        public IEnumerable<TItem> Data { get; set; }

        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        [Parameter]
        public RenderFragment<RenderFragment> ListTemplate { get; set; }
    }
}