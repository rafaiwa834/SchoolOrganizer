using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.CreateParent;

public record CreateParent(string Email, string FirstName, string LastName, string PhoneNumber,
    string Street, int BuildNumber, string City, string PostalCode) : ICommand;