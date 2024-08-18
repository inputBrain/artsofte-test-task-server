using Artsofte.Database.Department;
using Artsofte.Database.Employee;
using Artsofte.Database.Language;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database;

public class DatabaseFacade : IDatabaseFacade
{
    public IDepartmentRepository DepartmentRepository { get; }
    public IEmployeeRepository EmployeeRepository { get; }
    public ILanguageRepository LanguageRepository { get; }


    public DatabaseFacade(MssqlSqlContext context, ILoggerFactory loggerFactory)
    {
        DepartmentRepository = new DepartmentRepository(context, loggerFactory);
        EmployeeRepository = new EmployeeRepository(context, loggerFactory);
        LanguageRepository = new LanguageRepository(context, loggerFactory);
    }
}