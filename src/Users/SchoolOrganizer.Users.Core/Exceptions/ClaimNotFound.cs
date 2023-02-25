using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class ClaimNotFound: SchoolOrganizerException
{
    public ClaimNotFound(): base("Claim not found")
    {
        
    }

    public override int StatusCode { get; set; } = 400;
}