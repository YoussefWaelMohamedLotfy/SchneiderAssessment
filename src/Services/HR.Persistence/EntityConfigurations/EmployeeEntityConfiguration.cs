using HR.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Persistence.EntityConfigurations;

internal sealed class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.AnnualVacationRemaining).HasDefaultValue(11);
        builder.Property(x => x.SickVacationRemaining).HasDefaultValue(10);
    }
}
