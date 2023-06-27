using HR.Application.Features.VacationRequestFeatures.Commands;
using HR.Contracts.VacationRequestContracts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacationRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VacationRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVacationRequestById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(id, ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewVacationRequest(CreateVacationRequestDTO request, CancellationToken ct)
    {
        var result = await _mediator.Send(new CreateVacationRequestCommand(request), ct);
        return CreatedAtAction(nameof(GetVacationRequestById), new { id = result.ID }, result);
    }
}
