using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.API.Requests.Answer;

public class CreateAnswerRequest
{
    [Required]
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    [Required]
    public int QuestionId { get; set; }
}
