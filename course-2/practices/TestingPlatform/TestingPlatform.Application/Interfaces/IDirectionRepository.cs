using TestingPlatform.Application.DTOs;

namespace TestingPlatform.Application.Interfaces;

public interface IDirectionRepository
{
    Task<IEnumerable<DirectionDTO>> GetAllAsync();
    Task<DirectionDTO> GetByIdAsync(int id);
    Task<int> CreateAsync(DirectionDTO directionDto);
    Task UpdateAsync(DirectionDTO directionDto);
    Task DeleteAsync(int id);
}
