using AutoMapper;
using TestingPlatform.Application.DTOs;
using TestingPlatform.Application.Requests.Group;
using TestingPlatform.Application.Responces;
using TestingPlatform.Domain.Models;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<GroupDTO, Group>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Direction, o => o.Ignore())
            .ForMember(d => d.Course, o => o.Ignore())
            .ForMember(d => d.Project, o => o.Ignore())
            .ForMember(d => d.Students, o => o.Ignore())
            .ForMember(d => d.TestGroups, o => o.Ignore());

        CreateMap<GroupDTO, GroupResponse>();

        CreateMap<CreateGroupRequest, GroupDTO>()
            .ForMember(d => d.Direction, o => o.MapFrom(s => s.DirectionId > 0 ? new DirectionDTO { Id = s.DirectionId } : null))
            .ForMember(d => d.Course, o => o.MapFrom(s => s.CourseId > 0 ? new CourseDTO { Id = s.CourseId } : null))
            .ForMember(d => d.Project, o => o.MapFrom(s => s.ProjectId > 0 ? new ProjectDTO { Id = s.ProjectId } : null));

        CreateMap<UpdateGroupRequest, GroupDTO>()
            .ForMember(d => d.Direction, o => o.MapFrom(s => s.DirectionId > 0 ? new DirectionDTO { Id = s.DirectionId } : null))
            .ForMember(d => d.Course, o => o.MapFrom(s => s.CourseId > 0 ? new CourseDTO { Id = s.CourseId } : null))
            .ForMember(d => d.Project, o => o.MapFrom(s => s.ProjectId > 0 ? new ProjectDTO { Id = s.ProjectId } : null));
    }
}