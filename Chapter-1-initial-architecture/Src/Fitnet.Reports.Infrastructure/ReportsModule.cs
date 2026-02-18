namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using DataAccess;
using GenerateNewPassesRegistrationsPerMonthReport;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ReportsModule
{
    public static IServiceCollection AddReports(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddNewPassesRegistrationsPerMonthReport();

        return services;
    }

    public static IApplicationBuilder UseReports(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder;
}
