using System.Linq.Expressions;

namespace Frontend.Repository
{
    public interface IRepository<T>
    {        
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);

        Task<T> Get(Expression<Func<T, bool>> predicate);

        Task<T> Create(T entity);
        Task Create(params T[] entities);

        Task<T> Update(T entity);

        Task<bool> Delete(Expression<Func<T, bool>> predicate);
    }
}
