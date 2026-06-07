using QuizModel;

namespace QuizSolver.View.Contracts
{
    public interface ISingleQuestionView
    {
        event Action<List<int>>? AnswerSubmitted;

        event Action? QuizFinished;
        void DisplayQuestion(string content, List<Answer> answers, int questionNumber, int totalQuestions);
        void ShowResult(int score, int maxScore);
        void CloseView();
    }
}