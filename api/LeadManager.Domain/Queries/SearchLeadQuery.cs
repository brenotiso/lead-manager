using LeadManager.Domain.Enuns;
using LeadManager.Domain.Queries.Results;
using MediatR;

namespace LeadManager.Domain.Queries;

public class SearchLeadQuery : IRequest<IEnumerable<SearchLeadResultDto>>
{
    public LeadStatus Status { get; set; }
}
