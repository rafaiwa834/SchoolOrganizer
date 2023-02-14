using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Services;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Route(UsersModule.BasePath)]
public class AuthorizationController: ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthorizationController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        await _identityService.Register(registerDto);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<JwtToken>> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await _identityService.Login(loginDto));
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<JwtToken>> RefreshToken([FromBody] JwtToken jwtToken)
    {
        return Ok(await _identityService.RefreshToken(jwtToken));
    }
}