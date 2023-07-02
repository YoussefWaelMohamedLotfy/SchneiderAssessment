using HR.Domain.Common;

namespace HR.Domain.Entities;

public sealed class Employee : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;

    public int AnnualVacationRemaining { get; set; }

    public int SickVacationRemaining { get; set; }

    public List<VacationRequest> VacationRequests { get; set; } = default!;
}
