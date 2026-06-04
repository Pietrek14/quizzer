using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuestion.Contracts
{
    public interface ISingleQuestionView
    {
        event Action AddQuestion;
        event Action UpdateQuestion;
        event Action DeleteQuestion;

        event Action<string> QuestionContentUpdated;
        event Action<int, AnswerDto> AnswerUpdated;

        void SetQuestionContent(String questionContent);
        void SetAnswer(int index, AnswerDto answer);
        void EnableEdition(bool enabled);
        void DisplayError(string message);
        void Close();
    }
}
