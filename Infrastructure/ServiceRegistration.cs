using Core.Contracts;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddScoped<IDbConnection>(_ => new SqlConnection(connectionString: configuration.GetConnectionString("DbConnection")))
            .AddScoped<IUserRepository, UserRepository>();
    }
}
