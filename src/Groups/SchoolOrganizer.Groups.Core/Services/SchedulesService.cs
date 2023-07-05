using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Entities;
using SchoolOrganizer.Groups.Core.Exceptions;

namespace SchoolOrganizer.Groups.Core.Services;

public class SchedulesService: IScheduleService
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
            Date = createScheduleDto.Date.Date,
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

    public async Task Update(Guid scheduleId, UpdateScheduleDto updateScheduleDto, CancellationToken cancellationToken)
    {
        var schedule = await _dbContext.Schedules.FirstOrDefaultAsync(x => x.Id == scheduleId, cancellationToken);
        if (schedule is null)
            throw new ScheduleNotFoundException(scheduleId.ToString());
        schedule.Date = updateScheduleDto.Date;
        schedule.Hour = updateScheduleDto.Hour;
        schedule.Period = updateScheduleDto.Period;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ScheduleDto>> Get(Guid groupId, DateTime fromThisDate, DateTime toThisDate, CancellationToken cancellationToken)
    {
        fromThisDate = fromThisDate.Date;
        toThisDate = toThisDate.Date;
        return await _dbContext.Schedules.Where(x => x.GroupId == groupId && x.Date <= toThisDate && x.Date >= fromThisDate)
            .Select(x=> new ScheduleDto(){Id = x.Id, Date = x.Date, Hour = x.Hour, Period = x.Period, GroupId = x.GroupId})
            .ToListAsync(cancellationToken);
    }
}