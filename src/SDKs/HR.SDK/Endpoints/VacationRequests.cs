using HR.Contracts.VacationRequestContracts;
using HR.SDK.Interfaces;

using Refit;

namespace HR.SDK.Endpoints;

public sealed class VacationRequests
{
    private readonly IVacationRequestsClient _client;

    public VacationRequests(IVacationRequestsClient client)
        => _client = client;

    public async Task<IApiResponse<GetVacationRequestDTO>> GetVacationRequestByIDAsync(Guid id)
        => await _client.GetVacationRequestById(id);

    public async Task<IApiResponse<GetVacationRequestDTO>> CreateNewVacationRequestAsync(CreateVacationRequestDTO request)
        => await _client.CreateNewVacationRequest(request);
}
