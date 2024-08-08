using System.Collections.Generic;
using System.Threading.Tasks;
using Artsofte.Database.Employee;

namespace Artsofte.Database.Department;

public interface IDepartmentRepository
{
    Task<DepartmentModel> CreateModel(string name, int floor);

    Task UpdateModel(DepartmentModel model, string name, int floor, List<EmployeeModel> employees);

    Task DeleteModel(DepartmentModel model);

    Task<DepartmentModel?> FindOneById(int id);
}