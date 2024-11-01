using System.Linq.Expressions;
using ApiCatalogo.Repositories;
using AutoMapper;

public class Service<T, TRequestDto, TResponseDto> : IService<T, TRequestDto, TResponseDto> where T : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    
    public Service(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<TResponseDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.GetRepository<T>().GetAllAsync();
        return _mapper.Map<IEnumerable<TResponseDto>>(entities);
    }

    public async Task<TResponseDto?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        var entity = await _unitOfWork.GetRepository<T>().GetAsync(predicate);
        return entity == null ? default : _mapper.Map<TResponseDto>(entity);
    }

    public async Task<TResponseDto?> GetByIdAsync(int id)
    {
        var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
        return entity == null ? default : _mapper.Map<TResponseDto>(entity);
    }

    public async Task<TResponseDto> PostAsync(TRequestDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        await _unitOfWork.GetRepository<T>().PostAsync(entity);
        await _unitOfWork.Commit();
        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task<TResponseDto> PutAsync(TRequestDto dto)
    {
        // Obtém o ID a partir do DTO (assumindo que ele possui o campo 'Id')
        var entityId = (int)typeof(TRequestDto).GetProperty("Id")?.GetValue(dto);

        // Busca a entidade existente
        var existingEntity = await _unitOfWork.GetRepository<T>().GetByIdAsync(entityId);
        if (existingEntity == null)
        {
            throw new ArgumentException("Entity not found");
        }

        // Atualiza as propriedades com o mapeamento
        _mapper.Map(dto, existingEntity);

        // Chama o método de atualização no repositório
        var updatedEntity = await _unitOfWork.GetRepository<T>().PutAsync(existingEntity);
        await _unitOfWork.Commit();

        // Mapeia a entidade atualizada para o DTO de resposta
        return _mapper.Map<TResponseDto>(updatedEntity);
    }


    public async Task<TResponseDto> DeleteAsync(int id)
    {
        var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _unitOfWork.GetRepository<T>().DeleteAsync(id);
        await _unitOfWork.Commit();
        return _mapper.Map<TResponseDto>(entity);
    }
}
