namespace QuizSolver.Views
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
            btnNext = new Button();
            lblProgress = new Label();
            lblQuestion = new Label();
            cbAnswer0 = new CheckBox();
            cbAnswer1 = new CheckBox();
            cbAnswer2 = new CheckBox();
            cbAnswer3 = new CheckBox();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F);
            btnNext.Location = new Point(613, 386);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(148, 43);
            btnNext.TabIndex = 5;
            btnNext.Text = "Następne pytanie";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 12F);
            lblProgress.Location = new Point(349, 414);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(95, 21);
            lblProgress.TabIndex = 6;
            lblProgress.Text = "Pytanie x z y";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 12F);
            lblQuestion.ImageAlign = ContentAlignment.MiddleLeft;
            lblQuestion.Location = new Point(34, 26);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(45, 21);
            lblQuestion.TabIndex = 7;
            lblQuestion.Text = "Treść";
            // 
            // cbAnswer0
            // 
            cbAnswer0.AutoSize = true;
            cbAnswer0.Location = new Point(34, 76);
            cbAnswer0.Name = "cbAnswer0";
            cbAnswer0.Size = new Size(33, 19);
            cbAnswer0.TabIndex = 12;
            cbAnswer0.Text = "X";
            cbAnswer0.UseVisualStyleBackColor = true;
            // 
            // cbAnswer1
            // 
            cbAnswer1.AutoSize = true;
            cbAnswer1.Location = new Point(34, 126);
            cbAnswer1.Name = "cbAnswer1";
            cbAnswer1.Size = new Size(33, 19);
            cbAnswer1.TabIndex = 13;
            cbAnswer1.Text = "Y";
            cbAnswer1.UseVisualStyleBackColor = true;
            // 
            // cbAnswer2
            // 
            cbAnswer2.AutoSize = true;
            cbAnswer2.Location = new Point(34, 176);
            cbAnswer2.Name = "cbAnswer2";
            cbAnswer2.Size = new Size(33, 19);
            cbAnswer2.TabIndex = 14;
            cbAnswer2.Text = "Z";
            cbAnswer2.UseVisualStyleBackColor = true;
            // 
            // cbAnswer3
            // 
            cbAnswer3.AutoSize = true;
            cbAnswer3.Location = new Point(34, 231);
            cbAnswer3.Name = "cbAnswer3";
            cbAnswer3.Size = new Size(33, 19);
            cbAnswer3.TabIndex = 15;
            cbAnswer3.Text = "V";
            cbAnswer3.UseVisualStyleBackColor = true;
            // 
            // SingleQuestionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbAnswer3);
            Controls.Add(cbAnswer2);
            Controls.Add(cbAnswer1);
            Controls.Add(cbAnswer0);
            Controls.Add(lblQuestion);
            Controls.Add(lblProgress);
            Controls.Add(btnNext);
            Name = "SingleQuestionView";
            Text = "SingleQuestionView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnNext;
        private Label lblProgress;
        private Label lblQuestion;
        private CheckBox cbAnswer0;
        private CheckBox cbAnswer1;
        private CheckBox cbAnswer2;
        private CheckBox cbAnswer3;
    }
}