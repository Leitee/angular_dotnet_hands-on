using System.Threading.Tasks;

namespace Leonardo.Moreno.CORE.Contract.Data
{
    public interface IApplicationUow
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        bool Commit();
        Task<bool> CommitAsync();
    }
}
