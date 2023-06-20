using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Companies.Core.Exceptions;

public class UserIdNotFound: SchoolOrganizerException
{
    public UserIdNotFound() : base("User id not found in token")
    {
    }

    public override int StatusCode { get; set; } = 404;
}