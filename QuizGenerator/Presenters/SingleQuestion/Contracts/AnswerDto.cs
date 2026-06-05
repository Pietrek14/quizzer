using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuestion.Contracts
{
    public class AnswerDto
    {
        public String Content { get; set; } = "";
        public bool IsCorrect { get; set; } = false;

        public AnswerDto(string content, bool isCorrect)
        {
            Content = content;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
