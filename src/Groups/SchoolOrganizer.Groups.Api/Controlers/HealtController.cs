using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Groups.Api.Controlers;

[ApiController]
public class HealCheck: ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => Ok("Groups module is working");
}