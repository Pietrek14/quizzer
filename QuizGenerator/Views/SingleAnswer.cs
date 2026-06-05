using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizGenerator.Views
{
    [DefaultEvent(nameof(TextChanged))]
    public partial class SingleAnswer : UserControl
    {
        [Browsable(true)]
        public new event EventHandler? TextChanged
        {
            add => tbxAnswer.TextChanged += value;
            remove => tbxAnswer.TextChanged -= value;
        }

        [Browsable(true)]
        public event EventHandler? IsCorrectChanged
        {
            add => cbxIsCorrect.CheckedChanged += value;
            remove => cbxIsCorrect.CheckedChanged -= value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public String AnswerContent
        {
            get => tbxAnswer.Text;
            set => tbxAnswer.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCorrect
        {
            get => cbxIsCorrect.Checked;
            set => cbxIsCorrect.Checked = value;
        }

        public SingleAnswer()
        {
            InitializeComponent();
        }
    }
}
