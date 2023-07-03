using SchoolOrganizer.Shared.Abstractions.Exceptions;

namespace SchoolOrganizer.Groups.Core.Exceptions;

public class ScheduleNotFoundException: SchoolOrganizerException
{
    public ScheduleNotFoundException(string message) : base($"Schedule {message} not found")
    {
    }

    public override int StatusCode { get; set; } = 404;
}