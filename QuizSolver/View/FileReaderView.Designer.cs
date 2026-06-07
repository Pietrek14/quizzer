namespace QuizSolver.Views
{
    partial class FileReaderView
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
            label1 = new Label();
            label2 = new Label();
            btnLoad = new Button();
            label3 = new Label();
            cmbStrategy = new ComboBox();
            label4 = new Label();
            cmbScoringStrategy = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(333, 72);
            label1.Name = "label1";
            label1.Size = new Size(126, 45);
            label1.TabIndex = 0;
            label1.Text = "Quizzer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(276, 145);
            label2.Name = "label2";
            label2.Size = new Size(248, 32);
            label2.TabIndex = 1;
            label2.Text = "Rozwiązywacz Quizów";
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI", 12F);
            btnLoad.Location = new Point(308, 284);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(181, 81);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Wczytaj quiz";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(232, 206);
            label3.Name = "label3";
            label3.Size = new Size(196, 15);
            label3.TabIndex = 3;
            label3.Text = "Wybierz algorytm do odszyfrowania";
            // 
            // cmbStrategy
            // 
            cmbStrategy.FormattingEnabled = true;
            cmbStrategy.Location = new Point(449, 203);
            cmbStrategy.Name = "cmbStrategy";
            cmbStrategy.Size = new Size(121, 23);
            cmbStrategy.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(232, 248);
            label4.Name = "label4";
            label4.Size = new Size(144, 15);
            label4.TabIndex = 5;
            label4.Text = "Wybierz sposób oceniania";
            // 
            // cmbScoringStrategy
            // 
            cmbScoringStrategy.FormattingEnabled = true;
            cmbScoringStrategy.Location = new Point(449, 245);
            cmbScoringStrategy.Name = "cmbScoringStrategy";
            cmbScoringStrategy.Size = new Size(121, 23);
            cmbScoringStrategy.TabIndex = 6;
            // 
            // FileReaderView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbScoringStrategy);
            Controls.Add(label4);
            Controls.Add(cmbStrategy);
            Controls.Add(label3);
            Controls.Add(btnLoad);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FileReaderView";
            Text = "Rozwiązywacz Quizów";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnLoad;
        private Label label3;
        private ComboBox cmbStrategy;
        private Label label4;
        private ComboBox cmbScoringStrategy;
    }
}
