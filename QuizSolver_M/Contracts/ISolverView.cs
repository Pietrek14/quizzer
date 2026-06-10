namespace QuizSolver_M.Contracts
{
    public interface ISolverView
    {
        event Action LoadQuiz;
        event Action StartQuiz;
        event Action EndQuiz;
        event Action NavigateNext;
        event Action NavigatePrev;
        event Action<List<bool>> SaveAnswer;

        void SetQuizTitle(string title, int questionCount);
        void ShowQuestion(int index, int total, string content, List<string> answers);
        void SetAnswerSelections(List<bool> selections);
        void HighlightAnswers(List<bool> correct, List<bool> userAnswers);
        void UpdateTimer(string time);
        void EnableStart(bool enable);
        void EnableEnd(bool enable);
        void EnableNavigation(bool enable);
        void DisplayError(string message);
        void ShowResult(int score, int max, TimeSpan elapsed);
        void SetAnswersEnabled(bool enable);
    }
}