using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class ClaimNotFoundException: SchoolOrganizerException
{
    public ClaimNotFoundException(): base("Claim not found")
    {
        
    }

    public override int StatusCode { get; set; } = 400;
}