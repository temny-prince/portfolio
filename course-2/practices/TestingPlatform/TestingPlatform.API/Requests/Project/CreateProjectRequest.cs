using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Project;

public class CreateProjectRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
