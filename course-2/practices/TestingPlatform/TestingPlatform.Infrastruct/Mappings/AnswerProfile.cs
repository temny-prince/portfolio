using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Answer, AnswerDTO>().ReverseMap();
    }
}
