using Microsoft.AspNetCore.Components;
using FleetManager.YachtsContext;
using FleetManager.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.MAUI.Pages
{
    public partial class Index
    {
        [Inject]
        public FleetManagerContext fleetManagerContext { get; set; }

        public List<Yacht> Yachts { get; set; } = new();

        public Index()
        {
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                Yachts = fleetManagerContext.Yachts.AsNoTracking().ToList();

                StateHasChanged();
            }
        }
    }
}
