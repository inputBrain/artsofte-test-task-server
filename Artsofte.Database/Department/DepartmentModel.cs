using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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


    public void UpdateModel(DepartmentModel model, string name, int floor, List<EmployeeModel> employees)
    {
        model.Name = name;
        model.Floor = floor;
        model.Employees = employees;
    }


    public static bool IsSameDepartment(DepartmentModel model, string name, int floor,  List<EmployeeModel> employees)
    {
        return model.Name == name &&
               model.Floor == floor &&
               _isSameEmployees(model, employees);
               
    }


    private static bool _isSameEmployees(DepartmentModel model, List<EmployeeModel> employees)
    {
        if (model.Employees.Count > employees.Count | model.Employees.Count < employees.Count)
        {
            return false;
        }
    
        foreach (var apiEmployee in employees)
        {
            var foundEmployee = model.Employees.FirstOrDefault(x => x.Id == apiEmployee.Id);
    
            if (foundEmployee?.Id != apiEmployee.Id)
            {
                return false;
            }
        }
    
        return true;
    }
}