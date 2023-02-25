using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class FailedRefreshToken: SchoolOrganizerException
{
    public FailedRefreshToken(): base("Failed refresh token")
    {
        
    }

    public override int StatusCode { get; set; } = 404;
}