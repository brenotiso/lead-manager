using AutoMapper;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Queries;

namespace LeadManager.Api.Controllers.Leads;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<CreateContactRequestDto, CreateContactCommand>();
        CreateMap<CreateLeadRequestDto, CreateLeadCommand>();

        CreateMap<UpdateLeadRequestDto, UpdateLeadCommand>();

        CreateMap<SearchLeadRequestDto, SearchLeadQuery>();
    }
}
