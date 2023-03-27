using Frontend.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq.Expressions;

namespace Frontend.Repository
{
    public class DonmeeRepository<T> 
        : IRepository<T>, IDisposable
        where T : class
    {
        public DonmeeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbContext _dbContext;


        public async Task<IEnumerable<T>> GetAll()
        {
            var something = _dbContext.Set<T>();
            IEnumerable<T> values = await _dbContext.Set<T>().ToListAsync();
            return values;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> values = await _dbContext.Set<T>().Where(predicate).ToListAsync();
            return values;
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
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

        public async Task<T> Create(T entity)
        {
            EntityEntry<T> createdEntity = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task Create(params T[] entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> predicate)
        {
            T entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
