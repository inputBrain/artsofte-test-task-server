using Artsofte.Cms.Codec;
using Artsofte.Cms.Employee;
using Artsofte.Database;
using Artsofte.Database.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Host.Controllers;

public class EmployeeController : AbstractController<EmployeeController>
{
    public EmployeeController(MssqlSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }


    [HttpPost]
    [ProducesResponseType(typeof(GetOneEmployee.GetOneEmployeeResponse), 200)]
    public async Task<GetOneEmployee.GetOneEmployeeResponse> GetOneEmployeeById([FromBody] GetOneEmployee request)
    {
        var model = await Db.EmployeeRepository.GetOneById(request.EmployeeId);

        return new GetOneEmployee.GetOneEmployeeResponse(EmployeeCodec.EncodeEmployee(model));
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateEmployee.CreateEmployeeResponse), 200)]
    public async Task<GetAllEmployees.GetAllEmployeesResponse> CreateEmployee([FromBody] CreateEmployee request)
    {
        var department = await Db.DepartmentRepository.GetOneById(request.DepartmentId);
        var language = await Db.LanguageRepository.GetOneById(request.LanguageId);

        await Db.EmployeeRepository.CreateModel(
            department.Id,
            language.Id,
            request.Name,
            request.Surname,
            request.Age,
            (Gender) request.GenderPayload
        );
        
        
        var (collection, totalCount) = await Db.EmployeeRepository.ListAll(0, 20);

        return new GetAllEmployees.GetAllEmployeesResponse(collection.Select(EmployeeCodec.EncodeEmployee).ToList(), totalCount);
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(UpdateEmployee.UpdateEmployeeResponse), 200)]
    public async Task<GetAllEmployees.GetAllEmployeesResponse> UpdateEmployee([FromBody] UpdateEmployee request)
    {
        var model = await Db.EmployeeRepository.GetOneById(request.EmployeeId);
        var department = await Db.DepartmentRepository.GetOneById(request.DepartmentId);
        var language = await Db.LanguageRepository.GetOneById(request.LanguageId);
        
        
        
        await Db.EmployeeRepository.UpdateModel(
            model,
            department.Id,
            language.Id,
            request.Name,
            request.Surname,
            request.Age
        );
        
        
        var (collection, totalCount) = await Db.EmployeeRepository.ListAll(0, 20);

        return new GetAllEmployees.GetAllEmployeesResponse(collection.Select(EmployeeCodec.EncodeEmployee).ToList(), totalCount);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployee request)
    {
        var model = await Db.EmployeeRepository.GetOneById(request.EmployeeId);

        await Db.EmployeeRepository.DeleteModel(model);

        return SendOk();
    }
    

    [HttpPost]
    [ProducesResponseType(typeof(GetAllEmployees.GetAllEmployeesResponse), 200)]
    public async Task<GetAllEmployees.GetAllEmployeesResponse> ListAllEmployees([FromBody] GetAllEmployees request)
    {
        var (collection, totalCount) = await Db.EmployeeRepository.ListAll(request.Skip = 0, request.Take = 20);

        return new GetAllEmployees.GetAllEmployeesResponse(collection.Select(EmployeeCodec.EncodeEmployee).ToList(), totalCount);
    }
}