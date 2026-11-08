using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class StudentRepository(AppDbContext appDbContext, IMapper mapper) : IStudentRepository
{
    public async Task<IEnumerable<StudentDTO>> GetAllAsync()
    {
        var students = await appDbContext.Students
            .AsNoTracking()
            .Include(s => s.User)
            .ToListAsync();

        return mapper.Map<IEnumerable<StudentDTO>>(students);
    }

    public async Task<StudentDTO> GetByIdAsync(int id)
    {
        var student = await appDbContext.Students
            .AsNoTracking()
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student is null)
            throw new Exception("Студент не найден.");

        return mapper.Map<StudentDTO>(student);
    }

    public async Task<int> CreateAsync(StudentDTO studentDto)
    {
        var student = mapper.Map<Student>(studentDto);

        await appDbContext.Students.AddAsync(student);
        await appDbContext.SaveChangesAsync();

        return student.Id;
    }

    public async Task UpdateAsync(StudentDTO studentDto)
    {
        var student = await appDbContext.Students
            .FirstOrDefaultAsync(s => s.Id == studentDto.Id);

        if (student is null)
            throw new Exception("Студент не найден.");

        student.Phone = studentDto.Phone;
        student.VkProfileLink = studentDto.VkProfileLink;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await appDbContext.Students
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student is null)
            throw new Exception("Студент не найден.");

        appDbContext.Students.Remove(student);

        if (student.User is not null)
            appDbContext.Users.Remove(student.User);

        await appDbContext.SaveChangesAsync();
    }
}