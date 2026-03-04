namespace EvolutionaryArchitecture.Fitnet.Reports.Application;

using GenerateNewPassesRegistrationsPerMonthReport;

public interface IReportsService
{
    Task<NewPassesRegistrationsPerMonthResponse> GenerateNewPassesRegistrationsPerMonthReportAsync(CancellationToken cancellationToken);
    Task<Guid> RequestReportGenerationAsync(CancellationToken cancellationToken);
}
