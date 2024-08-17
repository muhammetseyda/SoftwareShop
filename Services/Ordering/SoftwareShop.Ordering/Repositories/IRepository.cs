using System.Linq.Expressions;

namespace SoftwareShop.Ordering.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> where);
    }
}
