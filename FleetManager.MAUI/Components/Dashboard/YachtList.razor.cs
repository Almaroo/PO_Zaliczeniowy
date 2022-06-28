using FleetManager.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace FleetManager.MAUI.Components.Dashboard
{
    public partial class YachtList
    {
        [Parameter]
        public List<Yacht> Yachts { get; set; }

        private void SelectActiveYacht(EventArgs e, Yacht yacht)
        {
            Debug.WriteLine(yacht.Name);
        }
    }
}
