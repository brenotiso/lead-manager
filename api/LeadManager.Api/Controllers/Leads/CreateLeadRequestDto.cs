namespace LeadManager.Api.Controllers.Leads;

public class CreateLeadRequestDto
{
    public uint JobId { get; set; }
    public CreateContactRequestDto Contact { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}
