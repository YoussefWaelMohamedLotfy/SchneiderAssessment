using System.Reflection;

using HR.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace HR.Persistence.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<VacationRequest> VacationRequests { get; set; } = default!;
    public DbSet<VacationType> VacationTypes { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
