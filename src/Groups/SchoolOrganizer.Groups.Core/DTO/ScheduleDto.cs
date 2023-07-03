namespace SchoolOrganizer.Groups.Core.DTO;

public class ScheduleDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int Hour { get; set; }
    public float Period { get; set; }
    public Guid GroupId { get; set; }
}