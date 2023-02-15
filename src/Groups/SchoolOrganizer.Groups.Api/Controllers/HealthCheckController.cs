using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Tags(GroupsModule.BasePath)]
[Route(GroupsModule.BasePath)]
public class HealthCheckController: ControllerBase
{
    [HttpGet("healthcheck")]
    public ActionResult<string> Get() => Ok("Groups module is working");
}