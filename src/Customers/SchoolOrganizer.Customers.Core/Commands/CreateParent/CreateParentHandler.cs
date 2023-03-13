using SchoolOrganizer.Customers.Domain.Entities;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;
using SchoolOrganizer.Shared.Abstractions.Commands;

namespace SchoolOrganizer.Customers.Core.Commands.CreateParent;

public class CreateParentHandler: ICommandHandler<CreateParent>
{
    private readonly IParentsRepository _parentsRepository;

    public CreateParentHandler(IParentsRepository parentsRepository)
    {
        _parentsRepository = parentsRepository;
    }
    public async Task HandleAsync(CreateParent command, CancellationToken cancellationToken = default)
    {
        var parent = await _parentsRepository.GetByEmail(command.Email, cancellationToken);
        if (parent is not null)
            throw new EmailInUseException(command.Email);

        parent = new Parent(
            id: Guid.NewGuid(), 
            email: command.Email,
            firstName: command.FirstName,
            lastName: command.LastName,
            phoneNumber: command.PhoneNumber,
            city: command.City,
            street: command.Street,
            buildNumber: command.BuildNumber,
            postalCode: command.PostalCode
        );
        await _parentsRepository.Create(parent, cancellationToken);
    }
}