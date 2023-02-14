namespace LeadManager.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : IAggregateRoot
{
    T Add(T entity, CancellationToken cancellationToken = default);
    void Delete(T entity, CancellationToken cancellationToken = default);
    void Update(T entity, CancellationToken cancellationToken = default);
    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}
