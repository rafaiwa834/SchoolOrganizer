using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Route(UsersModule.BasePath)]
public class HealthCheckController: ControllerBase
{
    [HttpGet("/healthcheck")]
    public ActionResult<string> Get() => Ok("Users module is working");
}