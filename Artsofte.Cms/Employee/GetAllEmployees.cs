using System.Collections.Generic;
using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Employee;

public sealed class GetAllEmployees
{
    public int Skip { get; set; }
    
    public int Take { get; set; }


    public sealed class GetAllEmployeesResponse : AbstractResponse
    {
        public List<EmployeePayload> Employees { get; set; }
        
        public int TotalCount { get; set; }


        public GetAllEmployeesResponse(List<EmployeePayload> employees, int totalCount)
        {
            Employees = employees;
            TotalCount = totalCount;
        }
    }
}