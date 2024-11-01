using System.Linq.Expressions;

public interface IService<T, TRequestDto, TResponseDto> where T : class
{
    Task<IEnumerable<TResponseDto>> GetAllAsync();
    Task<TResponseDto?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<TResponseDto?> GetByIdAsync(int id);
    Task<TResponseDto> PostAsync(TRequestDto dto);
    Task<TResponseDto> PutAsync(TRequestDto dto);
    Task<TResponseDto> DeleteAsync(int id);
}