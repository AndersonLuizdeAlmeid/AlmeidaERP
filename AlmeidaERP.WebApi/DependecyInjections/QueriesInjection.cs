namespace AlmeidaERP.WebApi.DependecyInjections;
public static class QueriesInjection
{
    public static IServiceCollection AddQueriesInjection(this IServiceCollection services)
    {
        //services.AddScoped<ICityQueries, CityQueries>()

        return services;
    }
}