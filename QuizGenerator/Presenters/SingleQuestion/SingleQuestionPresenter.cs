using QuizGenerator.Presenters.SingleQuestion.Contracts;
using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Presenters.SingleQuestion
{
    public class SingleQuestionPresenter
    {
        private ISingleQuestionView view;
        private Quiz quiz;
        private Guid? questionId;
        private String questionContent;
        private AnswerDto[] answers;

        public SingleQuestionPresenter(ISingleQuestionView view, Quiz quiz, Question? question) {
            this.view = view;
            this.quiz = quiz;

            if (question != null)
            {
                this.questionId = question.Id;
                this.questionContent = question.QuestionContent;
                this.answers = question.Answers.Items.Select(answer => new AnswerDto(answer.Content, answer.IsCorrect)).ToArray();
                this.view.EnableEdition(true);
            }
            else
            {
                this.questionContent = "";
                this.answers = new AnswerDto[4];
                for (int i = 0; i < 4; i++)
                {
                    this.answers[i] = new AnswerDto("", false);
                }
                this.view.EnableEdition(false);
            }

            this.UpdateView();

            this.view.QuestionContentUpdated += content => {
                this.questionContent = content;
                this.UpdateView();
            };
            this.view.AnswerUpdated += (index, answer) =>
            {
                if (index >= 0 && index < this.answers.Length)
                {
                    this.answers[index] = answer;
                    this.UpdateView();
                }
                this.UpdateView();
            };

            this.view.AddQuestion += AddQuestion;
            this.view.UpdateQuestion += UpdateQuestion;
            this.view.DeleteQuestion += DeleteQuestion;
        }

        private void SetQuestionContent()
        {
            this.view.SetQuestionContent(this.questionContent);
        }

        private void SetAnswers()
        {
            for(int i = 0; i < this.answers.Length; i++ )
            {
                this.view.SetAnswer(i, this.answers[i]);
            }
        }

        private void UpdateView()
        {
            SetQuestionContent();
            SetAnswers();
        }

        private Question ConstructQuestion()
        {
            if(this.questionId == null)
            {
                return new Question(
                    this.questionContent,
                    this.answers.Select(answer => new Answer(answer.Content, answer.IsCorrect)).ToArray()
                );
            }
            else
            {
                return new Question(
                    this.questionId.Value,
                    this.questionContent,
                    this.answers.Select(answer => new Answer(answer.Content, answer.IsCorrect)).ToArray()
                );
            }
        }

        private void AddQuestion()
        {
            var validator = new QuestionValidator();
            var error = validator.ValidateQuestion(this.questionContent, this.answers);

            if(error == null)
            {
                var question = ConstructQuestion();
                this.quiz.Questions.AddItem(question);
                this.view.Close();
            }
            else
            {
                this.view.DisplayError(error);
            }
        }

        private void UpdateQuestion()
        {
            var validator = new QuestionValidator();
            var error = validator.ValidateQuestion(this.questionContent, this.answers);

            if (error == null)
            {
                var question = ConstructQuestion();
                this.quiz.Questions.UpdateItem(question);
                this.view.Close();
            }
            else
            {
                this.view.DisplayError(error);
            }
        }

        private void DeleteQuestion()
        {
            if(this.questionId == null)
            {
                throw new InvalidOperationException("Can't delete a question that hasn't been added yet.");
            }

            this.quiz.Questions.RemoveItem(this.questionId.Value);
            this.view.Close();
        }
    }
}
