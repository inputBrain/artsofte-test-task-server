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
    
    [Required]
    public List<EmployeeModel> Employees { get; set; }


    public static DepartmentModel CreateModel(string name, int floor)
    {
        return new DepartmentModel
        {
            Name = name,
            Floor = floor
        };
    }


    public void UpdateModel(DepartmentModel model, string name, int floor)
    {
        model.Name = name;
        model.Floor = floor;
    }
    
    
    // public static bool IsSameDepartment(DepartmentModel model, int employeeId)
}