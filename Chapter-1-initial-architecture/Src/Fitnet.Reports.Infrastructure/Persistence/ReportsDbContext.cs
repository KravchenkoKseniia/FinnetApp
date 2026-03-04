namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;
using Outbox;
using Saga;

internal sealed class ReportsDbContext(DbContextOptions<ReportsDbContext> options) : DbContext(options)
{
    internal DbSet<ReportGeneration> ReportGenerations => Set<ReportGeneration>();
    internal DbSet<Outbox> OutboxMessages => Set<Outbox>();
    internal DbSet<ReportGenerationSaga> ReportGenerationSagas => Set<ReportGenerationSaga>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Reports");
        modelBuilder.Entity<ReportGeneration>(entity =>
        {
            entity.HasKey(r => r.Id);
        });
        modelBuilder.Entity<Outbox>(entity =>
        {
            entity.HasKey(o => o.Id);
        });
        modelBuilder.Entity<ReportGenerationSaga>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.HasIndex(s => s.CorrelationId).IsUnique();
            entity.Property(s => s.Status).HasConversion<string>();
        });
    }
}
