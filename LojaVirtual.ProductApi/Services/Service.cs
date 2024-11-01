using LojaVirtual.ProductApi.Repositories.Interfaces;
using System.Linq.Expressions;
using AutoMapper;
using LojaVirtual.ProductApi.Services.Interfaces;
using LojaVirtual.ProductApi.DTOs;

namespace LojaVirtual.ProductApi.Services
{
    public class Service<T, TDto> : IService<T, TDto> where T : class where TDto : IEntityDto
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.GetRepository<T>().GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetAsync(predicate);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            _unitOfWork.GetRepository<T>().Create(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var existingEntity = await _unitOfWork.GetRepository<T>().GetByIdAsync(dto.Id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Entity not found.");
            }

            var entity = _mapper.Map<T>(dto);
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.GetRepository<T>().Delete(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
