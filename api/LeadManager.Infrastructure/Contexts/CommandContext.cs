using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeadManager.Infrastructure.Contexts;

public class CommandContext : DbContext
{
    public CommandContext(DbContextOptions<CommandContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
