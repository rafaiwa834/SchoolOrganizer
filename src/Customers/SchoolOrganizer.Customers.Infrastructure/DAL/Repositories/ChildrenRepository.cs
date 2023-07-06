using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Customers.Domain.Entities;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;

namespace SchoolOrganizer.Customers.Infrastructure.DAL.Repositories;

public class ChildrenRepository: IChildrenRepository
{
    private readonly CustomersDbContext _context;
    private readonly DbSet<Child> _childrenDbContext;

    public ChildrenRepository(CustomersDbContext dbContext)
    {
        _childrenDbContext = dbContext.Children;
        _context = dbContext;
    }
    public async Task<Child> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await _childrenDbContext
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Child>> GetByParentId(Guid parentId, CancellationToken cancellationToken = default)
    {
        return await _childrenDbContext
            .Where(x => x.ParentId == parentId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task Create(Child child, CancellationToken cancellationToken = default)
    {
        await _childrenDbContext.AddAsync(child, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Child child, CancellationToken cancellationToken = default)
    {
        _childrenDbContext.Update(child);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Remove(Child child, CancellationToken cancellationToken = default)
    {
        _childrenDbContext.Remove(child);
        await _context.SaveChangesAsync(cancellationToken);
    }
}