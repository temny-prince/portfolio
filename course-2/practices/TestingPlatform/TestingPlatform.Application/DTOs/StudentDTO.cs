namespace TestingPlatform.Application.DTOs;

public class StudentDTO
{
    public int Id { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string VkProfileLink { get; set; } = string.Empty;
    public int UserId { get; set; }
    public UserDTO? User { get; set; }
}