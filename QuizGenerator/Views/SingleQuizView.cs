using QuizGenerator.Presenters.Common.Contracts;
using QuizGenerator.Presenters.SingleQuestion.Contracts;
using QuizGenerator.Presenters.SingleQuiz.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizGenerator.Views
{
    public partial class SingleQuizView : Form, ISingleQuizView
    {
        public event Action<String>? SetQuizTitle;
        public event Action? AddQuestion;
        public event Action<QuestionDto>? EditQuestion;

        public event Action? AddQuiz;
        public event Action? UpdateQuiz;
        public event Action? DeleteQuiz;
        public event Action<string, EncryptionStrategyDto>? SaveQuizToFile;

        public SingleQuizView()
        {
            InitializeComponent();
        }

        public void UpdateQuizTitle(string title)
        {
            tbxQuizName.Text = title;
        }

        public void UpdateQuestionList(IEnumerable<QuestionDto> questions)
        {
            lbxQuestions.Items.Clear();
            foreach (var question in questions)
            {
                lbxQuestions.Items.Add(question);
            }
        }

        public void EnableEdition(bool enabled)
        {
            btnAddQuiz.Enabled = !enabled;
            btnEditQuiz.Enabled = enabled;
            btnDeleteQuiz.Enabled = enabled;
            btnAddQuiz.Visible = !enabled;
            btnEditQuiz.Visible = enabled;
            btnDeleteQuiz.Visible = enabled;
        }

        public ISingleQuestionView GetSingleQuestionView()
        {
            var singleQuestionView = new SingleQuestionView();
            singleQuestionView.Show();
            return singleQuestionView;
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addQuestionButtonClick(object sender, EventArgs e)
        {
            AddQuestion?.Invoke();
        }

        private void questionSelectedForEdit(object sender, EventArgs e)
        {
            if (lbxQuestions.SelectedItem is QuestionDto selectedQuestion)
            {
                EditQuestion?.Invoke(selectedQuestion);
            }
        }

        private void quizNameChanged(object sender, EventArgs e)
        {
            SetQuizTitle?.Invoke(tbxQuizName.Text);
        }

        private void editQuiz(object sender, EventArgs e)
        {
            this.UpdateQuiz?.Invoke();
        }

        private void deleteQuiz(object sender, EventArgs e)
        {
            this.DeleteQuiz?.Invoke();
        }

        private void addQuiz(object sender, EventArgs e)
        {
            this.AddQuiz?.Invoke();
        }

        private void saveQuizToFile(object sender, EventArgs e)
        {
            if (sfdSaveQuiz.ShowDialog() == DialogResult.OK)
            {
                String quizFilePath = sfdSaveQuiz.FileName;
                EncryptionStrategyDto encryptionStrategy = cmbEncryptionStrategy.SelectedItem switch {
                    "Plaintext" => EncryptionStrategyDto.Plaintext,
                    "AES" => EncryptionStrategyDto.Aes,
                    "3DES" => EncryptionStrategyDto.TripleDes,
                    _ => EncryptionStrategyDto.Plaintext
                };
                this.SaveQuizToFile?.Invoke(quizFilePath, encryptionStrategy);
            }
        }
    }
}
