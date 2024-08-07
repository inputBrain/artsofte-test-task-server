using Microsoft.Extensions.Logging;

namespace Artsofte.Database;

public class DatabaseFacade : IDatabaseFacade
{
    public DatabaseFacade(MssqlSqlContext context, ILoggerFactory loggerFactory)
    {
    }
}