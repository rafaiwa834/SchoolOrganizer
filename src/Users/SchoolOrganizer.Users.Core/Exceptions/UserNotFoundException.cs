using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class UserNotFoundException: SchoolOrganizerException
{
    public UserNotFoundException(string? userId): base($"User not found {userId}")
    {
            
    }
    public override int StatusCode { get; set; } = 404;
}