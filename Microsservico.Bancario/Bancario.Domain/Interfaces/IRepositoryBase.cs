using System.Linq.Expressions;

namespace Bancario.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity, Expression<Func<T, object>> keySelector);
        Task<bool> Delete(Expression<Func<T, bool>> predicate);
    }
}
