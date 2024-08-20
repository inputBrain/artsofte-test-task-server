using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Department;

public class DepartmentRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<DepartmentModel>(context, loggerFactory), IDepartmentRepository
{
    
    public async Task<DepartmentModel> GetOneById(int id)
    {
        var model = await FindOneAsync(id);
        if (model == null)
        {
            throw new Exception("Department model is not found");
        }
        
        return model;
    }


    public async Task<List<DepartmentModel>> ListAll()
    {
        return await DbModel.Include(x => x.Employees).ToListAsync();
    }


    public async Task<ImmutableArray<string>> ListAllOnlyNames()
    {
        var collection = await DbModel.Select(x => x.Name).ToListAsync();

        return [..collection];
    }
}