using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Entities;
using SchoolOrganizer.Groups.Core.Exceptions;

namespace SchoolOrganizer.Groups.Core.Services;

public class GroupsService: IGroupService
{
    private readonly GroupsDbContext _dbContext;
    private readonly ILogger<GroupsService> _logger;

    public GroupsService(GroupsDbContext dbContext, ILogger<GroupsService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<GroupDto>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Groups.Select(x => new GroupDto()
                { Id = x.Id, Name = x.Name, Description = x.Description, Location = x.Location })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<GroupDto> Get(Guid id,CancellationToken cancellationToken = default)
    {
        return await _dbContext.Groups
            .Select(x=> new GroupDto() {Id = x.Id, Name = x.Name, Description = x.Description, Location = x.Location})
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? throw new GroupNotFoundException(id.ToString());
    }

    public async Task<Guid> Create(CreateGroupDto createGroupDto, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Name == createGroupDto.Name, cancellationToken);
        if (group is not null)
            throw new GroupNameAlreadyExistsException(createGroupDto.Name);
        group = new Group()
        {
            Id = Guid.NewGuid(),
            Name = createGroupDto.Name,
            Description = createGroupDto.Description,
            Location = createGroupDto.Location,
            IsActive = true,
        };
        await _dbContext.Groups.AddAsync(group, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return group.Id;
    }
    
    public async Task Update(UpdateGroupDto updateGroupDto, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == updateGroupDto.Id, cancellationToken);
        if (group is null)
            throw new GroupNotFoundException(updateGroupDto.Id.ToString());
        
        var groupsWithTheSameName = await _dbContext.Groups
            .Where(x => x.Id != updateGroupDto.Id && x.Name == updateGroupDto.Name)
            .AsNoTracking().ToListAsync(cancellationToken);
        if (groupsWithTheSameName.Any())
            throw new GroupNameAlreadyExistsException(updateGroupDto.Name);

        group.Update(updateGroupDto.Name, updateGroupDto.Description, updateGroupDto.Location);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var group = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (group is null)
            throw new GroupNotFoundException(id.ToString());
        _dbContext.Groups.Remove(group);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}