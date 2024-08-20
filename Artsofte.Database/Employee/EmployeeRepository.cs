using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Employee;

public class EmployeeRepository : AbstractStoredProcedure<EmployeeModel>, IEmployeeRepository
{
    public EmployeeRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    public async Task<EmployeeModel> CreateModel(
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age,
        Gender gender
    )
    {
        var parameters = new[]
        {
            new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = departmentId },
            new SqlParameter("@LanguageId", SqlDbType.Int) { Value = languageId },
            new SqlParameter("@Name", SqlDbType.VarChar, 100) { Value = name },
            new SqlParameter("@Surname", SqlDbType.VarChar, 100) { Value = surname },
            new SqlParameter("@Age", SqlDbType.Int) { Value = age },
            new SqlParameter("@Gender", SqlDbType.Int) { Value = (int)gender }
        };
        
        
        var result = await ExecuteProcedureAsync("CreateEmployee", parameters);
        
        if (result == null)
        {
            Logger.LogWarning("Employee model is not created. Result == null");
            throw new Exception("Employee model is not created. Result == null");
        }

        return result;
    }


    public async Task UpdateModel(
        EmployeeModel model,
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age
    )
    {
        if (EmployeeModel.IsSameEmployee(model, departmentId, languageId, name, surname, age))
        {
            Logger.LogWarning("Employee model is the same. Model is not updated");
            return;
        }
        var parameters = new[]
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = model.Id },
            new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = departmentId },
            new SqlParameter("@LanguageId", SqlDbType.Int) { Value = languageId },
            new SqlParameter("@Name", SqlDbType.VarChar, 100) { Value = name },
            new SqlParameter("@Surname", SqlDbType.VarChar, 100) { Value = surname },
            new SqlParameter("@Age", SqlDbType.Int) { Value = age }
        };
        
        var result = await ExecuteNonQueryAsync("UpdateEmployee", parameters);

        if (result == 0)
        {
            Logger.LogWarning("Employee model update failed");
            throw new Exception("Employee model update failed");
        }
    }


    public async Task DeleteModel(EmployeeModel model)
    {
        var parameters = new[]
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = model.Id }
        };
        
        var result = await ExecuteNonQueryAsync("DeleteEmployee", parameters);

        if (result == 0)
        {
            Logger.LogWarning("Employee model delete failed");
            throw new Exception("Employee model delete failed");
        }
    }


    public async Task<EmployeeModel> GetOneById(int id)
    {
        var parameters = new[]
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = id }
        };

        var model = await ExecuteProcedureAsync("GetEmployeeById", parameters);
        
        
        if (model == null)
        {
            throw new Exception("Employee model is not found");
        }
        
        return model;
    }


    public async Task<(List<EmployeeModel>, int)> ListAll(int skip, int take)
    {
        var outputParameter = new SqlParameter("@TotalCount", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        var parameters = new[]
        {
            new SqlParameter("@Skip", SqlDbType.Int) { Value = skip * take },
            new SqlParameter("@Take", SqlDbType.Int) { Value = take },
            outputParameter
        };

        var (collection, totalCount) = await ExecuteWithOutputAsync("ListAllEmployee", outputParameter, parameters);

        return (collection, totalCount);
    }
}