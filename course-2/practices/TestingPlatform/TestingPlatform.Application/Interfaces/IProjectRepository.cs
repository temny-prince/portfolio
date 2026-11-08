using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectDTO>> GetAllAsync();
    Task<ProjectDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(ProjectDTO projectDto);
    Task UpdateAsync(ProjectDTO projectDto);
    Task DeleteAsync(int id);
}
