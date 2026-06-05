using QuizGenerator.Presenters.QuizList;
using QuizGenerator.Services.Encryption;
using QuizGenerator.Views;
using QuizModel;
using QuizModel.Containers;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace QuizGenerator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var view = new QuizListView();
            var quizList = new Repository<Quiz>();
            var presenter = new QuizListPresenter(view, quizList);

            string message = "{\"Id\":\"07789f03-406c-4270-9f3c-d977136737a4\",\"Name\":\"ciekawostki\",\"Questions\":[{\"Id\":\"7f29b49b-dad4-4e61-bb3f-6f6e0c2d2cf2\",\"QuestionContent\":\"jak mam na imie?\",\"Answers\":[{\"Content\":\"dawid\",\"IsCorrect\":true},{\"Content\":\"jacek\",\"IsCorrect\":false},{\"Content\":\"dawidekpe\",\"IsCorrect\":true},{\"Content\":\"skurwiel\",\"IsCorrect\":false}]}]}";

            var encryptionStrategy = EncryptionService.Instance.GetAesStrategy();

            var encrypted = encryptionStrategy.Encrypt(message);
            var decrypted = encryptionStrategy.Decrypt(encrypted);

            Debug.WriteLine(message);
            Debug.WriteLine("");
            Debug.WriteLine(Encoding.UTF8.GetString(encrypted));
            Debug.WriteLine("");
            Debug.WriteLine(decrypted);

            Application.Run(view);
        }
    }
}