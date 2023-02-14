using LeadManager.Domain.Entities;

namespace LeadManager.Domain.Interfaces.Repositories;

public interface ILeadRepository : IRepository<Lead>
{
    Task<Lead?> GetById(Guid id);
    Task<bool> JobIdIsInUse(uint jobId);
}
