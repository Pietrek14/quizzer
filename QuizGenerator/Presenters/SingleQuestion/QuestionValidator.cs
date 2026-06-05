using QuizGenerator.Presenters.SingleQuestion.Contracts;
using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuestion
{
    internal class QuestionValidator
    {
        public string? ValidateQuestion(String content, AnswerDto[] answers)
        {
            if (content == null || content.Trim() == "")
            {
                return "Treść pytania nie może być pusta!";
            }

            if (answers == null || answers.Length != 4)
            {
                return "Pytanie musi zawierać dokładnie cztery odpowiedzi!";
            }

            foreach (AnswerDto answer in answers)
            {
                if (answer == null || answer.Content == null || answer.Content.Trim() == "")
                {
                    return "Wszystkie odpowiedzi muszą mieć treść!";
                }
            }

            return null;
        }
    }
}
