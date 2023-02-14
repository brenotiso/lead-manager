using LeadManager.Domain.Enuns;

namespace LeadManager.Api.Controllers.Leads;

public class UpdateLeadRequestDto
{
    public LeadStatus Status { get; set; }
}
