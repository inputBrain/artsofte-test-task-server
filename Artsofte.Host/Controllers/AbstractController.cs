using Artsofte.Database;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Host.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class AbstractController<T> : ControllerBase where T : ControllerBase
{
    protected readonly IDatabaseFacade Db;
    protected readonly ILogger<T> Logger;

    protected AbstractController(MssqlSqlContext context, ILoggerFactory loggerFactory)
    {
        Db = context.Db;
        Logger = loggerFactory.CreateLogger<T>();
    }   


    protected IActionResult SendOk()
    {
        return Ok();
    }


    protected IActionResult SendOk(object response)
    {
        return Ok(response);
    }
}