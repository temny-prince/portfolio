using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Course;

public class UpdateCourseRequest
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
