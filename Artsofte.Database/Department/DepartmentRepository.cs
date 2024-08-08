using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artsofte.Database.Employee;
using Microsoft.Extensions.Logging;

namespace Artsofte.Database.Department;

public class DepartmentRepository(MssqlSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<DepartmentModel>(context, loggerFactory), IDepartmentRepository
{
    public async Task<DepartmentModel> CreateModel(string name, int floor)
    {
        var model = DepartmentModel.CreateModel(name, floor);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Department model is not created. Result == null");
        }

        return result;
    }


    public async Task UpdateModel(DepartmentModel model, string name, int floor, List<EmployeeModel> employees)
    {
        if (DepartmentModel.IsSameDepartment(model, name, floor, employees))
        {
            Logger.LogWarning("Department model is the same. Model is not updated");
            return;
        }

        model.UpdateModel(model, name, floor, employees);
        await UpdateModelAsync(model);
    }


    public async Task DeleteModel(DepartmentModel model)
    {
        await DeleteModelAsync(model);
    }


    public async Task<DepartmentModel?> FindOneById(int id)
    {
        var model = await FindOneAsync(id);
        return model;
    }
}