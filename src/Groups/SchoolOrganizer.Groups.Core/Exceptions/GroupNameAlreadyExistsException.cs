using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Groups.Core.Exceptions;

public class GroupNameAlreadyExistsException: SchoolOrganizerException
{
    public GroupNameAlreadyExistsException(string name) : base($"Group name {name} alredy exists")
    {
    }

    public override int StatusCode { get; set; } = 400;
}