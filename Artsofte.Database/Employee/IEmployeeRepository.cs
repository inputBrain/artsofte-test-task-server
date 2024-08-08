using System.Collections.Generic;
using System.Threading.Tasks;
using Artsofte.Database.Language;

namespace Artsofte.Database.Employee;

public interface IEmployeeRepository
{
    Task<EmployeeModel> CreateModel(int departmentId, string name, string surname, int age, Gender gender, List<LanguageModel> languages);

    Task UpdateModel(EmployeeModel model, int departmentId, string name, string surname, int age, Gender gender, List<LanguageModel> languages);

    Task DeleteModel(EmployeeModel model);

    Task<EmployeeModel?> FindOneById(int id);
}