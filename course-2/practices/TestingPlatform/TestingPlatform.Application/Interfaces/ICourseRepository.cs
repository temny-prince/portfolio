using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<CourseDTO>> GetAllAsync();
    Task<CourseDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(CourseDTO courseDto);
    Task UpdateAsync(CourseDTO courseDto);
    Task DeleteAsync(int id);
}
