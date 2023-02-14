using LeadManager.Domain.Commands.Leads.Validations;

namespace LeadManager.Domain.Commands.Leads;

public class CreateLeadCommand : Command
{
    public uint JobId { get; set; }
    public CreateContactCommand Contact { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public override bool IsInvalid()
    {
        ValidationResult = new CreateLeadCommandValidation().Validate(this);
        return base.IsInvalid();
    }
}
