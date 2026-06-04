namespace QuizGenerator.Views
{
    partial class SingleQuizView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxQuizName = new TextBox();
            lbxQuestions = new ListBox();
            btnAddQuestion = new Button();
            btnAddQuiz = new Button();
            btnEditQuiz = new Button();
            btnDeleteQuiz = new Button();
            btnSaveQuiz = new Button();
            sfdSaveQuiz = new SaveFileDialog();
            SuspendLayout();
            // 
            // tbxQuizName
            // 
            tbxQuizName.Font = new Font("Segoe UI", 14F);
            tbxQuizName.Location = new Point(44, 39);
            tbxQuizName.Name = "tbxQuizName";
            tbxQuizName.PlaceholderText = "Nazwa Quizu";
            tbxQuizName.Size = new Size(242, 32);
            tbxQuizName.TabIndex = 0;
            tbxQuizName.TextChanged += quizNameChanged;
            // 
            // lbxQuestions
            // 
            lbxQuestions.FormattingEnabled = true;
            lbxQuestions.Location = new Point(44, 108);
            lbxQuestions.Name = "lbxQuestions";
            lbxQuestions.Size = new Size(704, 274);
            lbxQuestions.TabIndex = 1;
            lbxQuestions.SelectedIndexChanged += questionSelectedForEdit;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.BackColor = Color.Transparent;
            btnAddQuestion.FlatAppearance.BorderSize = 0;
            btnAddQuestion.FlatStyle = FlatStyle.Flat;
            btnAddQuestion.Font = new Font("Segoe UI", 21F);
            btnAddQuestion.ForeColor = SystemColors.ControlLightLight;
            btnAddQuestion.Location = new Point(712, 60);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(36, 42);
            btnAddQuestion.TabIndex = 2;
            btnAddQuestion.Text = "+";
            btnAddQuestion.UseVisualStyleBackColor = false;
            btnAddQuestion.Click += addQuestionButtonClick;
            // 
            // btnAddQuiz
            // 
            btnAddQuiz.Location = new Point(310, 388);
            btnAddQuiz.Name = "btnAddQuiz";
            btnAddQuiz.Size = new Size(167, 23);
            btnAddQuiz.TabIndex = 3;
            btnAddQuiz.Text = "Dodaj Quiz";
            btnAddQuiz.UseVisualStyleBackColor = true;
            btnAddQuiz.Click += addQuiz;
            // 
            // btnEditQuiz
            // 
            btnEditQuiz.Location = new Point(310, 388);
            btnEditQuiz.Name = "btnEditQuiz";
            btnEditQuiz.Size = new Size(167, 23);
            btnEditQuiz.TabIndex = 4;
            btnEditQuiz.Text = "Edytuj Quiz";
            btnEditQuiz.UseVisualStyleBackColor = true;
            btnEditQuiz.Click += editQuiz;
            // 
            // btnDeleteQuiz
            // 
            btnDeleteQuiz.Location = new Point(310, 415);
            btnDeleteQuiz.Name = "btnDeleteQuiz";
            btnDeleteQuiz.Size = new Size(167, 23);
            btnDeleteQuiz.TabIndex = 5;
            btnDeleteQuiz.Text = "Usuń Quiz";
            btnDeleteQuiz.UseVisualStyleBackColor = true;
            btnDeleteQuiz.Click += deleteQuiz;
            // 
            // btnSaveQuiz
            // 
            btnSaveQuiz.Location = new Point(662, 415);
            btnSaveQuiz.Name = "btnSaveQuiz";
            btnSaveQuiz.Size = new Size(86, 23);
            btnSaveQuiz.TabIndex = 6;
            btnSaveQuiz.Text = "Zapisz Quiz";
            btnSaveQuiz.UseVisualStyleBackColor = true;
            btnSaveQuiz.Click += saveQuizToFile;
            // 
            // SingleQuizView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveQuiz);
            Controls.Add(btnDeleteQuiz);
            Controls.Add(btnEditQuiz);
            Controls.Add(btnAddQuiz);
            Controls.Add(btnAddQuestion);
            Controls.Add(lbxQuestions);
            Controls.Add(tbxQuizName);
            Name = "SingleQuizView";
            Text = "Quizzer -- Quiz Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxQuizName;
        private ListBox lbxQuestions;
        private Button btnAddQuestion;
        private Button btnAddQuiz;
        private Button btnEditQuiz;
        private Button btnDeleteQuiz;
        private Button btnSaveQuiz;
        private SaveFileDialog sfdSaveQuiz;
    }
}