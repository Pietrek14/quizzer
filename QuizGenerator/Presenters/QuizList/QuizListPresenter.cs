using QuizGenerator.Model;
using QuizGenerator.Presenters.QuizList.Contracts;
using QuizGenerator.Presenters.SingleQuiz;
using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.QuizList
{
    public class QuizListPresenter
    {
        private IQuizListView view;
        private QuizListModel model;

        public QuizListPresenter(IQuizListView view, QuizListModel model)
        {
            this.view = view;
            this.model = model;

            Action<Quiz> updateQuizList = quiz => this.view.UpdateQuizList(this.model.Quizzes.Select(QuizToDto));
            this.model.QuizAdded += updateQuizList;
            this.model.QuizRemoved += updateQuizList;

            this.view.AddQuiz += () => OpenQuizForm(null);
            this.view.OpenQuiz += OpenQuizFormForEdition;
            this.view.LoadQuiz += LoadQuiz;
        }

        private QuizDto QuizToDto(Quiz quiz)
        {
            return new QuizDto(quiz.Id, quiz.Name);
        }

        private void OpenQuizFormForEdition(QuizDto quizDto)
        {
            Quiz? quiz = this.model.Quizzes.FirstOrDefault(q => q.Id == quizDto.Id);
            if (quiz != null)
            {
                OpenQuizForm(quiz);
            }
            else
            {
                this.view.DisplayError("Nie można znaleźć wybranego quizu.");
            }
        }

        private void OpenQuizForm(Quiz? quiz)
        {
            var singleQuizView = this.view.GetSingleQuizView();
            var singleQuizPresenter = new SingleQuizPresenter(singleQuizView, quiz);
        }

        private void LoadQuiz(string quizFilePath)
        {
        }
    }
}
