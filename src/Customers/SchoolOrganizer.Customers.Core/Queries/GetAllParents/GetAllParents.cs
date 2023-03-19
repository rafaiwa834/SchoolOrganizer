using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Customers.Core.Queries.GetAllParents;

public record GetAllParents(): IQuery<IList<ParentDto>>;