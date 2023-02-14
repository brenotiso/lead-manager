using FluentValidation.Results;
using MediatR;

namespace LeadManager.Domain.Commands;

public class Command : IRequest<ValidationResult>
{
    public ValidationResult ValidationResult { get; set; }

    public virtual bool IsInvalid()
    {
        return !ValidationResult.IsValid;
    }
}
