using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artsofte.Database.Employee;

namespace Artsofte.Database.Language;

public class LanguageModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int EmployeeId { get; set; }
    
    [ForeignKey("EmployeeId")]
    public EmployeeModel Employee { get; set; }
    
    public string Language { get; set; }
}