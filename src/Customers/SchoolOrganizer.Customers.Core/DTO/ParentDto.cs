using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Core.DTO;

public record ParentDto(Guid Id, string FirstName, string LastName, string Email, string PhoneNumber, string Street,
    string City, int BuildNumber, string PostalCode, List<Child> Children = null);