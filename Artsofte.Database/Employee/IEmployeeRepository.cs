using System.Threading.Tasks;

namespace Artsofte.Database.Employee;

public interface IEmployeeRepository
{
    Task<EmployeeModel> CreateModel(int departmentId, int languageId, string name, string surname, int age, Gender gender);

    Task UpdateModel(EmployeeModel model, int departmentId, int languageId, string name, string surname, int age, Gender gender);

    Task DeleteModel(EmployeeModel model);

    Task<EmployeeModel?> FindOneById(int id);
}