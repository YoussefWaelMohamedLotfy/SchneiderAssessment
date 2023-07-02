using HR.Contracts.VacationRequestContracts;
using HR.Contracts.VacationTypeContracts;

namespace HR.Razor.Components.Pages;

public partial class Employees
{
    private CreateVacationRequestDTO _newVacationrequest;
    private List<GetVacationTypeDTO> _vacationTypes;

    public Employees()
    {
        _newVacationrequest = new()
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
        };
    }

    protected override async Task OnInitializedAsync()
    {
        var response = await _hrClient.VacationTypes.GetAllVacationTypesAsync();

        if (response.IsSuccessStatusCode)
        {
            _vacationTypes = response.Content!;
        }

    }

    private async void SubmitNewVacationRequest()
    {
        var response = await _hrClient.VacationRequests.CreateNewVacationRequestAsync(_newVacationrequest);
    }
}