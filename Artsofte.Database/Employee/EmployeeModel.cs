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

    
    
}