using System.Reflection;

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


        return services;
    }
}
