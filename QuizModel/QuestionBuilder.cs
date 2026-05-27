using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class QuestionBuilder
    {
        private String questionContent;
        private String correctAnswer;
        private List<String> incorrectAnswers = new List<String>();

        public QuestionBuilder WithQuestionContent(String questionContent)
        {
            this.questionContent = questionContent;
            return this;
        }

        public QuestionBuilder WithCorrectAnswer(String correctAnswer)
        {
            this.correctAnswer = correctAnswer;
            return this;
        }

        public QuestionBuilder WithIncorrectAnswer(String incorrectAnswer)
        {
            if (string.IsNullOrWhiteSpace(incorrectAnswer))
                throw new ArgumentException("Incorrect answer cannot be empty.", nameof(incorrectAnswer));

            if (incorrectAnswer == correctAnswer)
                throw new ArgumentException("Incorrect answer cannot be the same as the correct answer.");

            if (incorrectAnswers.Count >= 3)
                throw new InvalidOperationException("A question can have at most three incorrect answers.");

            this.incorrectAnswers.Add(incorrectAnswer);
            return this;
        }
        public QuestionBuilder WithIncorrectAnswers(IEnumerable<string> incorrectAnswers)
        {
            if (incorrectAnswers == null)
                throw new ArgumentNullException(nameof(incorrectAnswers));

            foreach (var answer in incorrectAnswers)
            {
                WithIncorrectAnswer(answer);
            }
            return this;
        }

        public Question Build()
        {
            if (string.IsNullOrWhiteSpace(questionContent))
                throw new InvalidOperationException("Cannot build question: Content is missing.");

            if (string.IsNullOrWhiteSpace(correctAnswer))
                throw new InvalidOperationException("Cannot build question: Correct answer is missing.");

            if (incorrectAnswers.Count == 0)
                throw new InvalidOperationException("Cannot build question: At least one incorrect answer is required.");

            return new Question(questionContent, correctAnswer, incorrectAnswers);
        }
    }
}
