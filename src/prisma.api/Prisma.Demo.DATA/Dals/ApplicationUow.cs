using Leonardo.Moreno.CORE.Base;
using Leonardo.Moreno.CORE.Contract.Data;
using System;
using System.Threading.Tasks;

namespace Prisma.Demo.DATA.Dals
{
    public abstract class ApplicationUow : IApplicationUow, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUow(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Save pending changes to the database and return true if there was at least 1 row affected
        /// </summary>
        public bool Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Save pending changes to the database asyncly and return the amount of affected rows
        /// </summary>
        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        #region IDisposable
        //TODO: see Dispose pattern
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposed = true;
        }
        #endregion

        public abstract IRepository<T> GetRepository<T>() where T : class;

        public abstract T GetIdentityRepo<T>() where T : class;
    }

    public class ApplicationUow<TContext> : ApplicationUow where TContext : ApplicationDbContext
    {
        private readonly IRepositoryProvider<TContext> _repositoryProvider;

        public ApplicationUow(TContext context, IRepositoryProvider<TContext> repositoryProvider)
            : base(context)
        {
            _repositoryProvider = repositoryProvider;
        }

        public override IRepository<T> GetRepository<T>()
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        public override T GetIdentityRepo<T>()
        {
            return _repositoryProvider.GetRepository<T>();
        }
    }
}
