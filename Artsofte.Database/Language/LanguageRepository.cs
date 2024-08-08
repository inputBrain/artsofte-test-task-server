using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Language;

public class LanguageRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<LanguageModel>(context, loggerFactory), ILanguageRepository
{
}