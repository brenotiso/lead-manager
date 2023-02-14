using FluentValidation.Results;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Enuns;
using LeadManager.Domain.Interfaces.Repositories;
using MediatR;

namespace LeadManager.Application.Handlers.Leads;

public class UpdateLeadCommandHandler : CommandHandler, IRequestHandler<UpdateLeadCommand, ValidationResult>
{
    private readonly ILeadRepository _leadRepository;

    public UpdateLeadCommandHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }

    public async Task<ValidationResult> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        if (request.IsInvalid())
            return request.ValidationResult;

        var lead = await _leadRepository.GetById(request.Id);

        if (lead is null)
        {
            AddError("Lead not found.");
            return ValidationResult;
        }

        if (lead.Status != LeadStatus.Invited)
        {
            AddError("Lead already analyzed.");
            return ValidationResult;
        }

        lead.Status = request.Status;

        if (lead.Status == LeadStatus.Accepted)
            lead.SetAcceptedPrice();

        _leadRepository.Update(lead, cancellationToken);

        await _leadRepository.SaveChanges(cancellationToken);
        return ValidationResult;
    }
}
