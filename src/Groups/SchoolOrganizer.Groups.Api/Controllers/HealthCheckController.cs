using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Route(GroupsModule.BasePath)]
public class HealthCheckController: ControllerBase
{
    [HttpGet("/healthcheck")]
    public ActionResult<string> Get() => Ok("Groups module is working");
}