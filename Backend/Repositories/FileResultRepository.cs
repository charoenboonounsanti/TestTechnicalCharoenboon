namespace Backend.Repositories;

using System.Text.Json;
using Backend.Models.Result;
using Backend.Repositories.Interface;
using Microsoft.Extensions.Hosting;

public class FileResultRepository : IResultRepository
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly string _historyFilePath;

    public FileResultRepository(IHostEnvironment environment)
    {
        var dataDirectory = Path.Combine(environment.ContentRootPath, "Data");
        Directory.CreateDirectory(dataDirectory);
        _historyFilePath = Path.Combine(dataDirectory, "score-history.jsonl");
    }

    public async Task SaveResultAsync(QuizResult result)
    {
        await _lock.WaitAsync();

        try
        {
            var line = JsonSerializer.Serialize(result);
            await File.AppendAllTextAsync(_historyFilePath, line + Environment.NewLine);
        }
        finally
        {
            _lock.Release();
        }
    }
}
