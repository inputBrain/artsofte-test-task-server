using System.Collections.Generic;
using Artsofte.Cms.Payload.Department;

namespace Artsofte.Cms.Department;

public sealed class GetAllDepartment
{
    public sealed class GetAllDepartmentResponse : AbstractResponse
    {
        public List<DepartmentPayload> Departments { get; set; }


        public GetAllDepartmentResponse(List<DepartmentPayload> departments)
        {
            Departments = departments;
        }
    }
}