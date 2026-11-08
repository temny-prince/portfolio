using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class ProjectRepository(AppDbContext appDbContext, IMapper mapper) : IProjectRepository
{
    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await appDbContext.Projects
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects);
    }

    public async Task<ProjectDTO> GetByIdAsync(int id)
    {
        var project = await appDbContext.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project is null)
            throw new Exception("Проект не найден.");

        return mapper.Map<ProjectDTO>(project);
    }

    public async Task<int> CreateAsync(ProjectDTO projectDto)
    {
        var project = mapper.Map<Project>(projectDto);

        await appDbContext.Projects.AddAsync(project);
        await appDbContext.SaveChangesAsync();

        return project.Id;
    }

    public async Task UpdateAsync(ProjectDTO projectDto)
    {
        var project = await appDbContext.Projects
            .FirstOrDefaultAsync(p => p.Id == projectDto.Id);

        if (project is null)
            throw new Exception("Проект не найден.");

        project.Name = projectDto.Name;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var project = await appDbContext.Projects
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project is null)
            throw new Exception("Проект не найден.");

        appDbContext.Projects.Remove(project);
        await appDbContext.SaveChangesAsync();
    }
}
