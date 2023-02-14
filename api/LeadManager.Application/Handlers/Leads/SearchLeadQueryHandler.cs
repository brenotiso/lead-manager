using AutoMapper;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Queries;
using LeadManager.Domain.Queries.Results;
using LeadManager.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Application.Handlers.Leads;

public class SearchLeadQueryHandler : IRequestHandler<SearchLeadQuery, IEnumerable<SearchLeadResultDto>>
{
    private readonly IMapper _mapper;
    private readonly ReadContext _readContext;

    public SearchLeadQueryHandler(IMapper mapper, ReadContext readContext)
    {
        _mapper = mapper;
        _readContext = readContext;
    }

    public async Task<IEnumerable<SearchLeadResultDto>> Handle(SearchLeadQuery request, CancellationToken cancellationToken)
    {
        var leads = await _readContext
            .Set<Lead>()
            .Where(l => l.Status == request.Status)
            .Include(l => l.Contact)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<SearchLeadResultDto>>(leads);
    }
}
