using Artsofte.Cms.Payload.Department;
using Artsofte.Database.Department;

namespace Artsofte.Cms.Codec;

public static class DepartmentCodec
{
    public static DepartmentPayload EncodeDepartment(DepartmentModel dbModel)
    {
        return new DepartmentPayload
        {
            Id = dbModel.Id,
            Name = dbModel.Name,
            Floor = dbModel.Floor,
            // EmployeePayloads = dbModel.Employees.Select(EmployeeCodec.EncodeEmployee).ToList()
        };
    }
}