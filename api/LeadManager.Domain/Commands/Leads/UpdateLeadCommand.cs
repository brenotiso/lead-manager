using LeadManager.Domain.Commands.Leads.Validations;
using LeadManager.Domain.Enuns;

namespace LeadManager.Domain.Commands.Leads;

public class UpdateLeadCommand : Command
{
    public Guid Id { get; set; }
    public LeadStatus Status { get; set; }

    public override bool IsInvalid()
    {
        ValidationResult = new UpdateLeadCommandValidation().Validate(this);
        return base.IsInvalid();
    }
}
