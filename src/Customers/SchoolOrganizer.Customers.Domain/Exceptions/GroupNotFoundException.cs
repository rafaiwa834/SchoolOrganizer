using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Customers.Domain.Exceptions;

public class GroupNotFoundException: SchoolOrganizerException
{
    public GroupNotFoundException() : base("Group not found")
    {
    }

    public override int StatusCode { get; set; } = 400;
}