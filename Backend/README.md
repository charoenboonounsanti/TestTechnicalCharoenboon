# Backend Quiz API

ASP.NET Core Web API for serving quiz questions and scoring submissions.

## Setup

```bash
cd Backend
dotnet restore
dotnet run
```

The API starts on `http://localhost:5050`.

## Endpoints

- `GET /api/quiz/questions`
Returns the quiz questions and answer options.

- `POST /api/quiz/submit`
Scores a submission and returns:

```json
{
  "candidateName": "Jane",
  "score": 10,
  "totalQuestions": 10,
  "submittedTime": "2026-03-19T12:00:00Z"
}
```

Request body:

```json
{
  "candidateName": "Jane",
  "answers": {
    "1": 2,
    "2": 3
  }
}
```

## CORS

The API currently allows all origins, methods, and headers.

## Stack

- .NET 10
- ASP.NET Core
- C#
- JSON file persistence
