using System.Collections.Generic;
using QuizModel;

namespace QuizSolver.Presenters.Scoring
{
    public interface IScoringStrategy
    {
        int CalculateScore(List<int> selectedIndices, Answer[] answers);
    }
}