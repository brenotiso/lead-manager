using FluentValidation;

namespace LeadManager.Domain.Commands.Leads.Validations;

public class UpdateLeadCommandValidation : AbstractValidator<UpdateLeadCommand>
{
    public UpdateLeadCommandValidation()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Id");

        RuleFor(c => c.Status)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Status")
            .IsInEnum()
            .WithMessage("The Status must match the enum");
    }
}