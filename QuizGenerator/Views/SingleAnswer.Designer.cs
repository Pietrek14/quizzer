namespace QuizGenerator.Views
{
    partial class SingleAnswer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbxIsCorrect = new CheckBox();
            tbxAnswer = new TextBox();
            SuspendLayout();
            // 
            // cbxIsCorrect
            // 
            cbxIsCorrect.AutoSize = true;
            cbxIsCorrect.Location = new Point(3, 8);
            cbxIsCorrect.Name = "cbxIsCorrect";
            cbxIsCorrect.Size = new Size(15, 14);
            cbxIsCorrect.TabIndex = 0;
            cbxIsCorrect.UseVisualStyleBackColor = true;
            // 
            // tbxAnswer
            // 
            tbxAnswer.Location = new Point(24, 4);
            tbxAnswer.Name = "tbxAnswer";
            tbxAnswer.Size = new Size(277, 23);
            tbxAnswer.TabIndex = 1;
            // 
            // SingleAnswer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbxAnswer);
            Controls.Add(cbxIsCorrect);
            Name = "SingleAnswer";
            Size = new Size(304, 30);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbxIsCorrect;
        private TextBox tbxAnswer;
    }
}
