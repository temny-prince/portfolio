using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Course;

public class CreateCourseRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
