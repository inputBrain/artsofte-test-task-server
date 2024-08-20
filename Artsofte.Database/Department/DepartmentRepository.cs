using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Department;

public class DepartmentRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractStoredProcedure<DepartmentModel>(context, loggerFactory), IDepartmentRepository
{
    public async Task<DepartmentModel> GetOneById(int id)
    {
        var parameters = new[]
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id }
        };

        var model = await ExecuteProcedureAsync("GetDepartmentById", parameters);
        
        
        if (model == null)
        {
            throw new Exception("Department model is not found");
        }
        
        return model;
    }


    public async Task<List<DepartmentModel>> ListAll()
    {
        var collection = await ExecuteProcedureListAsync("ListAllEmployee");

        return collection;
    }


    public async Task<ImmutableArray<string>> ListAllOnlyNames()
    {
        var collection = await DbModel.Select(x => x.Name).ToListAsync();

        return [..collection];
    }
}