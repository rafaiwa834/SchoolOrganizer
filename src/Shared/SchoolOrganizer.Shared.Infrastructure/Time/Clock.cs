using SchoolOrganizer.Shared.Abstractions.Time;

namespace SchoolOrganizer.Shared.Infrastructure.Time;

public class Clock: IClock
{
    public DateTime GetDateTimeNow() => DateTime.UtcNow;
}