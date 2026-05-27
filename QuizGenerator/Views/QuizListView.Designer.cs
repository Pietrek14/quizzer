namespace QuizGenerator.Views
{
    partial class QuizListView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lbxQuizzes = new ListBox();
            btnAddQuiz = new Button();
            btnLoadQuiz = new Button();
            ofdLoadQuiz = new OpenFileDialog();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 27F);
            lblTitle.ForeColor = SystemColors.ControlLightLight;
            lblTitle.Location = new Point(12, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(140, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quizzer";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 16F);
            lblSubtitle.ForeColor = SystemColors.ControlLight;
            lblSubtitle.Location = new Point(17, 73);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(164, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Kreator Quizów";
            // 
            // lbxQuizzes
            // 
            lbxQuizzes.FormattingEnabled = true;
            lbxQuizzes.Location = new Point(32, 128);
            lbxQuizzes.Name = "lbxQuizzes";
            lbxQuizzes.Size = new Size(726, 289);
            lbxQuizzes.TabIndex = 2;
            lbxQuizzes.SelectedIndexChanged += quizSelectedForEdit;
            // 
            // btnAddQuiz
            // 
            btnAddQuiz.BackColor = Color.Transparent;
            btnAddQuiz.Cursor = Cursors.Hand;
            btnAddQuiz.FlatAppearance.BorderSize = 0;
            btnAddQuiz.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAddQuiz.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAddQuiz.FlatStyle = FlatStyle.Flat;
            btnAddQuiz.Font = new Font("Segoe UI", 21F);
            btnAddQuiz.ForeColor = SystemColors.ControlLightLight;
            btnAddQuiz.Location = new Point(729, 78);
            btnAddQuiz.Name = "btnAddQuiz";
            btnAddQuiz.Size = new Size(29, 44);
            btnAddQuiz.TabIndex = 3;
            btnAddQuiz.Text = "+";
            btnAddQuiz.UseVisualStyleBackColor = false;
            btnAddQuiz.Click += addQuizButtonClick;
            // 
            // btnLoadQuiz
            // 
            btnLoadQuiz.Location = new Point(628, 423);
            btnLoadQuiz.Name = "btnLoadQuiz";
            btnLoadQuiz.Size = new Size(130, 23);
            btnLoadQuiz.TabIndex = 4;
            btnLoadQuiz.Text = "Wczytaj Quiz z dysku";
            btnLoadQuiz.UseVisualStyleBackColor = true;
            btnLoadQuiz.Click += loadQuizButtonClick;
            // 
            // ofdLoadQuiz
            // 
            ofdLoadQuiz.FileName = "openFileDialog1";
            // 
            // QuizListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoadQuiz);
            Controls.Add(btnAddQuiz);
            Controls.Add(lbxQuizzes);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Name = "QuizListView";
            Text = "Quizzer -- Kreator Quizów";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private ListBox lbxQuizzes;
        private Button btnAddQuiz;
        private Button btnLoadQuiz;
        private OpenFileDialog ofdLoadQuiz;
    }
}
