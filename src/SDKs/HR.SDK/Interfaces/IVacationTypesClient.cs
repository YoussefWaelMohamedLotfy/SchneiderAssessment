using HR.Contracts.VacationTypeContracts;

using Refit;

namespace HR.SDK.Interfaces;

public interface IVacationTypesClient
{
    [Get("/VacationTypes")]
    Task<IApiResponse<List<GetVacationTypeDTO>>> GetAllVacationTypes();
}
