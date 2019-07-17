﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leonardo.Moreno.CORE.Contract.Data
{
    public interface IEfRepository<TEntity> : IRepository<TEntity>, IPaginableRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> GetCountAsync();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> ExecuteQueryAsync(string query, params object[] paramaters);

        Task<List<TEntity>> ExecSp(string spName, params object[] parameters);
    }
}
