using HR.Contracts.VacationRequestContracts;
using HR.Persistence.Data;

using MediatR;

namespace HR.Application.Features.VacationRequestFeatures.Queries;

internal sealed class GetVacationRequestByIdQueryHandler : IRequestHandler<GetVacationRequestByIdQuery, GetVacationRequestDTO?>
{
    private readonly AppDbContext _context;

    public GetVacationRequestByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetVacationRequestDTO?> Handle(GetVacationRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var vacationRequest = await _context.VacationRequests.FindAsync(new object[] { request.Id }, cancellationToken);

        return vacationRequest is null
            ? null
            : new()
        {
            ID = vacationRequest.ID,
            StartDate = vacationRequest.StartDate,
            EndDate = vacationRequest.EndDate,
            RequestingEmployeeId = vacationRequest.RequestingEmployeeId,
            VacationTypeId = vacationRequest.VacationTypeId
        };
    }
}
