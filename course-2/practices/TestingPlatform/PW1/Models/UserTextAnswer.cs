namespace PW1.Models
{
    public class UserTextAnswer
    {
        public int Id { get; set; }

        public string TextAnswer { get; set; } = null!;

        public int UserAttemptAnswerId { get; set; }
        public UserAttemptAnswer UserAttemptAnswer { get; set; } = null!;
    }
}