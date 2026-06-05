using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Answer : IGuided
    {
        public Guid Id { get; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(Guid id, string text, bool isCorrect)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public Answer(string text, bool isCorrect)
            : this(Guid.NewGuid(), text, isCorrect) {}
    }
}
