<template>
  <div class="quiz-page">
    <div class="quiz-container">
      <h1>แบบทดสอบ</h1>
      
      <div class="form-group">
        <label for="candidateName">ชื่อผู้สอบ:</label>
        <input
          id="candidateName"
          v-model="candidateName"
          type="text"
          placeholder="กรุณากรอกชื่อของท่าน"
          class="form-input"
        />
      </div>

      <div class="questions-container">
        <div v-for="question in questions" :key="question.id" class="question-block">
          <h3>{{ question.index }}. {{ question.text }}</h3>
          <div class="options">
            <div v-for="option in question.answerOptions" :key="option.id" class="option">
              <input
                :id="`q${question.id}o${option.id}`"
                type="radio"
                :name="`question-${question.id}`"
                :value="option.id"
                v-model="answers[question.id]"
                class="radio-input"
              />
              <label :for="`q${question.id}o${option.id}`" class="option-label">
                {{ option.index }}. {{ option.text }}
              </label>
            </div>
          </div>
        </div>
      </div>

      <div class="button-group">
        <button
          v-if="!quizResult"
          @click="submitQuiz"
          class="btn btn-primary"
          :disabled="isLoading"
        >
          {{ isLoading ? 'กำลังส่งข้อสอบ...' : 'ส่งข้อสอบ' }}
        </button>
        <button
          v-if="quizResult"
          @click="handleRetakeQuiz"
          class="btn btn-secondary"
        >
          ทำแบบทดสอบใหม่
        </button>
      </div>

      <div v-if="errorMessage" class="error-message">
        {{ errorMessage }}
      </div>

      <section v-if="quizResult" class="result-section">
        <h2>ผลการทดสอบ</h2>

        <div class="result-card">
          <div class="result-item">
            <span class="label">ชื่อผู้สอบ:</span>
            <span class="value">{{ quizResult.candidateName }}</span>
          </div>

          <div class="result-item">
            <span class="label">คะแนน:</span>
            <span class="value score">{{ quizResult.score }}/{{ quizResult.totalQuestions }}</span>
          </div>

          <div class="result-item">
            <span class="label">เปอร์เซ็นต์:</span>
            <span class="value percentage">{{ Math.round((quizResult.score / quizResult.totalQuestions) * 100) }}%</span>
          </div>

          <div class="result-item">
            <span class="label">เวลาที่ส่ง:</span>
            <span class="value">{{ formatDateTime(quizResult.submittedTime) }}</span>
          </div>
        </div>

        <div class="progress-bar">
          <div class="progress-fill" :style="{ width: progressPercentage + '%' }"></div>
        </div>
      </section>

    </div>
  </div>
</template>

<script setup>
import { computed, ref, onMounted } from 'vue';
import { getQuestions, submitQuiz as submitQuizApi } from '../api/quizApi';

const questions = ref([]);
const candidateName = ref('');
const answers = ref({});
const errorMessage = ref('');
const isLoading = ref(false);
const quizResult = ref(null);

const initializeAnswers = () => {
  const nextAnswers = {};

  questions.value.forEach(question => {
    nextAnswers[question.id] = null;
  });

  answers.value = nextAnswers;
};

const progressPercentage = computed(() => {
  if (!quizResult.value) return 0;
  return (quizResult.value.score / quizResult.value.totalQuestions) * 100;
});

const formatDateTime = (dateString) => {
  const date = new Date(dateString);
  return date.toLocaleString('th-TH', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit',
    second: '2-digit'
  });
};

onMounted(async () => {
  try {
    questions.value = await getQuestions();
    initializeAnswers();
  } catch (error) {
    errorMessage.value = 'ไม่สามารถโหลดข้อสอบได้';
  }
});

const submitQuiz = async () => {
  errorMessage.value = '';

  if (!candidateName.value.trim()) {
    errorMessage.value = 'กรุณากรอกชื่อผู้สอบ';
    return;
  }

  const unansweredQuestions = questions.value.filter(q => answers.value[q.id] === null || answers.value[q.id] === undefined);
  if (unansweredQuestions.length > 0) {
    errorMessage.value = `กรุณาตอบข้อที่ ${unansweredQuestions[0].index} ให้ครบถ้วน`;
    return;
  }

  isLoading.value = true;
  try {
    const payload = {
      candidateName: candidateName.value,
      answers: answers.value
    };

    quizResult.value = await submitQuizApi(payload);
  } catch (error) {
    errorMessage.value = 'เกิดข้อผิดพลาดในการส่งข้อสอบ';
  } finally {
    isLoading.value = false;
  }
};

