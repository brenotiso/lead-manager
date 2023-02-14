using LeadManager.Domain.Interfaces.Repositories;
using LeadManager.Domain.Interfaces.Services;
using LeadManager.Infrastructure.Contexts;
using LeadManager.Infrastructure.Repositories;
using LeadManager.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManager.Infrastructure;

public static class ConfigureDepencies
{
    public static void AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<CommandContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("WriteLeadConnection")));
        // Read context - poderia ser outra base de dados
        services.AddDbContext<ReadContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("WriteLeadConnection")));
        // Para conectar com um SQL Server basta utilizar as configurações abaixo
        //services.AddDbContext<CommandContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("WriteLeadConnection")));
        //services.AddDbContext<ReadContext>(options =>
        //    options.UseSqlite(configuration.GetConnectionString("WriteLeadConnection")));

        // Infra - Data
        services.AddScoped<CommandContext>();
        services.AddScoped<ILeadRepository, LeadRepository>();

        // Infra - Services
        services.AddScoped<IMailService, MailService>();
    }
}
