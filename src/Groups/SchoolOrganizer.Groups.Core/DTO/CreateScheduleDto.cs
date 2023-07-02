namespace SchoolOrganizer.Groups.Core.DTO;

public class CreateScheduleDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid GroupId { get; set; }
    public byte Hour { get; set; }
    public byte Period { get; set; }
}