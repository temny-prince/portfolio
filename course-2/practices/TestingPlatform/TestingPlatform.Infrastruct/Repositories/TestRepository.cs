using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class TestRepository(AppDbContext appDbContext, IMapper mapper) : ITestRepository
{
    public async Task<IEnumerable<TestDTO>> GetAllAsync()
    {
        var tests = await appDbContext.Tests
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<TestDTO>>(tests);
    }

    public async Task<TestDTO> GetByIdAsync(int id)
    {
        var test = await appDbContext.Tests
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (test is null)
            throw new Exception("Тест не найден.");

        return mapper.Map<TestDTO>(test);
    }

    public async Task<int> CreateAsync(TestDTO testDto)
    {
        var entity = mapper.Map<Test>(testDto);

        await appDbContext.Tests.AddAsync(entity);
        await appDbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateAsync(TestDTO testDto)
    {
        var entity = await appDbContext.Tests.FirstOrDefaultAsync(t => t.Id == testDto.Id);

        if (entity is null)
            throw new Exception("Тест не найден.");

        entity.Title = testDto.Title;
        entity.Description = testDto.Description;
        entity.IsRepeatable = testDto.IsRepeatable;
        entity.Type = testDto.Type;
        entity.PublishedAt = testDto.PublishedAt;
        entity.Deadline = testDto.Deadline;
        entity.DurationMinutes = testDto.DurationMinutes;
        entity.IsPublic = testDto.IsPublic;
        entity.PassingScore = testDto.PassingScore;
        entity.MaxAttempts = testDto.MaxAttempts;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await appDbContext.Tests.FirstOrDefaultAsync(t => t.Id == id);

        if (entity is null)
            throw new Exception("Тест не найден.");

        appDbContext.Tests.Remove(entity);
        await appDbContext.SaveChangesAsync();
    }
}
