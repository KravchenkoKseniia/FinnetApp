namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using GenerateNewPassesRegistrationsPerMonthReport;
using Microsoft.AspNetCore.Routing;

internal static class ReportsEndpoints
{
    internal static void MapReports(this IEndpointRouteBuilder app) =>
        app.MapGenerateNewPassesRegistrationsPerMonthReport();
}
