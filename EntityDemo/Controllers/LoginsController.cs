using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BOL;
using DAL;
namespace EntityDemo.Controllers;



[ApiController]
[Route("[controller]")]
public class LoginsController : ControllerBase
{
    
     private readonly ILogger<LoginsController> _logger;

    public LoginsController(ILogger<LoginsController> logger)
    {
        _logger = logger;
    }

    [EnableCors()]
    [HttpGet(Name = "GetLogins")]
    public IEnumerable<Login> Get()
    {
        LoginManager l = new LoginManager();

    List<Login> alllogins = l.GetLogins();
     return alllogins;
    }
}