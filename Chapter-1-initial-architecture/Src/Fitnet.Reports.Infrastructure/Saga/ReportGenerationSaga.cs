namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Saga;

using Domain;

internal sealed class ReportGenerationSaga
{
    public Guid Id { get; init; }
    public Guid CorrelationId { get; init; }
    public SagaStatus Status { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
    private ReportGenerationSaga() { }
    internal static ReportGenerationSaga Create(Guid correlationId) => new()
    {
        Id = Guid.NewGuid(),
        CorrelationId = correlationId,
        Status = SagaStatus.Started,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };
    internal void MarkAsCompleted()
    {
        Status = SagaStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
    }
    internal void MarkAsFailed()
    {
        Status = SagaStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
    }
}
