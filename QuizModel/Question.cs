using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizModel
{
    public class Question
    {
        public String QuestionContent { get; set; }

        private String correctAnswer;
        public String CorrectAnswer {
            get {
                return correctAnswer;
            }
            set {
                foreach (var incorrectAnswer in incorrectAnswers)
                {
                    if (value == incorrectAnswer)
                        throw new ArgumentException("Correct answer cannot be the same as any of the incorrect answers.");
                }
                correctAnswer = value;
            }
        }
        private List<String> incorrectAnswers;

        public Question(String questionContent, String correctAnswer, List<String> incorrectAnswers)
        {
            this.QuestionContent = questionContent;
            this.CorrectAnswer = correctAnswer;

            if(incorrectAnswers.Contains(correctAnswer))
                throw new ArgumentException("Incorrect answers cannot contain the correct answer.");

            if (incorrectAnswers.Count == 0)
                throw new ArgumentException("There must be at least one incorrect answer.");

            if (incorrectAnswers.Count > 3)
                throw new ArgumentException("There can be at most three incorrect answers.");

            this.incorrectAnswers = incorrectAnswers;
        }

        public void AddIncorrectAnswer(String incorrectAnswer)
        {
            if (incorrectAnswer == correctAnswer)
                throw new ArgumentException("Incorrect answer cannot be the same as the correct answer.");
            if (incorrectAnswers.Count >= 3)
                throw new InvalidOperationException("Cannot add more than three incorrect answers.");
            incorrectAnswers.Add(incorrectAnswer);
        }

        public List<String> GetIncorrectAnswers()
        {
            var allAnswers = new List<String>(incorrectAnswers);
            return allAnswers;
        }

        public List<String> GetAllAnswers()
        {
            var allAnswers = new List<String>(new String[] { correctAnswer });
            allAnswers.AddRange(incorrectAnswers);
            return allAnswers;
        }
    }
}
