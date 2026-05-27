using QuizGenerator.Model;
using QuizGenerator.Presenters.QuizList;
using QuizGenerator.Views;

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
            var model = new QuizListModel();
            var presenter = new QuizListPresenter(view, model);

            Application.Run(view);
        }
    }
}