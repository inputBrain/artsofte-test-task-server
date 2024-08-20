using System.Collections.Generic;
using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Payload.Department;

public class DepartmentPayload
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Floor { get; set; }
    
    public List<EmployeePayload> EmployeePayloads { get; set; }
}