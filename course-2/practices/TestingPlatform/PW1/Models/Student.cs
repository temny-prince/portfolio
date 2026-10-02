using PW1.Models.JoinTablesModels;

namespace PW1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Phone { get; set; } = null!;
        public string VkProfileLink { get; set; } = null!;
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public List<Group> Groups { get; set; } = new();
        public List<TestStudent> TestStudents { get; set; } = new();
        public List<Attempt> Attempts { get; set; } = new();
        public List<TestResult> TestResults { get; set; } = new();
    }
}