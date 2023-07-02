using HR.Contracts.VacationTypeContracts;
using HR.SDK.Interfaces;

using Refit;

namespace HR.SDK.Endpoints;

public sealed class VacationTypes
{
    private readonly IVacationTypesClient _client;

    public VacationTypes(IVacationTypesClient client)
    {
        _client = client;
    }

    public async Task<IApiResponse<List<GetVacationTypeDTO>>> GetAllVacationTypesAsync()
    {
        return await _client.GetAllVacationTypes();
    }
}
