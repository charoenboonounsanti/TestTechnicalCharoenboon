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
            Index = q.Index,
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
        var validationErrors = ValidateAnswers(request.Answers, questions, out var parsedAnswers);
        if (validationErrors.Count > 0)
        {
            return BadRequest(new ValidationProblemDetails(validationErrors));
        }

        int score = 0;
        foreach (var question in questions)
        {
            if (parsedAnswers.TryGetValue(question.Id, out Guid selectedOptionId) &&
                selectedOptionId == question.CorrectAnswerId)
            {
                score++;
            }
        }

        var result = new QuizResult
        {
            CandidateName = request.CandidateName,
            Score = score,
            TotalQuestions = questions.Count,
            SubmittedTime = DateTime.UtcNow,
            Answers = parsedAnswers
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

    private static Dictionary<string, string[]> ValidateAnswers(
        Dictionary<string, string> answers,
        List<Question> questions,
        out Dictionary<Guid, Guid> parsedAnswers)
    {
        parsedAnswers = new Dictionary<Guid, Guid>();
        var errors = new Dictionary<string, string[]>();
        var questionMap = questions.ToDictionary(question => question.Id);

        if (answers.Count == 0)
        {
            errors["answers"] = ["At least one answer is required."];
            return errors;
        }

        foreach (var (questionId, selectedOptionId) in answers)
        {
            if (!Guid.TryParse(questionId, out var parsedQuestionId))
            {
                errors[$"answers.{questionId}"] = ["Question ID must be a valid UUID."];
                continue;
            }

            if (!questionMap.TryGetValue(parsedQuestionId, out var question))
            {
                errors[$"answers.{questionId}"] = ["Question does not exist."];
                continue;
            }

            if (!Guid.TryParse(selectedOptionId, out var parsedAnswerId))
            {
                errors[$"answers.{questionId}"] = ["Answer option ID must be a valid UUID."];
                continue;
            }

            var answerExists = question.AnswerOptions.Any(option => option.Id == parsedAnswerId);
            if (!answerExists)
            {
                errors[$"answers.{questionId}"] = ["Selected answer option does not exist for this question."];
                continue;
            }

            parsedAnswers[parsedQuestionId] = parsedAnswerId;
        }

        var answeredQuestionIds = parsedAnswers.Keys.ToHashSet();
        var missingQuestionIds = questions
            .Select(question => question.Id)
            .Where(questionId => !answeredQuestionIds.Contains(questionId))
            .ToList();

        if (missingQuestionIds.Count > 0)
        {
            errors["answers.missing"] =
            [
                $"Missing answers for question IDs: {string.Join(", ", missingQuestionIds)}."
            ];
        }

        return errors;
    }
}

public class SubmitQuizRequest
{
    public string CandidateName { get; set; } = string.Empty;
    public Dictionary<string, string> Answers { get; set; } = new(); // questionId -> selectedOptionId
}
