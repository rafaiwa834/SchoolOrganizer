using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Entities;
using SchoolOrganizer.Groups.Core.Exceptions;

namespace SchoolOrganizer.Groups.Core.Services;

public class SchedulesService
{
    private readonly GroupsDbContext _dbContext;

    public SchedulesService(GroupsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(CreateScheduleDto createScheduleDto, CancellationToken cancellationToken)
    {
        var group = _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == createScheduleDto.GroupId, cancellationToken);
        if(group is null) 
            throw new GroupNotFoundException(createScheduleDto.GroupId.ToString());

        await _dbContext.Schedules.AddAsync(new Schedule()
        {
            Id = createScheduleDto.Id,
            Date = createScheduleDto.Date,
            GroupId = createScheduleDto.GroupId,
            Hour = createScheduleDto.Hour,
            Period = createScheduleDto.Period
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid scheduleId, CancellationToken cancellationToken)
    {
        _dbContext.Schedules.Remove(new Schedule() { Id = scheduleId });
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}