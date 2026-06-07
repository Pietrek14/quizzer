using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuizModel;
using QuizSolver.View.Contracts;

namespace QuizSolver.Views
{
    public partial class SingleQuestionView : Form, ISingleQuestionView
    {
        public event Action<List<int>>? AnswerSubmitted;
        public event Action? QuizFinished;

        public SingleQuestionView()
        {
            InitializeComponent();
        }

        public void DisplayQuestion(string content, List<Answer> answers, int questionNumber, int totalQuestions)
        {
            lblQuestion.Text = content;
            lblProgress.Text = $"Pytanie {questionNumber} z {totalQuestions}";

            cbAnswer0.Text = answers[0].Content;
            cbAnswer1.Text = answers[1].Content;
            cbAnswer2.Text = answers[2].Content;
            cbAnswer3.Text = answers[3].Content;

            cbAnswer0.Checked = false;
            cbAnswer1.Checked = false;
            cbAnswer2.Checked = false;
            cbAnswer3.Checked = false;
        }

        public void ShowResult(int score, int maxScore)
        {
            MessageBox.Show($"Twój wynik to: {score} na {maxScore} możliwych punktów!", "Koniec Quizu");
            QuizFinished?.Invoke();
        }

        public void CloseView()
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            List<int> selectedIndices = new List<int>();

            if (cbAnswer0.Checked) selectedIndices.Add(0);
            if (cbAnswer1.Checked) selectedIndices.Add(1);
            if (cbAnswer2.Checked) selectedIndices.Add(2);
            if (cbAnswer3.Checked) selectedIndices.Add(3);

            AnswerSubmitted?.Invoke(selectedIndices);
        }
    }
}