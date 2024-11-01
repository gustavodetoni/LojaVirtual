using System.Linq.Expressions;
using ApiCatalogo.Repositories;
using AutoMapper;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Services;

public class ProductService : Service<Product, ProductRequestDTO, ProductResponseDTO>, IProductService
{
    private IProductService _productServiceImplementation;

    public ProductService(IUnitOfWork repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    public async Task<CategoryResponseDTO> GetCategoryProducts(int categoryId)
    {
        var category = await _unitOfWork.CategoryRepository.GetCategoryProducts(categoryId);
        return _mapper.Map<CategoryResponseDTO>(category);
    }


    
}