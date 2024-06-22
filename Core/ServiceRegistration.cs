using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}
