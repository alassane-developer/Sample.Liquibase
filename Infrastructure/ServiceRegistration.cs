using Core.Contracts;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddScoped<IDbConnection>(_ => new NpgsqlConnection(configuration.GetConnectionString("Default")))
            .AddScoped<IUserRepository, UserRepository>();
    }
}
