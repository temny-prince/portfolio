using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Responces;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDTO, CourseResponse>();
    }
}