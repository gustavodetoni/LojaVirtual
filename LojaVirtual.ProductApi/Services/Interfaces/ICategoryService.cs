using System.Linq.Expressions;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Services;

public interface ICategoryService : IService<Category, CategoryRequestDTO, CategoryResponseDTO>
{
    Task<CategoryResponseDTO> GetCategoryProducts(int categoryId);
}