using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Employee;

public sealed class UpdateEmployee
{
    [Required]
    public int EmployeeId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public int DepartmentId { get; set; }

    [Required]
    public int LanguageId { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public GenderPayload GenderPayload { get; set; }
    
    
    public sealed class UpdateEmployeeResponse : AbstractResponse
    {
        public List<EmployeePayload> Employees { get; set; }
        
        public int TotalCount { get; set; }


        public UpdateEmployeeResponse(List<EmployeePayload> employees, int totalCount)
        {
            Employees = employees;
            TotalCount = totalCount;
        }
    }
}