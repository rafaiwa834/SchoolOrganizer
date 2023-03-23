namespace SchoolOrganizer.Customers.Core.DTO;

public record ChildDto(Guid Id, Guid ParentId, Guid GroupId, string firstName,
    string LastName, DateTime BirthDay);