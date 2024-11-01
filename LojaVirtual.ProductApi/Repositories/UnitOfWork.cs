using AutoMapper;
using MVPShop.ProductApi.DTOs;
using MVPShop.ProductApi.Infrastructure;
using MVPShop.ProductApi.Models;
using MVPShop.ProductApi.Repositories;
using MVPShop.ProductApi.Repositories.Interfaces;
using MVPShop.ProductApi.Services;

namespace ApiCatalogo.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IProductRepository? _produtoRep;
    private ICategoryRepository? _categoriaRep;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IProductRepository ProductRepository => _produtoRep ??= new ProductRepository(_context);

    public ICategoryRepository CategoryRepository => _categoriaRep ??= new CategoryRepository(_context);


    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (typeof(T) == typeof(Product))
            return (IRepository<T>)ProductRepository;
        if (typeof(T) == typeof(Category))
            return (IRepository<T>)CategoryRepository;

        throw new NotImplementedException("No repository found for this entity type.");
    }
}
