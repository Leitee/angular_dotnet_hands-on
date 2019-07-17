using Leonardo.Moreno.CORE.Contract.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Leonardo.Moreno.CORE.Utils
{
    public static class EntityFwkExtension
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query,
        params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes) where TEntity : class
        {
            if (includes == null)
                return query;

            foreach (var include in includes)
            {
                var includable = (Includable<TEntity>)include.Compile()(new Includable<TEntity>(query));
                query = includable.Input;
            }

            return query;
        }
    }
}
