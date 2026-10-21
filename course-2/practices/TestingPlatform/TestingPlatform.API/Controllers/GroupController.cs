using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Application.Requests.Group;
using TestingPlatform.Application.Responces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;
using TestingPlatform.Infrastruct.Repositories;

namespace TestingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController(IGroupRepository groupRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
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
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest group)
        {
            var id = await groupRepository.CreateAsync(mapper.Map<GroupDTO>(group));

            return StatusCode(StatusCodes.Status201Created, new { Id = id });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupRequest group)
        {
            await groupRepository.UpdateAsync(mapper.Map<GroupDTO>(group));

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await groupRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}