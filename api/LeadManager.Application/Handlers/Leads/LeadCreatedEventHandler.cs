using LeadManager.Domain.Interfaces.Services;
using LeadManager.Domain.Messaging.Lead;
using MediatR;

namespace LeadManager.Application.Handlers.Leads;

public class LeadCreatedEventHandler : INotificationHandler<LeadCreatedEvent>
{
    private readonly IMailService _mailService;

    public LeadCreatedEventHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public Task Handle(LeadCreatedEvent notification, CancellationToken cancellationToken)
    {
        _mailService
            .SendMail(notification.Contact.Email, "Lead created", $"New lead created with JobId {notification.JobId}");

        return Task.CompletedTask;
    }
}
