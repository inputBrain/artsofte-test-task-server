using System.ComponentModel.DataAnnotations;

namespace Artsofte.Cms.Employee;

public sealed class DeleteEmployee
{
    [Required]
    public int EmployeeId { get; set; }
    
    
}