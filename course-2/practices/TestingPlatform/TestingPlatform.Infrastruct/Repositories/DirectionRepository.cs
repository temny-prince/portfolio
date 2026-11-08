using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class DirectionRepository(AppDbContext appDbContext, IMapper mapper) : IDirectionRepository
{
    public async Task<IEnumerable<DirectionDTO>> GetAllAsync()
    {
        var directions = await appDbContext.Directions
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<DirectionDTO>>(directions);
    }

    public async Task<DirectionDTO> GetByIdAsync(int id)
    {
        var direction = await appDbContext.Directions
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        if (direction is null)
            throw new Exception("Направление не найдено.");

        return mapper.Map<DirectionDTO>(direction);
    }

    public async Task<int> CreateAsync(DirectionDTO directionDto)
    {
        var direction = mapper.Map<Direction>(directionDto);

        await appDbContext.Directions.AddAsync(direction);
        await appDbContext.SaveChangesAsync();

        return direction.Id;
    }

    public async Task UpdateAsync(DirectionDTO directionDto)
    {
        var direction = await appDbContext.Directions
            .FirstOrDefaultAsync(d => d.Id == directionDto.Id);

        if (direction is null)
            throw new Exception("Направление не найдено.");

        direction.Name = directionDto.Name;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var direction = await appDbContext.Directions
            .FirstOrDefaultAsync(d => d.Id == id);

        if (direction is null)
            throw new Exception("Направление не найдено.");

        appDbContext.Directions.Remove(direction);
        await appDbContext.SaveChangesAsync();
    }
}
