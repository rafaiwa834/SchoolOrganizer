using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Tags(UsersModule.BasePath)]
[Route(UsersModule.BasePath)]
public class HealthCheckController: ControllerBase
{
    [HttpGet("healthcheck")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<string> Get() => Ok("Users module is working");
}