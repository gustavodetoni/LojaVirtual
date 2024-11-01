using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetCategoryProducts(int categoryId);
    
}