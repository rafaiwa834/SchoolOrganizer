using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Customers.Core.DTO;
using SchoolOrganizer.Customers.Domain.Entities;
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

    public async Task<IList<Parent>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext.AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<Parent> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Parent>> GetMultiple(List<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext.Where(x => ids.Contains(x.Id)).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Parent> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext
            .SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<Parent> GetWithChildren(Guid id, CancellationToken cancellationToken = default)
    {
        return await _parentsDbContext
            .Include(x => x.Children)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
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