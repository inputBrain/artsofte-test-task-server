using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    [Range(18, 100)]
    public int Age { get; set; }

    [Required]
    public Gender Gender { get; set; }
    
    [Required]
    public List<LanguageModel> Languages { get; set; }

    
    public static EmployeeModel CreateModel(
        int departmentId,
        string name,
        string surname,
        int age,
        Gender gender,
        List<LanguageModel> languages
    )
    {
        return new EmployeeModel
        {
            DepartmentId = departmentId,
            Name = name,
            Surname = surname,
            Age = age,
            Gender = gender,
            Languages = languages
        };
    }
    
    
    public void UpdateModel(
        EmployeeModel model,
        int departmentId,
        string name,
        string surname,
        int age,
        Gender gender,
        List<LanguageModel> languages
    )
    {
        model.DepartmentId = departmentId;
        model.Name = name;
        model.Surname = surname;
        model.Age = age;
        model.Gender = gender;
        model.Languages = languages;
    }
    
    
    public static bool IsSameEmployee(
        EmployeeModel model,
        int departmentId,
        string name,
        string surname,
        int age,
        Gender gender,
        List<LanguageModel> languages
    )
    {
        return model.DepartmentId == departmentId &&
               model.Name == name &&
               model.Surname == surname &&
               model.Age == age &&
               model.Gender == gender &&
               _isSameLanguages(model, languages);
    }
    
    
    private static bool _isSameLanguages(EmployeeModel model, List<LanguageModel> languages)
    {
        if (model.Languages.Count > languages.Count | model.Languages.Count < languages.Count)
        {
            return false;
        }
    
        foreach (var apiLanguage in languages)
        {
            var foundLanguage = model.Languages.FirstOrDefault(x => x.Language == apiLanguage.Language);
    
            if (foundLanguage?.Language != apiLanguage.Language)
            {
                return false;
            }
        }
    
        return true;
    }
}