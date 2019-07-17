using Leonardo.Moreno.CORE.Response;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leonardo.Moreno.CORE.Contract.Data
{
    public interface IPaginableRepository<TEntity> where TEntity : class
    {
        Task<SvcPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes);
    }
}
