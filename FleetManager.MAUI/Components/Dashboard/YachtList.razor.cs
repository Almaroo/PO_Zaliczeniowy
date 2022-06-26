using FleetManager.Data;
using Microsoft.AspNetCore.Components;

namespace FleetManager.MAUI.Components.Dashboard
{
    public partial class YachtList
    {
        [Parameter]
        public List<Yacht> Yachts { get; set; }
    }
}
