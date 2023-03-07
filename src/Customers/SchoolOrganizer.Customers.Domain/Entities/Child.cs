namespace SchoolOrganizer.Customers.Domain.Entities;

public class Child
{
    internal Child(Guid id, Guid parentId, Guid groupId, string firstName, string lastName, DateTime birthDate)
    {
        Id = id;
        GroupId = groupId;
        ParentId = parentId;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid GroupId { get; private set; }
    public Guid ParentId { get; private set; }
    public DateTime BirthDate { get; private set; }
}