namespace LeadManager.Domain.Entities;

public class Contact : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Lead Lead { get; set; }
}
