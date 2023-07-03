using HR.Contracts.EmployeeContracts;
using HR.SDK.Interfaces;

using Refit;

namespace HR.SDK.Endpoints;

public sealed class Employees
{
    private readonly IEmployeesClient _client;

    public Employees(IEmployeesClient client)
        => _client = client;

    public async Task<IApiResponse<List<GetEmployeeDTO>>> GetAllEmployeesAsync()
        => await _client.GetAllEmployees();

    public async Task<IApiResponse<GetEmployeeDTO>> GetEmployeeById(Guid id)
        => await _client.GetEmployeeById(id);
}
