using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Employee;

public sealed class CreateEmployee
{
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
    
    
    public sealed class CreateEmployeeResponse : AbstractResponse
    {
        public List<EmployeePayload> Employees { get; set; }
        
        public int TotalCount { get; set; }


        public CreateEmployeeResponse(List<EmployeePayload> employees, int totalCount)
        {
            Employees = employees;
            TotalCount = totalCount;
        }
    }
}