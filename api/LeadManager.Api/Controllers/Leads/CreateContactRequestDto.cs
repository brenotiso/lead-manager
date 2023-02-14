namespace LeadManager.Api.Controllers.Leads;

public class CreateContactRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
