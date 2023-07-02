namespace HR.Contracts.VacationRequestContracts;

public class CreateVacationRequestDTO
{
    public string RequestingEmployeeId { get; set; } = default!;

    public int VacationTypeId { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }
}
