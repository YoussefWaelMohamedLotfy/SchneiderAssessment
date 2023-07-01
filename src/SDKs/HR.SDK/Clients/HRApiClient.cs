namespace HR.SDK.Endpoints;

public sealed class HRApiClient
{
    public VacationRequests VacationRequests { get; }

    public HRApiClient(VacationRequests vacationRequests)
    {
        VacationRequests = vacationRequests;
    }
}
