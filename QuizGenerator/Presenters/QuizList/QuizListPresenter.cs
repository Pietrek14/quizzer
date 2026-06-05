using QuizGenerator.Presenters.Common.Contracts;
using QuizGenerator.Presenters.QuizList.Contracts;
using QuizGenerator.Presenters.SingleQuiz;
using QuizServices.Encryption;
using QuizServices.Serialization;
using QuizModel;
using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace QuizGenerator.Presenters.QuizList
{
    public class QuizListPresenter
    {
        private IQuizListView view;
        private Repository<Quiz> quizList;

        public QuizListPresenter(IQuizListView view, Repository<Quiz> quizList)
        {
            this.view = view;
            this.quizList = quizList;

            Action<Quiz> updateQuizList = quiz => this.view.UpdateQuizList(this.quizList.Items.Values.Select(QuizToDto));
            this.quizList.ItemAdded += updateQuizList;
            this.quizList.ItemUpdated += updateQuizList;
            this.quizList.ItemRemoved += updateQuizList;

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
            Quiz? quiz = this.quizList.Items[quizDto.Id];
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
            var singleQuizPresenter = new SingleQuizPresenter(singleQuizView, quizList, quiz);
        }

        private void LoadQuiz(string quizFilePath, EncryptionStrategyDto encryptionStrategy)
        {
            IEncryptionStrategy strategy = encryptionStrategy switch
            {
                EncryptionStrategyDto.Plaintext => new PlaintextStrategy(),
                EncryptionStrategyDto.Aes => EncryptionService.Instance.GetAesStrategy(),
                EncryptionStrategyDto.TripleDes => EncryptionService.Instance.GetTripleDesStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(encryptionStrategy), encryptionStrategy, null)
            };

            var serializer = new QuizSerializer(strategy);

            try
            {
                var quiz = serializer.Deserialize(quizFilePath);

                if(quizList.Items.ContainsKey(quiz.Id))
                {
                    this.view.DisplayError("Ten quiz został już dodany do listy");
                    return;
                }

                this.quizList.AddItem(quiz);
            }
            catch (Exception ex) when (ex is SerializationException or CryptographicException or JsonException)
            {
                this.view.DisplayError($"Nie można załadować quizu w lokalizacji {quizFilePath}");
            }
        }
    }
}
