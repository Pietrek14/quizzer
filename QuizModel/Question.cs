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
                if (IncorrectAnswers != null && IncorrectAnswers.Contains(value))
                    throw new ArgumentException("Correct answer cannot be the same as any of the incorrect answers.");
                correctAnswer = value;
            }
        }
        public List<String> IncorrectAnswers { get; }

        public List<String> AllAnswers {
            get {
                var allAnswers = new List<String>(new String[] { correctAnswer });
                allAnswers.AddRange(IncorrectAnswers);
                return allAnswers;
            }
        }

        public Question(String questionContent, String correctAnswer, List<String> incorrectAnswers)
        {
            this.QuestionContent = questionContent;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswers = incorrectAnswers ?? throw new ArgumentNullException(nameof(incorrectAnswers));

            if (incorrectAnswers.Contains(correctAnswer))
                throw new ArgumentException("Incorrect answers cannot contain the correct answer.");

            if (incorrectAnswers.Count == 0)
                throw new ArgumentException("There must be at least one incorrect answer.");

            if (incorrectAnswers.Count > 3)
                throw new ArgumentException("There can be at most three incorrect answers.");
        }
    }
}
