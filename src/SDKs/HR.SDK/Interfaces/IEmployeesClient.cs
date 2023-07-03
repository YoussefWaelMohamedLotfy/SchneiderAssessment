using HR.Contracts.EmployeeContracts;

using Refit;

namespace HR.SDK.Interfaces;

public interface IEmployeesClient
{
    [Get("/Employees")]
    Task<IApiResponse<List<GetEmployeeDTO>>> GetAllEmployees();

    [Get("/Employees/{id}")]
    Task<IApiResponse<GetEmployeeDTO>> GetEmployeeById(Guid id);
}
