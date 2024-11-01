using System.Linq.Expressions;

namespace MVPShop.ProductApi.Repositories;

public interface IRepository <T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(int id);
    Task<T> PostAsync(T entity);
    Task<T> PutAsync(T entity);
    Task<T> DeleteAsync(int id);
}