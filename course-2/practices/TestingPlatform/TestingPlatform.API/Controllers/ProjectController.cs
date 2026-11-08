using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Project;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectRepository projectRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await projectRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<ProjectResponse>>(projects));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await projectRepository.GetByIdAsync(id);
        return Ok(mapper.Map<ProjectResponse>(project));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
    {
        var dto = new ProjectDTO
        {
            Name = request.Name
        };

        var projectId = await projectRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = projectId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequest request)
    {
        var dto = new ProjectDTO
        {
            Id = request.Id,
            Name = request.Name
        };

        await projectRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        await projectRepository.DeleteAsync(id);
        return NoContent();
    }
}
