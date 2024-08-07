using Artsofte.Database.Department;
using Artsofte.Database.Employee;
using Artsofte.Database.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database;

public class MssqlSqlContext : DbContext
{
    public readonly IDatabaseFacade Db;
    
    public DbSet<EmployeeModel> Employee { get; set; }
    public DbSet<DepartmentModel> Department { get; set; }
    public DbSet<LanguageModel> Language { get; set; }


    public MssqlSqlContext(DbContextOptions<MssqlSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseFacade(this, loggerFactory);
    }
}