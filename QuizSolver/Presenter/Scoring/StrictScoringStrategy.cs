using System.Collections.Generic;
using System.Linq;
using QuizModel;

namespace QuizSolver.Presenters.Scoring
{
    public class StrictScoringStrategy : IScoringStrategy
    {
        public int CalculateScore(List<int> selectedIndices, Answer[] answers)
        {
            List<int> correctIndices = new List<int>();
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].IsCorrect)
                {
                    correctIndices.Add(i);
                }
            }

            bool isCorrect = (correctIndices.Count == selectedIndices.Count) &&
                             !correctIndices.Except(selectedIndices).Any();

            return isCorrect ? 1 : 0;
        }
    }
}