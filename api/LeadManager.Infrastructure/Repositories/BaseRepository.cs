using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : class, IAggregateRoot
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;
    protected RepositoryBase(DbContext dbContext)
    {
        _context = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual T Add(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public virtual void Delete(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
    }

    public virtual void Update(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
