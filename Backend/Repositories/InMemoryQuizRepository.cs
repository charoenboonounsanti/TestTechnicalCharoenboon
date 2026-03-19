namespace Backend.Repositories;

using Backend.Models.Answer;
using Backend.Models.Question;
using Backend.Repositories.Interface;

public class InMemoryQuizRepository : IQuizRepository
{
    private readonly List<Question> _questions;

    public InMemoryQuizRepository()
    {
        _questions = InitializeMockData();
    }

    public Task<List<Question>> GetAllQuestionsAsync()
    {
        return Task.FromResult(_questions);
    }

    private List<Question> InitializeMockData()
    {
        return new List<Question>
        {
            new Question
            {
                Id = 1,
                Text = "2 + 3 เท่ากับเท่าไร",
                CorrectAnswerId = 2,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "4" },
                    new AnswerOption { Id = 2, Text = "5" },
                    new AnswerOption { Id = 3, Text = "6" },
                    new AnswerOption { Id = 4, Text = "7" }
                }
            },
            new Question
            {
                Id = 2,
                Text = "7 - 4 เท่ากับเท่าไร",
                CorrectAnswerId = 3,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "1" },
                    new AnswerOption { Id = 2, Text = "2" },
                    new AnswerOption { Id = 3, Text = "3" },
                    new AnswerOption { Id = 4, Text = "4" }
                }
            },
            new Question
            {
                Id = 3,
                Text = "5 x 2 เท่ากับเท่าไร",
                CorrectAnswerId = 4,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "7" },
                    new AnswerOption { Id = 2, Text = "8" },
                    new AnswerOption { Id = 3, Text = "9" },
                    new AnswerOption { Id = 4, Text = "10" }
                }
            },
            new Question
            {
                Id = 4,
                Text = "12 / 3 เท่ากับเท่าไร",
                CorrectAnswerId = 1,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "4" },
                    new AnswerOption { Id = 2, Text = "3" },
                    new AnswerOption { Id = 3, Text = "5" },
                    new AnswerOption { Id = 4, Text = "6" }
                }
            },
            new Question
            {
                Id = 5,
                Text = "9 + 6 เท่ากับเท่าไร",
                CorrectAnswerId = 3,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "13" },
                    new AnswerOption { Id = 2, Text = "14" },
                    new AnswerOption { Id = 3, Text = "15" },
                    new AnswerOption { Id = 4, Text = "16" }
                }
            },
            new Question
            {
                Id = 6,
                Text = "10 - 7 เท่ากับเท่าไร",
                CorrectAnswerId = 2,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "2" },
                    new AnswerOption { Id = 2, Text = "3" },
                    new AnswerOption { Id = 3, Text = "4" },
                    new AnswerOption { Id = 4, Text = "5" }
                }
            },
            new Question
            {
                Id = 7,
                Text = "3 x 3 เท่ากับเท่าไร",
                CorrectAnswerId = 1,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "9" },
                    new AnswerOption { Id = 2, Text = "6" },
                    new AnswerOption { Id = 3, Text = "12" },
                    new AnswerOption { Id = 4, Text = "8" }
                }
            },
            new Question
            {
                Id = 8,
                Text = "16 / 4 เท่ากับเท่าไร",
                CorrectAnswerId = 4,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "2" },
                    new AnswerOption { Id = 2, Text = "3" },
                    new AnswerOption { Id = 3, Text = "5" },
                    new AnswerOption { Id = 4, Text = "4" }
                }
            },
            new Question
            {
                Id = 9,
                Text = "8 + 1 เท่ากับเท่าไร",
                CorrectAnswerId = 2,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "8" },
                    new AnswerOption { Id = 2, Text = "9" },
                    new AnswerOption { Id = 3, Text = "10" },
                    new AnswerOption { Id = 4, Text = "11" }
                }
            },
            new Question
            {
                Id = 10,
                Text = "14 - 5 เท่ากับเท่าไร",
                CorrectAnswerId = 3,
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption { Id = 1, Text = "7" },
                    new AnswerOption { Id = 2, Text = "8" },
                    new AnswerOption { Id = 3, Text = "9" },
                    new AnswerOption { Id = 4, Text = "10" }
                }
            }
        };
    }
}
