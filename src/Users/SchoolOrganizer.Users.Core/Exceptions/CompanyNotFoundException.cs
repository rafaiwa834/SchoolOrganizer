using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class CompanyNotFoundException: SchoolOrganizerException
{
    public CompanyNotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode { get; set; } = 404;
}