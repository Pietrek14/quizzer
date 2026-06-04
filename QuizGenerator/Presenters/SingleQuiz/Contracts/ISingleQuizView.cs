using QuizGenerator.Presenters.SingleQuestion.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuiz.Contracts
{
    public interface ISingleQuizView
    {
        public event Action<String> SetQuizTitle;
        public event Action AddQuestion;
        public event Action<QuestionDto> EditQuestion;
        public event Action AddQuiz;
        public event Action UpdateQuiz;
        public event Action DeleteQuiz;
        public event Action<string> SaveQuizToFile;

        void UpdateQuizTitle(string title);
        void UpdateQuestionList(IEnumerable<QuestionDto> questions);
        void EnableEdition(bool enabled);
        ISingleQuestionView GetSingleQuestionView();
        void DisplayError(string message);
        void Close();
    }
}
