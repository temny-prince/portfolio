using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Student;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentRepository studentRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await studentRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<StudentResponse>>(students));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await studentRepository.GetByIdAsync(id);
        return Ok(mapper.Map<StudentResponse>(student));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
    {
        var dto = new StudentDTO
        {
            Phone = request.Phone,
            VkProfileLink = request.VkProfileLink,
            UserId = request.UserId
        };

        var studentId = await studentRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = studentId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest request)
    {
        var dto = new StudentDTO
        {
            Id = request.Id,
            Phone = request.Phone,
            VkProfileLink = request.VkProfileLink,
            UserId = request.UserId
        };

        await studentRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await studentRepository.DeleteAsync(id);
        return NoContent();
    }
}
