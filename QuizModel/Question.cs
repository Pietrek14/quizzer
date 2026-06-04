using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Question : IGuided
    {
        public Guid Id { get; }
        public String QuestionContent { get; set; }
        public Repository<Answer> Answers { get; set; } = new Repository<Answer>();
        public Question(String questionContent, List<Answer> answers)
            : this(Guid.NewGuid(), questionContent, answers) {}

        public Question(Guid id, String questionContent, List<Answer> answers)
        {
            this.Id = id;
            this.QuestionContent = questionContent;

            if(answers == null || answers.Count != 4)
            {
                throw new ArgumentException("A question must have exactly four answers.");
            }

            foreach (var answer in answers)
            {
                this.Answers.AddItem(answer);
            }
        }
    }
}
