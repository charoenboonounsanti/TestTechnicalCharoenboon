namespace Backend.Models.Result;

public class QuizResult
{
    public string CandidateName { get; set; } = string.Empty;
    public int Score { get; set; }
    public int TotalQuestions { get; set; }
    public DateTime SubmittedTime { get; set; }
    public Dictionary<int, int> Answers { get; set; } = new();
}
