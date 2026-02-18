namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.GenerateNewPassesRegistrationsPerMonthReport;

using Application;
using Application.GenerateNewPassesRegistrationsPerMonthReport;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

internal static class GenerateNewPassesPerMonthReportModule
{
    internal static IServiceCollection AddNewPassesRegistrationsPerMonthReport(this IServiceCollection services)
    {
        services.AddSingleton<INewPassesRegistrationPerMonthReportDataRetriever, NewPassesRegistrationPerMonthReportDataRetriever>();
        services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        services.AddScoped<IReportsService, ReportsService>();

        return services;
    }
}
