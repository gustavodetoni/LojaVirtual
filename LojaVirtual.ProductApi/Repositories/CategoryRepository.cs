using Microsoft.EntityFrameworkCore;
using MVPShop.ProductApi.Infrastructure;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Repositories.Interfaces;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category> GetCategoryProducts(int categoryId)
    {
        var categoryProducts = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
        return categoryProducts;
    }
}