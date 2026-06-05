using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.QuizList.Contracts
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public QuizDto(Guid id, String name) {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
