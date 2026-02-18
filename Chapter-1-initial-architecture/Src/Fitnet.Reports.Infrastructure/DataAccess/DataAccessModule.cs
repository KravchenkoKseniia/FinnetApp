namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.DataAccess;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ReportsPersistenceOptions>(configuration.GetSection(ReportsPersistenceOptions.SectionName));
        services.AddOptionsWithValidateOnStart<ReportsPersistenceOptions>();
        services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

        return services;
    }
}
