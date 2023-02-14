using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces.Repositories;
using LeadManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Repositories;

public class LeadRepository : RepositoryBase<Lead>, ILeadRepository
{
    public LeadRepository(CommandContext dbContext) : base(dbContext)
    {
    }

    public async Task<Lead?> GetById(Guid id)
    {
        return await _dbSet.Where(l => l.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> JobIdIsInUse(uint jobId)
    {
        return await _dbSet.AnyAsync(l => l.JobId == jobId);
    }
}
