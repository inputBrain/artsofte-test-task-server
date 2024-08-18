using Artsofte.Database.Department;
using Artsofte.Database.Employee;
using Artsofte.Database.Language;

namespace Artsofte.Database;

public interface IDatabaseFacade
{
    IDepartmentRepository DepartmentRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    ILanguageRepository LanguageRepository { get; }
}