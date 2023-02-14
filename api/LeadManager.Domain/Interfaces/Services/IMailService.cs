namespace LeadManager.Domain.Interfaces.Services;

public interface IMailService
{
    void SendMail(string to, string subject, string content);
}
