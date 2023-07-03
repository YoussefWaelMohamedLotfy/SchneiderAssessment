using HR.Contracts.EmployeeContracts;
using HR.Persistence.Data;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.EmployeeFeatures.Queries;

public sealed record GetAllEmployeesQuery() : IRequest<IEnumerable<GetEmployeeDTO>>;

internal sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<GetEmployeeDTO>>
{
    private readonly AppDbContext _context;

    public GetAllEmployeesQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetEmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _context.Employees.ToListAsync(cancellationToken);

        if (!employees.Any())
        {
            return Enumerable.Empty<GetEmployeeDTO>();
        }

        List<GetEmployeeDTO> result = new(3);

        result.AddRange(employees.Select(x => new GetEmployeeDTO()
        { 
            ID = x.ID,
            Name = x.Name,
            AnnualVacationRemaining = x.AnnualVacationRemaining,
            SickVacationRemaining = x.SickVacationRemaining
        }));

        return result;
    }
}
