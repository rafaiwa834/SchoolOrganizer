using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class InvalidPassword: SchoolOrganizerException
{
    public InvalidPassword(): base("Invalid password")
    {
    }

    public override int StatusCode { get; set; } = 404;
}