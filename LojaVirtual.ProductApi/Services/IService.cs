using System.Linq.Expressions;

namespace LojaVirtual.ProductApi.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);   
        Task<TDto> CreateAsync<TDto>(TDto dto);
        Task<TDto> UpdateAsync<TDto>(TDto dto);
    }
}
