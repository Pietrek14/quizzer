using QuizGenerator.Presenters.SingleQuestion.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizGenerator.Views
{
    public partial class SingleQuestionView : Form, ISingleQuestionView
    {
        public event Action? AddQuestion;
        public event Action? UpdateQuestion;
        public event Action? DeleteQuestion;

        public event Action<string>? QuestionContentUpdated;
        public event Action<int, AnswerDto>? AnswerUpdated;

        private SingleAnswer[] answerForms;

        public SingleQuestionView()
        {
            InitializeComponent();

            answerForms = new SingleAnswer[] { ans1, ans2, ans3, ans4 };

            for (int i = 0; i < answerForms.Length; i++)
            {
                var index = i;
                answerForms[index].TextChanged += (sender, e) =>
                {
                    AnswerUpdated?.Invoke(index, new AnswerDto(answerForms[index].AnswerContent, answerForms[index].IsCorrect));
                };
                answerForms[index].IsCorrectChanged += (sender, e) =>
                {
                    AnswerUpdated?.Invoke(index, new AnswerDto(answerForms[index].AnswerContent, answerForms[index].IsCorrect));
                };
            }
        }

        public void SetQuestionContent(string content)
        {
            this.tbxQuestion.Text = content;
        }

        public void SetAnswer(int index, AnswerDto answer)
        {
            answerForms[index].AnswerContent = answer.Content;
            answerForms[index].IsCorrect = answer.IsCorrect;
        }

        public void EnableEdition(bool edition)
        {
            btnAddQuestion.Enabled = !edition;
            btnEditQuestion.Enabled = edition;
            btnDeleteQuestion.Enabled = edition;
            btnAddQuestion.Visible = !edition;
            btnEditQuestion.Visible = edition;
            btnDeleteQuestion.Visible = edition;
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void questionContentChanged(object sender, EventArgs e)
        {
            QuestionContentUpdated?.Invoke(tbxQuestion.Text);
        }

        private void addQuestion(object sender, EventArgs e)
        {
            AddQuestion?.Invoke();
        }

        private void editQuestion(object sender, EventArgs e)
        {
            UpdateQuestion?.Invoke();
        }

        private void deleteQuestion(object sender, EventArgs e)
        {
            DeleteQuestion?.Invoke();
        }
    }
}
