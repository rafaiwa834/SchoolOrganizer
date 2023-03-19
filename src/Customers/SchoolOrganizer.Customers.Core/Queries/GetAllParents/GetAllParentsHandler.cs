using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Customers.Core.Queries.GetAllParents;

public class GetAllParentsHandler : IQueryHandler<GetAllParents, IList<ParentDto>>
{
    private readonly IParentsRepository _parentsRepository;

    public GetAllParentsHandler(IParentsRepository parentsRepository)
    {
        _parentsRepository = parentsRepository;
    }

    public async Task<IList<ParentDto>> HandleAsync(GetAllParents query,
        CancellationToken cancellationToken = default)
    {
        var parents = await _parentsRepository.GetAll(cancellationToken);

        return parents.Select(x => new ParentDto(x.Id, x.FirstName, x.LastName, x.Email, x.PhoneNumber, x.Street,
            x.City, x.BuildNumber, x.PostalCode)).ToList();
    }
}