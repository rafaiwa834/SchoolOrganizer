using Microsoft.AspNetCore.Mvc;

namespace Bootstrapper.Controllers;

[ApiController]
[Route("Bootstrapper")]
public class TestController: ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Bootstrapper module is working"); 
    } 
    
 
}