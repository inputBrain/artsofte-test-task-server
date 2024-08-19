using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artsofte.Database.Employee;

namespace Artsofte.Database.Department;

public class DepartmentModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(-5, 100)]
    public int Floor { get; set; }

    public List<EmployeeModel> Employees { get; set; }
}