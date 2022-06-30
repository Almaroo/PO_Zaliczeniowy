using FleetManager.YachtsContext;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly FleetManagerContext fleetManagerContext;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(FleetManagerContext fleetManagerContext)
        {
            this.fleetManagerContext = fleetManagerContext;
            this.dbSet = fleetManagerContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;

            return query.ToList();
        }
    }
}
