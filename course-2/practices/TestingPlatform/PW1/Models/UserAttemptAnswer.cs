namespace PW1.Models
{
    public class UserAttemptAnswer
    {
        public int Id { get; set; }

        public bool IsCorrect { get; set; }
        public int ScoreAwarded { get; set; }

        public int AttemptId { get; set; }
        public int QuestionId { get; set; }

        public Attempt Attempt { get; set; } = null!;
        public Question Question { get; set; } = null!;

        public List<UserSelectedOption>? UserSelectedOptions { get; set; }
        public UserTextAnswer? UserTextAnswer { get; set; }
    }
}