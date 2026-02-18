namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.GenerateNewPassesRegistrationsPerMonthReport;

using Application;
using Application.GenerateNewPassesRegistrationsPerMonthReport;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

internal static class GenerateNewPassesPerMonthReportEndpoint
{
    internal static void MapGenerateNewPassesRegistrationsPerMonthReport(this IEndpointRouteBuilder app) => app.MapGet(
            ReportsApiPaths.GenerateNewReport, async (
                IReportsService reportsService,
                CancellationToken cancellationToken) =>
            {
                var report =
                    await reportsService.GenerateNewPassesRegistrationsPerMonthReportAsync(cancellationToken);
                return Results.Ok(report);
            })
        .WithSummary("Returns report of all passes registered in a month")
        .WithDescription("This endpoint is used to retrieve all passes that were registered in a given month.")
        .Produces<NewPassesRegistrationsPerMonthResponse>()
        .Produces(StatusCodes.Status500InternalServerError);
}
