using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class DirectionProfile : Profile
{
    public DirectionProfile()
    {
        CreateMap<Direction, DirectionDTO>().ReverseMap();
    }
}

