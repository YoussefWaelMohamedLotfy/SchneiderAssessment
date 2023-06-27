namespace HR.Contracts.VacationTypeContracts;

public sealed class GetVacationTypeDTO
{
    public int ID { get; set; }

    public string Name { get; set; } = default!;
}
