using QuizGenerator.Presenters.SingleQuestion;
using QuizGenerator.Presenters.SingleQuiz.Contracts;
using QuizGenerator.Services.Serialization;
using QuizGenerator.Views;
using QuizModel;
using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuiz
{
    public class SingleQuizPresenter
    {
        private ISingleQuizView view;
        private Repository<Quiz> quizList;
        private Quiz quiz;

        public SingleQuizPresenter(ISingleQuizView view, Repository<Quiz> quizList, Quiz? quiz)
        {
            this.view = view;
            this.quizList = quizList;

            if (quiz != null)
            {
                this.quiz = quiz;
                this.view.EnableEdition(true);
            }
            else
            {
                this.quiz = new Quiz();
                this.view.EnableEdition(false);
            }

            this.UpdateView();

            this.quiz.Questions.ItemAdded += question => UpdateQuestionList(this.quiz.Questions.Items.Values);
            this.quiz.Questions.ItemUpdated += question => UpdateQuestionList(this.quiz.Questions.Items.Values);
            this.quiz.Questions.ItemRemoved += question => UpdateQuestionList(this.quiz.Questions.Items.Values);

            this.view.SetQuizTitle += SetQuizTitle;
            this.view.AddQuestion += () => OpenQuestionForm(null);
            this.view.EditQuestion += questionDto =>
            {
                if (this.quiz.Questions.Items.TryGetValue(questionDto.Id, out var question))
                {
                    OpenQuestionForm(question);
                }
                else
                {
                    this.view.DisplayError("Nie można znaleźć wybranego pytania.");
                }
            };

            this.view.AddQuiz += AddQuiz;
            this.view.UpdateQuiz += UpdateQuiz;
            this.view.DeleteQuiz += DeleteQuiz;
            this.view.SaveQuizToFile += SaveQuizToFile;
        }

        private void SetQuizTitle(String title)
        {
            this.quiz.Name = title;
        }

        private void UpdateQuizTitle(String title)
        {
            this.view.UpdateQuizTitle(title);
        }

        private void UpdateQuestionList(IEnumerable<Question> questions)
        {
            this.view.UpdateQuestionList(questions.Select(q => new QuestionDto(q.Id, q.QuestionContent)));
        }

        private void UpdateView()
        {
            UpdateQuizTitle(this.quiz.Name);
            UpdateQuestionList(this.quiz.Questions.Items.Values);
        }

        private void OpenQuestionForm(Question? question)
        {
            var singleQuestionView = this.view.GetSingleQuestionView();
            var singleQuestionPresenter = new SingleQuestionPresenter(singleQuestionView, quiz, question);
        }

        private void AddQuiz()
        {
            var validator = new QuizValidator();
            var error = validator.ValidateQuiz(this.quiz);
            if (error == null)
            {
                this.quizList.AddItem(this.quiz);
                this.view.Close();
            }
            else
            {
                this.view.DisplayError(error);
            }
        }

        private void UpdateQuiz()
        {
            var validator = new QuizValidator();
            var error = validator.ValidateQuiz(this.quiz);
            if (error == null)
            {
                this.quizList.UpdateItem(this.quiz);
                this.view.Close();
            }
            else
            {
                this.view.DisplayError(error);
            }
        }

        private void DeleteQuiz()
        {
            this.quizList.RemoveItem(this.quiz.Id);
            this.view.Close();
        }

        private void SaveQuizToFile(string quizFilePath)
        {
            var serializer = new QuizSerializer(new PlaintextStrategy());
            var validator = new QuizValidator();

            var error = validator.ValidateQuiz(this.quiz);
            if (error == null)
            {
                try
                {
                    serializer.Serialize(this.quiz, quizFilePath);
                }
                catch(CryptographicException)
                {
                    this.view.DisplayError("Zapisanie quizu do pliku nie powiodło się :(");
                }
            }
            else
            {
                this.view.DisplayError(error);
            }
        }
    }
}
