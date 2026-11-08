using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface ITestRepository
{
    Task<IEnumerable<TestDTO>> GetAllAsync();
    Task<TestDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(TestDTO testDto);
    Task UpdateAsync(TestDTO testDto);
    Task DeleteAsync(int id);
}
