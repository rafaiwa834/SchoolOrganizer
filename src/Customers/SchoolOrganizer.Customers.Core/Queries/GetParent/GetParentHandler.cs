using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Customers.Core.Queries.GetParent;

public class GetParentHandler: IQueryHandler<GetParent, ParentDto>
{
    private readonly IParentsRepository _parentsRepository;

    public GetParentHandler(IParentsRepository parentsRepository)
    {
        _parentsRepository = parentsRepository;
    }
    public async Task<ParentDto> HandleAsync(GetParent query, CancellationToken cancellationToken)
    {
        var parent = await _parentsRepository.Get(query.Id, cancellationToken)
            ?? throw new ParentNotFoundException();

        return new ParentDto(
            Id: parent.Id,
            FirstName: parent.FirstName,
            LastName: parent.LastName,
            Email: parent.Email,
            PhoneNumber: parent.PhoneNumber,
            Street: parent.Street,
            City: parent.City,
            BuildNumber: parent.BuildNumber,
            PostalCode: parent.PostalCode
            );
    }
}