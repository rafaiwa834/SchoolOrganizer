namespace SchoolOrganizer.Groups.Core.DTO;

public class UpdateGroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
}