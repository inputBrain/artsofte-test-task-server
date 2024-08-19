using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artsofte.Database.Department;
using Artsofte.Database.Language;

namespace Artsofte.Database.Employee;

public class EmployeeModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int DepartmentId { get; set; }
    
    [Required]
    [ForeignKey("DepartmentId")]
    public DepartmentModel Department { get; set; }
    
    [Required]
    public int LanguageId { get; set; }
    
    [Required]
    [ForeignKey("LanguageId")]
    public LanguageModel Language { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    [Range(18, 100)]
    public int Age { get; set; }

    [Required]
    public Gender Gender { get; set; }

    
    public static EmployeeModel CreateModel(
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age,
        Gender gender
    )
    {
        return new EmployeeModel
        {
            DepartmentId = departmentId,
            LanguageId = languageId,
            Name = name,
            Surname = surname,
            Age = age,
            Gender = gender
        };
    }
    
    
    public void UpdateModel(
        EmployeeModel model,
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age
    )
    {
        model.DepartmentId = departmentId;
        model.LanguageId = languageId;
        model.Name = name;
        model.Surname = surname;
        model.Age = age;
    }
    
    
    public static bool IsSameEmployee(
        EmployeeModel model,
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age
    )
    {
        return model.DepartmentId == departmentId &&
               model.LanguageId == languageId &&
               model.Name == name &&
               model.Surname == surname &&
               model.Age == age;
    }
}