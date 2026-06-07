using System;
using System.Windows.Forms;
using QuizServices.Serialization;
using QuizSolver.View.Contracts;

namespace QuizSolver.Views
{
    public partial class FileReaderView : Form, IFileReaderView
    {
        public event Action<string, EncryptionStrategyDto, string>? LoadQuizRequested;

        public FileReaderView()
        {
            InitializeComponent();

            cmbStrategy.DataSource = Enum.GetValues(typeof(EncryptionStrategyDto));

            cmbScoringStrategy.Items.Add("Rygorystyczne");
            cmbScoringStrategy.Items.Add("Częściowe");
            cmbScoringStrategy.SelectedIndex = 0;
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void HideView()
        {
            this.Hide();
        }

        public ISingleQuestionView GetQuizSolverView()
        {
            var view = new SingleQuestionView();
            view.FormClosed += (sender, args) => this.Close();
            view.Show();
            return view;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var encryptionStrategy = (EncryptionStrategyDto)cmbStrategy.SelectedItem;
                    var scoringStrategy = cmbScoringStrategy.SelectedItem.ToString();

                    if (scoringStrategy != null)
                    {
                        LoadQuizRequested?.Invoke(ofd.FileName, encryptionStrategy, scoringStrategy);
                    }
                }
            }
        }
    }
}