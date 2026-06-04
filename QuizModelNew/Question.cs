using QuizModel.Containers;
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
        public ArrayRepository<Answer> Answers { get; set; }
        public Question(String questionContent, IEnumerable<Answer> answers)
            : this(Guid.NewGuid(), questionContent, answers) {}

        public Question(Guid id, String questionContent, IEnumerable<Answer> answers)
        {
            this.Id = id;
            this.QuestionContent = questionContent;

            var answersArr = answers.ToArray();

            if(answers == null || answersArr.Length != 4)
            {
                throw new ArgumentException("A question must have exactly four answers.");
            }

            this.Answers = new ArrayRepository<Answer>(answersArr);
        }
    }
}
