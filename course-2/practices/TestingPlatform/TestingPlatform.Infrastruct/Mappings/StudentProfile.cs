using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDTO>()
            .ForMember(d => d.User, opt => opt.MapFrom(s => s.User));

        CreateMap<StudentDTO, Student>()
            .ForMember(d => d.User, opt => opt.Ignore());
    }
}