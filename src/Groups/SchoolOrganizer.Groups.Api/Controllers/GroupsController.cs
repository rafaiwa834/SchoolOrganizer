using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolOrganizer.Groups.Core.DTO;
using SchoolOrganizer.Groups.Core.Services;

namespace SchoolOrganizer.Groups.Api.Controllers;

[ApiController]
[Tags(GroupsModule.BasePath)]
[Route(GroupsModule.BasePath)]
[Authorize]
public class GroupsController: ControllerBase
{
    private readonly IGroupsService _groupsService;

    public GroupsController(IGroupsService groupsService)
    {
        _groupsService = groupsService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GroupDto>> Get(Guid id)
    {
        return Ok(await _groupsService.Get(id));
    } 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetAll()
    {
        return Ok(await _groupsService.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
    {
        return Ok( new { id = await _groupsService.Create(createGroupDto)});
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateGroupDto updateGroupDto)
    {
        await _groupsService.Update(id, updateGroupDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _groupsService.Delete(id);
        return NoContent();
    }
}