namespace SchoolOrganizer.Groups.Core.Entities;

public class Attendance
{
    public Guid Id { get; set; }
    public Guid ChildrenId { get; set; }
    public bool IsPresent { get; set; }
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}