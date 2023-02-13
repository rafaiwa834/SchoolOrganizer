namespace SchoolOrganizer.Shared.Abstractions.Auth;

public class JwtToken
{
    public string AccesToken { get; set; }
    public string RefreshToken { get; set; }
}