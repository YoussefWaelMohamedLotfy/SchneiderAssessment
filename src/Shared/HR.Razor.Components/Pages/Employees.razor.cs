using HR.Contracts.EmployeeContracts;

namespace HR.Razor.Components.Pages;

public sealed partial class Employees
{
    private List<GetEmployeeDTO> _employees;

    protected override async Task OnInitializedAsync()
    {
        var response = await _hrClient.Employees.GetAllEmployeesAsync();

        if (response.IsSuccessStatusCode)
        {
            _employees = response.Content!;
        }
    }
}