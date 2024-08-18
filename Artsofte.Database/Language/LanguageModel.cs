using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Artsofte.Database.Employee;

namespace Artsofte.Database.Language;

public class LanguageModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Language { get; set; }

    public List<EmployeeModel> Employees { get; set; }


    public static LanguageModel CreateModel(string language)
    {
        return new LanguageModel
        {
            Language = language
        };
    }
    
    
    public void UpdateModel(LanguageModel model, string language)
    {
        model.Language = language;
    }


    public static bool IsSameLanguage(LanguageModel model, string language)
    {
        return model.Language == language;
    }
}