using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuiz.Contracts
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public String Content { get; set; }

        public QuestionDto(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
