using QuizGenerator.Presenters.Common.Contracts;
using QuizGenerator.Presenters.SingleQuiz.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.QuizList.Contracts
{
    public interface IQuizListView
    {
        public event Action AddQuiz;
        public event Action<string, EncryptionStrategyDto> LoadQuiz;
        public event Action<QuizDto> OpenQuiz;

        void UpdateQuizList(IEnumerable<QuizDto> quizzes);
        void DisplayError(string message);
        ISingleQuizView GetSingleQuizView();
    }
}
