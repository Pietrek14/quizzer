using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Question : IGuided
    {
        public Guid Id { get; }
        public String QuestionContent { get; set; }
        public ObservedArray<Answer> Answers { get; set {
            var anyAnswerCorrect = value.Items.Aggregate(false, (acc, ans) => acc || ans.IsCorrect);

            if (!anyAnswerCorrect)
            {
                throw new ArgumentException("At least one answer must be correct.");
            }

            field = value;
        } }
        public Question(String questionContent, IEnumerable<Answer> answers)
            : this(Guid.NewGuid(), questionContent, answers) { }

        public Question(Guid id, String questionContent, IEnumerable<Answer> answers)
        {
            this.Id = id;
            this.QuestionContent = questionContent;

            var answersArr = answers.ToArray();

            if (answers == null || answersArr.Length != 4)
            {
                throw new ArgumentException("A question must have exactly four answers.");
            }

            var anyAnswerCorrect = answersArr.Aggregate(false, (acc, ans) => acc || ans.IsCorrect);

            if (!anyAnswerCorrect)
            {
                throw new ArgumentException("At least one answer must be correct.");
            }

            this.Answers = new ObservedArray<Answer>(answersArr);
        }

        [JsonConstructor]
        public Question(Guid id, String questionContent, ObservedArray<Answer> answers)
        {
            this.Id = id;
            this.QuestionContent = questionContent;

            if (answers == null || answers.Items.Length != 4)
            {
                throw new ArgumentException("A question must have exactly four answers.");
            }

            var anyAnswerCorrect = answers.Items.Aggregate(false, (acc, ans) => acc || ans.IsCorrect);

            if (!anyAnswerCorrect)
            {
                throw new ArgumentException("At least one answer must be correct.");
            }

            this.Answers = answers;
        }
    }
}
