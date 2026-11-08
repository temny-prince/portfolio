using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IGroupRepository
{
    Task<IEnumerable<GroupDTO>> GetAllAsync();
    Task<GroupDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(GroupDTO groupDto);
    Task UpdateAsync(GroupDTO groupDto);
    Task DeleteAsync(int id);
}