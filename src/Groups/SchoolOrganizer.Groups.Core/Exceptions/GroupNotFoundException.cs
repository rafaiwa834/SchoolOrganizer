using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Groups.Core.Exceptions;

public class GroupNotFoundException: SchoolOrganizerException
{
    public GroupNotFoundException(string id) : base($"Group {id} not found")
    {
    }

    public override int StatusCode { get; set; } = 404;
}