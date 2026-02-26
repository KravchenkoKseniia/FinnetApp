namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;

internal sealed class ReportsDbContext(DbContextOptions<ReportsDbContext> options) : DbContext(options)
{
    internal DbSet<ReportGeneration> ReportGenerations => Set<ReportGeneration>();
    internal DbSet<Outbox> OutboxMessages => Set<Outbox>();
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
    }
}
