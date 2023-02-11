namespace SchoolOrganizer.Users.Core.Exceptions;

public class EmailInUse : Exception
{
    public EmailInUse() : base("Email is in use")
    {
    }
}