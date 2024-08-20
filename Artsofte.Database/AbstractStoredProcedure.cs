using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database;

public abstract class AbstractStoredProcedure<T> where T : AbstractModel
{
    protected readonly DbSet<T> DbModel;

    protected readonly ILogger<T> Logger;

    protected readonly MssqlSqlContext Context;


    protected AbstractStoredProcedure(MssqlSqlContext context, ILoggerFactory loggerFactory)
    {
        Context = context;
        DbModel = context.Set<T>();
        Logger = loggerFactory.CreateLogger<T>();
    }
    

    /// <summary>
    /// Procedure for return an entity from DB
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameters"></param>
    /// <returns>Entity from DB</returns>
    async protected Task<T?> ExecuteProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
    {
        var sql = $"EXEC {storedProcedureName} {string.Join(", ", parameters.Select(p => p.ParameterName))}";

        var result = await DbModel
            .FromSqlRaw(sql, parameters)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return result;
    }


    /// <summary>
    /// Execute a procedure with no returning an Entity
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameters"></param>
    /// <returns>int 0 or 1 in case success or not the result</returns>
    async protected Task<int> ExecuteNonQueryAsync(string storedProcedureName, params SqlParameter[] parameters)
    {
        var connection = Context.Database.GetDbConnection();

        await using (var command = connection.CreateCommand())
        {
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            return await command.ExecuteNonQueryAsync();
        }
    }
    
    /// <summary>
    /// This private procedure for returning collection without pagination
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameters"></param>
    /// <returns>Noт-paginated collection without total rows count in DB</returns>
    private async Task<List<T>> ExecuteStoredProcedureListAsync(string storedProcedureName, params SqlParameter[] parameters)
    {
        var sql = $"EXEC {storedProcedureName} {string.Join(", ", parameters.Select(p => p.ParameterName))}";

        var result = await Context.Set<T>()
            .FromSqlRaw(sql, parameters)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
    
    
    /// <summary>
    /// This procedure for paginated collection with skip and take
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="outputParameter"></param>
    /// <param name="parameters"></param>
    /// <returns>Paginated collection with total rows count in DB</returns>
    async protected Task<(List<T>, int)> ExecuteWithOutputAsync(string storedProcedureName, SqlParameter outputParameter, params SqlParameter[] parameters)
    {
        var result = await ExecuteStoredProcedureListAsync(storedProcedureName, parameters.Append(outputParameter).ToArray());

        var totalCount = (int)(outputParameter.Value ?? 0);

        return (result, totalCount);
    }
    
    
    /// <summary>
    /// This method executes a stored procedure without parameters and returns a collection of entities.
    /// </summary>
    /// <param name="storedProcedureName">The name of the stored procedure to execute.</param>
    /// <returns>A collection of entities returned by the stored procedure.</returns>
    async protected Task<List<T>> ExecuteProcedureListAsync(string storedProcedureName)
    {
        var sql = $"EXEC {storedProcedureName}";

        var result = await Context.Set<T>()
            .FromSqlRaw(sql)
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}