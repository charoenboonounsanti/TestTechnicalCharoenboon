namespace Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using Backend.Models.Question;
using Backend.Models.Result;
using Backend.Repositories.Interface;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizRepository _quizRepository;
    private readonly IResultRepository _resultRepository;

    public QuizController(IQuizRepository quizRepository, IResultRepository resultRepository)
    {
        _quizRepository = quizRepository;
        _resultRepository = resultRepository;
    }

    [HttpGet("questions")]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestions()
    {
        var questions = await _quizRepository.GetAllQuestionsAsync();
        var questionDtos = questions.Select(q => new QuestionDto
        {
            Id = q.Id,
            Text = q.Text,
            AnswerOptions = q.AnswerOptions
        }).ToList();
        return Ok(questionDtos);
    }

    [HttpPost("submit")]
    public async Task<ActionResult<QuizResultDto>> SubmitQuiz([FromBody] SubmitQuizRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.CandidateName))
        {
            return BadRequest("Candidate name is required");
        }

        var questions = await _quizRepository.GetAllQuestionsAsync();
        
        int score = 0;
        foreach (var question in questions)
        {
            if (request.Answers.TryGetValue(question.Id, out int selectedOptionId))
            {
                if (selectedOptionId == question.CorrectAnswerId)
                {
                    score++;
                }
            }
        }

        var result = new QuizResult
        {
            CandidateName = request.CandidateName,
            Score = score,
            TotalQuestions = questions.Count,
            SubmittedTime = DateTime.UtcNow,
            Answers = request.Answers
        };

        await _resultRepository.SaveResultAsync(result);

        return Ok(new QuizResultDto
        {
            CandidateName = result.CandidateName,
            Score = result.Score,
            TotalQuestions = result.TotalQuestions,
            SubmittedTime = result.SubmittedTime
        });
    }
}

public class SubmitQuizRequest
{
    public string CandidateName { get; set; } = string.Empty;
    public Dictionary<int, int> Answers { get; set; } = new(); // questionId -> selectedOptionId
}
