using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.UpdateChild;

public record UpdateChild(Guid Id, Guid GroupId): ICommand;