using LojaVirtual.ProductApi.Context;
using LojaVirtual.ProductApi.Models;
using LojaVirtual.ProductApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
