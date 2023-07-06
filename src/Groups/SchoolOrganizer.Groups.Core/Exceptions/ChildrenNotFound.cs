using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Groups.Core.Exceptions;

public class ChildrenNotFound: SchoolOrganizerException
{
    public ChildrenNotFound(string message) : base($"Children {message} not found")
    {
    }

    public override int StatusCode { get; set; } = 404;
}