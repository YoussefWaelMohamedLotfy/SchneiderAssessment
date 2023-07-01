using HR.Application.Features.VacationTypeFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class VacationTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VacationTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all Vacation Types from Datastore
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllVacationTypes(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllVacationTypesQuery(), ct);
        return Ok(result);
    }
}
