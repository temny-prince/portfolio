using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Course;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseRepository courseRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await courseRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<CourseResponse>>(courses));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await courseRepository.GetByIdAsync(id);
        return Ok(mapper.Map<CourseResponse>(course));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
    {
        var dto = new CourseDTO
        {
            Name = request.Name
        };

        var courseId = await courseRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = courseId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequest request)
    {
        var dto = new CourseDTO
        {
            Id = request.Id,
            Name = request.Name
        };

        await courseRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        await courseRepository.DeleteAsync(id);
        return NoContent();
    }
}
