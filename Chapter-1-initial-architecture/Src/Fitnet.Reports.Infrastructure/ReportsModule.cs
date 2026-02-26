namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using DataAccess;
using GenerateNewPassesRegistrationsPerMonthReport;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

public static class ReportsModule
{
    public static IServiceCollection AddReports(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddNewPassesRegistrationsPerMonthReport();
        services.AddDbContext<ReportsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Reports")));

        return services;
    }

    public static IApplicationBuilder UseReports(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder;
}
