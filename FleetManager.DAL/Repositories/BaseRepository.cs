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

        public async virtual Task<List<TEntity>> Get(
            Specification<TEntity>? specification = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            )
        {
            IQueryable<TEntity> query = dbSet;

            if (specification is not null) query = query.Where(specification.ToExpression());

            return orderBy is not null 
                ? await orderBy(query).ToListAsync() 
                : await query.ToListAsync();
        }

        public async virtual Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public async virtual ValueTask Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
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
