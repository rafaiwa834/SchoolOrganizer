using System.Security.Claims;

namespace SchoolOrganizer.Shared.Abstractions.Auth;

public interface ITokenManager
{
    string CreateToken(string userId, string userRole, string userEmail);
    public string GenerateRefreshToken();
    public ClaimsPrincipal GetPrincipal(string token);
}