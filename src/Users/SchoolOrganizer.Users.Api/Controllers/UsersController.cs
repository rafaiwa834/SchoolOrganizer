using System.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Services;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Route(UsersModule.BasePath)]
[Tags(UsersModule.BasePath)]
[Authorize]
public class UsersController: ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("password")]
    public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
    {
        await _userService.UpdatePassword(updatePasswordDto);
        return NoContent();
    }
    
    [HttpPut("email")]
    public async Task<ActionResult> UpdateEmail([FromBody] UpdateEmailDto updateEmailDto)
    {
        await _userService.UpdateEmail(updateEmailDto);
        return NoContent();
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("role")]
    public async Task<ActionResult> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
    {
        await _userService.UpdateRole(updateRoleDto);
        return NoContent();
    }
    
    [Authorize(Roles = "admin,owner")]
    [HttpPut("assign")]
    public async Task<ActionResult> AssignToCompany([FromHeader] Guid userId, [FromHeader] Guid companyId)
    {
        await _userService.AssignToCompany(userId, companyId);
        return NoContent();
    }
}