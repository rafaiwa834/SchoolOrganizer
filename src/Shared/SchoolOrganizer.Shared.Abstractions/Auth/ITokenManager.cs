namespace SchoolOrganizer.Shared.Abstractions.Auth;

public interface ITokenManager
{
    Task<JwtToken> CreateToken(string userId, string userRole, string userEmail);
}