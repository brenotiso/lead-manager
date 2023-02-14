using AutoMapper;
using LeadManager.Domain.Commands.Leads;
using LeadManager.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.Api.Controllers.Leads;

[ApiController]
[Route("leads")]
public class LeadController : CustomControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LeadController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] SearchLeadRequestDto dto)
    {
        var result = await _mediator.Send(_mapper.Map<SearchLeadQuery>(dto));
        return CustomResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateLeadRequestDto dto)
    {
        var result = await _mediator.Send(_mapper.Map<CreateLeadCommand>(dto));
        return CustomResponse(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateLeadRequestDto dto)
    {
        var command = _mapper.Map<UpdateLeadCommand>(dto);
        command.Id = id;

        var result = await _mediator.Send(command);
        return CustomResponse(result);
    }
}
