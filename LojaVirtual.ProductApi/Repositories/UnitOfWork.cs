using LojaVirtual.ProductApi.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProductApi.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository? _produtoRepo;
    public ICategoryRepository? _categoriaRepo;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IProductRepository ProductRepository
    {
        get
        {
            return _produtoRepo = _produtoRepo ?? new ProductRepository(_context);
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoryRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
