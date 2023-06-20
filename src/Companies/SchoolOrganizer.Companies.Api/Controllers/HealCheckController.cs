using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Companies.Api.Controllers;

[ApiController]
[Tags(CompaniesModule.BasePath)]
[Route(CompaniesModule.BasePath)]
public class HealCheckController: ControllerBase
{
    [HttpGet("healthcheck")]
    public ActionResult<string> Get() => Ok("Users module is working");

}