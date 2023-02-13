using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Shared.Abstractions.Time;
using SchoolOrganizer.Users.Core.DAL;
using SchoolOrganizer.Users.Core.DTO;
using SchoolOrganizer.Users.Core.Entities;
using SchoolOrganizer.Users.Core.Exceptions;

namespace SchoolOrganizer.Users.Core.Services;

public class IdentityService
{
    private readonly UsersDbContext _usersDbContext;
    private readonly ITokenManager _tokenManager;
    private readonly IClock _clock;

    public IdentityService(UsersDbContext usersDbContext, ITokenManager tokenManager, IClock clock)
    {
        _usersDbContext = usersDbContext;
        _tokenManager = tokenManager;
        _clock = clock;
    }

    internal async Task Register(RegisterDto registerDto, CancellationToken cancellationToken = default)
    {
        var user = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email, cancellationToken);
        if (user is not null)
            throw new EmailInUse();
        var hashedPassword = HashingService.Hash(registerDto.Password);
        user = new User()
        {
            Id = Guid.NewGuid(),
            Password = hashedPassword,
            Email = registerDto.Email,
            Role = registerDto.Role?.ToLowerInvariant() ?? "user",
            CreatedAt = _clock.GetDateTimeNow()
        };
        await _usersDbContext.Users.AddAsync(user, cancellationToken);
        await _usersDbContext.SaveChangesAsync(cancellationToken);
    }

    internal async Task<JwtToken> Login(LoginDto loginDto, CancellationToken cancellationToken= default)
    {
        var user = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email, cancellationToken);
        if (user is null)
            throw new UserNotFound(loginDto.Email);

        if (!HashingService.Verify(loginDto.Password, user.Password))
            throw new InvalidPassword();

        var accessToken = _tokenManager.CreateToken(user.Id.ToString(), user.Role, user.Email);
        var refreshToken = _tokenManager.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = _clock.GetDateTimeNow().AddHours(8);
        await _usersDbContext.SaveChangesAsync(cancellationToken);
        
        return new JwtToken()
        {
            AccesToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    internal async Task<JwtToken> RefreshToken(JwtToken jwtToken, CancellationToken cancellationToken = default)
    {
        var principal = _tokenManager.GetPrincipalFromExpiredToken(jwtToken.AccesToken);
        var userId = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
        if (userId is null)
            throw new ClaimNotFound();
        var user = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Id == new Guid(userId.Value) , cancellationToken);
        if (user is null || user.RefreshToken != jwtToken.RefreshToken ||
            user.RefreshTokenExpiryTime <= _clock.GetDateTimeNow())
            throw new FailedRefreshToken();

        var newAccesToken = _tokenManager.CreateToken(user.Id.ToString(), user.Role, user.Email);
        var newRefreshToken = _tokenManager.GenerateRefreshToken();
        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = _clock.GetDateTimeNow().AddHours(8);
        await _usersDbContext.SaveChangesAsync(cancellationToken);
        return new JwtToken()
        {
            RefreshToken = newRefreshToken,
            AccesToken = newAccesToken
        };
    }
}