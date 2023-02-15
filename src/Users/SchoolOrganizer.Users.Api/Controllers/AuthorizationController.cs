using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Services;

namespace SchoolOrganizer.Users.Api.Controllers;

[ApiController]
[Tags(UsersModule.BasePath)]
[Route(UsersModule.BasePath)]
public class AuthorizationController: ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthorizationController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        await _identityService.Register(registerDto);
        return NoContent();
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtToken>> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await _identityService.Login(loginDto));
    }

    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtToken>> RefreshToken([FromBody] JwtToken jwtToken)
    {
        return Ok(await _identityService.RefreshToken(jwtToken));
    }
}