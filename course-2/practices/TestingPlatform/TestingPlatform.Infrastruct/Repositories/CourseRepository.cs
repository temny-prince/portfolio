using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class CourseRepository(AppDbContext appDbContext, IMapper mapper) : ICourseRepository
{
    public async Task<IEnumerable<CourseDTO>> GetAllAsync()
    {
        var courses = await appDbContext.Courses
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<CourseDTO>>(courses);
    }

    public async Task<CourseDTO> GetByIdAsync(int id)
    {
        var course = await appDbContext.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course is null)
            throw new Exception(" урс не найден.");

        return mapper.Map<CourseDTO>(course);
    }

    public async Task<int> CreateAsync(CourseDTO courseDto)
    {
        var course = mapper.Map<Course>(courseDto);

        await appDbContext.Courses.AddAsync(course);
        await appDbContext.SaveChangesAsync();

        return course.Id;
    }

    public async Task UpdateAsync(CourseDTO courseDto)
    {
        var course = await appDbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == courseDto.Id);

        if (course is null)
            throw new Exception(" урс не найден.");

        course.Name = courseDto.Name;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var course = await appDbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course is null)
            throw new Exception(" урс не найден.");

        appDbContext.Courses.Remove(course);
        await appDbContext.SaveChangesAsync();
    }
}
