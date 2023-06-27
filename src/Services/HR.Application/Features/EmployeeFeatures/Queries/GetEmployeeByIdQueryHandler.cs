using HR.Contracts.EmployeeContracts;
using HR.Persistence.Data;

using MediatR;

namespace HR.Application.Features.EmployeeFeatures.Queries;

public sealed record GetEmployeeByIdQuery(Guid Id) : IRequest<GetEmployeeDTO?>;

internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeDTO?>
{
    private readonly AppDbContext _context;

    public GetEmployeeByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetEmployeeDTO?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

        return employee is null
            ? null
            : new()
        {
            ID = employee.ID,
            Name = employee.Name,
            AnnualVacationRemaining = employee.AnnualVacationRemaining,
            SickVacationRemaining = employee.SickVacationRemaining
        };
    }
}
