namespace Backend.Models.Result;

public class QuizResultDto
{
    public string CandidateName { get; set; } = string.Empty;
    public int Score { get; set; }
    public int TotalQuestions { get; set; }
    public DateTime SubmittedTime { get; set; }
}
