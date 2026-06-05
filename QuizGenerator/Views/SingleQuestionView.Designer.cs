namespace QuizGenerator.Views
{
    partial class SingleQuestionView
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
            tbxQuestion = new TextBox();
            ans1 = new SingleAnswer();
            ans2 = new SingleAnswer();
            ans3 = new SingleAnswer();
            ans4 = new SingleAnswer();
            btnDeleteQuestion = new Button();
            btnEditQuestion = new Button();
            btnAddQuestion = new Button();
            SuspendLayout();
            // 
            // tbxQuestion
            // 
            tbxQuestion.BorderStyle = BorderStyle.None;
            tbxQuestion.Font = new Font("Segoe UI", 16F);
            tbxQuestion.Location = new Point(48, 22);
            tbxQuestion.Name = "tbxQuestion";
            tbxQuestion.PlaceholderText = "Treść";
            tbxQuestion.Size = new Size(687, 29);
            tbxQuestion.TabIndex = 0;
            tbxQuestion.TextChanged += questionContentChanged;
            // 
            // ans1
            // 
            ans1.AnswerContent = "";
            ans1.IsCorrect = false;
            ans1.Location = new Point(68, 67);
            ans1.Name = "ans1";
            ans1.Size = new Size(304, 30);
            ans1.TabIndex = 1;
            // 
            // ans2
            // 
            ans2.AnswerContent = "";
            ans2.IsCorrect = false;
            ans2.Location = new Point(68, 103);
            ans2.Name = "ans2";
            ans2.Size = new Size(304, 30);
            ans2.TabIndex = 2;
            // 
            // ans3
            // 
            ans3.AnswerContent = "";
            ans3.IsCorrect = false;
            ans3.Location = new Point(68, 139);
            ans3.Name = "ans3";
            ans3.Size = new Size(304, 30);
            ans3.TabIndex = 3;
            // 
            // ans4
            // 
            ans4.AnswerContent = "";
            ans4.IsCorrect = false;
            ans4.Location = new Point(68, 175);
            ans4.Name = "ans4";
            ans4.Size = new Size(304, 30);
            ans4.TabIndex = 4;
            // 
            // btnDeleteQuestion
            // 
            btnDeleteQuestion.Location = new Point(330, 400);
            btnDeleteQuestion.Name = "btnDeleteQuestion";
            btnDeleteQuestion.Size = new Size(167, 23);
            btnDeleteQuestion.TabIndex = 8;
            btnDeleteQuestion.Text = "Usuń Pytanie";
            btnDeleteQuestion.UseVisualStyleBackColor = true;
            btnDeleteQuestion.Click += deleteQuestion;
            // 
            // btnEditQuestion
            // 
            btnEditQuestion.Location = new Point(330, 371);
            btnEditQuestion.Name = "btnEditQuestion";
            btnEditQuestion.Size = new Size(167, 23);
            btnEditQuestion.TabIndex = 7;
            btnEditQuestion.Text = "Edytuj Pytanie";
            btnEditQuestion.UseVisualStyleBackColor = true;
            btnEditQuestion.Click += editQuestion;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Location = new Point(330, 373);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(167, 23);
            btnAddQuestion.TabIndex = 6;
            btnAddQuestion.Text = "Dodaj Pytanie";
            btnAddQuestion.UseVisualStyleBackColor = true;
            btnAddQuestion.Click += addQuestion;
            // 
            // SingleQuestionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteQuestion);
            Controls.Add(btnEditQuestion);
            Controls.Add(btnAddQuestion);
            Controls.Add(ans4);
            Controls.Add(ans3);
            Controls.Add(ans2);
            Controls.Add(ans1);
            Controls.Add(tbxQuestion);
            Name = "SingleQuestionView";
            Text = "Quizzer -- Question Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxQuestion;
        private SingleAnswer ans1;
        private SingleAnswer ans2;
        private SingleAnswer ans3;
        private SingleAnswer ans4;
        private Button btnDeleteQuestion;
        private Button btnEditQuestion;
        private Button btnAddQuestion;
    }
}