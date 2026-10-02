namespace PW1.Models
{
    public class UserSelectedOption
    {
        public int Id { get; set; }

        public int UserAttemptAnswerId { get; set; }
        public int AnswerId { get; set; }

        public UserAttemptAnswer UserAttemptAnswer { get; set; } = null!;
        public Answer Answer { get; set; } = null!;
    }
}