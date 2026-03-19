namespace Backend.Models.Answer;

public class AnswerOption
{
    public int Index { get; set; }
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
}
