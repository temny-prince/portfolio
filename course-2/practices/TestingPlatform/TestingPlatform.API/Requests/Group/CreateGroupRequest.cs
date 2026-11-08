using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Group;

public class CreateGroupRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int DirectionId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    public int ProjectId { get; set; }
}