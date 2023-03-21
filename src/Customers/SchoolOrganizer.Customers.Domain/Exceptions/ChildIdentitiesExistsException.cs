using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Customers.Domain.Exceptions;

public class ChildIdentitiesExistsException: SchoolOrganizerException 
{
    public ChildIdentitiesExistsException() : base("Child with provided identities exists for this parent")
    {
    }

    public override int StatusCode { get; set; } = 400;
}