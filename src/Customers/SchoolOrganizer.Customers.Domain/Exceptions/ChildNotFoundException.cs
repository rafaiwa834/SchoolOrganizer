using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Customers.Domain.Exceptions;

public class ChildNotFoundException: SchoolOrganizerException
{
    public ChildNotFoundException() : base("Child not found")
    {
    }

    public override int StatusCode { get; set; } = 404;
}