using Artsofte.Cms.Codec;
using Artsofte.Cms.Language;
using Artsofte.Database;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Host.Controllers;

public class LanguageController : AbstractController<LanguageController>
{
    public LanguageController(MssqlSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(GetAllLanguage.GetAllLanguageResponse), 200)]
    public async Task<GetAllLanguage.GetAllLanguageResponse> ListAllLanguage()
    {
        var collection = await Db.LanguageRepository.ListAll();

        return new GetAllLanguage.GetAllLanguageResponse(collection.Select(LanguageCodec.EncodeLanguage).ToList());
    }
}