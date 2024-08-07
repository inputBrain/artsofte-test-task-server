using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database;

public abstract class AbstractRepository<T> where T : AbstractModel
{
    protected readonly DbSet<T> DbModel;

    protected readonly ILogger<T> Logger;

    protected readonly MssqlSqlContext Context;


    protected AbstractRepository(MssqlSqlContext context, ILoggerFactory loggerFactory)
    {
        Context = context;
        DbModel = context.Set<T>();
        Logger = loggerFactory.CreateLogger<T>();
    }


    async protected Task<T> CreateModelAsync(T model)
    {
        await Context.AddAsync(model);
        var result = await Context.SaveChangesAsync();
        if (result == 0)
        {
            throw new Exception("Db error. Model is not created");
        }

        return model;
    }


    protected Task<int> UpdateModelAsync(T model)
    {
        DbModel.Update(model);
        return Context.SaveChangesAsync();
    }
}