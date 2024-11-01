using MVPShop.ProductApi.Infrastructure;
using MVPShop.ProductApi.Models;

namespace MVPShop.ProductApi.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}