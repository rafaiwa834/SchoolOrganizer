using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Api.Controllers;

[Tags(CustomersModule.BasePath)]
[Route(CustomersModule.BasePath)]
[ApiController]
public class HealthCheckController: ControllerBase
{
    [HttpGet("healthcheck")] 
    public ActionResult<string> Get() => Ok("Customer module is working");

}