using HR.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace HR.Persistence.Data;

public static class AppDbContextExtensions
{
    public static void Seed(this AppDbContext context, ILogger<AppDbContext> logger)
    {
        if (!context.VacationTypes.Any())
        {
            context.VacationTypes.AddRange(new[]
            {
                new VacationType { Name = "Annual" },
                new VacationType { Name = "Sick" },
            });
            context.SaveChanges();
        }

        if (!context.Employees.Any())
        {
            context.Employees.AddRange(new[]
            {
                new Employee { Name = "Ahmed" },
                new Employee { Name = "Mohamed" },
                new Employee { Name = "Khaled" },
            });
            context.SaveChanges();
        }

        logger.LogInformation("Completed Seeding of context...");
    }
}
