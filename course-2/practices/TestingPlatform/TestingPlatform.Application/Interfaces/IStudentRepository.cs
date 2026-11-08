using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IStudentRepository
{
    Task<IEnumerable<StudentDTO>> GetAllAsync();
    Task<StudentDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(StudentDTO studentDto);
    Task UpdateAsync(StudentDTO studentDto);
    Task DeleteAsync(int id);
}