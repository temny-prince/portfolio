using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Responces;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDTO, ProjectResponse>();
    }
}

