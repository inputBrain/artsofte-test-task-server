using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artsofte.Database.Employee;

public interface IEmployeeRepository
{
    Task<EmployeeModel> CreateModel(int departmentId, int languageId, string name, string surname, int age, Gender gender);

    Task UpdateModel(EmployeeModel model, int departmentId, int languageId, string name, string surname, int age);

    Task DeleteModel(EmployeeModel model);

    Task<EmployeeModel> GetOneById(int id);
    
    Task<(List<EmployeeModel>, int)> ListAll(int skip, int take);
}