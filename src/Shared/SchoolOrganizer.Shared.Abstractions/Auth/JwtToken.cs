namespace SchoolOrganizer.Shared.Abstractions.Auth;

public class JwtToken
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string UserId { get; set; }
}