using System.Collections.Generic;
using Artsofte.Cms.Payload.Language;

namespace Artsofte.Cms.Language;

public sealed class GetAllLanguage
{
    public sealed class GetAllLanguageResponse
    {
        public List<LanguagePayload> Languages { get; set; }


        public GetAllLanguageResponse(List<LanguagePayload> languages)
        {
            Languages = languages;
        }
    }
}