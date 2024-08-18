using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Employee;

public class EmployeeRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<EmployeeModel>(context, loggerFactory), IEmployeeRepository
{
    public async Task<EmployeeModel> CreateModel(
        int departmentId,
        int languageId,
        string name,
        string surname,
        int age,
        Gender gender
    )
    {
        var model = EmployeeModel.CreateModel(
            // departmentId, languageId,
            name, surname, age, gender);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
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
        int age,
        Gender gender
    )
    {
        if (EmployeeModel.IsSameEmployee(model, departmentId, languageId, name, surname, age, gender))
        {
            Logger.LogWarning("Employee model is the same. Model is not updated");
            return;
        }

        model.UpdateModel(model, departmentId, languageId, name, surname, age, gender);
        await UpdateModelAsync(model);
    }


    public async Task DeleteModel(EmployeeModel model)
    {
        await DeleteModelAsync(model);
    }


    public async Task<EmployeeModel?> FindOneById(int id)
    {
        var model = await FindOneAsync(id);
        return model;
    }
}