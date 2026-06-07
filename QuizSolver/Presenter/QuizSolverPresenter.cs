using QuizModel;
using QuizSolver.View.Contracts;
using QuizSolver.Presenters.Scoring;
using System.Collections.Generic;
using System.Linq;

namespace QuizSolver.Presenters
{
    public class QuizSolverPresenter
    {
        private readonly ISingleQuestionView _view;
        private readonly Quiz _quiz;
        private readonly List<Question> _questions;
        private readonly IScoringStrategy _scoringStrategy;

        private int _currentQuestionIndex = 0;
        private int _score = 0;

        public QuizSolverPresenter(ISingleQuestionView view, Quiz quiz, IScoringStrategy scoringStrategy)
        {
            _view = view;
            _quiz = quiz;
            _scoringStrategy = scoringStrategy;

            _questions = _quiz.Questions.Items.Values.ToList();

            _view.AnswerSubmitted += OnAnswerSubmitted;
            _view.QuizFinished += () => _view.CloseView();

            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            if (_currentQuestionIndex < _questions.Count)
            {
                var currentQuestion = _questions[_currentQuestionIndex];
                var answers = currentQuestion.Answers.Items.ToList();

                _view.DisplayQuestion(
                    currentQuestion.QuestionContent,
                    answers,
                    _currentQuestionIndex + 1,
                    _questions.Count
                );
            }
            else
            {
                _view.ShowResult(_score, _questions.Count);
            }
        }

        private void OnAnswerSubmitted(List<int> selectedIndices)
        {
            var currentQuestion = _questions[_currentQuestionIndex];
            var answers = currentQuestion.Answers.Items;

            _score += _scoringStrategy.CalculateScore(selectedIndices, answers);

            _currentQuestionIndex++;
            ShowCurrentQuestion();
        }
    }
}