namespace TestingPlatform.Domain.Models
{
    public class Attempt
    {
        public int Id { get; set; }

        public DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset? SubmittedAt { get; set; }

        public int? Score { get; set; }

        public int TestId { get; set; }
        public int StudentId { get; set; }

        public Test Test { get; set; } = null!;
        public Student Student { get; set; } = null!;

        public List<UserAttemptAnswer> UserAttemptAnswers { get; set; } = new();
    }
}