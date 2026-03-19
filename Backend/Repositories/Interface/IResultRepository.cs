namespace Backend.Repositories.Interface;

using Backend.Models.Result;

public interface IResultRepository
{
    Task SaveResultAsync(QuizResult result);
}
