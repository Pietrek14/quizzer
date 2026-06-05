using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuiz
{
    internal class QuizValidator
    {
        public string? ValidateQuiz(Quiz quiz)
        {
            if(quiz.Name == null || quiz.Name.Trim() == "")
            {
                return "Nazwa quizu nie może być pusta!";
            }

            if (quiz.Questions.Items.Count == 0)
            {
                return "Quiz musi zawierać co najmniej jedno pytanie!";
            }

            return null;
        }
    }
}
