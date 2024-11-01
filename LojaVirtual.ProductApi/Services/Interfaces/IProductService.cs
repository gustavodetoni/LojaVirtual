using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Services;

public interface IProductService : IService<Product, ProductRequestDTO, ProductResponseDTO>
{
    
}