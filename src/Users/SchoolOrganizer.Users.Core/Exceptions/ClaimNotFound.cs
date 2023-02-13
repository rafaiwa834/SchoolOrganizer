namespace SchoolOrganizer.Users.Core.Exceptions;

public class ClaimNotFound: Exception
{
    public ClaimNotFound(): base("Claim not found")
    {
        
    }
}