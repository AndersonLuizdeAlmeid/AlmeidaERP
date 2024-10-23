using AlmeidaERP.Core.Factory;
using AlmeidaERP.Core.Factory.Interfaces;

namespace AlmeidaERP.WebApi.DependecyInjections;
public static class DatabaseInjection
{
    public static IServiceCollection AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDatabaseFactory, DatabaseFactory>(sr => new DatabaseFactory(configuration.GetConnectionString("DefaultConnection")!));

        return services;
    }
}