using Microsoft.AspNetCore.Components;
using FleetManager.Data.Models;
using FleetManager.DAL.Utilities;

namespace FleetManager.MAUI.Pages
{
    public partial class Index
    {
        [Inject]
        public UnitOfWork unitOfWork { get; set; }

        public List<Yacht> Yachts { get; set; } = new();

        public Index()
        {
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Yachts = await unitOfWork.Yachts.Get();

                StateHasChanged();
            }
        }
    }
}
