# Quiz Frontend

Vue 3 + Vite frontend for the quiz application.

## Setup

```bash
cd Frontend
npm install
npm run dev
```

The app runs on `http://localhost:5173`.

## Build

```bash
npm run build
```

## Behavior

- Loads quiz questions from `/api/quiz/questions`
- Submits answers to `/api/quiz/submit`
- Shows candidate name, score, percentage, and submitted time
- Allows quiz reset and retake

## Configuration

- Dev server port and API proxy are in `vite.config.js`
- `VITE_API_BASE_URL` can override the default `/api` base URL
