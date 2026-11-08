using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories;

public class GroupRepository(AppDbContext appDbContext, IMapper mapper) : IGroupRepository
{
    public async Task<IEnumerable<GroupDTO>> GetAllAsync()
    {
        var groups = await appDbContext.Groups
            .AsNoTracking()
            .Include(g => g.Direction)
            .Include(g => g.Course)
            .Include(g => g.Project)
            .ToListAsync();

        return mapper.Map<IEnumerable<GroupDTO>>(groups);
    }

    public async Task<GroupDTO> GetByIdAsync(int id)
    {
        var group = await appDbContext.Groups
            .AsNoTracking()
            .Include(g => g.Direction)
            .Include(g => g.Course)
            .Include(g => g.Project)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (group is null)
            throw new Exception("Группа не найдена.");

        return mapper.Map<GroupDTO>(group);
    }

    public async Task<int> CreateAsync(GroupDTO groupDto)
    {
        var group = mapper.Map<Group>(groupDto);

        await appDbContext.Groups.AddAsync(group);
        await appDbContext.SaveChangesAsync();

        return group.Id;
    }

    public async Task UpdateAsync(GroupDTO groupDto)
    {
        var group = await appDbContext.Groups
            .FirstOrDefaultAsync(g => g.Id == groupDto.Id);

        if (group is null)
            throw new Exception("Группа не найдена.");

        group.Name = groupDto.Name;
        group.DirectionId = groupDto.DirectionId;
        group.CourseId = groupDto.CourseId;
        group.ProjectId = groupDto.ProjectId;

        await appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var group = await appDbContext.Groups
            .FirstOrDefaultAsync(g => g.Id == id);

        if (group is null)
            throw new Exception("Группа не найдена.");

        appDbContext.Groups.Remove(group);
        await appDbContext.SaveChangesAsync();
    }
}