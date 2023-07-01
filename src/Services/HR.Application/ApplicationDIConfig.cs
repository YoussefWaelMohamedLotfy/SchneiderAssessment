using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace HR.Application;

public static class ApplicationDIConfig
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(o =>
        {
            o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
