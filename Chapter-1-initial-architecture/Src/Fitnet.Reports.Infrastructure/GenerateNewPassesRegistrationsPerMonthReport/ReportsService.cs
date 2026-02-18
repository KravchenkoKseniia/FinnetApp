namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure;

using Application;
using Application.GenerateNewPassesRegistrationsPerMonthReport;


internal class ReportsService(INewPassesRegistrationPerMonthReportDataRetriever dataRetriever) : IReportsService
{
    public async Task<NewPassesRegistrationsPerMonthResponse> GenerateNewPassesRegistrationsPerMonthReportAsync(
        CancellationToken cancellationToken)
    {
        var reportData = await dataRetriever.GetReportDataAsync(cancellationToken);
        return NewPassesRegistrationsPerMonthResponse.Create(reportData);
    }
}
