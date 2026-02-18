namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.DataAccess;

using System.ComponentModel.DataAnnotations;

internal sealed class ReportsPersistenceOptions
{
    public const string SectionName = "ConnectionStrings";

    [Required] public string Reports { get; init; } = string.Empty;
}
