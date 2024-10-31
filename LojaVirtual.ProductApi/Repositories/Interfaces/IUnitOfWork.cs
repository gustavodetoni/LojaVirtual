namespace LojaVirtual.ProductApi.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IRepository<T> GetRepository<T>() where T : class;
        Task CommitAsync();
    }
}
