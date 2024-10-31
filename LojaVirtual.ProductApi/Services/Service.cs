using LojaVirtual.ProductApi.Repositories.Interfaces;
using System.Linq.Expressions;
using AutoMapper;

namespace LojaVirtual.ProductApi.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<T>().GetAllAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _unitOfWork.GetRepository<T>().GetAsync(predicate);
        }

        public async Task<T> CreateAsync(T entity)
        {
            _unitOfWork.GetRepository<T>().Create(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.CommitAsync();
            return entity;
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

        public async Task<TDto> CreateAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            _unitOfWork.GetRepository<T>().Create(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> UpdateAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}
