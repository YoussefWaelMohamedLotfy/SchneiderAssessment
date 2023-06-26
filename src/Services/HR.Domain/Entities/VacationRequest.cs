using HR.Domain.Common;

namespace HR.Domain.Entities;

public sealed class VacationRequest : BaseEntity<Guid>
{
    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public int RequestingEmployeeId { get; set; }

    public Employee RequestingEmployee { get; set; } = default!;

    public int VacationTypeId { get; set; }

    public VacationType VacationType { get; set; } = default!;

}
