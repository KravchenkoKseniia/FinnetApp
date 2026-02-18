namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using GenerateNewPassesRegistrationsPerMonthReport;
using Microsoft.AspNetCore.Routing;

public static class ReportsEndpoints
{
    public static void MapReports(this IEndpointRouteBuilder app) =>
        app.MapGenerateNewPassesRegistrationsPerMonthReport();
}
