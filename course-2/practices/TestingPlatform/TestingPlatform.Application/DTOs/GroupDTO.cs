namespace TestingPlatform.Application.DTOs;

public class GroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int DirectionId { get; set; }
    public int CourseId { get; set; }
    public int ProjectId { get; set; }

    public DirectionDTO? Direction { get; set; }
    public CourseDTO? Course { get; set; }
    public ProjectDTO? Project { get; set; }
}
