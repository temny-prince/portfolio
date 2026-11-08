using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.API.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
