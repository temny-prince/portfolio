using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.API.Requests.Test;

public class UpdateTestRequest
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public bool IsRepeatable { get; set; }

    [Required]
    public TestType Type { get; set; }

    public DateTimeOffset PublishedAt { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public int? DurationMinutes { get; set; }
    public bool IsPublic { get; set; }
    public int? PassingScore { get; set; }
    public int? MaxAttempts { get; set; }
}
