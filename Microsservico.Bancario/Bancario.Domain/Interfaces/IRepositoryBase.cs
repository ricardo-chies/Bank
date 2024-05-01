﻿using System.Linq.Expressions;

namespace Bancario.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
