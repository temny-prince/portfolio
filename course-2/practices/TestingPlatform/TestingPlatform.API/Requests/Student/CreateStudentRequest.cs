using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Student;

public class CreateStudentRequest
{
    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [Url]
    public string VkProfileLink { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }
}
