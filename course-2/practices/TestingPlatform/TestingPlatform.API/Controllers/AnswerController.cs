using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Answer;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController(IAnswerRepository answerRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAnswers()
    {
        var answers = await answerRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<AnswerResponse>>(answers));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAnswerById(int id)
    {
        var answer = await answerRepository.GetByIdAsync(id);
        return Ok(mapper.Map<AnswerResponse>(answer));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerRequest request)
    {
        var dto = new AnswerDTO
        {
            Text = request.Text,
            IsCorrect = request.IsCorrect,
            QuestionId = request.QuestionId
        };

        var answerId = await answerRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = answerId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerRequest request)
    {
        var dto = new AnswerDTO
        {
            Id = request.Id,
            Text = request.Text,
            IsCorrect = request.IsCorrect,
            QuestionId = request.QuestionId
        };

        await answerRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAnswer(int id)
    {
        await answerRepository.DeleteAsync(id);
        return NoContent();
    }
}
