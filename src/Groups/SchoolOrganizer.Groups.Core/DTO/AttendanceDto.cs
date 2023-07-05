namespace SchoolOrganizer.Groups.Core.DTO;

public class AttendanceDto
{
    public Guid Id { get; set; }
    public Guid ChildrenId { get; set; }
    public Guid ScheduleId { get; set; }
    public bool IsPresent { get; set; }
}