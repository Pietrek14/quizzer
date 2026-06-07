using System;
using QuizServices.Serialization;

namespace QuizSolver.View.Contracts
{
    public interface IFileReaderView
    {
        event Action<string, EncryptionStrategyDto, string>? LoadQuizRequested;

        void DisplayError(string message);
        void HideView();

        ISingleQuestionView GetQuizSolverView();
    }
}