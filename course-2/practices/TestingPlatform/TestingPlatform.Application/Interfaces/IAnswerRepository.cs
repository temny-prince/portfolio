using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IAnswerRepository
{
    Task<IEnumerable<AnswerDTO>> GetAllAsync();
    Task<AnswerDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(AnswerDTO answerDto);
    Task UpdateAsync(AnswerDTO answerDto);
    Task DeleteAsync(int id);
}
