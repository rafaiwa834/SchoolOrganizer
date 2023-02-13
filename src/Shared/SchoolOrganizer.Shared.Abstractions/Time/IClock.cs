namespace SchoolOrganizer.Shared.Abstractions.Time;

public interface IClock
{
    DateTime GetDateTimeNow();
}