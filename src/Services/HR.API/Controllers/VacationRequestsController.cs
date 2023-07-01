using HR.Application.Features.VacationRequestFeatures.Commands;
using HR.Application.Features.VacationRequestFeatures.Queries;
using HR.Contracts.VacationRequestContracts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class VacationRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VacationRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets a single Vacation Request by ID
    /// </summary>
    /// <param name="id">Unique Identifier of Vacation Request</param>
    /// <param name="ct"></param>
    /// <returns>The requested Vacation Request</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVacationRequestById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetVacationRequestByIdQuery(id), ct);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new Vacation Request for an Employee
    /// </summary>
    /// <param name="request">New Vacation Request Body</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateNewVacationRequest(CreateVacationRequestDTO request, CancellationToken ct)
    {
        var result = await _mediator.Send(new CreateVacationRequestCommand(request), ct);
        return result is not null ? CreatedAtAction(nameof(GetVacationRequestById), new { id = result.ID }, result)
            : BadRequest();
    }
}
