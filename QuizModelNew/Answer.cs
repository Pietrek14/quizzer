using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Answer
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string content, bool isCorrect)
        {
            Content = content;
            IsCorrect = isCorrect;
        }
    }
}
