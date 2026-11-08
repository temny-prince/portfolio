using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDTO>().ReverseMap();
    }
}
