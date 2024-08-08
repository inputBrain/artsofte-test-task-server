using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artsofte.Database.Language;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Employee;

public class EmployeeRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<EmployeeModel>(context, loggerFactory), IEmployeeRepository
{
    public async Task<EmployeeModel> CreateModel(
        int departmentId,
        string name,
        string surname,
        int age,
        Gender gender,
        List<LanguageModel> languages
    )
    {
        var model = EmployeeModel.CreateModel(departmentId, name, surname, age, gender, languages);

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
        string name,
        string surname,
        int age,
        Gender gender,
        List<LanguageModel> languages
    )
    {
        if (EmployeeModel.IsSameEmployee(model, departmentId, name, surname, age, gender, languages))
        {
            Logger.LogWarning("Employee model is the same. Model is not updated");
            return;
        }

        model.UpdateModel(model, departmentId, name, surname, age, gender, languages);
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