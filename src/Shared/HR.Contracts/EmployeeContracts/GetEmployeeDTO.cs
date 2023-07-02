namespace HR.Contracts.EmployeeContracts;

public sealed class GetEmployeeDTO
{
    public Guid ID { get; set; }

    public string Name { get; set; } = default!;

    public int AnnualVacationRemaining { get; set; }

    public int SickVacationRemaining { get; set; }
}
