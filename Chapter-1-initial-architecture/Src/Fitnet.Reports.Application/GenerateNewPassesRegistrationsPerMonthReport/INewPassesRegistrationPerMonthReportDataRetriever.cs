namespace EvolutionaryArchitecture.Fitnet.Reports.Application.GenerateNewPassesRegistrationsPerMonthReport;

using Domain;

internal interface INewPassesRegistrationPerMonthReportDataRetriever
{
    Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDto>> GetReportDataAsync(CancellationToken cancellationToken = default);
}
