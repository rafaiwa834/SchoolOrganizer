using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Domain.Repositories;

public interface IChildrenRepository
{
    public Task<Child?> Get(Guid id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<Child>> GetByParentId(Guid parentId, CancellationToken cancellationToken = default);
    public Task Create(Child child, CancellationToken cancellationToken = default);
    public Task Update(Child child, CancellationToken cancellationToken = default);
    public Task Remove(Child child, CancellationToken cancellationToken = default);
}