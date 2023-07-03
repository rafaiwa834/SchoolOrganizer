using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Services;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Route(GroupsModule.BasePath)]
[Tags(GroupsModule.BasePath)]
public class SchedulesController: ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public SchedulesController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateScheduleDto createScheduleDto)
    {
        await _scheduleService.Create(createScheduleDto, new CancellationToken());
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromHeader] Guid scheduleId)
    {
        await _scheduleService.Delete(scheduleId, new CancellationToken());
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateScheduleDto updateScheduleDto)
    {
        await _scheduleService.Update(id, updateScheduleDto, new CancellationToken());
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<ScheduleDto>> Get(Guid groupId, DateTime from, DateTime to)
    {
        var schedules = await _scheduleService.Get(groupId, from, to, new CancellationToken());
        return Ok(schedules);
    }
}