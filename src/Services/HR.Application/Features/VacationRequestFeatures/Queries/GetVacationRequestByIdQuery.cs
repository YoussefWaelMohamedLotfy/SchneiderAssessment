using HR.Contracts.VacationRequestContracts;

using MediatR;

namespace HR.Application.Features.VacationRequestFeatures.Queries;

public sealed record GetVacationRequestByIdQuery(Guid Id) : IRequest<GetVacationRequestDTO?>;
