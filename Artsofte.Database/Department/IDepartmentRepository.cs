using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Artsofte.Database.Department;

public interface IDepartmentRepository
{
    Task<DepartmentModel> GetOneById(int id);

    Task<List<DepartmentModel>> ListAll();

    Task<ImmutableArray<string>> ListAllOnlyNames();
}