using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Domain.Repositories;

public interface IParentsRepository
{
    public Task<Parent> Get(Guid id, CancellationToken cancellationToken);
    public Task<Parent> GetByEmail(string email, CancellationToken cancellationToken);
    public Task<Parent> GetWithChildren(Guid id, CancellationToken cancellationToken);
    public Task Create(Parent parent, CancellationToken cancellationToken);
    public Task Update(Parent parent, CancellationToken cancellationToken);
    public Task Remove(Parent parent, CancellationToken cancellationToken);
}