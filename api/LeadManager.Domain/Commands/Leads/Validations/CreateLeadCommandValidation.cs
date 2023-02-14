using FluentValidation;

namespace LeadManager.Domain.Commands.Leads.Validations;

public class CreateLeadCommandValidation : AbstractValidator<CreateLeadCommand>
{
    public CreateLeadCommandValidation()
    {
        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Description")
            .Length(10, 255)
            .WithMessage("The Description must have between 10 and 255 characters");

        RuleFor(c => c.Suburb)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Suburb")
            .Length(2, 255)
            .WithMessage("The Suburb must have between 2 and 100 characters");

        RuleFor(c => c.Category)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Category")
            .Length(2, 30)
            .WithMessage("The Category must have between 2 and 30 characters");

        RuleFor(c => c.Price)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Price")
            .GreaterThan(0)
            .WithMessage("The Price must bee greater than zero")
            .PrecisionScale(7, 2, true)
            .WithMessage("The Price precision must be less than eight");

        RuleFor(c => c.JobId)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the JobId")
            .GreaterThan((uint)0)
            .WithMessage("The JobId must bee greater than zero");

        RuleFor(c => c.Contact.FirstName)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Contact FirstName")
            .Length(2, 30)
            .WithMessage("The Contact FirstName must have between 2 and 30 characters");

        RuleFor(c => c.Contact.LastName)
           .NotEmpty()
           .WithMessage("Please ensure you have entered the Contact LastName")
           .Length(2, 30)
           .WithMessage("The Contact LastName must have between 2 and 30 characters");

        RuleFor(c => c.Contact.Email)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the Contact Email")
            .Length(2, 50)
            .WithMessage("The Contact Email must have between 2 and 50 characters")
            .EmailAddress()
            .WithMessage("Contact Email is invalid");

        RuleFor(c => c.Contact.PhoneNumber)
           .NotEmpty()
           .WithMessage("Please ensure you have entered the Contact PhoneNumber")
           .Length(8, 15)
           .WithMessage("The Contact LastName must have between 8 and 15 characters");
    }
}
