using HR.Domain.Common;

namespace HR.Domain.Entities;

public sealed class VacationType : BaseEntity<int>
{
    public string Name { get; set; } = default!;

    public List<VacationRequest> Requests { get; set; } = default!;
}
