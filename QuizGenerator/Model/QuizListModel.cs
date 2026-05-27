using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Model
{
    public class QuizListModel
    {
        public event Action<Quiz>? QuizAdded;
        public event Action<Quiz>? QuizRemoved;

        public List<Quiz> Quizzes { get; } = new List<Quiz>();

        public void AddQuiz(Quiz quiz)
        {
            Quizzes.Add(quiz);
            QuizAdded?.Invoke(quiz);
        }

        public void RemoveQuiz(Quiz quiz)
        {
            Quizzes.Remove(quiz);
            QuizRemoved?.Invoke(quiz);
        }
    }
}
