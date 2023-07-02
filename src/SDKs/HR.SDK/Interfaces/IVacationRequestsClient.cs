using HR.Contracts.VacationRequestContracts;

using Refit;

namespace HR.SDK.Interfaces;

public interface IVacationRequestsClient
{
    [Get("/VacationRequests/{id}")]
    Task<IApiResponse<GetVacationRequestDTO>> GetVacationRequestById(Guid id);

    [Post("/VacationRequests")]
    Task<IApiResponse<GetVacationRequestDTO>> CreateNewVacationRequest([Body] CreateVacationRequestDTO request);
}
