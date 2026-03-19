# TestTechnicalCharoenboon

Simple quiz application with:

- ASP.NET Core backend serving quiz questions and scoring submissions
- Vue 3 frontend for taking the quiz and showing the result
- Local JSON persistence for submitted results

## Project Structure

- `Backend/` ASP.NET Core Web API on `http://localhost:5050`
- `Frontend/` Vite + Vue app on `http://localhost:5173`

## Run Locally

Backend:

```bash
cd Backend
dotnet restore
dotnet run
```

Frontend:

```bash
cd Frontend
npm install
npm run dev
```

Open `http://localhost:5173`.

## User Flow

1. Enter a candidate name.
2. Answer all questions.
3. Submit the quiz.
4. Review score, percentage, and submitted time.
5. Retake if needed.

## Available API

- `GET /api/quiz/questions`
- `POST /api/quiz/submit`

Example submit payload:

```json
{
  "candidateName": "Jane",
  "answers": {
    "66142ce2-dc8e-4122-b95f-d4a5cfa18144": "3daf599e-a859-44f5-86bc-dccf366dbb72",
    "327c94f1-3a9c-42b7-a6f6-d0862b228d71": "cc7cb837-59f6-42bc-b50f-0f7b89fe0e92"
  }
}
```

## Quick Verification

Check the questions endpoint:

```bash
curl http://localhost:5050/api/quiz/questions
```

Expected result: a JSON array of 10 questions.

Check the submit endpoint:

```bash
curl -X POST http://localhost:5050/api/quiz/submit \
  -H "Content-Type: application/json" \
  -d '{"candidateName":"Jane","answers":{"66142ce2-dc8e-4122-b95f-d4a5cfa18144":"3daf599e-a859-44f5-86bc-dccf366dbb72","327c94f1-3a9c-42b7-a6f6-d0862b228d71":"cc7cb837-59f6-42bc-b50f-0f7b89fe0e92","c2f39cf6-85dd-4602-baeb-8530c6c17d1f":"318363bc-06be-4b1c-a9c4-87b93a7ddfab","b21db0aa-bfe9-4b3d-bf34-545ab428cc91":"bd4c2dfb-b536-47ba-84f0-2516fa53a7a6","f2563794-ce34-4f6b-ba1f-42c7db9383c2":"0e437ce3-95df-4fdd-ac32-0f4ca8e80e92","8e3d744d-4551-4426-9266-337d25b4300e":"47f179eb-c3a0-47fc-be11-e1531faba1be","ec5006fc-5d42-4bcb-ad38-0dc1af652fdb":"d85cf376-79cc-4831-aa29-1ec43f6ef686","e904dbda-0f03-4627-a724-6e3bc8d31337":"b9c420c0-3b9b-4bf8-a100-d7fa52e66640","2807860d-bb3a-460f-b7f3-83f40d62463a":"8d2d6985-c989-49ec-a28f-dd6ed032afcd","fb2af1d9-2a44-4e9a-ae96-cf327d9d3e4b":"f8867c6e-c3d9-4d93-8935-a9f987bc00e8"}}'
```

Expected result: score summary JSON with candidate name, score, total questions, and submitted time.

Questions and answer options include both:
- `index` for display order
- `id` as UUID for API submission

## Key Files

- `Backend/Program.cs` application startup and CORS policy
- `Backend/Controllers/QuizController.cs` quiz API endpoints
- `Backend/Repositories/InMemoryQuizRepository.cs` question set
- `Backend/Repositories/FileResultRepository.cs` JSONL result persistence
- `Frontend/src/components/QuizPage.vue` quiz UI
- `Frontend/src/api/quizApi.js` frontend API client

## Configuration

- Backend port: `Backend/Program.cs`
- Frontend dev server and proxy: `Frontend/vite.config.js`
- Optional frontend API base URL override: `VITE_API_BASE_URL`
