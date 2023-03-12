using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Customers.Domain.Entities;
using SchoolOrganizer.Customers.Domain.Exceptions;
using SchoolOrganizer.Customers.Domain.Repositories;

namespace SchoolOrganizer.Customers.Infrastructure.DAL.Repositories;

public class ParentRepository : IParentsRepository
{
    private readonly DbSet<Parent> _parentsDbContext;
    private readonly CustomersDbContext _context;

    public ParentRepository(CustomersDbContext dbContext)
    {
        _parentsDbContext = dbContext.Parents;
        _context = dbContext;
    }

    public async Task<Parent> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext
                   .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
               ?? throw new ParentNotFoundException();
    }

    public async Task<Parent> GetWithChildren(Guid id, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext
                   .Include(x => x.Children)
                   .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
               ?? throw new ParentNotFoundException();
    }

    public async Task Create(Parent parent, CancellationToken cancellationToken = default)
    {
        await _parentsDbContext.AddAsync(parent, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Parent parent, CancellationToken cancellationToken = default)
    {
        _parentsDbContext.Update(parent);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Remove(Parent parent, CancellationToken cancellationToken = default)
    {
        _parentsDbContext.Remove(parent);
        await _context.SaveChangesAsync(cancellationToken);
    }
}