using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.CreateChild;

public record CreateChild(Guid GroupId, Guid ParentId, string FirstName, string LastName, DateTime BirthDate): ICommand;