using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Tags(GroupsModule.BasePath)]
[Route(GroupsModule.BasePath)]
public class GroupsController: ControllerBase
{

    [HttpGet]
    [Authorize]
    public ActionResult<string> Test()
    {
        return Ok("autoryzacja przebiegła pomyślnie");
    }
}