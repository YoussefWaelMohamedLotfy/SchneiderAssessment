using HR.Contracts.VacationRequestContracts;

using MediatR;

namespace HR.Application.Features.VacationRequestFeatures.Commands;

public sealed record CreateVacationRequestCommand(CreateVacationRequestDTO VacationRequestInput) : IRequest<GetVacationRequestDTO?>;
