#pragma warning disable CA1873

namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Outbox;

using System.Text.Json;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

internal sealed class OutboxProcessor(IServiceScopeFactory factory, ILogger<OutboxProcessor> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessOutboxMessagesAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
    private async Task ProcessOutboxMessagesAsync(CancellationToken cancellationToken)
    {
        using var scope = factory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ReportsDbContext>();
        var retriever = scope.ServiceProvider.GetRequiredService<INewPassesRegistrationPerMonthReportDataRetriever>();
        var messages = await dbContext.OutboxMessages
            .Where(m => m.ProcessedAt == null).ToListAsync(cancellationToken);
        foreach (var msg in messages)
        {
            logger.LogInformation("Processing outbox message {MessageId}: {MessageType}", msg.Id, msg.Type);
            if (msg.Type == "ReportGenerationRequested")
            {
                var payload = JsonSerializer.Deserialize<ReportGenerationPayload>(msg.Payload);
                var reportId = payload!.ReportId;
                var saga = await dbContext.ReportGenerationSagas.FirstOrDefaultAsync(s => s.CorrelationId == reportId, cancellationToken);
                if (saga is not null && saga.Status == SagaStatus.Completed)
                {
                    logger.LogInformation("Report generation already completed for {ReportId}, skipping", reportId);
                    msg.ProcessedAt = DateTime.UtcNow;
                    continue;
                }
                try
                {
                    var reportData = await retriever.GetReportDataAsync(cancellationToken);
                    msg.ProcessedAt = DateTime.UtcNow;
                    saga?.MarkAsCompleted();
                    logger.LogInformation("Retrieved report data for {ReportId}: {RecordCount} records", reportId, reportData.Count);
                }
                catch (Exception ex)
                {
                    saga?.MarkAsFailed();
                    logger.LogError(ex, "Error processing report generation for {ReportId}", reportId);
                }
            }
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    private sealed record ReportGenerationPayload(Guid ReportId);
}
