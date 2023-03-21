using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Groups.Contracts;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.Entities;

namespace SchoolOrganizer.Groups.Core.Services;

public class GroupsModuleApi : IGroupsModuleApi
{
    private readonly DbSet<Group> _groupsDbContext;

    public GroupsModuleApi(GroupsDbContext dbContext)
    {
        _groupsDbContext = dbContext.Groups;
    }

    public async Task<bool> CheckIfGroupExist(Guid id, CancellationToken cancellationToken = default)
    {
        return await _groupsDbContext.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not null 
            ? true : false;
    }
}