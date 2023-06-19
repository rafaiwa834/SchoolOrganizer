using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Companies.Api.Controllers;

[ApiController]
[Tags(CompaniesModule.BasePAth)]
[Route(CompaniesModule.BasePAth)]
public class HealCheckController: ControllerBase
{
    [HttpGet("healthcheck")]
    public ActionResult<string> Get() => Ok("Users module is working");

}