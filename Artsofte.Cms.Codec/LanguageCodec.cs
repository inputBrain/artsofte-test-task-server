using System.Linq;
using Artsofte.Cms.Payload.Language;
using Artsofte.Database.Language;

namespace Artsofte.Cms.Codec;

public static class LanguageCodec
{
    public static LanguagePayload EncodeLanguage(LanguageModel dbModel)
    {
        return new LanguagePayload
        {
            Id = dbModel.Id,
            Language = dbModel.Language,
            // EmployeePayloads = dbModel.Employees.Select(EmployeeCodec.EncodeEmployee).ToList()
        };
    }
}