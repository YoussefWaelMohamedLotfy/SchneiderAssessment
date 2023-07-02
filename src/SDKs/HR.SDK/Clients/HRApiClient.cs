namespace HR.SDK.Endpoints;

public sealed class HRApiClient
{
    public VacationRequests VacationRequests { get; }
    public Employees Employees { get; }
    public VacationTypes VacationTypes { get; }

    public HRApiClient(VacationRequests vacationRequests,
                       Employees employees,
                       VacationTypes vacationTypes)
    {
        VacationRequests = vacationRequests;
        Employees = employees;
        VacationTypes = vacationTypes;
    }
}
