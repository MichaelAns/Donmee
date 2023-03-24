using Frontend.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

namespace Frontend.Repository
{
    public class FrontendRepository<T> 
        : IRepository<T>
        where T : class
    {

        private DonmeeDbContext _dbContext;

        public async Task<IEnumerable<T>> GetAll()
        {
            using (_dbContext = new())
            {
                IEnumerable<T> values = await _dbContext.Set<T>().ToListAsync();
                return values;
            }
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            using (_dbContext = new())
            {
                IEnumerable<T> values = await _dbContext.Set<T>().Where(predicate).ToListAsync();
                return values;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            using (_dbContext = new())
            {
                T value = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
                if (value != null)
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<T> Create(T entity)
        {
            using (_dbContext = new())
            {
                EntityEntry<T> createdEntity = await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> predicate)
        {
            using (_dbContext = new())
            {
                T entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Update(T entity)
        {
            using (_dbContext = new())
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}
