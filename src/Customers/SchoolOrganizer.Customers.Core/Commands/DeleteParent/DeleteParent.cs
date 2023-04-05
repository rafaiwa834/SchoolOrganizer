using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.DeleteParent;

public record DeleteParent(Guid Id) : ICommand;