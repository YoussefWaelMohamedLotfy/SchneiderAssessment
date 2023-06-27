using HR.Contracts.VacationRequestContracts;
using HR.Domain.Entities;
using HR.Persistence.Data;

using MediatR;

namespace HR.Application.Features.VacationRequestFeatures.Commands;

internal sealed class CreateVacationRequestCommandHandler : IRequestHandler<CreateVacationRequestCommand, GetVacationRequestDTO?>
{
    private readonly AppDbContext _context;

    public CreateVacationRequestCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetVacationRequestDTO?> Handle(CreateVacationRequestCommand request, CancellationToken cancellationToken)
    {
        var newRequest = new VacationRequest
        {
            StartDate = request.VacationRequestInput.StartDate,
            EndDate = request.VacationRequestInput.EndDate,
            VacationTypeId = request.VacationRequestInput.VacationTypeId,
            RequestingEmployeeId = request.VacationRequestInput.RequestingEmployeeId
        };

        await _context.VacationRequests.AddAsync(newRequest, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);

        return new GetVacationRequestDTO
        {
            ID = newRequest.ID,
            StartDate = newRequest.StartDate,
            EndDate = newRequest.EndDate,
            VacationTypeId = newRequest.VacationTypeId,
            RequestingEmployeeId = newRequest.RequestingEmployeeId
        };
    }
}
