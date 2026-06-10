using System.Windows.Forms;
using Font = System.Drawing.Font;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace QuizSolver_M.Views
{
    partial class SolverView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnStart = new Button();
            btnEnd = new Button();
            lblTimer = new Label();
            lblQuizTitle = new Label();
            lblQuestion = new Label();
            chk1 = new CheckBox();
            chk2 = new CheckBox();
            chk3 = new CheckBox();
            chk4 = new CheckBox();
            btnPrev = new Button();
            btnNext = new Button();
            lblScore = new Label();
            lblQuestionCounter = new Label();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.White;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(12, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 35);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "📂 Wczytaj Quiz";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.White;
            btnStart.Enabled = false;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Location = new Point(140, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(120, 35);
            btnStart.TabIndex = 1;
            btnStart.Text = "▶ Rozpocznij";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnEnd
            // 
            btnEnd.BackColor = Color.White;
            btnEnd.Enabled = false;
            btnEnd.FlatAppearance.BorderSize = 0;
            btnEnd.FlatStyle = FlatStyle.Flat;
            btnEnd.Location = new Point(268, 12);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(120, 35);
            btnEnd.TabIndex = 2;
            btnEnd.Text = "⏹ Zakończ";
            btnEnd.UseVisualStyleBackColor = false;
            btnEnd.Click += btnEnd_Click;
            // 
            // lblTimer
            // 
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTimer.ForeColor = Color.White;
            lblTimer.Location = new Point(500, 12);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(100, 35);
            lblTimer.TabIndex = 3;
            lblTimer.Text = "00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblQuizTitle
            // 
            lblQuizTitle.BackColor = Color.Transparent;
            lblQuizTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblQuizTitle.ForeColor = Color.White;
            lblQuizTitle.Location = new Point(12, 60);
            lblQuizTitle.Name = "lblQuizTitle";
            lblQuizTitle.Size = new Size(590, 30);
            lblQuizTitle.TabIndex = 4;
            lblQuizTitle.Text = "Brak wczytanego quizu";
            // 
            // lblQuestion
            // 
            lblQuestion.BackColor = Color.Transparent;
            lblQuestion.Font = new Font("Segoe UI", 11F);
            lblQuestion.ForeColor = Color.Black;
            lblQuestion.Location = new Point(12, 125);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(590, 60);
            lblQuestion.TabIndex = 6;
            // 
            // chk1
            // 
            chk1.BackColor = Color.FromArgb(224, 224, 224);
            chk1.Font = new Font("Segoe UI", 10F);
            chk1.ForeColor = Color.Black;
            chk1.Location = new Point(20, 200);
            chk1.Name = "chk1";
            chk1.Size = new Size(570, 30);
            chk1.TabIndex = 7;
            chk1.UseVisualStyleBackColor = false;
            chk1.CheckedChanged += chk_CheckedChanged;
            // 
            // chk2
            // 
            chk2.BackColor = Color.FromArgb(224, 224, 224);
            chk2.Font = new Font("Segoe UI", 10F);
            chk2.ForeColor = Color.Black;
            chk2.Location = new Point(20, 238);
            chk2.Name = "chk2";
            chk2.Size = new Size(570, 30);
            chk2.TabIndex = 8;
            chk2.UseVisualStyleBackColor = false;
            chk2.CheckedChanged += chk_CheckedChanged;
            // 
            // chk3
            // 
            chk3.BackColor = Color.FromArgb(224, 224, 224);
            chk3.Font = new Font("Segoe UI", 10F);
            chk3.ForeColor = Color.Black;
            chk3.Location = new Point(20, 276);
            chk3.Name = "chk3";
            chk3.Size = new Size(570, 30);
            chk3.TabIndex = 9;
            chk3.UseVisualStyleBackColor = false;
            chk3.CheckedChanged += chk_CheckedChanged;
            // 
            // chk4
            // 
            chk4.BackColor = Color.FromArgb(224, 224, 224);
            chk4.Font = new Font("Segoe UI", 10F);
            chk4.ForeColor = Color.Black;
            chk4.Location = new Point(20, 314);
            chk4.Name = "chk4";
            chk4.Size = new Size(570, 30);
            chk4.TabIndex = 10;
            chk4.UseVisualStyleBackColor = false;
            chk4.CheckedChanged += chk_CheckedChanged;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.White;
            btnPrev.Enabled = false;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Location = new Point(12, 365);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(120, 35);
            btnPrev.TabIndex = 11;
            btnPrev.Text = "◀ Poprzednie";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.Enabled = false;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(140, 365);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 35);
            btnNext.TabIndex = 12;
            btnNext.Text = "Następne ▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblScore
            // 
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblScore.ForeColor = Color.LightGreen;
            lblScore.Location = new Point(12, 415);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(590, 40);
            lblScore.TabIndex = 13;
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestionCounter
            // 
            lblQuestionCounter.BackColor = Color.Transparent;
            lblQuestionCounter.Font = new Font("Segoe UI", 9F);
            lblQuestionCounter.ForeColor = Color.WhiteSmoke;
            lblQuestionCounter.Location = new Point(12, 95);
            lblQuestionCounter.Name = "lblQuestionCounter";
            lblQuestionCounter.Size = new Size(590, 22);
            lblQuestionCounter.TabIndex = 5;
            // 
            // SolverView
            // 
            BackColor = Color.Silver;
            ClientSize = new Size(620, 470);
            Controls.Add(btnLoad);
            Controls.Add(btnStart);
            Controls.Add(btnEnd);
            Controls.Add(lblTimer);
            Controls.Add(lblQuizTitle);
            Controls.Add(lblQuestionCounter);
            Controls.Add(lblQuestion);
            Controls.Add(chk1);
            Controls.Add(chk2);
            Controls.Add(chk3);
            Controls.Add(chk4);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(lblScore);
            Name = "SolverView";
            Text = "Rozwiązywator Quizu";
            ResumeLayout(false);
        }

        private Button btnLoad, btnStart, btnEnd, btnPrev, btnNext;
        private Label lblTimer, lblQuizTitle, lblQuestion, lblScore, lblQuestionCounter;
        private CheckBox chk1, chk2, chk3, chk4;
    }
}