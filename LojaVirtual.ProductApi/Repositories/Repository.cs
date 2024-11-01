using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVPShop.ProductApi.Infrastructure;

namespace MVPShop.ProductApi.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    
    protected AppDbContext _context;
    
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().Take(20).AsNoTracking().ToListAsync();
        
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> PostAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public async Task<T> PutAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        // Identifica a chave primária (Id) usando reflexo, caso a entidade tenha essa propriedade
        var entityKey = _context.Entry(entity).Property("Id").CurrentValue;
        var trackedEntity = _context.Set<T>().Local.FirstOrDefault(e => 
            _context.Entry(e).Property("Id").CurrentValue.Equals(entityKey));

        if (trackedEntity != null && trackedEntity != entity)
        {
            // Desanexa a entidade rastreada para evitar conflito
            _context.Entry(trackedEntity).State = EntityState.Detached;
        }

        // Atualiza o estado para Modified e salva as alterações
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }



    public async Task<T> DeleteAsync(int id)
    {
        var entityToDelete = _context.Set<T>().Find(id);
        if (entityToDelete == null) throw new ArgumentNullException(nameof(entityToDelete));
        _context.Set<T>().Remove(entityToDelete);
        _context.SaveChanges();
        return entityToDelete;
    }
}