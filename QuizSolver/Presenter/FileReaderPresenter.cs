using System;
using QuizModel;
using QuizServices.Encryption;
using QuizServices.Serialization;
using QuizSolver.View.Contracts;
using QuizSolver.Presenters.Scoring;

namespace QuizSolver.Presenters
{
    public class FileReaderPresenter
    {
        private readonly IFileReaderView _view;

        public FileReaderPresenter(IFileReaderView view)
        {
            _view = view;
            _view.LoadQuizRequested += OnLoadQuizRequested;
        }

        private void OnLoadQuizRequested(string filePath, EncryptionStrategyDto strategyType, string scoringStrategyName)
        {
            try
            {
                IEncryptionStrategy strategy = strategyType switch
                {
                    EncryptionStrategyDto.Plaintext => new PlaintextStrategy(),
                    EncryptionStrategyDto.Aes => EncryptionService.Instance.GetAesStrategy(),
                    EncryptionStrategyDto.TripleDes => EncryptionService.Instance.GetTripleDesStrategy(),
                    _ => new PlaintextStrategy()
                };

                var serializer = new QuizSerializer(strategy);
                Quiz loadedQuiz = serializer.Deserialize(filePath);

                _view.HideView();
                var quizSolverView = _view.GetQuizSolverView();

                IScoringStrategy scoringStrategy = scoringStrategyName switch
                {
                    "Rygorystyczne" => new StrictScoringStrategy(),
                    "Częściowe" => new PartialScoringStrategy(),
                    _ => new StrictScoringStrategy()
                };

                var quizSolverPresenter = new QuizSolverPresenter(quizSolverView, loadedQuiz, scoringStrategy);
            }
            catch (Exception ex)
            {
                _view.DisplayError($"Nie udało się wczytać quizu: {ex.Message}");
            }
        }
    }
}