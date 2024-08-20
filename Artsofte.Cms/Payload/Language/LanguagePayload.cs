using System.Collections.Generic;
using Artsofte.Cms.Payload.Employee;

namespace Artsofte.Cms.Payload.Language;

public class LanguagePayload
{
    public int Id { get; set; }
    
    public string Language { get; set; }

    public List<EmployeePayload> EmployeePayloads { get; set; }
}