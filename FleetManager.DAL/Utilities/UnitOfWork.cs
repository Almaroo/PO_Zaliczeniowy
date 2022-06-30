using FleetManager.DAL.Repositories;
using FleetManager.YachtsContext;

namespace FleetManager.DAL.Utilities
{
    public class UnitOfWork : IDisposable
    {
        private readonly FleetManagerContext fleetManagerContext;
        private readonly YachtsRepository yachtsRepository;

        public YachtsRepository Yachts { get => yachtsRepository; }

        public UnitOfWork(FleetManagerContext fleetManagerContext, YachtsRepository yachtsRepository)
        {
            this.fleetManagerContext = fleetManagerContext;
            this.yachtsRepository = yachtsRepository;
        }

        public async ValueTask<bool> Save()
        {
            var isSuccess = true;
            using var transaction = fleetManagerContext.Database.BeginTransaction();

            try
            {
                await fleetManagerContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                isSuccess = false;
                await transaction.RollbackAsync();
            }

            return isSuccess;
        }

        #region IDisposable implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    fleetManagerContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
