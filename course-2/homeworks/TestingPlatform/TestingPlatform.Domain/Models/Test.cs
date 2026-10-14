using TestingPlatform.Domain.Models.Enums;

namespace TestingPlatform.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public bool IsRepeatable { get; set; } = false;
        public TestType Type { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset PublishedAt { get; set; }
        public DateTimeOffset Deadline { get; set; }

        public int? DurationMinutes { get; set; }
        public bool IsPublic { get; set; } = false;
        public int? PassingScore { get; set; }
        public int? MaxAttempts { get; set; }

        public List<Question> Questions { get; set; } = new();

        public List<TestStudent> TestStudents { get; set; } = new();
        public List<TestProject> TestProjects { get; set; } = new();
        public List<TestCourse> TestCourses { get; set; } = new();
        public List<TestGroup> TestGroups { get; set; } = new();
        public List<TestDirection> TestDirections { get; set; } = new();
    }
}