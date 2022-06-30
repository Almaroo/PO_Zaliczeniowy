using FleetManager.Data.Models;
using FleetManager.YachtsContext;

namespace FleetManager.DAL.Repositories
{
    public class YachtsRepository : BaseRepository<Yacht>
    {
        public YachtsRepository(FleetManagerContext fleetManagerContext) : base(fleetManagerContext)
        {
        }
    }
}
