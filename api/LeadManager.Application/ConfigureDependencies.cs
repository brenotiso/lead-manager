using FluentValidation.Results;
using LeadManager.Application.Handlers.Leads;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Messaging.Lead;
using LeadManager.Domain.Queries;
using LeadManager.Domain.Queries.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManager.Application;

public static class ConfigureDependencies
{
    public static void AddApplicaitionDependencyInjection(this IServiceCollection services)
    {
        // Queries
        services.AddScoped<IRequestHandler<SearchLeadQuery, IEnumerable<SearchLeadResultDto>>, SearchLeadQueryHandler>();

        // Commands
        services.AddScoped<IRequestHandler<CreateLeadCommand, ValidationResult>, CreateLeadCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateLeadCommand, ValidationResult>, UpdateLeadCommandHandler>();

        // Events
        services.AddScoped<INotificationHandler<LeadCreatedEvent>, LeadCreatedEventHandler>();
    }
}
