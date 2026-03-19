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
2. Answer all 10 questions.
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
    "1": 2,
    "2": 3
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
  -d '{"candidateName":"Jane","answers":{"1":2,"2":3,"3":4,"4":1,"5":3,"6":2,"7":1,"8":4,"9":2,"10":3}}'
```

Expected result: score summary JSON with candidate name, score, total questions, and submitted time.

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

## Notes

- Quiz questions come from `Backend/Repositories/InMemoryQuizRepository.cs`.
- Submitted attempts are appended to `Backend/Data/score-history.jsonl`.
- The frontend proxies `/api` requests to the backend during local development.
- Backend CORS is currently open to all origins, methods, and headers.

## Troubleshooting

- Port `5050` already in use: stop the existing process or change `app.Run(...)` in `Backend/Program.cs`.
- Port `5173` already in use: change `server.port` in `Frontend/vite.config.js`.
- Frontend cannot load questions: confirm the backend is running on `http://localhost:5050`.
- Submission history file missing: it is created automatically under `Backend/Data/score-history.jsonl` after the first submit.

See `Backend/README.md` and `Frontend/README.md` for component-specific setup details.
