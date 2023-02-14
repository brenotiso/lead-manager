using AutoMapper;
using FluentValidation.Results;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces.Repositories;
using LeadManager.Domain.Messaging.Lead;
using MediatR;

namespace LeadManager.Application.Handlers.Leads;

public class CreateLeadCommandHandler : CommandHandler, IRequestHandler<CreateLeadCommand, ValidationResult>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILeadRepository _leadRepository;

    public CreateLeadCommandHandler(IMediator mediator, IMapper mapper, ILeadRepository leadRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _leadRepository = leadRepository;
    }

    public async Task<ValidationResult> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        if (request.IsInvalid())
            return request.ValidationResult;

        if (await _leadRepository.JobIdIsInUse(request.JobId))
        {
            AddError("The JobId has already been taken.");
            return ValidationResult;
        }

        var lead = _mapper.Map<Lead>(request);
        lead.CreateAt = DateTime.Now;

        _leadRepository.Add(lead, cancellationToken);

        await _mediator.Publish(_mapper.Map<LeadCreatedEvent>(lead), cancellationToken);
        await _leadRepository.SaveChanges(cancellationToken);

        return ValidationResult;
    }
}
