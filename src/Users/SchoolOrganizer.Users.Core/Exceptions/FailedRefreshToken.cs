namespace SchoolOrganizer.Users.Core.Exceptions;

public class FailedRefreshToken: Exception
{
    public FailedRefreshToken(): base("Failed refresh token")
    {
        
    }
}