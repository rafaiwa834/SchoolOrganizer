namespace SchoolOrganizer.Customers.Domain.Entities;

public class Parent
{
    private List<Child> _children = new();
    
    internal Parent(Guid id, string firstName, string lastName, string email, string phoneNumber,
        string street, string city, string postalCode, int buildNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Street = street;
        BuildNumber = buildNumber;
        City = city;
        PostalCode = postalCode;
    }
    
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Street { get; private set; }
    public int BuildNumber { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public IReadOnlyCollection<Child> Children => _children;

    internal Child CreateChild(Guid id, Guid groupId , string firstName, string lastName, DateTime birthDate)
    {
        var child = new Child(id, Id, groupId, firstName, lastName, birthDate);
        _children.Add(child);
        return child;
    }
}