using HR.Contracts.VacationTypeContracts;
using HR.Persistence.Data;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace HR.Application.Features.VacationTypeFeatures.Queries;

public sealed record GetAllVacationTypesQuery() : IRequest<IEnumerable<GetVacationTypeDTO>>;

internal sealed class GetAllVacationTypesQueryHandler : IRequestHandler<GetAllVacationTypesQuery, IEnumerable<GetVacationTypeDTO>>
{
    private readonly AppDbContext _context;

    public GetAllVacationTypesQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetVacationTypeDTO>> Handle(GetAllVacationTypesQuery request, CancellationToken cancellationToken)
    {
        var vacationTypes = await _context.VacationTypes.ToListAsync(cancellationToken);

        if (!vacationTypes.Any()) 
        {
            return Enumerable.Empty<GetVacationTypeDTO>();
        }

        List<GetVacationTypeDTO> result = new(2);

        foreach (var item in vacationTypes)
        {
            result.Add(new() { ID = item.ID, Name = item.Name });
        }

        return result;
    }
}
