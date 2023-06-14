using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Users.Core.Exceptions;

public class RoleNotFoundException: SchoolOrganizerException
{
    public RoleNotFoundException(string roleId) : base($"Role: {roleId} not found")
    {
    }

    public override int StatusCode { get; set; }
}