using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bancario.Domain.Interfaces;

namespace Bancario.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly DataBaseContext _context;

        public RepositoryBase(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_context.Set<T>().AsNoTracking());
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity, Expression<Func<T, object>> keySelector)
        {
            var key = keySelector.Compile()(entity);
            var existingEntity = await _context.Set<T>().FindAsync(key);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