const handleRetakeQuiz = () => {
  errorMessage.value = '';
  candidateName.value = '';
  quizResult.value = null;
  initializeAnswers();
};
</script>

<style scoped>
.quiz-page {
  min-height: 100vh;
  padding: 20px;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.quiz-container {
  max-width: 800px;
  margin: 0 auto;
  background: white;
  border-radius: 12px;
  padding: 40px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
}

h1 {
  text-align: center;
  color: #333;
  margin-bottom: 30px;
  font-size: 2em;
}

.form-group {
  margin-bottom: 30px;
}

label {
  display: block;
  margin-bottom: 8px;
  font-weight: 600;
  color: #555;
}

.form-input {
  width: 100%;
  padding: 12px;
  border: 2px solid #ddd;
  border-radius: 6px;
  font-size: 1em;
  transition: border-color 0.3s;
}

.form-input:focus {
  outline: none;
  border-color: #667eea;
}

.questions-container {
  margin-bottom: 30px;
  max-height: 500px;
  overflow-y: auto;
}

.question-block {
  margin-bottom: 25px;
  padding: 20px;
  background: #f8f9fa;
  border-radius: 8px;
  border-left: 4px solid #667eea;
}

.question-block h3 {
  margin-bottom: 15px;
  color: #333;
  font-size: 1.1em;
}

.options {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.option {
  display: flex;
  align-items: center;
}

.radio-input {
  margin-right: 10px;
  cursor: pointer;
  width: 18px;
  height: 18px;
}

.option-label {
  display: inline;
  margin: 0;
  cursor: pointer;
  color: #555;
  font-weight: normal;
}

.button-group {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  justify-content: center;
}

.btn {
  padding: 12px 30px;
  font-size: 1em;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: all 0.3s;
  font-weight: 600;
}

.btn:disabled {
  cursor: not-allowed;
  opacity: 0.7;
  transform: none;
  box-shadow: none;
}

.btn-primary {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
}

.btn-primary:hover {
  transform: translateY(-2px);
  box-shadow: 0 5px 15px rgba(102, 126, 234, 0.4);
}

.btn-secondary {
  background: #eef2ff;
  color: #4c51bf;
}

.btn-secondary:hover:not(:disabled) {
  background: #dfe5ff;
}

.error-message {
  margin-top: 20px;
  padding: 12px;
  background: #fee;
  color: #c33;
  border-radius: 6px;
  text-align: center;
}

.result-section {
  margin-top: 36px;
  padding-top: 32px;
  border-top: 1px solid #e5e7eb;
}

.result-section h2 {
  margin-bottom: 20px;
  text-align: center;
  color: #333;
  font-size: 1.6em;
}

.result-card {
  background: #f8f9fa;
  border-radius: 12px;
  padding: 30px;
  margin-bottom: 20px;
  border-left: 5px solid #667eea;
}

.result-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 16px;
  padding: 15px 0;
  border-bottom: 1px solid #e0e0e0;
}

.result-item:last-child {
  border-bottom: none;
}

.label {
  font-weight: 600;
  color: #666;
}

.value {
  color: #333;
  font-size: 1.05em;
  text-align: right;
}

.value.score {
  color: #667eea;
  font-size: 1.5em;
  font-weight: 700;
}

.value.percentage {
  color: #764ba2;
  font-size: 1.5em;
  font-weight: 700;
}

.progress-bar {
  width: 100%;
  height: 30px;
  background: #e0e0e0;
  border-radius: 15px;
  overflow: hidden;
}

.progress-fill {
  height: 100%;
  background: linear-gradient(90deg, #667eea 0%, #764ba2 100%);
  transition: width 1s ease-out;
}

@media (max-width: 640px) {
  .quiz-container {
    padding: 24px;
  }

  .result-item {
    flex-direction: column;
    align-items: flex-start;
  }

  .value {
    text-align: left;
  }
}
</style>
