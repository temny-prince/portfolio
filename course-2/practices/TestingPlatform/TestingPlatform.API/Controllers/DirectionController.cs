using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Direction;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectionsController(IDirectionRepository directionRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDirections()
    {
        var directions = await directionRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<DirectionResponse>>(directions));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDirectionById(int id)
    {
        var direction = await directionRepository.GetByIdAsync(id);
        return Ok(mapper.Map<DirectionResponse>(direction));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDirection([FromBody] CreateDirectionRequest request)
    {
        var dto = new DirectionDTO
        {
            Name = request.Name
        };

        var directionId = await directionRepository.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created, new { Id = directionId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDirection([FromBody] UpdateDirectionRequest request)
    {
        var dto = new DirectionDTO
        {
            Id = request.Id,
            Name = request.Name
        };

        await directionRepository.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDirection(int id)
    {
        await directionRepository.DeleteAsync(id);
        return NoContent();
    }
}
