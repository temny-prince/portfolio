using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Group;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController(IGroupRepository groupRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
        var groups = await groupRepository.GetAllAsync();

        return Ok(mapper.Map<IEnumerable<GroupResponse>>(groups));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGroupById(int id)
    {
        var group = await groupRepository.GetByIdAsync(id);

        return Ok(mapper.Map<GroupResponse>(group));
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
    {
        var dto = new GroupDTO
        {
            Name = request.Name,
            DirectionId = request.DirectionId,
            CourseId = request.CourseId,
            ProjectId = request.ProjectId
        };

        var groupId = await groupRepository.CreateAsync(dto);

        return StatusCode(StatusCodes.Status201Created, new { Id = groupId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupRequest request)
    {
        var dto = new GroupDTO
        {
            Id = request.Id,
            Name = request.Name,
            DirectionId = request.DirectionId,
            CourseId = request.CourseId,
            ProjectId = request.ProjectId
        };

        await groupRepository.UpdateAsync(dto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        await groupRepository.DeleteAsync(id);

        return NoContent();
    }
}