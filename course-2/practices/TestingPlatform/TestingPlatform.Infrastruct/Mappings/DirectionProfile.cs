using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class DirectionProfile : Profile
{
    public DirectionProfile()
    {
        CreateMap<Direction, DirectionDTO>().ReverseMap();
    }
}