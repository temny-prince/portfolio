using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models ;
using TestingPlatform.Infrastruct.Data;

namespace TestingPlatform.Infrastruct.Repositories
{
    public class GroupRepository(AppDbContext appDbContext, IMapper mapper) : IGroupRepository
    {
        public async Task<List<GroupDTO>> GetAllAsync()
        {
            var groups = await appDbContext.Groups
                .Include(g => g.Project)
                .Include(g => g.Direction)
                .Include(g => g.Course)
                .Include(g => g.Students)
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<GroupDTO>>(groups);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var group = await appDbContext.Groups
                .Include(g => g.Project)
                .Include(g => g.Course)
                .Include(g => g.Direction)
                .AsNoTracking()
                .FirstOrDefaultAsync(group => group.Id == id);

            if (group == null)
            {
                throw new Exception("Группа не найдена.");
            }

            return mapper.Map<GroupDTO>(group);
        }


        public async Task<int> CreateAsync(GroupDTO groupDto)
        {
            if (groupDto.Direction is null) throw new ArgumentException("directionId обязателен и должен быть > 0.");
            if (groupDto.Course is null) throw new ArgumentException("courseId обязателен и должен быть > 0.");
            if (groupDto.Project is null) throw new ArgumentException("projectId обязателен и должен быть > 0.");

            var group = mapper.Map<Group>(groupDto);

            group.Direction = await appDbContext.Directions
                .FirstOrDefaultAsync(d => d.Id == groupDto.Direction.Id)
                ?? throw new Exception("Направление не найдено.");

            group.Course = await appDbContext.Courses
                .FirstOrDefaultAsync(c => c.Id == groupDto.Course.Id)
                ?? throw new Exception("Курс не найден.");

            group.Project = await appDbContext.Projects
                .FirstOrDefaultAsync(p => p.Id == groupDto.Project.Id)
                ?? throw new Exception("Проект не найден.");

            await appDbContext.Groups.AddAsync(group);
            await appDbContext.SaveChangesAsync();

            return group.Id;
        }

        public async Task UpdateAsync(GroupDTO groupDto)
        {
            var group = await appDbContext.Groups.FirstOrDefaultAsync(group => group.Id == groupDto.Id);

            if (group == null)
            {
                throw new Exception("Группа не найдена.");
            }

            group.Name = groupDto.Name;
            group.CourseId = groupDto.Course.Id;
            group.DirectionId = groupDto.Direction.Id;
            group.ProjectId = groupDto.Project.Id;

            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await appDbContext.Groups.FirstOrDefaultAsync(group => group.Id == id);

            if (group == null)
            {
                throw new Exception("Группа не найдена.");
            }

            appDbContext.Groups.Remove(group);
            await appDbContext.SaveChangesAsync();
        }
    }
}
