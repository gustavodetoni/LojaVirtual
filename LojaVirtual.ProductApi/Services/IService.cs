using System.Linq.Expressions;

namespace LojaVirtual.ProductApi.Services.Interfaces
{
    public interface IService<T, TDto> where T : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<TDto> CreateAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
    }
}
