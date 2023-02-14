using SchoolOrganizer.Shared.Abstractions.Auth;
using SchoolOrganizer.Users.Core.DTO;

namespace SchoolOrganizer.Users.Core.Services;

public interface IIdentityService
{
    public Task Register(RegisterDto registerDto, CancellationToken cancellationToken = default);
    public Task<JwtToken> Login(LoginDto loginDto, CancellationToken cancellationToken = default);
    public Task<JwtToken> RefreshToken(JwtToken jwtToken, CancellationToken cancellationToken = default);
}