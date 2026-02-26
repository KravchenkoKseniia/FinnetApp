namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.GenerateNewPassesRegistrationsPerMonthReport;

using System.Text.Json;
using Application;
using Domain;
using EvolutionaryArchitecture.Fitnet.Reports.Application.GenerateNewPassesRegistrationsPerMonthReport;
using Outbox;
using Persistence;

internal class ReportsService(INewPassesRegistrationPerMonthReportDataRetriever dataRetriever, ReportsDbContext context) : IReportsService
{
    public async Task<NewPassesRegistrationsPerMonthResponse> GenerateNewPassesRegistrationsPerMonthReportAsync(
        CancellationToken cancellationToken)
    {
        var reportData = await dataRetriever.GetReportDataAsync(cancellationToken);
        return NewPassesRegistrationsPerMonthResponse.Create(reportData);
    }
    public async Task<Guid> RequestReportGenerationAsync(CancellationToken cancellationToken)
    {
        var report = ReportGeneration.Create();
        var outboxMessage = Outbox.Create("ReportGenerationRequested", JsonSerializer.Serialize(new { ReportId = report.Id }));
        context.ReportGenerations.Add(report);
        context.OutboxMessages.Add(outboxMessage);
        await context.SaveChangesAsync(cancellationToken);
        return report.Id;
    }
}
