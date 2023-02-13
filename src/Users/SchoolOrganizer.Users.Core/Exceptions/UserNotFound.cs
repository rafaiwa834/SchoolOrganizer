namespace SchoolOrganizer.Users.Core.Exceptions;

public class UserNotFound: Exception
{
    public UserNotFound(string userId): base($"User not found {userId}")
    {
            
    }
}