using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Domain.Repositories;

public interface IParentsRepository
{
    public Task<Parent> Get(Guid id, CancellationToken cancellationToken = default);
    public Task<Parent> GetWithChildren(Guid id,CancellationToken cancellationToken = default);
    public Task Create(Parent parent,CancellationToken cancellationToken = default);
    public Task Update(Parent parent,CancellationToken cancellationToken = default);
    public Task Remove(Parent parent,CancellationToken cancellationToken = default);
}