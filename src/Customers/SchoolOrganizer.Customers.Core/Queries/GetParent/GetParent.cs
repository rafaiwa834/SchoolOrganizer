using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Customers.Core.Queries.GetParent;

public record GetParent(Guid Id): IQuery<ParentDto>;