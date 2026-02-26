namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Persistence;

internal sealed class Outbox
{
    public Guid Id { get; init; }
    public string Type { get; init; } = string.Empty;
    public string Payload { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime? ProcessedAt { get; set; }
    private Outbox() { }

    internal static Outbox Create(string type, string payload) => new()
    {
        Id = Guid.NewGuid(),
        Type = type,
        Payload = payload,
        CreatedAt = DateTime.UtcNow,
        ProcessedAt = null
    };
}
