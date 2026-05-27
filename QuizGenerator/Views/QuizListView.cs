using QuizGenerator.Presenters.QuizList.Contracts;
using QuizGenerator.Presenters.SingleQuiz.Contracts;

namespace QuizGenerator.Views
{
    public partial class QuizListView : Form, IQuizListView
    {
        public event Action? AddQuiz;
        public event Action<string>? LoadQuiz;
        public event Action<QuizDto>? OpenQuiz;

        public QuizListView()
        {
            InitializeComponent();
        }

        public void UpdateQuizList(IEnumerable<QuizDto> quizzes)
        {
            lbxQuizzes.Items.Clear();
            foreach (var quiz in quizzes)
            {
                lbxQuizzes.Items.Add(quiz);
            }
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public ISingleQuizView GetSingleQuizView()
        {
            var singleQuizView = new SingleQuizView();
            singleQuizView.Show();
            return singleQuizView;
        }

        private void addQuizButtonClick(object sender, EventArgs e)
        {
            AddQuiz?.Invoke();
        }

        private void loadQuizButtonClick(object sender, EventArgs e)
        {
            if(ofdLoadQuiz.ShowDialog() == DialogResult.OK)
            {
                String quizFilePath = ofdLoadQuiz.FileName;
                LoadQuiz?.Invoke(quizFilePath);
            }
        }

        private void quizSelectedForEdit(object sender, EventArgs e)
        {
            if (lbxQuizzes.SelectedItem is QuizDto selectedQuiz)
            {
                OpenQuiz?.Invoke(selectedQuiz);
            }
        }
    }
}
