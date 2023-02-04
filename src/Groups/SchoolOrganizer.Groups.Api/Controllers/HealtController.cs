using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Route("groups")]
public class HealtCheck: ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => Ok("Groups module is working");
}