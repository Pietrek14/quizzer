using QuizSolver_M.Contracts;
using QuizSolver_M.Presenters;
namespace QuizSolver_M.Views
{
    public partial class SolverView : Form, ISolverView
    {
        public event Action? LoadQuiz;
        public event Action? StartQuiz;
        public event Action? EndQuiz;
        public event Action? NavigateNext;
        public event Action? NavigatePrev;
        public event Action<List<bool>>? SaveAnswer;

        private bool _quizEnded = false;

        public SolverView()
        {
            InitializeComponent();
            var presenter = new SolverPresenter(this);
        }
        

        
        private void OnAnswerChanged()
        {
            if (!_quizEnded)
                SaveAnswer?.Invoke(GetCurrentSelections());
        }

        public List<bool> GetCurrentSelections() =>
            new() { chk1.Checked, chk2.Checked, chk3.Checked, chk4.Checked };

        public void SetQuizTitle(string title, int questionCount)
        {
            lblQuizTitle.Text = title;
            lblQuestionCounter.Text = $"Liczba pytań: {questionCount}";
        }

        public void ShowQuestion(int index, int total, string content, List<string> answers)
        {
            lblQuestionCounter.Text = $"Pytanie {index + 1} / {total}";
            lblQuestion.Text = content;

            // Reset kolorów
            chk1.ForeColor = chk2.ForeColor = chk3.ForeColor = chk4.ForeColor = Color.Black;

            var checkboxes = new[] { chk1, chk2, chk3, chk4 };
            for (int i = 0; i < checkboxes.Length; i++)
                checkboxes[i].Text = i < answers.Count ? answers[i] : "";
        }

        public void SetAnswerSelections(List<bool> selections)
        {
            var checkboxes = new[] { chk1, chk2, chk3, chk4 };
            for (int i = 0; i < checkboxes.Length; i++)
                checkboxes[i].Checked = i < selections.Count && selections[i];
        }

        public void HighlightAnswers(List<bool> correct, List<bool> userAnswers)
        {
            _quizEnded = true;
            var checkboxes = new[] { chk1, chk2, chk3, chk4 };
            for (int i = 0; i < checkboxes.Length; i++)
            {
                if (correct[i] && userAnswers[i])
                    checkboxes[i].ForeColor = Color.Green;       
                else if (correct[i] && !userAnswers[i])
                    checkboxes[i].ForeColor = Color.Orange;      
                else if (!correct[i] && userAnswers[i])
                    checkboxes[i].ForeColor = Color.Red;         
            }
        }

        public void UpdateTimer(string time) => lblTimer.Text = time;

        public void EnableStart(bool enable) => btnStart.Enabled = enable;
        public void EnableEnd(bool enable) => btnEnd.Enabled = enable;

        public void EnableNavigation(bool enable)
        {
            btnNext.Enabled = enable;
            btnPrev.Enabled = enable;
        }

        public void ShowResult(int score, int max, TimeSpan elapsed)
        {
            lblScore.Text = $"Wynik: {score} / {max} pkt";
            MessageBox.Show(
                $"Quiz zakończony!\n\nWynik: {score} / {max} pkt\nCzas: {elapsed:mm\\:ss}",
                "Wynik",
                MessageBoxButtons.OK);

        }
        public void SetAnswersEnabled(bool enable)
    {
    }

        public void DisplayError(string message) =>
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnLoad_Click(object sender, EventArgs e) => LoadQuiz?.Invoke();
        private void btnStart_Click(object sender, EventArgs e) => StartQuiz?.Invoke();
        private void btnEnd_Click(object sender, EventArgs e) => EndQuiz?.Invoke();
        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveAnswer?.Invoke(GetCurrentSelections());
            NavigatePrev?.Invoke();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveAnswer?.Invoke(GetCurrentSelections());
            NavigateNext?.Invoke();
        }
        
        private void chk_CheckedChanged(object sender, EventArgs e) => OnAnswerChanged();
    }
}