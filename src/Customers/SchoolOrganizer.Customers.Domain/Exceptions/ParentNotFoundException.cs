using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Customers.Domain.Exceptions;

public class ParentNotFoundException: SchoolOrganizerException
{
    public ParentNotFoundException() : base("Parent not found")
    {
    }

    public override int StatusCode { get; set; } = 404;
}