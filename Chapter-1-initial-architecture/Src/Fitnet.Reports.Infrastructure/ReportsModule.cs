namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using DataAccess;
using GenerateNewPassesRegistrationsPerMonthReport;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class ReportsModule
{
    internal static IServiceCollection AddReports(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddNewPassesRegistrationsPerMonthReport();

        return services;
    }

    internal static IApplicationBuilder UseReports(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder;
}
