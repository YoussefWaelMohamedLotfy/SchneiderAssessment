using HR.Contracts.EmployeeContracts;
using HR.Contracts.VacationRequestContracts;
using HR.Contracts.VacationTypeContracts;

using Microsoft.AspNetCore.Components;

namespace HR.Razor.Components.Pages;

public sealed partial class EmployeeDetails
{
    [Parameter]
    public Guid EmployeeId { get; init; }

    private GetEmployeeDTO _employee;

    private CreateVacationRequestDTO _newVacationrequest;
    private List<GetVacationTypeDTO> _vacationTypes;

    private string DaysToBeDeducted;

    protected override async Task OnInitializedAsync()
    {
        _newVacationrequest = new()
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(1),
        };
        CalculateDaysToBeDeducted();

        var response = await _hrClient.VacationTypes.GetAllVacationTypesAsync();
        var employeeResponse = await _hrClient.Employees.GetEmployeeById(EmployeeId);

        if (response.IsSuccessStatusCode)
        {
            _vacationTypes = response.Content!;
        }

        if (employeeResponse.IsSuccessStatusCode)
        {
            _employee = employeeResponse.Content!;
        }
    }

    private async Task SubmitNewVacationRequest()
    {
        _newVacationrequest.RequestingEmployeeId = EmployeeId.ToString();
        var response = await _hrClient.VacationRequests.CreateNewVacationRequestAsync(_newVacationrequest);

        if (response.IsSuccessStatusCode)
        {
            if (_newVacationrequest.VacationTypeId == 1) // Annual
            {
                _employee.AnnualVacationRemaining -= int.Parse(DaysToBeDeducted);
            }
            else if (_newVacationrequest.VacationTypeId == 2) // Sick
            {
                _employee.SickVacationRemaining -= int.Parse(DaysToBeDeducted);
            }
        }
    }

    private void CalculateDaysToBeDeducted()
    {
        DaysToBeDeducted = GetBusinessDays(_newVacationrequest.StartDate, _newVacationrequest.EndDate).ToString();
    }

    private int GetBusinessDays(DateTimeOffset firstDay, DateTimeOffset lastDay, params DateTimeOffset[] bankHolidays)
    {
        firstDay = firstDay.Date;
        lastDay = lastDay.Date;
        if (firstDay > lastDay)
            throw new ArgumentException("Incorrect last day " + lastDay);

        TimeSpan span = lastDay - firstDay;
        int businessDays = span.Days + 1;
        int fullWeekCount = businessDays / 7;

        // find out if there are weekends during the time exceedng the full weeks
        if (businessDays > fullWeekCount * 7)
        {
            // we are here to find out if there is a 1-day or 2-days weekend
            // in the time interval remaining after subtracting the complete weeks
            int firstDayOfWeek = (int)firstDay.DayOfWeek;
            int lastDayOfWeek = (int)lastDay.DayOfWeek;

            if (lastDayOfWeek < firstDayOfWeek)
                lastDayOfWeek += 7;

            if (firstDayOfWeek <= 6)
            {
                if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                    businessDays -= 2;
                else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                    businessDays -= 1;
            }
            else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                businessDays -= 1;
        }

        // subtract the weekends during the full weeks in the interval
        businessDays -= fullWeekCount + fullWeekCount;

        // subtract the number of bank holidays during the time interval
        foreach (DateTimeOffset bankHoliday in bankHolidays)
        {
            DateTimeOffset bh = bankHoliday.Date;

            if (firstDay <= bh && bh <= lastDay)
                --businessDays;
        }

        return businessDays;
    }
}