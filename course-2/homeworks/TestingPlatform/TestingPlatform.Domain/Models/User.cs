using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;

        public UserRole Role { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Student? Student { get; set; }
    }
}