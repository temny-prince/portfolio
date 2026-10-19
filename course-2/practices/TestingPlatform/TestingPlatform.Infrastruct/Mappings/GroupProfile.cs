using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupDTO>();
        CreateMap<GroupDTO, Group>()
            .ForMember(d => d.Course, o => o.Ignore())
            .ForMember(d => d.Direction, o => o.Ignore())
            .ForMember(d => d.Project, o => o.Ignore());
    }
}
