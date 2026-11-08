using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.User;
using TestingPlatform.API.Responses;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;

namespace TestingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userRepository.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<UserResponse>>(users));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userRepository.GetByIdAsync(id);
        return Ok(mapper.Map<UserResponse>(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var dto = new UserDTO
        {
            Login = request.Login,
            Email = request.Email,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Role = request.Role
        };

        var userId = await userRepository.CreateAsync(dto, request.Password);
        return StatusCode(StatusCodes.Status201Created, new { Id = userId });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var dto = new UserDTO
        {
            Id = request.Id,
            Login = request.Login,
            Email = request.Email,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            Role = request.Role
        };

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            await userRepository.UpdateAsync(dto, request.Password);
        }
        else
        {
            await userRepository.UpdateAsync(dto);
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userRepository.DeleteAsync(id);
        return NoContent();
    }
}
