using System.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Route(UsersModule.BasePath)]
[Tags(UsersModule.BasePath)]
[Authorize]
public class UsersController: ControllerBase
{

    [HttpGet]
    public void ChangePassword()
    {
        
    }
}