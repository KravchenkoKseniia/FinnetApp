namespace EvolutionaryArchitecture.Fitnet.Reports.Infrastructure.DataAccess;

using System.Data;

internal interface IDatabaseConnectionFactory : IDisposable
{
    IDbConnection Create();
}
