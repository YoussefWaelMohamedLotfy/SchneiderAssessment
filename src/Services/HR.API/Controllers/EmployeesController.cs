﻿using HR.Application.Features.EmployeeFeatures.Queries;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace HR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all Employees from Data store
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees(CancellationToken ct)
        => Ok(await _mediator.Send(new GetAllEmployeesQuery(), ct));

    /// <summary>
    /// Gets a single Employee by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetEmployeeByIdQuery(id), ct);
        return result is not null ? Ok(result) : NotFound();
    }
}
