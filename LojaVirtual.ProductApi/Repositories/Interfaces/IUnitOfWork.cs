using MVPShop.ProductApi.Repositories;
using MVPShop.ProductApi.Services;

namespace ApiCatalogo.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    IRepository<T> GetRepository<T>() where T : class;
    Task<bool> Commit();
    void Dispose();
}