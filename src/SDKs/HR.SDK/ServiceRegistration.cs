using HR.SDK.Configuration;
using HR.SDK.Endpoints;
using HR.SDK.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using Refit;

namespace HR.SDK;

public static class ServiceRegistration
{
    public static IServiceCollection AddHRApiClients(this IServiceCollection services, Action<HRApiOptions> options)
    {
        HRApiOptions apiOptions = new();
        options?.Invoke(apiOptions);

        services.AddRefitClient<IVacationRequestsClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiOptions.BaseUrl));

        services.AddRefitClient<IVacationTypesClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiOptions.BaseUrl));

        services.AddRefitClient<IEmployeesClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiOptions.BaseUrl));

        services.AddTransient<VacationRequests>()
            .AddTransient<VacationTypes>()
            .AddTransient<Employees>()
            .AddTransient<HRApiClient>();

        return services;
    }
}
