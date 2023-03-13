using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Customers.Domain.Exceptions;

public class EmailInUseException: SchoolOrganizerException
{
    public EmailInUseException(string email) : base($"Email {email} is in use")
    {
    }

    public override int StatusCode { get; set; } = 400;
}