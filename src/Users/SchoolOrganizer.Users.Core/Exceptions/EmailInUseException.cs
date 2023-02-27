using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class EmailInUseException : SchoolOrganizerException
{
    public EmailInUseException() : base("Email is in use")
    {
    }

    public override int StatusCode { get; set; } = 400;
}