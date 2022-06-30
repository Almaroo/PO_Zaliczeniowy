using FleetManager.DAL.Utilities;
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

        public virtual IEnumerable<TEntity> Get(
            Specification<TEntity>? specification = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            )
        {
            IQueryable<TEntity> query = dbSet;

            if (specification is not null) query = query.Where(specification.ToExpression());

            return orderBy is not null 
                ? orderBy(query).ToList() 
                : query.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (fleetManagerContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            fleetManagerContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
}
