using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class FailedRefreshTokenException: SchoolOrganizerException
{
    public FailedRefreshTokenException(): base("Failed refresh token")
    {
        
    }

    public override int StatusCode { get; set; } = 404;
}