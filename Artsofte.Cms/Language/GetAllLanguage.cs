using System.Collections.Generic;
using Artsofte.Cms.Payload.Language;

namespace Artsofte.Cms.Language;

public sealed class GetAllLanguage
{
    public sealed class GetAllLanguageResponse
    {
        public List<LanguagePayload> LanguagePayloads { get; set; }


        public GetAllLanguageResponse(List<LanguagePayload> languagePayloads)
        {
            LanguagePayloads = languagePayloads;
        }
    }
}