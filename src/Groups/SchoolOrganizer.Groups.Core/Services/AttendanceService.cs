using SchoolOrganizer.Customers.Contracts;
using SchoolOrganizer.Groups.Core.DAL;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Entities;
using SchoolOrganizer.Groups.Core.Exceptions;

namespace SchoolOrganizer.Groups.Core.Services;

public class AttendanceService: IAttendanceService
{
    private readonly GroupsDbContext _dbContext;
    private readonly ICustomersModuleClient _customersModuleClient;

    public AttendanceService(GroupsDbContext dbContext, ICustomersModuleClient customersModuleClient)
    {
        _dbContext = dbContext;
        _customersModuleClient = customersModuleClient;
    }

    public async Task Create(CreateAttendanceDto createAttendance, CancellationToken cancellationToken)
    {
        if (await _customersModuleClient.CheckIfChildrenExists(createAttendance.ChildrenId, cancellationToken))
            throw new ChildrenNotFound(createAttendance.ChildrenId.ToString());

        var attendance = new Attendance()
        {
            Id = Guid.NewGuid(),
            ChildrenId = createAttendance.ChildrenId,
            ScheduleId = createAttendance.ScheduleId,
            IsPresent = createAttendance.IsPresent
        };
        await _dbContext.Attendance.AddAsync(attendance, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}