namespace SchoolOrganizer.Groups.Core.DTO;

public class CreateAttendanceDto
{
    public Guid ChildrenId { get; set; }
    public Guid ScheduleId { get; set; }
    public bool IsPresent { get; set; }
}