using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDTO>> GetAllAsync();
    Task<UserDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(UserDTO userDto, string password);
    Task UpdateAsync(UserDTO userDto);
    Task UpdateAsync(UserDTO userDto, string password);
    Task DeleteAsync(int id);
}