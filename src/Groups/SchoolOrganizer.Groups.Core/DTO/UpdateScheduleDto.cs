namespace SchoolOrganizer.Groups.Core.DTO;

public class UpdateScheduleDto
{
    public DateTime Date { get; set; }
    public Guid GroupId { get; set; }
    public byte Hour { get; set; }
    public byte Period { get; set; }
}