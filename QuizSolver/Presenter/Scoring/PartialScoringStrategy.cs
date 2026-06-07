using System.Collections.Generic;
using QuizModel;

namespace QuizSolver.Presenters.Scoring
{
    public class PartialScoringStrategy : IScoringStrategy
    {
        public int CalculateScore(List<int> selectedIndices, Answer[] answers)
        {
            int score = 0;

            foreach (int index in selectedIndices)
            {
                if (answers[index].IsCorrect)
                {
                    score++;
                }
                else
                {
                    score--;
                }
            }

            return score > 0 ? score : 0;
        }
    }
}