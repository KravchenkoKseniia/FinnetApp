namespace EvolutionaryArchitecture.Fitnet.Reports.Domain;

public sealed class ReportGeneration
{
    public Guid Id { get; init; }
    public DateTime GeneratedAt { get; init; }
    private ReportGeneration() { }
    public static ReportGeneration Create() => new()
    {
        Id = Guid.NewGuid(),
        GeneratedAt = DateTime.UtcNow
    };
}
