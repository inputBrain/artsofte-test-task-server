using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Artsofte.Database.Department;

public interface IDepartmentRepository
{
    Task<DepartmentModel> GetOneById(int id);

    Task<ImmutableArray<string>> ListAllNames();
}