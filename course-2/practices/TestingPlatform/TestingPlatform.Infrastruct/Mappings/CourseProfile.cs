using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDTO>().ReverseMap();
    }
}