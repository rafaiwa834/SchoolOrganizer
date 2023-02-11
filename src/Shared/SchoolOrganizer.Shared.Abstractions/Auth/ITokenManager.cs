namespace SchoolOrganizer.Shared.Abstractions.Auth;

public interface ITokenManager
{
    JwtToken CreateToken(string userId, string userRole, string userEmail);
}