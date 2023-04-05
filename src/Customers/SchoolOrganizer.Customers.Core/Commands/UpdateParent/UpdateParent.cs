using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.UpdateParent;

public record UpdateParent(Guid Id, string LastName, string Email, string PhoneNumber,
    string Street, int BuildNumber, string City, string PostalCode) : ICommand;