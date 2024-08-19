using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Employee;

public sealed class GetOneEmployee
{
    public int EmployeeId { get; set; }


    public sealed class GetOneEmployeeResponse : AbstractResponse
    {
        public EmployeePayload Employee { get; set; }


        public GetOneEmployeeResponse(EmployeePayload employee)
        {
            Employee = employee;
        }
    }
}