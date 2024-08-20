using Artsofte.Cms.Codec;
using Artsofte.Cms.Department;
using Artsofte.Database;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Host.Controllers;

public class DepartmentController : AbstractController<DepartmentController>
{
    public DepartmentController(MssqlSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(GetAllDepartment.GetAllDepartmentResponse), 200)]
    public async Task<GetAllDepartment.GetAllDepartmentResponse> ListAllDepartment([FromBody] GetAllDepartment request)
    {
        var collection = await Db.DepartmentRepository.ListAll();

        return new GetAllDepartment.GetAllDepartmentResponse(collection.Select(DepartmentCodec.EncodeDepartment).ToList());
    }
}