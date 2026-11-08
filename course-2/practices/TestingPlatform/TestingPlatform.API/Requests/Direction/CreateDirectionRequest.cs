using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Direction;

public class CreateDirectionRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
