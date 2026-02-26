namespace EvolutionaryArchitecture.Fitnet.Reports.Application;

using EvolutionaryArchitecture.Fitnet.Reports.Domain;

internal interface INewPassesRegistrationPerMonthReportDataRetriever
{
    Task<IReadOnlyCollection<NewPassesRegistrationsPerMonthDto>> GetReportDataAsync(CancellationToken cancellationToken = default);
}
