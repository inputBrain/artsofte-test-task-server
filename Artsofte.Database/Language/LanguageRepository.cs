using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Language;

public class LanguageRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractStoredProcedure<LanguageModel>(context, loggerFactory), ILanguageRepository
{
    public async Task<LanguageModel> GetOneById(int id)
    {
        var parameters = new[]
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id }
        };

        var model = await ExecuteProcedureAsync("GetLanguageById", parameters);
        if (model == null)
        {
            throw new Exception("Department model is not found");
        }
    
        return model;
        
    }


    public async Task<List<LanguageModel>> ListAll()
    {
        var collection = await ExecuteProcedureListAsync("ListAllLanguage");

        return collection;
    }


    public async Task<ImmutableArray<string>> ListAllOnlyNames()
    {
        var collection = await DbModel.Select(x => x.Language).ToListAsync();

        return [..collection];
    }
}