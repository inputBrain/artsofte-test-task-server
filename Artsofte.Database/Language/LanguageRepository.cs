using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Language;

public class LanguageRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<LanguageModel>(context, loggerFactory), ILanguageRepository
{
    public async Task<LanguageModel> GetOneById(int id)
    {
        var model = await FindOneAsync(id);

        if (model == null)
        {
            throw new Exception("Language model is not found");
        }
        return model;
    }


    public async Task<List<LanguageModel>> ListAll()
    {
        return await DbModel.Include(x => x.Employees).ToListAsync();

    }


    public async Task<ImmutableArray<string>> ListAllOnlyNames()
    {
        var collection = await DbModel.Select(x => x.Language).ToListAsync();

        return [..collection];
    }
}