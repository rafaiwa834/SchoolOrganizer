namespace SchoolOrganizer.Groups.Core.Entities;

public class Schedule
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int Hour { get; set; }
    public float Period { get; set; }
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public List<Attendance> Attendance { get; set; }
}