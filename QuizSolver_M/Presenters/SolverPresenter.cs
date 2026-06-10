using QuizModel;
using QuizModel.Containers;
using QuizServices.Encryption;
using QuizServices.Serialization;
using QuizSolver_M.Contracts;


namespace QuizSolver_M.Presenters
{
    public class SolverPresenter
    {
        private readonly ISolverView _view;
        private Quiz? _quiz;
        private List<Question> _questions = new();
        private Dictionary<Guid, List<bool>> _userAnswers = new();
        private int _currentIndex = 0;
        private System.Windows.Forms.Timer _timer = new();
        private DateTime _startTime;
        private TimeSpan _elapsed;
        private bool _quizEnded = false;

        public SolverPresenter(ISolverView view)
        {
            _view = view;

            _view.LoadQuiz += OnLoadQuiz;
            _view.StartQuiz += OnStartQuiz;
            _view.EndQuiz += OnEndQuiz;
            _view.NavigateNext += OnNext;
            _view.NavigatePrev += OnPrev;
            _view.SaveAnswer += OnSaveAnswer;

            _timer.Interval = 1000;
            _timer.Tick += (s, e) => _view.UpdateTimer((DateTime.Now - _startTime).ToString(@"mm\:ss"));
        }

        private void OnLoadQuiz()
        {
            using var dialog = new OpenFileDialog { Filter = "All files|*.*" };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var strategies = new List<IEncryptionStrategy>
            {
                EncryptionService.Instance.GetAesStrategy(),
                EncryptionService.Instance.GetTripleDesStrategy(),
                new PlaintextStrategy()
            };

            foreach (var strategy in strategies)
            {
                try
                {
                    var serializer = new QuizSerializer(strategy);
                    _quiz = serializer.Deserialize(dialog.FileName);
                    _questions = _quiz.Questions.Items.Values.ToList();
                    _userAnswers = _questions.ToDictionary(q => q.Id, q => new List<bool> { false, false, false, false });
                    _quizEnded = false;
                    _view.SetQuizTitle(_quiz.Name, _questions.Count);
                    _view.EnableStart(true);
                    return;
                }
                catch { }
            }

            _view.DisplayError("Nie udało się wczytać quizu. Sprawdź plik i spróbuj ponownie.");
        }

        private void OnStartQuiz()
        {
            _currentIndex = 0;
            _quizEnded = false;
            _startTime = DateTime.Now;
            _timer.Start();
            _view.EnableStart(false);
            _view.EnableEnd(true);
            _view.EnableNavigation(true);
            _view.SetAnswersEnabled(true); 
            ShowCurrentQuestion();
        }

        private void OnEndQuiz()
        {
            _timer.Stop();
            _elapsed = DateTime.Now - _startTime;
            _quizEnded = true;
            _view.EnableEnd(false);
            _view.EnableNavigation(true);
            _view.SetAnswersEnabled(false); 

            int score = CalculateScore();
            ShowCorrectAnswers();
            _view.ShowResult(score, _questions.Count, _elapsed);
        }

        private void OnNext()
        {
            if (_currentIndex < _questions.Count - 1)
            {
                _currentIndex++;
                ShowCurrentQuestion();
            }
        }

        private void OnPrev()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                ShowCurrentQuestion();
            }
        }

        private void OnSaveAnswer(List<bool> selections)
        {
            if (_quiz == null || _questions.Count == 0) return;
            if (!_quizEnded) 
                _userAnswers[_questions[_currentIndex].Id] = selections;
        }

        private void ShowCurrentQuestion()
        {
            var q = _questions[_currentIndex];
            var answers = q.Answers.Items.Select(a => a.Content).ToList();
            _view.ShowQuestion(_currentIndex, _questions.Count, q.QuestionContent, answers);
            _view.SetAnswerSelections(_userAnswers[q.Id]);

            
            if (_quizEnded)
                ShowCorrectAnswers();
        }

        private void ShowCorrectAnswers()
        {
            var q = _questions[_currentIndex];
            var correct = q.Answers.Items.Select(a => a.IsCorrect).ToList();
            var user = _userAnswers[q.Id];
            _view.HighlightAnswers(correct, user);
        }

        private int CalculateScore()
        {
            int score = 0;
            foreach (var q in _questions)
            {
                var correct = q.Answers.Items.Select(a => a.IsCorrect).ToList();
                var user = _userAnswers[q.Id];
                if (correct.SequenceEqual(user)) score++;
            }
            return score;
        }
    }
}