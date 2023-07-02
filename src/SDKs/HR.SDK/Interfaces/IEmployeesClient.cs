using HR.Contracts.EmployeeContracts;

using Refit;

namespace HR.SDK.Interfaces;

public interface IEmployeesClient
{
    [Get("/Employees/{id}")]
    Task<IApiResponse<GetEmployeeDTO>> GetEmployeeById(Guid id);
}
