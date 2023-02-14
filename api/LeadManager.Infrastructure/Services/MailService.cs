using LeadManager.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace LeadManager.Infrastructure.Services;

public class MailService : IMailService
{
    private readonly ILogger<MailService> _logger;

    public MailService(ILogger<MailService> logger)
    {
        _logger = logger;
    }

    public void SendMail(string to, string subject, string content)
    {
        _logger.LogInformation("Sending mail to {to} with subject {subject}\nContent:\n{content}", to, subject, content);
    }
}
