using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastruct.Mappings;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupDTO>()
            .ForMember(d => d.Direction, opt => opt.MapFrom(s => s.Direction))
            .ForMember(d => d.Course, opt => opt.MapFrom(s => s.Course))
            .ForMember(d => d.Project, opt => opt.MapFrom(s => s.Project));

        CreateMap<GroupDTO, Group>()
            .ForMember(d => d.Direction, opt => opt.Ignore())
            .ForMember(d => d.Course, opt => opt.Ignore())
            .ForMember(d => d.Project, opt => opt.Ignore());
    }
}