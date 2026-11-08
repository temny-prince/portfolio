namespace TestingPlatform.API.Responses;

public class StudentResponse
{
    public int Id { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string VkProfileLink { get; set; } = string.Empty;
    public int UserId { get; set; }
    public UserResponse? User { get; set; }
}
