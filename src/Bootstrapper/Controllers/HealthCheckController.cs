using Microsoft.AspNetCore.Mvc;

namespace Bootstrapper.Controllers;

public class HealthCheckController: ControllerBase
{
    [HttpGet("healthcheck")] 
    public ActionResult<string> Get() => Ok("School organizer is working");
}