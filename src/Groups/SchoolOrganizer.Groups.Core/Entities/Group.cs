using System.Security.Cryptography;

namespace SchoolOrganizer.Groups.Core.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }

    public void Update(string name, string description, string location)
    {
        Name = name;
        Description = description;
        Location = location;
    }
}