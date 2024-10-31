using LojaVirtual.ProductApi.Context;
using LojaVirtual.ProductApi.Models;
using LojaVirtual.ProductApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
