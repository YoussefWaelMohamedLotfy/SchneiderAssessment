using HR.SDK.Configuration;
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

        return services;
    }
}
