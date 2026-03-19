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
Returns quiz questions and answer options with:

- `index` for display order
- `id` as UUID

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
    "66142ce2-dc8e-4122-b95f-d4a5cfa18144": "3daf599e-a859-44f5-86bc-dccf366dbb72",
    "327c94f1-3a9c-42b7-a6f6-d0862b228d71": "cc7cb837-59f6-42bc-b50f-0f7b89fe0e92"
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
