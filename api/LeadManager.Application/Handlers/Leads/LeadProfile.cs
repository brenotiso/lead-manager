using AutoMapper;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Messaging.Lead;
using LeadManager.Domain.Queries.Results;

namespace LeadManager.Application.Handlers.Leads;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<CreateLeadCommand, Lead>();
        CreateMap<CreateContactCommand, Contact>();

        CreateMap<Lead, LeadCreatedEvent>()
            .ForMember(dest => dest.AggregateId, map => map.MapFrom(l => l.Id));
        CreateMap<Contact, ContactCreatedEvent>();

        CreateMap<Lead, SearchLeadResultDto>();
        CreateMap<Contact, ContactResultDto>();
    }
}
