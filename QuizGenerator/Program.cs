using QuizGenerator.Presenters.QuizList;
using QuizGenerator.Views;
using QuizModel;
using QuizModel.Containers;

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

            Application.Run(view);
        }
    }
}