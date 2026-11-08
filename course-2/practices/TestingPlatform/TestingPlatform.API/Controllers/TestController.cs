using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Test;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController(ITestRepository testRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTests()
    {
        var tests = await testRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<TestResponse>>(tests));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTestById(int id)
    {
        var test = await testRepository.GetByIdAsync(id);
        return Ok(mapper.Map<TestResponse>(test));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTest([FromBody] CreateTestRequest request)
    {
        var dto = new TestDTO
        {
            Title = request.Title,
            Description = request.Description,
            IsRepeatable = request.IsRepeatable,
            Type = request.Type,
            PublishedAt = request.PublishedAt,
            Deadline = request.Deadline,
            DurationMinutes = request.DurationMinutes,
            IsPublic = request.IsPublic,
            PassingScore = request.PassingScore,
            MaxAttempts = request.MaxAttempts
        };

        var testId = await testRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = testId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTest([FromBody] UpdateTestRequest request)
    {
        var dto = new TestDTO
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            IsRepeatable = request.IsRepeatable,
            Type = request.Type,
            PublishedAt = request.PublishedAt,
            Deadline = request.Deadline,
            DurationMinutes = request.DurationMinutes,
            IsPublic = request.IsPublic,
            PassingScore = request.PassingScore,
            MaxAttempts = request.MaxAttempts
        };

        await testRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        await testRepository.DeleteAsync(id);
        return NoContent();
    }
}
