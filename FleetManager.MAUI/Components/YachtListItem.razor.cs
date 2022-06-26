using Microsoft.AspNetCore.Components;
using FleetManager.Data;

namespace FleetManager.MAUI.Components
{
    public partial class YachtListItem
    {
        [Parameter] public Yacht YachtViewModel { get; set; }
    }
}
