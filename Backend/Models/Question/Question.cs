namespace Backend.Models.Question;

using Backend.Models.Answer;

public class Question
{
    public int Index { get; set; }
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<AnswerOption> AnswerOptions { get; set; } = new();
    public Guid CorrectAnswerId { get; set; }
}
