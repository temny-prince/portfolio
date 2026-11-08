using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class AnswerRepository(AppDbContext appDbContext, IMapper mapper) : IAnswerRepository
{
    public async Task<IEnumerable<AnswerDTO>> GetAllAsync()
    {
        var answers = await appDbContext.Answers
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<AnswerDTO>>(answers);
    }

    public async Task<AnswerDTO> GetByIdAsync(int id)
    {
        var answer = await appDbContext.Answers
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (answer is null)
            throw new Exception("Ответ не найден.");

        return mapper.Map<AnswerDTO>(answer);
    }

    public async Task<int> CreateAsync(AnswerDTO answerDto)
    {
        var entity = mapper.Map<Answer>(answerDto);

        await appDbContext.Answers.AddAsync(entity);
        await appDbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateAsync(AnswerDTO answerDto)
    {
        var entity = await appDbContext.Answers.FirstOrDefaultAsync(a => a.Id == answerDto.Id);

        if (entity is null)
            throw new Exception("Ответ не найден.");

        entity.Text = answerDto.Text;
        entity.IsCorrect = answerDto.IsCorrect;
        entity.QuestionId = answerDto.QuestionId;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await appDbContext.Answers.FirstOrDefaultAsync(a => a.Id == id);

        if (entity is null)
            throw new Exception("Ответ не найден.");

        appDbContext.Answers.Remove(entity);
        await appDbContext.SaveChangesAsync();
    }
}
