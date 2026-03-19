using Backend.Repositories;
using Backend.Repositories.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<IQuizRepository, InMemoryQuizRepository>();
builder.Services.AddSingleton<IResultRepository, FileResultRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueDev", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
var backendVersion = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "unknown";

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowVueDev");
app.UseAuthorization();
app.MapGet("/", () => $"Backend API server for technical test v{backendVersion}");
app.MapControllers();

app.Run("http://localhost:5050");
