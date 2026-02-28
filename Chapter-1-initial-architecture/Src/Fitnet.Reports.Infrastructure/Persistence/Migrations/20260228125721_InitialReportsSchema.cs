#nullable disable

namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.Persistence.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class InitialReportsSchema : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "Reports");

        migrationBuilder.CreateTable(
            name: "OutboxMessages",
            schema: "Reports",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "text", nullable: false),
                Payload = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OutboxMessages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ReportGenerations",
            schema: "Reports",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReportGenerations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ReportGenerationSagas",
            schema: "Reports",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CorrelationId = table.Column<Guid>(type: "uuid", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReportGenerationSagas", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ReportGenerationSagas_CorrelationId",
            schema: "Reports",
            table: "ReportGenerationSagas",
            column: "CorrelationId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OutboxMessages",
            schema: "Reports");

        migrationBuilder.DropTable(
            name: "ReportGenerations",
            schema: "Reports");

        migrationBuilder.DropTable(
            name: "ReportGenerationSagas",
            schema: "Reports");
    }
}
