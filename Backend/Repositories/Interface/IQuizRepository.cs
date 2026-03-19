namespace Backend.Repositories.Interface;

using Backend.Models.Question;

public interface IQuizRepository
{
    Task<List<Question>> GetAllQuestionsAsync();
}
