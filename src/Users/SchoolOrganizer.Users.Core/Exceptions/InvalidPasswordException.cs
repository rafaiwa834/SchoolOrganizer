using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class InvalidPasswordException: SchoolOrganizerException
{
    public InvalidPasswordException(): base("Invalid password")
    {
    }

    public override int StatusCode { get; set; } = 404;
}