using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Responces;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class DirectionProfile : Profile
{
    public DirectionProfile()
    {
        CreateMap<DirectionDTO, DirectionResponse>();
    }
}

