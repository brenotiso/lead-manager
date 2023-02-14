using LeadManager.Domain.Enuns;

namespace LeadManager.Api.Controllers.Leads;

public class SearchLeadRequestDto
{
    public LeadStatus Status { get; set; }
}
