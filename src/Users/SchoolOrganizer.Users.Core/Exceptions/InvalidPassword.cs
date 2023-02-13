namespace SchoolOrganizer.Users.Core.Exceptions;

public class InvalidPassword: Exception
{
    public InvalidPassword(): base("Invalid password")
    {
    }
}